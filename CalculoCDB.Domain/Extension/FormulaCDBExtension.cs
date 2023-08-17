using CalculoCDB.Domain.Constantes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculoCDB.Domain.Extension
{
    public static class FormulaCDBExtension
    {
        public static Task<decimal> FormulaCDB(this decimal valor)
        {
            return Task.FromResult(valor * (1 + TaxaCDBConstantes.CDI * TaxaCDBConstantes.TB));
        }
    }
}
