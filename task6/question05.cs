// Which implementation will Controller A receive?
// How many services will be injected into Controller B?
// Answer:
// Registration
builder.Services.AddScoped<IEmailService, SmtpEmailService>();
builder.Services.AddScoped<IEmailService, SendGridEmailService>();
builder.Services.AddScoped<IEmailService, MailgunEmailService>();

// Controller A
public class ControllerA
{
    private readonly IEmailService _email;
    public ControllerA(IEmailService email)
    {
        _email = email; // Which one? any implementation of the three classes
    }
}

// Controller B
public class ControllerB
{
    private readonly IEnumerable<IEmailService> _emails;
    public ControllerB(IEnumerable<IEmailService> emails)
    {
        _emails = emails; // How many? 1 , since it's scoped
    }
}