using CalculoCDB.Application.Excpetions;

namespace CalculoCDB.WebApi.Models
{
    public class ErroNegocio
    {
        public ErroNegocio(List<Erro> erros)
        {
            Erros = erros;
        }

        public List<Erro> Erros { get; }

        
    }
}
