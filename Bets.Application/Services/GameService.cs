using Bets.Application.Entities;
using Bets.Application.Enums;
using Bets.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bets.Application.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        //private readonly IPlayerRepository _playerRepository;
        private readonly IPlayerService _playerService;
        private readonly IUnitOfWork _unitOfWork;
        public GameService(IGameRepository gameRepository, IPlayerService playerService, IUnitOfWork unitOfWork)
        {
            this._gameRepository = gameRepository;
            this._playerService = playerService;
            this._unitOfWork = unitOfWork;
        }
        public async Task PostGameAsync(Game game)
        {
            await this._gameRepository.Add(game: game);
            await this._unitOfWork.Save();
        }
        public async Task PutGame(Game game)
        {
            await this._gameRepository.Update(id: game.Id, game: game);
            await this._unitOfWork.Save();
        }
        public async Task AddBetToGameByRouletteIdAsync(string rouletteId, Bet bet)
        {
            Game game = await this._gameRepository.GetOpenByRouletteId(rouletteId: rouletteId);
            this.ValidateOpenGame(game: game);
            await this.ValidatePlayer(playerId: bet.PlayerId, betAmount: bet.Amount);
            this.ValidateMaximunAmount(maximunAmount: game.MaximunAmount, amount: bet.Amount);
            game.ListOfBets.Add(item: bet);
            await this.PutGame(game: game);
        }
        public async Task<Game> CloseGameByRouletteIdAsync(string rouletteId)
        {
            int resulNumber = 0;
            Game game = await this._gameRepository.GetOpenByRouletteId(rouletteId: rouletteId);
            this.ValidateOpenGame(game: game);
            resulNumber = this.RandomNumber();
            game.ResultNumber = resulNumber;
            game.ResultColor = this.GetColorByNumber(resulNumber);
            this.CalculateBettingResult(game: game);
            await this.PutGame(game: game);

            return game;
        }
        private void CalculateBettingResult(Game game)
        {
            foreach (Bet bet in game.ListOfBets)
            {
                bet.AmountEarned = 0;
                if (bet.Number != null)
                {
                    if (bet.Number == game.ResultNumber)
                    {
                        bet.AmountEarned = bet.Amount * 5;
                    }
                }
                else if (bet.Color != null)
                {
                    if (bet.Color == game.ResultColor)
                    {
                        bet.AmountEarned = bet.Amount * (decimal)1.8;
                    }
                }
            }
        }
        private void ValidateOpenGame(Game game)
        {
            if (game == null)
            {
                throw new Exception("Esta ruleta no tiene juegos abierto");
            }
            else if (!game.Open)
            {
                throw new Exception("Este juego no está abierto.");
            }
        }
        private async Task ValidatePlayer(string playerId, decimal betAmount)
        {
            Player player = await this._playerService.GetPlayerByIdAsync(id: playerId);
            if (player == null)
            {
                throw new Exception("Este id de jugador no existe.");
            }
            else if (betAmount > player.Balance)
            {
                throw new Exception("El saldo del jugador es menor al monto de la apuesta.");
            }
        }
        private void ValidateMaximunAmount(decimal maximunAmount, decimal amount)
        {
            if (amount > maximunAmount)
            {
                throw new Exception("Esta apuesta supera el valor máximo de apuesta para este juego");
            }
        }
        private int RandomNumber()
        {
            Random random = new Random();
            int number = random.Next(0, 36);

            return number;
        }
        private int GetColorByNumber(int number)
        {
            int color = number % 2 == 0 ? (int)ColorEnum.Red : (int)ColorEnum.Black;

            return color;
        }
    }
}
