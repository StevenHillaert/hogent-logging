namespace LogItLikeItsHot.Shared.Features
{
    public class GetMenuResponse
    {
        public record MenuItem(string Name, decimal Price);

        public MenuItem[] Menu { get; set; } = new MenuItem[0];
    }
}
