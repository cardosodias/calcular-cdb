namespace CalculoCDB.Application.Excpetions
{
    public class Erro
        {
        public Erro(string campo, string mensagem)
        {
            Campo = campo;
            Mensagem = mensagem;
        }

        public string Campo { get; }
            public string Mensagem { get; }
        }    
}
