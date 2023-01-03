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

    // ! Because the cart in the context is always seeded, we can't really
    // !    test for a null Cart DbSet
    [Fact]
    public async void GetCartReturnsListOfCarts(){
        // TODO : IMPLEMENT
        // * ARRANGE

        // * ACT

        // * ASSERT
    }

    [Fact]
    public async void GetCartIDReturnsNotFound(){
        // TODO : IMPLEMENT
        // * ARRANGE

        // * ACT

        // * ASSERT
    }

    [Fact]
    public async void GetCartIDReturnsCartItem(){
        // TODO : IMPLEMENT
        // * ARRANGE

        // * ACT

        // * ASSERT
    }

    [Fact]
    public async void PutCartReturnsBadRequest(){
        // TODO : IMPLEMENT
        // * ARRANGE

        // * ACT

        // * ASSERT
    }
    
    [Fact]
    public async void PutCartReturnsNotFound(){
        // TODO : IMPLEMENT
        // * ARRANGE

        // * ACT

        // * ASSERT
    }

    [Fact]
    public async void PutCartReturnsNoContent(){
        // TODO : IMPLEMENT
        // * ARRANGE

        // * ACT

        // * ASSERT
    }

    [Fact]
    public async void PostCartReturnsCreated(){
        // TODO : IMPLEMENT
        // * ARRANGE

        // * ACT

        // * ASSERT
    }

    [Fact]
    public async void DeleteCartReturnsNotFound(){
        // TODO : IMPLEMENT
        // * ARRANGE

        // * ACT

        // * ASSERT
    }

    [Fact]
    public async void DeleteCartReturnsNoContent(){
        // TODO : IMPLEMENT
        // * ARRANGE

        // * ACT

        // * ASSERT
    }
}