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
    public class CadastrarsController : Controller
    {
        private readonly AsianFlixContext _context;

        public CadastrarsController(AsianFlixContext context)
        {
            _context = context;
        }

        // GET: Cadastrars
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cadastrar.ToListAsync());
        }

        // GET: Cadastrars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastrar = await _context.Cadastrar
                .FirstOrDefaultAsync(m => m.CadastrarID == id);
            if (cadastrar == null)
            {
                return NotFound();
            }

            return View(cadastrar);
        }

        // GET: Cadastrars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cadastrars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CadastrarID,ClienteName,DtNascimento,Cpf,FormaPagamento,Email,Password,PasswordConfirmation")] Cadastrar cadastrar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastrar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadastrar);
        }

        // GET: Cadastrars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastrar = await _context.Cadastrar.FindAsync(id);
            if (cadastrar == null)
            {
                return NotFound();
            }
            return View(cadastrar);
        }

        // POST: Cadastrars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CadastrarID,ClienteName,DtNascimento,Cpf,FormaPagamento,Email,Password,PasswordConfirmation")] Cadastrar cadastrar)
        {
            if (id != cadastrar.CadastrarID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastrar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastrarExists(cadastrar.CadastrarID))
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
            return View(cadastrar);
        }

        // GET: Cadastrars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastrar = await _context.Cadastrar
                .FirstOrDefaultAsync(m => m.CadastrarID == id);
            if (cadastrar == null)
            {
                return NotFound();
            }

            return View(cadastrar);
        }

        // POST: Cadastrars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cadastrar = await _context.Cadastrar.FindAsync(id);
            if (cadastrar != null)
            {
                _context.Cadastrar.Remove(cadastrar);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastrarExists(int id)
        {
            return _context.Cadastrar.Any(e => e.CadastrarID == id);
        }
    }
}
