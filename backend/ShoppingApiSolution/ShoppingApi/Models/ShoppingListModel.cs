namespace ShoppingApi.Models;

public record ShoppingListItemModel
{
    public string Id { get; set; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public bool Purchased { get; init; } = false;

}

public record CollectionResponse<T>
{
    public List<T> Data { get; set; } = new();
}

public record ShoppingListItemCreateModel
{
    public string Description { get; init; } = string.Empty;
}

[HttpPost("/shopping-list")]
public async Task<ActionResult> AddShoppingListItem([FromBody] ShoppingListItemCreateModel model)
{
    if (ModelState.IsValid)
    {
        ShoppingListItemModel response = await _shoppingListManager.AddItemAsync(model);

        return Ok(response);
    }
    else
    {
        return BadRequest();
    }
}