using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculoJuros.Domain.Entities
{
    public class CalculoJuros
    {
        public CalculoJuros(double valorInicial, int tempoEmMeses, double valorJuros)
        {
            ValorInicial = valorInicial;
            TempoEmMeses = tempoEmMeses;
            ValorJuros = valorJuros;

            Validar();
        }

        public double ValorInicial { get; private set; }
        public int TempoEmMeses{ get; private set; }
        public double ValorJuros { get; private set; }
        public double ValorFinal{ get; private set; }

        private void Validar()
        {
            if (TempoEmMeses <= 0)
                throw new Exception("Defina o tempo em meses maior que 0!");

            if (ValorInicial <= 0)
                throw new Exception("Defina o valor inicial maior que 0!");

        }

        public double CalcularValorFinal()
        {
            ValorFinal = Math.Pow((1 + ValorJuros), TempoEmMeses) * ValorInicial;
            ValorFinal = double.Parse(String.Format("{0:F2}", ValorFinal));
            return ValorFinal;
        }
    }
}
