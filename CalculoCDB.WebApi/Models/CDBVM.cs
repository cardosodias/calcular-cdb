using CalculoCDB.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace CalculoCDB.WebApi.Models
{
    public class CDBVM
    {
        [Required]
        public decimal ValorResgate { get; set; }

        [Required]
        public int QtdMes { get; set; }

        public Cdb ConvertToCDB()
        {
            return new Cdb(ValorResgate, QtdMes);
        }
    }
}
