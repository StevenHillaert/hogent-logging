using Destructurama.Attributed;
using MediatR;

namespace LogItLikeItsHot.Shared.Features
{
    public class PlaceOrderCommand : IRequest<PlaceOrderResponse>
    {
        public Guid OrderReference { get; } = Guid.NewGuid();
        public string Customer { get; set; } = string.Empty;
        public string[] Coffees { get; set; } = [];

        public string CreditCard { get; set; } = string.Empty;
        
        public string Image { get; set; } = "large image or complex object graph";
    }
}
