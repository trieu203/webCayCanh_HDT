using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webCayCanh.huongDT.Data;

namespace webCayCanh.huongDT.Controllers
{
    public class DonHangsController : Controller
    {
        private readonly WebHdtContext _context;

        public DonHangsController(WebHdtContext context)
        {
            _context = context;
        }

        // GET: DonHangs
        public async Task<IActionResult> Index()
        {
            var webHdtContext = _context.DonHangs.Include(d => d.MaDgNavigation);
            return View(await webHdtContext.ToListAsync());
        }

        // GET: DonHangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donHang = await _context.DonHangs
                .Include(d => d.MaDgNavigation)
                .FirstOrDefaultAsync(m => m.MaDh == id);
            if (donHang == null)
            {
                return NotFound();
            }

            return View(donHang);
        }

        // GET: DonHangs/Create
        public IActionResult Create()
        {
            ViewData["MaDg"] = new SelectList(_context.DanhGiaDhs, "MaDg", "MaDg");
            return View();
        }

        // POST: DonHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaDh,MaKh,MaDg,NgayDat,NgayNhan,TongTien")] DonHang donHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaDg"] = new SelectList(_context.DanhGiaDhs, "MaDg", "MaDg", donHang.MaDg);
            return View(donHang);
        }

        // GET: DonHangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donHang = await _context.DonHangs.FindAsync(id);
            if (donHang == null)
            {
                return NotFound();
            }
            ViewData["MaDg"] = new SelectList(_context.DanhGiaDhs, "MaDg", "MaDg", donHang.MaDg);
            return View(donHang);
        }

        // POST: DonHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaDh,MaKh,MaDg,NgayDat,NgayNhan,TongTien")] DonHang donHang)
        {
            if (id != donHang.MaDh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonHangExists(donHang.MaDh))
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
            ViewData["MaDg"] = new SelectList(_context.DanhGiaDhs, "MaDg", "MaDg", donHang.MaDg);
            return View(donHang);
        }

        // GET: DonHangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donHang = await _context.DonHangs
                .Include(d => d.MaDgNavigation)
                .FirstOrDefaultAsync(m => m.MaDh == id);
            if (donHang == null)
            {
                return NotFound();
            }

            return View(donHang);
        }

        // POST: DonHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var donHang = await _context.DonHangs.FindAsync(id);
            if (donHang != null)
            {
                _context.DonHangs.Remove(donHang);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonHangExists(int id)
        {
            return _context.DonHangs.Any(e => e.MaDh == id);
        }
    }
}
