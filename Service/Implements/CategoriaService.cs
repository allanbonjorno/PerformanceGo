﻿using FarmaciaPerformanceGo.Data;
using FarmaciaPerformanceGo.Model;
using Microsoft.EntityFrameworkCore;

namespace FarmaciaPerformanceGo.Service.Implements
{
    public class CategoriaService : ICategoriaService
    {
        public readonly AppDbContext _context;

        public CategoriaService(AppDbContext context)
        {
            _context = context;

        }

        public async Task<IEnumerable<Categoria>> GetAll()
        {
            return await _context.Categoria
                 .Include(t => t.Produto)
                 .ToListAsync();
        }

        public async Task<Categoria?> GetById(long id)
        {
            try
            {
                var Categoria = await _context.Categoria
                     .Include(t => t.Produto)
                     .FirstAsync(t => t.Id == id);

                return Categoria;
            }
            catch
            {
                return null;
            }

        }

        public async Task<IEnumerable<Categoria>> GetByDescricao(string descricao)
        {
            var Categoria = await _context.Categoria
                .Include(p => p.Produto)
                .Where(p => p.Descricao.Contains(descricao))
                .ToListAsync();

            return Categoria;
        }

        public async Task<Categoria> Create(Categoria categoria)
        {
            _context.Categoria.Add(categoria);
            await _context.SaveChangesAsync();

            return categoria;
        }

        public async Task<Categoria?> Update(Categoria categoria)
        {

            var CategoriaUpdate = await _context.Categoria.FindAsync(categoria.Id);

            if (CategoriaUpdate is null)
                return null;

            _context.Entry(CategoriaUpdate).State = EntityState.Detached;
            _context.Entry(categoria).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return categoria;
        }

        public async Task Delete(Categoria categoria)
        {

            _context.Categoria.Remove(categoria);
            await _context.SaveChangesAsync();

        }
    }
}