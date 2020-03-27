using AutoMapper;
using Kitchen.Web.Data;
using Kitchen.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Kitchen.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public OrdersController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _mapper.ProjectTo<OrderViewModel>(_context.Orders.OrderByDescending(o => o.PurchasedAt)).ToListAsync();

            return View(orders);
        }
    }
}