using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmaciaPerformanceGo.Model;

namespace FarmaciaPerformanceGo.Service
{
    public interface ICategoriaService
    {
        Task<IEnumerable<Categoria>> GetAll();

        Task<Categoria?> GetById(long id);

        Task<IEnumerable<Categoria>> GetByDescricao(string descricao);

        Task<Categoria> Create(Categoria tema);

        Task<Categoria?> Update(Categoria tema);

        Task Delete(Categoria tema);
    }
}