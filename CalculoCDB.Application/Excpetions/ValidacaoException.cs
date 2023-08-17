namespace CalculoCDB.Application.Excpetions
{
    public class ValidacaoException : Exception
    {
        public List<Erro> Erros { get; }

        public ValidacaoException(List<Erro> erros) : base("Erros de validação.")
        {
            Erros = erros ?? new List<Erro>();
        }
       
    }
}
