using Microsoft.EntityFrameworkCore;
using ShoppingApi.Data;

namespace ShoppingApi.Controllers;



public class StatusLookup : ILookupTheStatus
{

    private readonly ShoppingDataContext _context;
    public StatusLookup(ShoppingDataContext context) 
    {
        _context = context;
    }
    public async Task<GetStatusResponse> GetCurrentStatusAsync()
    {
        var savedStatus = await _context.StatusMessages.OrderBy(m => m.LastChecked).FirstOrDefaultAsync();
        if (savedStatus is null) {
            //Message
            var entitytoSave = new StatusEntity
            {
                Message = "Looks Good",
                LastChecked = DateTimeOffset.Now
            };
            _context.StatusMessages.Add(entitytoSave);
            await _context.SaveChangesAsync();
        }
        else
        {
            //check if it is stale
        }
        var response = new GetStatusResponse
        {
            Message = "Looks Good Here",
            LastChecked = DateTimeOffset.Now
        };
        return response;
    }
}