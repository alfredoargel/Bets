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
    public class PlayerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPlayerService _playerService;
        public PlayerController(IMapper mapper, IPlayerService playerService)
        {
            this._mapper = mapper;
            this._playerService = playerService;
        }
        [HttpGet]
        public async Task<IActionResult> GetPlayers()
        {
            try
            {
                List<Player> players = await this._playerService.GetPlayersAsync();
                List<PlayerDto> result = this._mapper.Map<List<PlayerDto>>(source: players);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error al consultar los jugadores.", ex = ex });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlayer(PlayerDto playerDto)
        {
            try
            {
                Player player = _mapper.Map<Player>(source: playerDto);
                await this._playerService.PostPlayerAsync(player: player);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "No se pudo crear el jugador.", ex = ex });
            }
        }

        [HttpPut]
        public async Task<IActionResult> AddAmountToPlayerBalance([FromHeader] string playerId, [FromQuery] decimal amount)
        {
            try
            {
                await this._playerService.AddAmountToPlayerBalance(playerId: playerId, amount: amount);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "No se pudo actualizar el balance del jugador.", ex = ex });
            }
        }
    }
}
