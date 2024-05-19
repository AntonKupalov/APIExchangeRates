namespace API.ApiService;

public class ExchangeRatesDto
{
    public string Cur_Abbreviation { get; set; }
    
    public double Cur_OfficialRate { get; set; }
    
    public DateTime Date { get; set; }
}