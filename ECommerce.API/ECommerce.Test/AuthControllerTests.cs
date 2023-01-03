namespace ECommerce.Test;

[Collection("ECommerce Collection")]
public class AuthControllerTest
{
    private readonly CommerceContext _context;
    // ! _output is just for extra logging in the xUnit console
    private readonly ITestOutputHelper _output;

    public AuthControllerTest(CommerceContext context, ITestOutputHelper output){
        this._context = context;
        this._output = output;
    }

    [Fact]
    public async void RegisterReturnsBadRequest(){
        // TODO : IMPLEMENT
        // * ARRANGE

        // * ACT

        // * ASSERT
    }

    [Fact]
    public async void RegisterReturnsOkAndUser(){
        // TODO : IMPLEMENT
        // * ARRANGE

        // * ACT

        // * ASSERT
    }

    [Fact]
    public async void LoginReturnsBadRequest(){
        // TODO : IMPLEMENT
        // * ARRANGE

        // * ACT

        // * ASSERT
    }

    [Fact]
    public async void LoginReturnsUser(){
        // TODO : IMPLEMENT
        // * ARRANGE

        // * ACT

        // * ASSERT
    }

    [Fact]
    public async void LogoutReturnsOk(){
        // TODO : IMPLEMENT
        // * ARRANGE

        // * ACT

        // * ASSERT
    }
}