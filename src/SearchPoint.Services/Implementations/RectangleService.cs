using System.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SearchPoint.Data.DBContext;
using SearchPoint.Data.Dto;
using SearchPoint.Services.Interfaces;

namespace SearchPoint.Services.Implementations
{
    public class RectangleService : IRectangleService
	{
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;

        public RectangleService(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<RectangleDto>> FindAsync(PointDto point)
        {
            // the algorithm can change. I used this one:
            // https://www.geeksforgeeks.org/check-if-a-point-lies-on-or-inside-a-rectangle-set-2/

            var rectangles = await _context.Rectangles
                            .Where(r => point.X > r.BottomLeftX && point.X < r.TopRightX &&
                                        point.Y > r.BottomLeftY && point.Y < r.TopRightY)
                            .AsNoTracking()
                            .ToListAsync();

            var result = _mapper.Map<List<RectangleDto>>(rectangles);
            return result;
        }
    }
}

