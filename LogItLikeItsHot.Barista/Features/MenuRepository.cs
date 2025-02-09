using LogItLikeItsHot.Shared.Features;

namespace LogItLikeItsHot.Barista.Features
{
    public class MenuRepository
    {
        public static GetMenuResponse.MenuItem[] GetMenuItems()
        {
            return new[]
                {
                    new GetMenuResponse.MenuItem("Latte", 3.50m),
                    new GetMenuResponse.MenuItem("Cappuccino", 3.50m),
                    new GetMenuResponse.MenuItem("Flat White", 3.50m),
                    new GetMenuResponse.MenuItem("Long Black", 3.50m),
                    new GetMenuResponse.MenuItem("Espresso", 2.00m),
                    new GetMenuResponse.MenuItem("Macchiato", 2.50m),
                    new GetMenuResponse.MenuItem("Mocha", 4.00m),
                    new GetMenuResponse.MenuItem("Affogato", 4.00m),
                    new GetMenuResponse.MenuItem("Iced Coffee", 4.00m),
                    new GetMenuResponse.MenuItem("Hot Chocolate", 3.00m)
                };
        }
    }
}
