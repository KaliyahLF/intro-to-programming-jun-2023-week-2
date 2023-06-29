using System.Reflection.Metadata.Ecma335;

namespace ShoppingApi.Controllers.ShoppingList;

public class ShoppingListController : ControllerBase
{

    private readonly IManageTheShoppingList _shoppingListManager;
    public ShoppingListController(IManageTheShoppingList shoppingListManager)
    {
        _shoppingListManager = shoppingListManager;
    }

    [HttpPut("/completed-shopping-items/{itemId}")]
    public async Task<ActionResult> MarkItemAsPurchased(string itemId, [FromBody] ShoppingListItemModel request)
    {
        if (itemId != request.Id)
        {
            return BadRequest();
        }



        bool wasUpdated = await _shoppingListManager.MarkAsPurchasedAsync(request);
        if (wasUpdated)
        {
            return NoContent();
        }
        else
        {
            return NotFound();
        }
    }
}
