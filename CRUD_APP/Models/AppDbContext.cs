using Microsoft.EntityFrameworkCore;
namespace CRUD_APP.Models;

public class AppDbContext : DbContext
{ 
    public DbSet<Product> Products { get; set; } // Each DbSet corresponds to a table in the database, and each Product corresponds to a row in the Products table.
    //Note that <Product> here is the Product.cs class that was made. Each Product row will contain the properties defined in that class (ID, Name, Price).
    
    //This is a constructor for the AppDbContext class. DbContextOptions comes from Microsoft.EntityFrameworkCore.
    //The <AppDbContext> in DbContextOptions<AppDbContext> indicates that these options are specific to the AppDbContext class.
    //options is a parameter being passed to the constructor, which contains these configuration settings.
    //This is the constructor used when creating AppDbContext instances. The options parameter is passed in during an instance creation.
    //Note that the AppDbContext or any other DbContext instances are not manually insantiated. They're handled by the Dependency Injection System behind the scenes.
    //Actual use and implementation of this constructor is done in the Program.CS file.
    
    //base(options) line in your DbContext class constructor is used to pass the options (which are of type DbContextOptions<TContext>) to the base class constructor (DbContext), which is part of the Entity Framework Core (EF Core) framework.
    //The EF Core framework is what actually handles database connections and configurations based on these options
    //base:(options) is always used
    //Dependency Injection: When you configure your DbContext in Program.cs, the DbContextOptions are created automatically and passed to your AppDbContext constructor through dependency injection.
    //DbContextOptions is a parameter automatically passed from appDbContext instantiation in the Program.CS file when you use builder.Services.AddDbContext<AppDbContext>.
    // hen you use the :base (options) you're actually creating an instance of DbContext so it can be used in the: public class AppDbContext : DbContext {} (THIS CLASS).
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
}

//Why use Angular brackets? 
//Generics are a feature in C# that allow you to define classes or methods that can operate on any data type while maintaining strong type safety. The angular brackets (< >) define the type that the generic class or method will work with.