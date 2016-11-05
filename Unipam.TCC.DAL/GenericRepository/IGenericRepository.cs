using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unipam.TCC.DAL.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {

        void Adicionar(T entity);

        void Alterar(T entity);

        void Excluir(T entity);

        void SalvarAlteracoes(); //Commit

        IList<T> Todos();

        IList<T> Consultar(Func<T, bool> where);

        T Obter(Func<T, bool> where);

        DbSet<T> GetDbEntity();

        void Dispose();


    }
}
