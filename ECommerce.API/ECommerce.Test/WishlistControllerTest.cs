namespace ECommerce.Test;

[Collection("ECommerce Collection")]
public class WishlistControllerTest
{
    private readonly CommerceContext _context;
    // ! _output is just for extra logging in the xUnit console
    private readonly ITestOutputHelper _output;

    public WishlistControllerTest(CommerceContext context, ITestOutputHelper output){
        this._context = context;
        this._output = output;
    }

    [Fact]
    public async void GetWishlistReturnsList(){
        // TODO : IMPLEMENT
        // * ARRANGE

        // * ACT

        // * ASSERT
    }

    [Fact]
    public async void GetWishlistProductsReturnsNotFound(){
        // TODO : IMPLEMENT
        // * ARRANGE

        // * ACT

        // * ASSERT
    }

    [Fact]
    public async void GetWishlistProductsReturnsProductList(){
        // TODO : IMPLEMENT
        // * ARRANGE

        // * ACT

        // * ASSERT
    }

    [Fact]
    public async void PutWishlistReturnsBadRequest(){
        // TODO : IMPLEMENT
        // * ARRANGE

        // * ACT

        // * ASSERT
    }

    [Fact]
    public async void PutWishlistReturnsNotFound(){
        // TODO : IMPLEMENT
        // * ARRANGE

        // * ACT

        // * ASSERT
    }

    [Fact]
    public async void PutWishlistReturnsNoContent(){
        // TODO : IMPLEMENT
        // * ARRANGE

        // * ACT

        // * ASSERT
    }

    [Fact]
    public async void PostWishlistReturnsCreated(){
        // TODO : IMPLEMENT
        // * ARRANGE

        // * ACT

        // * ASSERT
    }

    [Fact]
    public async void DeleteWishlistReturnsNotFound(){
        // TODO : IMPLEMENT
        // * ARRANGE

        // * ACT

        // * ASSERT
    }

    [Fact]
    public async void DeleteWishlistReturnsNoContent(){
        // TODO : IMPLEMENT
        // * ARRANGE

        // * ACT

        // * ASSERT
    }

    
}