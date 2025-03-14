namespace BlazorNavigation.Library.Models
{
    internal class MenuItemModel
    {
        public string Text { get; set; } = string.Empty;

        public List<MenuItemModel>? SubItems { get; set; }
    }
}
