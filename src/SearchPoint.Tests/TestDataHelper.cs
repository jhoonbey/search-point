using SearchPoint.Data.Dto;

namespace SearchPoint.Tests;

public static class TestDataHelper
{
    public static List<RectangleDto> GetFakeRectangleList()
    {
        return new List<RectangleDto>()
        {
            new RectangleDto
            {
                BottomLeftX = 5,
                BottomLeftY = 8,
                TopRightX = 12,
                TopRightY = 18,
            },
            new RectangleDto
            {
                BottomLeftX = 3,
                BottomLeftY = 7,
                TopRightX = 22,
                TopRightY = 30,
            },
        };
    }
}