using Destructurama.Attributed;
using MediatR;

namespace LogItLikeItsHot.Shared.Features
{
    public class PlaceOrderCommand : IRequest<PlaceOrderResponse>
    {
        public Guid OrderReference { get; } = Guid.NewGuid();
        public string Customer { get; set; } = string.Empty;
        public string[] Coffees { get; set; } = [];

        // todo : 3c. mask this property, keep the first and last 4 digits
        [LogMasked(PreserveLength = true, ShowFirst = 4, ShowLast = 4)]
        public string CreditCard { get; set; } = string.Empty;

        // todo : 3b. exclude this property from logging
        [NotLogged]
        public string Image { get; set; } = "large image or complex object graph";
    }
}
