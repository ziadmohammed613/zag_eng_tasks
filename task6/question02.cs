// What's the difference between A and B? Which one is better?
// Answer:
// A -> emailService created inside Class
// B -> emailService is passed to Class (DI)
// B is better and cleaner


// Scenario A
public class UserService
{
    private EmailService _emailService = new EmailService();
    public void RegisterUser(User user)
    {
        // Save user...
        _emailService.SendWelcomeEmail(user.Email);
    }
}


// Scenario B
public class UserService
{
    private readonly IEmailService _emailService;
    public UserService(IEmailService emailService)
    {
        _emailService = emailService;
    }
    public void RegisterUser(User user)
    {
        // Save user...
        _emailService.SendWelcomeEmail(user.Email);
    }
}