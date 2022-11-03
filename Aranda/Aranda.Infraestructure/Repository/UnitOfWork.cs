using Aranda.Infraestructure.Context;
using System;

namespace Aranda.Infraestructure.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        ArandaConexion Context { get; }
        void Commit();
    }
    public class UnitOfWork : IUnitOfWork
    {

        public ArandaConexion Context { get; }

        public UnitOfWork(ArandaConexion context)
        {
            Context = context;
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
