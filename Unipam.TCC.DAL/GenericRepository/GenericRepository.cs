using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unipam.TCC.DAL.Entity;

namespace Unipam.TCC.DAL.GenericRepository
{
    public class GenericRepository<T>
            : IGenericRepository<T> where T : class
    {

        TCCModel contexto = new TCCModel();

        public void Adicionar(T entity)
        {
            //Recupera o contexto de persistência do objeto
            var db = contexto.Set<T>();
            db.Add(entity);

        }

        public void Alterar(T entity)
        {
            contexto.Entry(entity).State = EntityState.Modified;
        }

        public IList<T> Consultar(Func<T, bool> where)
        {
            var db = contexto.Set<T>();

            return db.Where(where).ToList();
        }

        public void Dispose()
        {
            contexto.Dispose();
        }

        public void Excluir(T entity)
        {
            var db = contexto.Set<T>();
            db.Remove(entity);
        }

        public DbSet<T> GetDbEntity()
        {
            return contexto.Set<T>();
        }

        public T Obter(Func<T, bool> where)
        {
            var db = contexto.Set<T>();

            return db.Where(where).FirstOrDefault();
        }

        public void SalvarAlteracoes()
        {
            contexto.SaveChanges();
        }

        public IList<T> Todos()
        {
            var db = contexto.Set<T>();
            return db.ToList();
        }
    }
}
