using API.Models;
using API.Models.ExchangeRatesModels;

namespace API.ApiService;

public class ExchangeRatesBuildViewModel
{
    private const string CUR_ABBREVIATION_USD = "USD";
    private const string CUR_ABBREVIATION_EUR = "EUR";
    private const string CUR_ABBREVIATION_RUB = "RUB";

    public ExchangeRatesViewModel BuildViewModel(List<ExchangeRatesDto> viewModel)
    {
        var view = new ExchangeRatesViewModel();
        foreach (var model in viewModel)
        {
            if (model.Cur_Abbreviation == CUR_ABBREVIATION_USD)
            {
                view.USD = model.Cur_OfficialRate;
            }
            else if (model.Cur_Abbreviation == CUR_ABBREVIATION_EUR)
            {
                view.EUR = model.Cur_OfficialRate;
            }
            else if (model.Cur_Abbreviation == CUR_ABBREVIATION_RUB)
            {
                view.RUB = model.Cur_OfficialRate;
            }
        }

        return view;
    }
    
}