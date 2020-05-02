using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Compras.Web.Data;
using Compras.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Compras.Web.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly DataContext _context;

        public ProdutoController(DataContext context)
        {
            this._context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Produtos.OrderBy(o => o.Descricao).ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Descricao", "Unidade", "Qtd", "Preco")] Produto produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(produto);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível salvar dados!");
            }
            return View(produto);
        }

        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos.SingleOrDefaultAsync(p => p.ProdutoId == id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("ProdutoId", "Descricao", "Unidade", "Qtd", "Preco")] Produto produto)
        {
            if( id != produto.ProdutoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.ProdutoId))
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

            return View(produto);

        }

        private bool ProdutoExists(long? id)
        {
            return _context.Produtos.Any(p => p.ProdutoId == id);
        }

        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos.SingleOrDefaultAsync(p => p.ProdutoId == id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        public async Task<IActionResult> Detete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos.SingleOrDefaultAsync(p => p.ProdutoId == id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var produto = await _context.Produtos.SingleOrDefaultAsync(p => p.ProdutoId == id);
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}