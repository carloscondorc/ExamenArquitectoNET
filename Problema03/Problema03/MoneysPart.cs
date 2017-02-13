using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema03
{
    public class MoneyParts
    {
        decimal[] denominaciones = new decimal[] { 0.05m, 0.1m, 0.2m, 0.5m, 1m, 2m, 5m, 10m, 20m, 50m, 100m, 200m };
        List<decimal[]> combinaciones;
        List<decimal> combinacion;
        public decimal[][] build(string monto)
        {
            var montodouble = decimal.Parse(monto);
            combinaciones = new List<decimal[]>();
            combinacion = new List<decimal>();
            obtenercombinaciones(montodouble);
            return combinaciones.ToArray();
        }

        void obtenercombinaciones(decimal m)
        {

            if (m < 0.001m)
            {
                combinaciones.Add(combinacion.ToArray());
                return;
            }
            for (int i = 0; i < denominaciones.Length; i++)
            {
                if (m >= denominaciones[i])
                {
                    combinacion.Add(denominaciones[i]);
                    obtenercombinaciones(m - denominaciones[i]);
                    combinacion.RemoveAt(combinacion.Count() - 1);
                }
                else
                {
                    break;
                }

            }

        }
    }
}
