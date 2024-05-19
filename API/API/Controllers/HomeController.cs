using System.Diagnostics;
using API.ApiService;
using Microsoft.AspNetCore.Mvc;
using API.Models;

namespace API.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private ExchangeRatesApi _exchangeRatesApi;
    private ExchangeRatesBuildViewModel _exchangeRatesBuildViewModel;

    public HomeController(ILogger<HomeController> logger
        ,ExchangeRatesApi exchangeRatesApi
        ,ExchangeRatesBuildViewModel exchangeRatesBuildViewModel)
    {
        _logger = logger;
        _exchangeRatesApi = exchangeRatesApi;
        _exchangeRatesBuildViewModel = exchangeRatesBuildViewModel;
    }

    public async Task<IActionResult> Index()
    {
        var view = new HomeIndexVIewModel();
        var exchangeRates = _exchangeRatesApi.GetExcangeRates();
        Task.WaitAll(exchangeRates);

        view.ExchangeRatesViewModel = _exchangeRatesBuildViewModel.BuildViewModel(exchangeRates.Result);
        return View(view);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}