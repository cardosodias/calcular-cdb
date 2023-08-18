using CalculoCDB.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace CalculoCDB.WebApi.Models
{
    public class CdbVm
    {
        [Required]
        public decimal ValorResgate { get; set; }

        [Required]
        public int QtdMes { get; set; }

        public Cdb ConvertToCdb()
        {
            return new Cdb(ValorResgate, QtdMes);
        }
    }
}
