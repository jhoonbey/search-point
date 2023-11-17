using SearchPoint.Data.Dto;

namespace SearchPoint.Services.Interfaces
{
    public interface IRectangleService
    {
        Task<List<RectangleDto>> FindAsync(RequestDto request);
    }
}