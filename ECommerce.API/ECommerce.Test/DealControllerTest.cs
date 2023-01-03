namespace ECommerce.Test;

[Collection("ECommerce Collection")]
public class DealControllerTest
{
    private readonly CommerceContext _context;
    // ! _output is just for extra logging in the xUnit console
    private readonly ITestOutputHelper _output;

    public DealControllerTest(CommerceContext context, ITestOutputHelper output){
        this._context = context;
        this._output = output;
    }

    [Fact]
    public async void GetDealsReturnsList(){
        // TODO : IMPLEMENT
        // * ARRANGE

        // * ACT

        // * ASSERT
    }

    [Fact]
    public async void GetDealIDReturnsNotFound(){
        // TODO : IMPLEMENT
        // * ARRANGE

        // * ACT

        // * ASSERT
    }

    [Fact]
    public async void GetDealIDReturnsDeal(){
        // TODO : IMPLEMENT
        // * ARRANGE

        // * ACT

        // * ASSERT
    }

    [Theory]
    [InlineData()]
    [InlineData()]
    public async void CreateDealReturnsBadRequest(){
        // TODO : IMPLEMENT
        // * ARRANGE

        // * ACT

        // * ASSERT
    }

    [Fact]
    public async void CreateDealReturnsOk(){
        // TODO : IMPLEMENT
        // * ARRANGE

        // * ACT

        // * ASSERT
    }

    [Fact]
    public async void UpdateDealReturnsNotFound(){
        // TODO : IMPLEMENT
        // * ARRANGE

        // * ACT

        // * ASSERT
    }

    [Fact]
    public async void UpdateDealReturnsNoContent(){
        // TODO : IMPLEMENT
        // * ARRANGE

        // * ACT

        // * ASSERT
    }

    [Fact]
    public async void DeleteDealIDReturnsNotFound(){
        // TODO : IMPLEMENT
        // * ARRANGE

        // * ACT

        // * ASSERT
    }

    [Fact]
    public async void DeleteDealIDReturnsNoContent(){
        // TODO : IMPLEMENT
        // * ARRANGE

        // * ACT

        // * ASSERT
    }

    [Fact]
    public async void DeleteDealsReturnsNoContent(){
        // TODO : IMPLEMENT
        // * ARRANGE

        // * ACT

        // * ASSERT
    }

    [Fact]
    public async void DeleteDealsReturnsBadRequest(){
        // TODO : IMPLEMENT
        // * ARRANGE

        // * ACT

        // * ASSERT
    }
}