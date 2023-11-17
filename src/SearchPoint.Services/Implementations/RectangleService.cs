using System.Data;
using AutoMapper;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using SearchPoint.Data.DBContext;
using SearchPoint.Data.Dto;
using SearchPoint.Data.Entities;
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

        public async Task<List<RectangleDto>> FindAsync(RequestDto request)
        {
            // the algorithm can change. I used this one:
            // https://www.geeksforgeeks.org/check-if-a-point-lies-on-or-inside-a-rectangle-set-2/

            var predicate = PredicateBuilder.New<Rectangle>(false);
            foreach (PointDto item in request.Points)
            {
                PointDto point = item;
                predicate = predicate.Or(r => point.X > r.BottomLeftX && point.X < r.TopRightX &&
                                              point.Y > r.BottomLeftY && point.Y < r.TopRightY);
            }

            var rectangles = await _context.Rectangles
                            .Where(predicate)
                            .AsNoTracking()
                            .ToListAsync();

            var result = _mapper.Map<List<RectangleDto>>(rectangles);
            return result;
        }
    }
}

