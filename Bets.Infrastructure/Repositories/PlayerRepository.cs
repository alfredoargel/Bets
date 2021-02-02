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
    public class PlayerRepository : IPlayerRepository
    {
        private readonly RouletteDBContext _context;
        public PlayerRepository(RouletteDBContext context)
        {
            this._context = context;
        }
        public async Task<List<Player>> GetAll()
        {
            return await this._context.Players.Find(filter: r => true).ToListAsync();
        }
        public async Task<Player> GetById(string id)
        {
            return await this._context.Players.Find(filter: g => g.Id == id).FirstOrDefaultAsync();
        }
        public async Task Add(Player player)
        {
            await this._context.Players.InsertOneAsync(session: this._context.Session, document: player);
        }
        public async Task Update(string id, Player player)
        {
            await this._context.Players.ReplaceOneAsync(session: this._context.Session, filter: r => r.Id == id, replacement: player);
        }
    }
}
