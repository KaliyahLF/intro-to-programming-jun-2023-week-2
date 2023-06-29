
using Microsoft.EntityFrameworkCore;
namespace ShoppingApi.Data;

public class ShoppingDataContext :DbContext
{
    public ShoppingDataContext(DbContextOptions<ShoppingDataContext> options): base(options){ }
    public DbSet<StatusEntity> StatusMessages { get; set; }
    public DbSet<ShoppingListEntity> ShoppingList { get; set; }
}
public class StatusEntity
{
    public int Id { get; set; }
    public string Message { get; set; } = string.Empty;
    public DateTimeOffset LastChecked { get; set; }
}

public class ShoppingListEntity
{
    public int Id { get; set; }
    public string Description { get; init; } = string.Empty;
    public bool Purchased { get; init; }



    public DateTimeOffset DateAdded { get; set; }

}