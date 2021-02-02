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
    public class GameRepository : IGameRepository
    {
        private readonly RouletteDBContext _context;
        public GameRepository(RouletteDBContext context)
        {
            this._context = context;
        }

        public async Task<Game> GetById(string id)
        {
            return await this._context.Games.Find(filter: g => g.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Game> GetOpenByRouletteId(string rouletteId)
        {
            return await this._context.Games.Find(filter: g => g.RouletteId == rouletteId && g.Open).FirstOrDefaultAsync();
        }

        public async Task Add(Game game)
        {
            await this._context.Games.InsertOneAsync(session: this._context.Session, document: game);
        }

        public async Task Update(string id, Game game)
        {
            await this._context.Games.ReplaceOneAsync(session: this._context.Session, filter: r => r.Id == id, replacement: game);
        }
    }
}
