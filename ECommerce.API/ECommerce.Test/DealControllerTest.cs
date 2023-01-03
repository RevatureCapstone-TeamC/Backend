namespace ECommerce.Test;

[Collection("ECommerce Collection")]
public class DealControllerTest
{
    private readonly ECommerceFixture _fixture;
    // ! _output is just for extra logging in the xUnit console
    private readonly ITestOutputHelper _output;

    public DealControllerTest(ECommerceFixture fixture, ITestOutputHelper output){
        this._fixture = fixture;
        this._output = output;
    }

    [Fact]
    public async void GetDealsReturnsList(){
        // * ARRANGE
        var controller = new DealController(_fixture.Context);

        // * ACT
        var result = await controller.GetDeals();

        // * ASSERT
        Assert.IsType<List<Deal>>(result.Value);
    }

    [Fact]
    public async void GetDealIDReturnsNotFound(){
        // * ARRANGE
        var controller = new DealController(_fixture.Context);
        // ! No deal with ID: 3
        int id = 3;

        // * ACT
        var result = await controller.GetDeal(id);

        // * ASSERT
        Assert.IsType<Microsoft.AspNetCore.Mvc.NotFoundResult>(result.Result);
    }

    // ! GetDeal does not produce a status code on success
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public async void GetDealIDReturnsDeal(int id){
        // * ARRANGE
        var controller = new DealController(_fixture.Context);

        // * ACT
        var result = await controller.GetDeal(id);

        // * ASSERT
        Assert.IsType<Deal>(result.Value);
        Assert.NotNull(result.Value);
    }

    // * CreateDeal() produces BadRequest() when ProductID is invalid or SalePrice is negative
    [Theory]
    [InlineData(5, 150.0)]
    [InlineData(4, -50.0)]
    public async void CreateDealReturnsBadRequest(int pId, double sp){
        // * ARRANGE
        var controller = new DealController(_fixture.Context);
        Deal tmpD = new Deal{DealId=0, fk_Product_Id=pId, SalePrice=(decimal)sp};

        // * ACT
        var result = await controller.CreateDeal(tmpD);
        _output.WriteLine($"CreateDeal() Returned: {result}");

        // * ASSERT
        Assert.IsType<Microsoft.AspNetCore.Mvc.BadRequestObjectResult>(result);
    }

    [Fact]
    public async void CreateDealReturnsOk(){
        // TODO : IMPLEMENT
        // * ARRANGE
        var controller = new DealController(_fixture.Context);

        // * ACT

        // * ASSERT
    }

    [Fact]
    public async void UpdateDealReturnsNotFound(){
        // TODO : IMPLEMENT
        // * ARRANGE
        var controller = new DealController(_fixture.Context);

        // * ACT

        // * ASSERT
    }

    [Fact]
    public async void UpdateDealReturnsNoContent(){
        // TODO : IMPLEMENT
        // * ARRANGE
        var controller = new DealController(_fixture.Context);

        // * ACT

        // * ASSERT
    }

    [Fact]
    public async void DeleteDealIDReturnsNotFound(){
        // TODO : IMPLEMENT
        // * ARRANGE
        var controller = new DealController(_fixture.Context);

        // * ACT

        // * ASSERT
    }

    [Fact]
    public async void DeleteDealIDReturnsNoContent(){
        // TODO : IMPLEMENT
        // * ARRANGE
        var controller = new DealController(_fixture.Context);

        // * ACT

        // * ASSERT
    }

    [Fact]
    public async void DeleteDealsReturnsNoContent(){
        // TODO : IMPLEMENT
        // * ARRANGE
        var controller = new DealController(_fixture.Context);

        // * ACT

        // * ASSERT
    }

    [Fact]
    public async void DeleteDealsReturnsBadRequest(){
        // TODO : IMPLEMENT
        // * ARRANGE
        var controller = new DealController(_fixture.Context);

        // * ACT

        // * ASSERT
    }
}