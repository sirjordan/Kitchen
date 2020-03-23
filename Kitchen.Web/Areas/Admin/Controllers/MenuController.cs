using AutoMapper;
using Kitchen.Web.Areas.Admin.Models;
using Kitchen.Web.Data;
using Kitchen.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Kitchen.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MenuController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var dishes = await _mapper.ProjectTo<DishViewModel>(_context.Dishes).ToListAsync();
            return View(nameof(Index), dishes);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dish = await _context.Dishes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dish == null)
            {
                return NotFound();
            }

            return View(dish);
        }

        public async Task<IActionResult> Create()
        {
            var categories = await _context.Categories.Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToListAsync();

            return View(new MainMenuItemViewModel { Categories = categories });
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Description,Allergens")] DishViewModel dish)
        {
            if (ModelState.IsValid)
            {
                _context.Add(_mapper.Map<Dish>(dish));
                await _context.SaveChangesAsync();
                return await Index();
            }
            return View(dish);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dish = await _context.Dishes.FindAsync(id);
            if (dish == null)
            {
                return NotFound();
            }
            return View(dish);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Description,Allergens")] Dish dish)
        {
            if (id != dish.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dish);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DishExists(dish.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dish);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dish = await _context.Dishes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dish == null)
            {
                return NotFound();
            }

            return View(dish);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dish = await _context.Dishes.FindAsync(id);
            _context.Dishes.Remove(dish);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DishExists(int id)
        {
            return _context.Dishes.Any(e => e.Id == id);
        }
    }
}
