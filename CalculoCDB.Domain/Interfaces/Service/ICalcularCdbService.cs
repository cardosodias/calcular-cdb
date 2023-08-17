using CalculoCDB.Domain.DTO;
using CalculoCDB.Domain.Models;

namespace CalculoCDB.Domain.Interfaces.Service
{
    public interface ICalcularCdbService
    {
        Task<CdbResponseDto> CalcularResgateCDBAsync(Cdb cDB, CancellationToken cancellationToken);
    }
}
