using LogItLikeItsHot.Shared.Features;
using MediatR;

namespace LogItLikeItsHot.Barista.Features
{
    public class GetMenuHandler : IRequestHandler<GetMenuQuery, GetMenuResponse>
    {
        public async Task<GetMenuResponse> Handle(GetMenuQuery request, CancellationToken cancellationToken)
        {
            await Task.Delay(new Random().Next(100, 500));

            var items = MenuRepository.GetMenuItems();

            return new GetMenuResponse()
            {
                Menu = items
            };
        }
    }
}
