namespace CalculoCDB.Domain.Models
{
    public class Cdb
    {
        public Cdb(decimal valorResgate, int qtdMes)
        {
            ValorResgate = valorResgate;
            QtdMes = qtdMes;
        }

        public decimal ValorResgate { get; }
        public int QtdMes { get; }
    }
}
