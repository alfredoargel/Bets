using Bets.Application.Interfaces;
using Bets.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bets.Infrastructure
{
    public sealed class UnitOfWork : IUnitOfWork, IDisposable
    {

        private bool _disposed = false;
        private readonly RouletteDBContext _rouletteDBContext;

        public UnitOfWork(RouletteDBContext rouletteDBContext)
        {
            this._rouletteDBContext = rouletteDBContext;
        }

        public async Task Save()
        {
            await this._rouletteDBContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _rouletteDBContext.Dispose();
                }
            }

            _disposed = true;
        }
    }
}
