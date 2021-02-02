using Bets.Application.Entities;
using Bets.Application.Interfaces;
using Bets.Infrastructure.Data.Context;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bets.Infrastructure.Repositories
{
    public class RouletteRepository : IRouletteRepository
    {
        private readonly RouletteDBContext _context;
        public RouletteRepository(RouletteDBContext context)
        {
            this._context = context;
        }

        public async Task<List<Roulette>> GetAll()
        {
            return await this._context.Roulettes.Find(filter: r => true).ToListAsync();
        }

        public async Task<Roulette> GetById(string id)
        {
            return await this._context.Roulettes.Find(filter: r => r.Id == id).FirstOrDefaultAsync();
        }

        public async Task Add(Roulette roulette)
        {
            await this._context.Roulettes.InsertOneAsync(session: this._context.Session, document: roulette);
        }

        public async Task Update(string id, Roulette roulette)
        {
            await this._context.Roulettes.ReplaceOneAsync(session: this._context.Session, filter: r => r.Id == id, replacement: roulette);
        }
    }
}
