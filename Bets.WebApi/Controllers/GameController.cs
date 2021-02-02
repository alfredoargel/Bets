using AutoMapper;
using Bets.Application.Entities;
using Bets.Application.Interfaces;
using Bets.WebApi.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bets.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGameService _gameService;
        public GameController(IMapper mapper, IGameService gameService)
        {
            this._mapper = mapper;
            this._gameService = gameService;
        }
        [HttpPost]
        public async Task<IActionResult> OpenGameForRoulette([FromQuery] string rouletteId)
        {
            try
            {
                Game game = new Game
                {
                    RouletteId = rouletteId,
                    MaximunAmount = 10000,
                    Open = true,
                    ListOfBets = new List<Bet>()
                };
                await this._gameService.PostGameAsync(game: game);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error al abrir la ruleta.", ex = ex });
            }
        }
        [HttpPut]
        public async Task<IActionResult> PostBetToRoulette([FromHeader] string playerId, [FromQuery] string rouletteId, [FromBody] BetDto bet)
        {
            try
            {
                Bet objBet = this._mapper.Map<Bet>(source: bet);
                objBet.PlayerId = playerId;
                await this._gameService.AddBetToGameByRouletteIdAsync(rouletteId: rouletteId, bet: objBet);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error al agregar apuesta a la ruleta.", ex = ex });
            }
        }
        [HttpPut]
        public async Task<IActionResult> CloseGameForRoulette([FromQuery] string rouletteId)
        {
            try
            {
                Game game = await this._gameService.CloseGameByRouletteIdAsync(rouletteId: rouletteId);
                GameDto result = this._mapper.Map<GameDto>(source: game);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error al cerrar la ruleta.", ex = ex });
            }
        }
    }
}
