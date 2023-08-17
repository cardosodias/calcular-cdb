using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculoCDB.Application.Excpetions
{    
        public class Erro
        {
        public Erro(string campo, string menssagem)
        {
            Campo = campo;
            Menssagem = menssagem;
        }

        public string Campo { get; }
            public string Menssagem { get; }
        }    
}
