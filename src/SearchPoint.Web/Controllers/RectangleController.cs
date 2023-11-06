﻿using Microsoft.AspNetCore.Mvc;
using SearchPoint.Data.Dto;
using SearchPoint.Services.Interfaces;

namespace SearchPoint.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RectangleController : ControllerBase
    {
        private readonly IRectangleService _rectangleService;
        private readonly ILoggerManager _logger;

        public RectangleController(ILoggerManager logger, IRectangleService rectangleService)
        {
            _rectangleService = rectangleService;
            _logger = logger;
        }

        /// <summary>
        ///  Find rectangles that given point lies inside in
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PointDto point)
        {
            var response = await _rectangleService.FindAsync(point);

            _logger.LogInfo($"Returned {response.Count} rectangles.");

            return Ok(response);
        }
    }
}