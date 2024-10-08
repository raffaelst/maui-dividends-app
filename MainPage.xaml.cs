using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace StockMarketApp;

public partial class MainPage : ContentPage
{
    private const string ApiKey = "UQUYOJUV6PMMSBFQ"; 
    private readonly HttpClient _httpClient = new HttpClient();
    public ObservableCollection<Stock> Stocks { get; set; }

    public MainPage()
    {
        InitializeComponent();
        Stocks = new ObservableCollection<Stock>();
        StockListView.ItemsSource = Stocks;
        StockListView.ItemSelected += OnStockSelected;
        LoadStockData();
    }

    private async void OnRefreshClicked(object sender, EventArgs e)
    {
        await LoadStockData();
    }

    private async Task LoadStockData()
    {
        Stocks.Clear();
        var symbols = new List<string> { "AAPL", "MSFT", "GOOGL", "AMZN", "TSLA" }; 

        foreach (var symbol in symbols)
        {
            var stock = await GetStockData(symbol);
            if (stock != null)
            {
                Stocks.Add(stock);
            }
        }
    }

    private async Task<Stock> GetStockData(string symbol)
    {
        try
        {
            string url = $"https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol={symbol}&apikey={ApiKey}";
            var response = await _httpClient.GetStringAsync(url);
            var data = JsonConvert.DeserializeObject<AlphaVantageResponse>(response);

            if (data != null && data?.GlobalQuote?.ContainsKey("05. price") == true)
            {
                return new Stock
                {
                    Symbol = symbol,
                    Price = data.GlobalQuote["05. price"]
                };
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching data for {symbol}: {ex.Message}");
        }
        return null;
    }

    private async void OnStockSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is Stock selectedStock)
        {
            await Navigation.PushAsync(new DividendPage { Symbol = selectedStock.Symbol });
            StockListView.SelectedItem = null;
        }
    }

}

public class Stock
{
    public string Symbol { get; set; }
    public string Price { get; set; }
}

public class AlphaVantageResponse
{
    [JsonProperty("Global Quote")]
    public Dictionary<string, string> GlobalQuote { get; set; }
}
