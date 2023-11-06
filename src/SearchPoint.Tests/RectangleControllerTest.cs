using Microsoft.AspNetCore.Mvc;
using Moq;
using SearchPoint.Data.Dto;
using SearchPoint.Services.Interfaces;
using SearchPoint.Web.Controllers;

namespace SearchPoint.Tests;

public class RectangleControllerTest
{
    private readonly Mock<IRectangleService> rectangleService;

    public RectangleControllerTest()
    {
        rectangleService = new Mock<IRectangleService>();
    }

    [Fact]
    public async void WhenGivenPoint_shouldReturnRectangle_ifFound()
    {
        // arrange
        var point = new PointDto
        {
            X = 8,
            Y = 9
        };
        var response = TestDataHelper.GetFakeRectangleList();

        var loggerMock = new Mock<ILoggerManager>();
        rectangleService.Setup(x => x.FindAsync(point)).ReturnsAsync(() => response);
        var controller = new RectangleController(loggerMock.Object, rectangleService.Object);

        // act
        var actionResult = await controller.Get(point);

        var okObjectResult = actionResult as OkObjectResult;
        Assert.NotNull(okObjectResult);

        var result = okObjectResult.Value as List<RectangleDto>;
        Assert.NotNull(result);

        // assert
        Assert.Equal(response.ToString(), result.ToString());
        Assert.True(response.Equals(result));
        Assert.Equal(2, result.Count);
    }
}
