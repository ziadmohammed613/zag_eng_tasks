// What happens when a request is received?
// Answer: controller calls the product service to save it in repository

public interface IRepository
{
    void Save(object data);
}
public class SqlRepository : IRepository
{
    public void Save(object data)
    {
        Console.WriteLine("Saving to SQL Database");
    }
}
public class ProductService
{
    private readonly IRepository _repository;
    // Constructor Injection
    public ProductService(IRepository repository)
    {
        _repository = repository;
    }
    public void AddProduct(string product)
    {
        Console.WriteLine("Adding product: {product}");
        _repository.Save(product);
    }
} //
// in ASP.NET Core Startup / Program.cs
builder.Services.AddScoped<IRepository, SqlRepository>();
builder.Services.AddScoped<ProductService>();
// in Controller
public class ProductController : ControllerBase
{
    private readonly ProductService _productService;
    public ProductController(ProductService productService)
    {
        _productService = productService;
    }
    [HttpPost]
    public IActionResult Add(string name)
    {
        _productService.AddProduct(name);
        return Ok();
    }
}