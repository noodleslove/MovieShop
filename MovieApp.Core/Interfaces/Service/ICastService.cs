using MovieApp.Core.Models.Response;

namespace MovieApp.Core.Interfaces.Service;

public interface ICastService
{
    Task<CastResponseModel?> GetCastDetails(int id);
}