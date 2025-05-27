using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AIC.Data;
using AIC.Models;

namespace AIC.Controllers
{
    public class AuthorShipsController : Controller
    {
        private readonly DataContext _context;

        public AuthorShipsController(DataContext context)
        {
            _context = context;
        }

        // GET: AuthorShips
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.AuthorShip.Include(a => a.Author).Include(a => a.Book);
            return View(await dataContext.ToListAsync());
        }

        // GET: AuthorShips/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authorShip = await _context.AuthorShip
                .Include(a => a.Author)
                .Include(a => a.Book)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (authorShip == null)
            {
                return NotFound();
            }

            return View(authorShip);
        }

        // GET: AuthorShips/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.Author, "AuthorId", "Name");
            ViewData["BookId"] = new SelectList(_context.Book, "BookId", "Title");
            return View();
        }

        // POST: AuthorShips/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BookId,AuthorId,PublishDate,Role")] AuthorShip authorShip)
        {
            if (ModelState.IsValid)
            {
                _context.Add(authorShip);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Author, "AuthorId", "Name", authorShip.AuthorId);
            ViewData["BookId"] = new SelectList(_context.Book, "BookId", "Title", authorShip.BookId);
            return View(authorShip);
        }

        // GET: AuthorShips/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authorShip = await _context.AuthorShip.FindAsync(id);
            if (authorShip == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_context.Author, "AuthorId", "Name", authorShip.AuthorId);
            ViewData["BookId"] = new SelectList(_context.Book, "BookId", "Title", authorShip.BookId);
            return View(authorShip);
        }

        // POST: AuthorShips/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BookId,AuthorId,PublishDate,Role")] AuthorShip authorShip)
        {
            if (id != authorShip.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(authorShip);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthorShipExists(authorShip.Id))
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
            ViewData["AuthorId"] = new SelectList(_context.Author, "AuthorId", "Name", authorShip.AuthorId);
            ViewData["BookId"] = new SelectList(_context.Book, "BookId", "Title", authorShip.BookId);
            return View(authorShip);
        }

        // GET: AuthorShips/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authorShip = await _context.AuthorShip
                .Include(a => a.Author)
                .Include(a => a.Book)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (authorShip == null)
            {
                return NotFound();
            }

            return View(authorShip);
        }

        // POST: AuthorShips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var authorShip = await _context.AuthorShip.FindAsync(id);
            if (authorShip != null)
            {
                _context.AuthorShip.Remove(authorShip);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuthorShipExists(int id)
        {
            return _context.AuthorShip.Any(e => e.Id == id);
        }
    }
}
