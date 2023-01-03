namespace ECommerce.Test;

[Collection("ECommerce Collection")]
public class ProductControllerTest
{
    private readonly CommerceContext _context;
    // ! _output is just for extra logging in the xUnit console
    private readonly ITestOutputHelper _output;

    public ProductControllerTest(CommerceContext context, ITestOutputHelper output){
        this._context = context;
        this._output = output;
    }

    [Fact]
    public async void GetOneReturnsNotFound(){
        // TODO : IMPLEMENT
        // * ARRANGE

        // * ACT

        // * ASSERT
    }

    [Fact]
    public async void GetOneReturnsProduct(){
        // TODO : IMPLEMENT
        // * ARRANGE

        // * ACT

        // * ASSERT
    }

    [Fact]
    public async void GetAllReturnsList(){
        // TODO : IMPLEMENT
        // * ARRANGE

        // * ACT

        // * ASSERT
    }

    // TODO : Write up a test for Purchase()
}