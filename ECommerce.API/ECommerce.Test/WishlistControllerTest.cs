namespace ECommerce.Test;

[Collection("ECommerce Collection")]
public class WishlistControllerTest
{
    private readonly ECommerceFixture _fixture;
    // ! _output is just for extra logging in the xUnit console
    private readonly ITestOutputHelper _output;

    public WishlistControllerTest(ECommerceFixture fixture, ITestOutputHelper output){
        this._fixture = fixture;
        this._output = output;
    }

    // * GetWishlist() returns a List
    // ! Only returns NotFound() if the Wishlist DbSet itself is null 
    [Fact]
    public async void GetWishlistReturnsList(){
        // * ARRANGE
        var controller = new WishlistController(_fixture.Context);

        // * ACT
        var result = await controller.GetWishlist();

        // * ASSERT
        Assert.IsType<List<Wishlist>>(result.Value);
    }

    [Fact]
    public async void GetWishlistProductsReturnsNotFound(){
        // TODO : IMPLEMENT AFTER MERGING
        // * ARRANGE
        var controller = new WishlistController(_fixture.Context);
        //no products in the wishlists are Product #2
        int wid = 3;

        // * ACT
        var result = await controller.GetWishlistProducts(wid);

        // * ASSERT
        Assert.IsType<Microsoft.AspNetCore.Mvc.NotFoundResult>(result);
    }

    [Fact]
    public async void GetWishlistProductsReturnsProductList(){
        // TODO : IMPLEMENT
        // * ARRANGE
        var controller = new WishlistController(_fixture.Context);

        // * ACT

        // * ASSERT
    }

    [Fact]
    public async void PutWishlistReturnsBadRequest(){
        // TODO : IMPLEMENT
        // * ARRANGE
        var controller = new WishlistController(_fixture.Context);

        // * ACT

        // * ASSERT
    }

    [Fact]
    public async void PutWishlistReturnsNotFound(){
        // TODO : IMPLEMENT
        // * ARRANGE
        var controller = new WishlistController(_fixture.Context);

        // * ACT

        // * ASSERT
    }

    [Fact]
    public async void PutWishlistReturnsNoContent(){
        // TODO : IMPLEMENT
        // * ARRANGE
        var controller = new WishlistController(_fixture.Context);

        // * ACT

        // * ASSERT
    }

    [Fact]
    public async void PostWishlistReturnsCreated(){
        // TODO : IMPLEMENT
        // * ARRANGE
        var controller = new WishlistController(_fixture.Context);

        // * ACT

        // * ASSERT
    }

    [Fact]
    public async void DeleteWishlistReturnsNotFound(){
        // TODO : IMPLEMENT
        // * ARRANGE
        var controller = new WishlistController(_fixture.Context);

        // * ACT

        // * ASSERT
    }

    [Fact]
    public async void DeleteWishlistReturnsNoContent(){
        // TODO : IMPLEMENT
        // * ARRANGE
        var controller = new WishlistController(_fixture.Context);

        // * ACT

        // * ASSERT
    }

    
}