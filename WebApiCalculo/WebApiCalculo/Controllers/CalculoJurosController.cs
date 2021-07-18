using CrossCutting.ConsumoAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCalculo.Controllers
{
    [ApiController]
    public class CalculoJurosController : Controller
    {
        private readonly IConsumoAPI<double> _consumoAPI;
        private readonly IConfiguration _configuration;

        public CalculoJurosController(IConfiguration configuration, IConsumoAPI<double> consumoAPI)
        {
            _configuration = configuration;
            _consumoAPI = consumoAPI;
        }

        [HttpGet("calculajuros")]
        public async Task<IActionResult> CalcularJuros([FromQuery] double valorInicial, [FromQuery] int tempoEmMeses)
        {
            try
            {
                var juros = await _consumoAPI.Get(_configuration.GetSection("BaseURLWebApiJuros").Value + "taxajuros");

                var calculoJuros = new CalculoJuros.Domain.Entities.CalculoJuros(valorInicial, tempoEmMeses, juros);
                return Ok(calculoJuros.CalcularValorFinal());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }
    }
}
