using LogItLikeItsHot.Shared.Features;
using LogItLikeItsHot.Shared.Logging;
using Serilog;
using Serilog.Core;
using System.Net.Http.Json;

namespace LogItLikeItsHot.Customers
{
    internal class Program
    {
        private static HttpClient _client = new HttpClient() { BaseAddress = new Uri("https://localhost:7088/api/Barista/") };

        static async Task Main(string[] args)
        {
            LoggerBuilder.BuildLogger("1bJXLdO4yIMfIP9Kx5Q3", "customer app");

            Console.WriteLine("Coffee shop, log a cup, is open for business");
            Console.WriteLine("=====================================================");
            Console.WriteLine("Press enter to start ordering...");
            Console.ReadLine();

            #region loading customers
            var tasks = new List<Task>();
            foreach (var customer in customers)
            {
                tasks.Add(OrderCoffee(customer.Item1, customer.Item2));
            }
            await Task.WhenAll(tasks);
            #endregion
        }

        private static async Task OrderCoffee(string customer, string creditcard)
        {
            while (true)
            {
                #region ordering coffee
                // wait for a random time
                await Task.Delay(new Random().Next(100, 1000));

                // get the menu
                var response = await _client.GetAsync("menu");
                var menu = await response.Content.ReadFromJsonAsync<GetMenuResponse>();

                // pick random number of coffees
                var coffees = new List<string>();
                var count = new Random().Next(1, 8);
                for (int i = 0; i < count; i++)
                {
                    var coffee = menu.Menu[new Random().Next(0, menu.Menu.Length)];
                    coffees.Add(coffee.Name);
                }

                // place the order
                var order = new PlaceOrderCommand() { Customer = customer, CreditCard = creditcard, Coffees = coffees.ToArray() };
                var orderResponseMessage = await _client.PostAsJsonAsync("orders", order);

                var orderResponse = (await orderResponseMessage.Content.ReadFromJsonAsync<PlaceOrderResponse>())!;
                #endregion

                // todo : 1a. log customer, amount of coffees and total amount of the order...
                Log.Information("{customer} ordered {count} coffees for a total of {total}EUR", orderResponse.Customer, orderResponse.TotalCoffees, orderResponse.Total);

            }
        }

        private static List<(string, string)> customers = new List<(string, string)>
        {
            ("Alice", "0000 0000 0000 0000"),
            ("Alice", "0000 0000 0000 0000"),
            ("Bob", "1111 1111 1111 1111"),
            ("Charlie", "2222 2222 2222 2222"),
            ("Charlie", "2222 2222 2222 2222"),
            ("David", "3333 3333 3333 3333"),
            ("Eve", "4444 4444 4444 4444"),            
            ("Grace", "6666 6666 6666 6666"),
            ("Grace", "6666 6666 6666 6666"),
            ("Grace", "6666 6666 6666 6666"),
        };
    }
}
