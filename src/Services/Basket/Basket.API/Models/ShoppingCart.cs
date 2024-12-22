// ReSharper disable PreferConcreteValueOverDefault
// ReSharper disable MemberCanBePrivate.Global
namespace Basket.API.Models;

public class ShoppingCart
{
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public string UserName { get; set; } = default!;
    public List<ShoppingCartItem> Items { get; set; } = [];
    public decimal TotalPrice => Items.Sum(x => x.Price * x.Quantity);

    public ShoppingCart(string userName)
    {
        UserName = userName;
    }
    
    //Required for mapping
    public ShoppingCart()
    {
        
    }
}