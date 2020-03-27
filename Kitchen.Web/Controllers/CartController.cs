using AutoMapper;
using Kitchen.Web.Data;
using Kitchen.Web.Models;
using Kitchen.Web.Session;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Kitchen.Web.Controllers
{
    [AllowAnonymous]
    public class CartController : Controller
    {
        private const string CART_SESSION_KEY = "cart";
        private const string CART_COUNT_SESSION_KEY = "cart-items-count";
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CartController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View(GetCart());
        }

        public async Task<IActionResult> Add(int id)
        {
            var menuItem = await _context.Dishes.FindAsync(id);
            if (menuItem == null)
            {
                return NotFound();
            }

            var cart = GetCart();
            cart.Items.Add(_mapper.Map<DishViewModel>(menuItem));

            HttpContext.Session.Set(CART_SESSION_KEY, cart);
            HttpContext.Session.Set(CART_COUNT_SESSION_KEY, cart.Items.Count);

            // TODO: Receive return url to redirect to
            return RedirectToAction("index", "home");
        }

        public IActionResult Purchase()
        {
            var order = new OrderViewModel
            {
                Cart = GetCart()
            };
            
            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> Purchase(OrderViewModel model)
        {
            var cart = GetCart();
            if (cart.Items.Count == 0)
            {
                return BadRequest("You cannot purchase an empty cart");
            }

            var items = _context.Dishes
                .Where(d => cart.Items.Select(c => c.Id).Contains(d.Id))
                .ToList();

            var order = _mapper.Map<Order>(model);
            order.PurchasedAt = DateTime.Now;

            foreach (var i in items)
            {
                order.Dishes.Add(new OrderDishes 
                {
                    Order = order,
                    Dish = i
                });
            }

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            // TODO: Send email -> check https://www.mailjet.com

            HttpContext.Session.Remove(CART_SESSION_KEY);
            HttpContext.Session.Set(CART_COUNT_SESSION_KEY, 0);

            return RedirectToAction("index", "home");
        }

        private CartViewModel GetCart()
        {
            var cart = HttpContext.Session.Get<CartViewModel>(CART_SESSION_KEY) ?? new CartViewModel();
            HttpContext.Session.Set(CART_SESSION_KEY, cart);

            return cart;
        }
    }
}