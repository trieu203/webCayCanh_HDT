using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webCayCanh.huongDT.Data;

namespace webCayCanh.huongDT.Controllers
{
    public class PhanLoaiSpsController : Controller
    {
        private readonly WebHdtContext _context;

        public PhanLoaiSpsController(WebHdtContext context)
        {
            _context = context;
        }

        // GET: PhanLoaiSps
        public async Task<IActionResult> Index()
        {
            return View(await _context.PhanLoaiSps.ToListAsync());
        }

        // GET: PhanLoaiSps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phanLoaiSp = await _context.PhanLoaiSps
                .FirstOrDefaultAsync(m => m.MaPhanLoai == id);
            if (phanLoaiSp == null)
            {
                return NotFound();
            }

            return View(phanLoaiSp);
        }

        // GET: PhanLoaiSps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PhanLoaiSps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaPhanLoai,TenPhanLoai,MoTaPl")] PhanLoaiSp phanLoaiSp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phanLoaiSp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phanLoaiSp);
        }

        // GET: PhanLoaiSps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phanLoaiSp = await _context.PhanLoaiSps.FindAsync(id);
            if (phanLoaiSp == null)
            {
                return NotFound();
            }
            return View(phanLoaiSp);
        }

        // POST: PhanLoaiSps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaPhanLoai,TenPhanLoai,MoTaPl")] PhanLoaiSp phanLoaiSp)
        {
            if (id != phanLoaiSp.MaPhanLoai)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phanLoaiSp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhanLoaiSpExists(phanLoaiSp.MaPhanLoai))
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
            return View(phanLoaiSp);
        }

        // GET: PhanLoaiSps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phanLoaiSp = await _context.PhanLoaiSps
                .FirstOrDefaultAsync(m => m.MaPhanLoai == id);
            if (phanLoaiSp == null)
            {
                return NotFound();
            }

            return View(phanLoaiSp);
        }

        // POST: PhanLoaiSps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phanLoaiSp = await _context.PhanLoaiSps.FindAsync(id);
            if (phanLoaiSp != null)
            {
                _context.PhanLoaiSps.Remove(phanLoaiSp);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhanLoaiSpExists(int id)
        {
            return _context.PhanLoaiSps.Any(e => e.MaPhanLoai == id);
        }
    }
}
