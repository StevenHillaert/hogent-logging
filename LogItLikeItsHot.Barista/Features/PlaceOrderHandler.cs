using LogItLikeItsHot.Shared.Features;
using MediatR;
using Serilog;

namespace LogItLikeItsHot.Barista.Features
{
    public class PlaceOrderHandler : IRequestHandler<PlaceOrderCommand, PlaceOrderResponse>
    {
        public async Task<PlaceOrderResponse> Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
        {
            await Task.Delay(new Random().Next(100, 500));

            var total = CalculateTotal(request);

            // todo : 1b. log command information...

            return new PlaceOrderResponse()
            {
                OrderReference = request.OrderReference,
                Customer = request.Customer,
                TotalCoffees = request.Coffees.Length,
                Total = total
            };
        }

        private decimal CalculateTotal(PlaceOrderCommand request)
        {
            var menuItems = MenuRepository.GetMenuItems();
            Log.Debug("Menu items: {@MenuItems}", menuItems);

            return menuItems.Where(x => request.Coffees.Contains(x.Name)).Sum(item => item.Price);
        }
    }
}
