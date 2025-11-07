using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using UTM_Chat.Web.Models;

namespace UTM_Chat.Web.Controllers;

public class HomeController : Controller
{
    private static BallPositionViewModel ballPosition = new BallPositionViewModel() { xPosition = 100, yPosition = 100 };
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View(ballPosition);
    }


    [HttpPost]
    public IActionResult UpdatePosition([FromBody] string key)
        {
            switch(key)
            {
                case "ArrowUp": ballPosition.yPosition -= 5; break;
                case "ArrowDown": ballPosition.yPosition += 5; break;
                case "ArrowLeft": ballPosition.xPosition -= 5; break;
                case "ArrowRight": ballPosition.xPosition += 5; break;
            }
            return Json(ballPosition);
        }
    }

    

