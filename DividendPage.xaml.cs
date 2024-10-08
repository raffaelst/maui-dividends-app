using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace StockMarketApp;

[QueryProperty(nameof(Symbol), "symbol")]
public partial class DividendPage : ContentPage
{
    private const string ApiKey = "UQUYOJUV6PMMSBFQ"; 
    private readonly HttpClient _httpClient = new HttpClient();
    public ObservableCollection<Dividend> Dividends { get; set; }
    public string Symbol { get; set; }

    public DividendPage()
    {
        InitializeComponent();
        Dividends = new ObservableCollection<Dividend>();
        DividendListView.ItemsSource = Dividends;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (!string.IsNullOrEmpty(Symbol))
        {
            await LoadDividendData(Symbol);
        }
    }

    private async Task LoadDividendData(string symbol)
    {
        try
        {
            string url = $"https://www.alphavantage.co/query?function=TIME_SERIES_MONTHLY_ADJUSTED&symbol={symbol}&apikey={ApiKey}";
            var response = await _httpClient.GetStringAsync(url);
            var data = JsonConvert.DeserializeObject<AlphaVantageTimeSeriesResponse>(response);

            if (data != null && data.MonthlyAdjustedTimeSeries != null)
            {
                foreach (var item in data.MonthlyAdjustedTimeSeries)
                {
                    if (item.Value.ContainsKey("7. dividend amount") && decimal.TryParse(item.Value["7. dividend amount"], out var dividend) && dividend > 0)
                    {
                        Dividends.Add(new Dividend
                        {
                            Date = item.Key,
                            DividendValue = item.Value["7. dividend amount"]
                        });
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching dividend data: {ex.Message}");
        }
    }
}

public class Dividend
{
    public string Date { get; set; }
    public string DividendValue { get; set; }
}

public class AlphaVantageTimeSeriesResponse
{
    [JsonProperty("Monthly Adjusted Time Series")]
    public Dictionary<string, Dictionary<string, string>> MonthlyAdjustedTimeSeries { get; set; }
}
