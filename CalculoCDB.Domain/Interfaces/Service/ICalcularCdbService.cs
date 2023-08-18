using CalculoCDB.Domain.DTO;
using CalculoCDB.Domain.Models;

namespace CalculoCDB.Domain.Interfaces.Service
{
    public interface ICalcularCdbService
    {
        Task<CdbResponseDto> CalcularResgateCdbAsync(Cdb cDB, CancellationToken cancellationToken);
    }
}
