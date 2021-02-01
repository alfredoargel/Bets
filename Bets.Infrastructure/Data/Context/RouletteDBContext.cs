using Bets.Application.Entities;
using Bets.Infrastructure.Data.MongoDB;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bets.Infrastructure.Data.Context
{
    public class RouletteDBContext : IDisposable
    {
        private readonly IMongoDatabase _db;
        private readonly IClientSessionHandle _session;
        private bool _disposed;

        public RouletteDBContext(MongoDBConfig config)
        {
            var client = new MongoClient(config.ConnectionString);
            _db = client.GetDatabase(config.Database);
            this._session = client.StartSession();
            this._session.StartTransaction();
        }

        public IMongoCollection<Roulette> Roulettes => _db.GetCollection<Roulette>("Roulettes");

        internal IClientSessionHandle Session => _session;

        public async Task SaveChangesAsync()
        {
            await this.Session.CommitTransactionAsync();
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
                    this.Session.Dispose();
                }
            }

            _disposed = true;
        }
    }
}
