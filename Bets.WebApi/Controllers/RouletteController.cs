using AutoMapper;
using Bets.Application.Entities;
using Bets.Application.Interfaces;
using Bets.WebApi.Models;
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
    public class RouletteController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRouletteService _rouletteService;
        public RouletteController(IMapper mapper, IRouletteService rouletteService)
        {
            this._mapper = mapper;
            this._rouletteService = rouletteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRoulettes()
        {
            try
            {
                List<Roulette> roulettes = await this._rouletteService.GetRoulettesAsync();
                List<RouletteDto> result = this._mapper.Map<List<RouletteDto>>(source: roulettes);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error al consultar las ruletas.", ex = ex });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoulette(RouletteDto rouletteDto)
        {
            try
            {
                Roulette roulette = _mapper.Map<Roulette>(source: rouletteDto);
                await this._rouletteService.PostRouletteAsync(roulette: roulette);

                return Ok(roulette.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "No se pudo crear la ruleta.", ex = ex });
            }
        }
    }
}
