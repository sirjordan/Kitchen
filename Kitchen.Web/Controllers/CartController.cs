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
        private readonly string CART_SESSION_KEY = "card";
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

            // TODO: Receive return url to redirect to
            return RedirectToAction("index", "home");
        }

        public async Task<IActionResult> Purchase()
        {
            var cart = GetCart();
            if (cart.Items.Count == 0)
            {
                return BadRequest("You cannot purchase an empty cart");
            }

            var items = _context.Dishes
                .Where(d => cart.Items.Select(c => c.Id).Contains(d.Id))
                .ToList();

            var order = new Order()
            {
                Items = items, //_mapper.ProjectTo<Dish>(cart.Items.AsQueryable()).ToList(),
                PurchasedAt = DateTime.Now,
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            // TODO: Send email -> check https://www.mailjet.com

            HttpContext.Session.Remove(CART_SESSION_KEY);

            return RedirectToAction("index", "home");
        }

        private CartViewModel GetCart() => HttpContext.Session.Get<CartViewModel>(CART_SESSION_KEY) ?? new CartViewModel();
    }
}