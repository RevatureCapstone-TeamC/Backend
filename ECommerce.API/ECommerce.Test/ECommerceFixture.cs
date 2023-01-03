
namespace ECommerce.Test;

public class ECommerceFixture : IDisposable 
{
    public CommerceContext Context { get; set; }

    // * Fixture constructor called every time a test is done
    public ECommerceFixture(){
        var dbcOptions = new DbContextOptionsBuilder<CommerceContext>()
            .UseInMemoryDatabase(databaseName: "ECommerceDB").Options;
        Context = new CommerceContext(dbcOptions);

        // * Seed the DB now
        //User/Auth
        //Products
        //Cart
        //Deal
        //Wishlist

        // * Save the changes now before starting
        Context.SaveChangesAsync();
    }

    public void Dispose()
    {
        Context.Dispose();
    }
}