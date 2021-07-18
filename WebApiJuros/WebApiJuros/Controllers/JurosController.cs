using CalculoJuros.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiJuros.Controllers
{
    [ApiController]
    public class JurosController : Controller
    {
        [HttpGet("taxaJuros")]
        public IActionResult ObterTaxaDeJuros()
        {
            return Ok(Juros.VALOR_TAXA_JUROS);
        }
    }
}
