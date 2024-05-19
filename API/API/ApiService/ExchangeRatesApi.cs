namespace API.ApiService;

public class ExchangeRatesApi
{
   private HttpClient _httpClient;

   public ExchangeRatesApi(HttpClient httpClient)
   {
      _httpClient = httpClient;
   }

   public Task<List<ExchangeRatesDto?>> GetExcangeRates()
   {
      return _httpClient.GetFromJsonAsync<List<ExchangeRatesDto>>("/exrates/rates?periodicity=0");
   }
   


}