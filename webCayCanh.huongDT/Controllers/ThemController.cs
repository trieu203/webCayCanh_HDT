using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webCayCanh.huongDT.Data;

namespace webCayCanh.huongDT.Controllers
{
    public class ThemController : Controller
    {
        private readonly WebHdtContext _context;

        public ThemController(WebHdtContext context)
        {
            _context = context;
        }

        // GET: Them
        public async Task<IActionResult> Index()
        {
            var webHdtContext = _context.Thems.Include(t => t.MaGhNavigation).Include(t => t.MaSpNavigation);
            return View(await webHdtContext.ToListAsync());
        }

        // GET: Them/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var them = await _context.Thems
                .Include(t => t.MaGhNavigation)
                .Include(t => t.MaSpNavigation)
                .FirstOrDefaultAsync(m => m.MaSp == id);
            if (them == null)
            {
                return NotFound();
            }

            return View(them);
        }

        // GET: Them/Create
        public IActionResult Create()
        {
            ViewData["MaGh"] = new SelectList(_context.GioHangs, "MaGh", "MaGh");
            ViewData["MaSp"] = new SelectList(_context.SanPhams, "MaSp", "MaSp");
            return View();
        }

        // POST: Them/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSp,MaGh,Soluong")] Them them)
        {
            if (ModelState.IsValid)
            {
                _context.Add(them);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaGh"] = new SelectList(_context.GioHangs, "MaGh", "MaGh", them.MaGh);
            ViewData["MaSp"] = new SelectList(_context.SanPhams, "MaSp", "MaSp", them.MaSp);
            return View(them);
        }

        // GET: Them/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var them = await _context.Thems.FindAsync(id);
            if (them == null)
            {
                return NotFound();
            }
            ViewData["MaGh"] = new SelectList(_context.GioHangs, "MaGh", "MaGh", them.MaGh);
            ViewData["MaSp"] = new SelectList(_context.SanPhams, "MaSp", "MaSp", them.MaSp);
            return View(them);
        }

        // POST: Them/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaSp,MaGh,Soluong")] Them them)
        {
            if (id != them.MaSp)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(them);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThemExists(them.MaSp))
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
            ViewData["MaGh"] = new SelectList(_context.GioHangs, "MaGh", "MaGh", them.MaGh);
            ViewData["MaSp"] = new SelectList(_context.SanPhams, "MaSp", "MaSp", them.MaSp);
            return View(them);
        }

        // GET: Them/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var them = await _context.Thems
                .Include(t => t.MaGhNavigation)
                .Include(t => t.MaSpNavigation)
                .FirstOrDefaultAsync(m => m.MaSp == id);
            if (them == null)
            {
                return NotFound();
            }

            return View(them);
        }

        // POST: Them/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var them = await _context.Thems.FindAsync(id);
            if (them != null)
            {
                _context.Thems.Remove(them);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThemExists(int id)
        {
            return _context.Thems.Any(e => e.MaSp == id);
        }
    }
}
