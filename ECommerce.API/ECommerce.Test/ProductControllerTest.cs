namespace ECommerce.Test;

[Collection("ECommerce Collection")]
public class ProductControllerTest
{
    private readonly ECommerceFixture _fixture;
    // ! _output is just for extra logging in the xUnit console
    private readonly ITestOutputHelper _output;

    public ProductControllerTest(ECommerceFixture fixture, ITestOutputHelper output){
        this._fixture = fixture;
        this._output = output;
    }

    [Fact]
    public async void GetOneReturnsNotFound(){
        // * ARRANGE
        var controller = new ProductController(_fixture.Context);
        //No products with an id of 5 exist
        int id = 5;

        // * ACT
        var result = await controller.GetOne(id);

        // * ASSERT
        Assert.IsType<Microsoft.AspNetCore.Mvc.NotFoundResult>(result.Result);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    public async void GetOneReturnsProduct(int id){
        // * ARRANGE
        var controller = new ProductController(_fixture.Context);

        // * ACT
        var result = await controller.GetOne(id);
        _output.WriteLine($"GetOne returned the result: {result}\nProduct: {result.Value}");

        // * ASSERT
        Assert.IsType<Product>(result.Value);
        Assert.NotNull(result.Value);
    }

    [Fact]
    public async void GetAllReturnsList(){
        // * ARRANGE
        var controller = new ProductController(_fixture.Context);

        // * ACT
        var result = await controller.GetAll();

        // * ASSERT
        Assert.IsType<List<Product>>(result.Value);
        Assert.NotEmpty(result.Value);
    }

    // TODO : Write up a test for Purchase()
}