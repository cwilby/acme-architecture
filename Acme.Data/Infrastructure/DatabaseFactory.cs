using Acme.Core.Infrastructure;
using Acme.Data.Context;
using System;

namespace Acme.Data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private readonly AcmeDataContext _dataContext;

        public AcmeDataContext GetDataContext()
        {
            return _dataContext ?? new AcmeDataContext();
        }

        public DatabaseFactory()
        {
            _dataContext = new AcmeDataContext();
        }

        protected override void DisposeCore()
        {
            _dataContext?.Dispose();
        }
    }
    public interface IDatabaseFactory : IDisposable
    {
        AcmeDataContext GetDataContext();
    }
}
