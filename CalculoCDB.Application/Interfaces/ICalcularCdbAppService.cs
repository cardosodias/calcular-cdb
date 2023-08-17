using CalculoCDB.Domain.DTO;
using CalculoCDB.Domain.Models;

namespace CalculoCDB.Application.Interfaces
{
    public interface ICalcularCdbAppService
    {
        Task<CdbResponseDto> ResgatarCDBAsync(Cdb cDB,CancellationToken cancellationToken);
    }
}
