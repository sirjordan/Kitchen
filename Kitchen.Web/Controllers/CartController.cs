using AutoMapper;
using Kitchen.Web.Data;
using Kitchen.Web.Models;
using Kitchen.Web.Session;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            var cart = HttpContext.Session.Get<CartViewModel>(CART_SESSION_KEY) ?? new CartViewModel();

            return View(cart);
        }

        public async Task<IActionResult> Add(int id)
        {
            var menuItem = await _context.Dishes.FindAsync(id);
            if (menuItem == null)
            {
                return NotFound();
            }

            var cart = HttpContext.Session.Get<CartViewModel>(CART_SESSION_KEY) ?? new CartViewModel();
            cart.Items.Add(_mapper.Map<DishViewModel>(menuItem));

            HttpContext.Session.Set(CART_SESSION_KEY, cart);

            // TODO: Receive return url to redirect to
            return RedirectToAction("index", "home");
        }
    }
}