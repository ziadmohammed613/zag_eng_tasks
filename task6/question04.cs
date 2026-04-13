// What is the output for each registration?
// Answer:
// Registration A
// OUTPUT : instance created for each service in the request
builder.Services.AddTransient<IEmailService, EmailService>();
// Registration B
// OUTPUT : only one instance for each service depends on the EmailService
builder.Services.AddScoped<IEmailService, EmailService>();
// Registration C
// OUTPUT : only one instance for each application
builder.Services.AddSingleton<IEmailService, EmailService>();
// Controller
public class HomeController : ControllerBase
{
    private readonly IEmailService _email1;
    private readonly IEmailService _email2;
    public HomeController( IEmailService email1, IEmailService email2)
    {
        _email1 = email1;
        _email2 = email2;
    }
    [HttpGet]
    public IActionResult Test()
    {
        var same = Object.ReferenceEquals(_email1, _email2);
        return Ok(new { AreSameInstance = same });
    }
}