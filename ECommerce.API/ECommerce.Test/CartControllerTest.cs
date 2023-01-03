namespace ECommerce.Test;

[Collection("ECommerce Collection")]
public class CartControllerTest
{
    private readonly CommerceContext _context;
    // ! _output is just for extra logging in the xUnit console
    private readonly ITestOutputHelper _output;

    public CartControllerTest(CommerceContext context, ITestOutputHelper output){
        this._context = context;
        this._output = output;
    }
}