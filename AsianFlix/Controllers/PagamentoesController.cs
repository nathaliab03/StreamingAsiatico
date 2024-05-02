using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AsianFlix.Data;
using AsianFlix.Models;

namespace AsianFlix.Controllers
{
    public class PagamentoesController : Controller
    {
        private readonly AsianFlixContext _context;

        public PagamentoesController(AsianFlixContext context)
        {
            _context = context;
        }

        // GET: Pagamentoes
        public async Task<IActionResult> Index()
        {
            var asianFlixContext = _context.Pagamento.Include(p => p.Cliente);
            return View(await asianFlixContext.ToListAsync());
        }

        // GET: Pagamentoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagamento = await _context.Pagamento
                .Include(p => p.Cliente)
                .FirstOrDefaultAsync(m => m.PagamentoId == id);
            if (pagamento == null)
            {
                return NotFound();
            }

            return View(pagamento);
        }

        // GET: Pagamentoes/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteID", "ClienteName");
            return View();
        }

        // POST: Pagamentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PagamentoId,ClienteId,DataPagamento,ValorPagamento,FormaPagamento,StatusPagamento")] Pagamento pagamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pagamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteID", "ClienteName", pagamento.ClienteId);
            return View(pagamento);
        }

        // GET: Pagamentoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagamento = await _context.Pagamento.FindAsync(id);
            if (pagamento == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteID", "ClienteName", pagamento.ClienteId);
            return View(pagamento);
        }

        // POST: Pagamentoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PagamentoId,ClienteId,DataPagamento,ValorPagamento,FormaPagamento,StatusPagamento")] Pagamento pagamento)
        {
            if (id != pagamento.PagamentoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pagamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagamentoExists(pagamento.PagamentoId))
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
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteID", "ClienteName", pagamento.ClienteId);
            return View(pagamento);
        }

        // GET: Pagamentoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagamento = await _context.Pagamento
                .Include(p => p.Cliente)
                .FirstOrDefaultAsync(m => m.PagamentoId == id);
            if (pagamento == null)
            {
                return NotFound();
            }

            return View(pagamento);
        }

        // POST: Pagamentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pagamento = await _context.Pagamento.FindAsync(id);
            if (pagamento != null)
            {
                _context.Pagamento.Remove(pagamento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagamentoExists(int id)
        {
            return _context.Pagamento.Any(e => e.PagamentoId == id);
        }
    }
}
