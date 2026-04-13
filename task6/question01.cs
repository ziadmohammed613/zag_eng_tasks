// إیھ المشاكل في الكود ده؟
// Answer: no dependancy injection
public class OrderService
{
    public void CreateOrder(Order order)
    {
        // Save to database
        var connection = new SqlConnection("connection_string");
        // ... database logic
        // Send email
        var emailSender = new EmailSender();
        emailSender.Send("Order created!");
        // Log
        var logger = new FileLogger();
        logger.Log("Order created");
    }
}
// DONE BETTER
public class OrderService
{
    public void CreateOrder(Order order , EmailSender emailSender , FileLogger logger)
    {
        // Save to database
        var connection = new SqlConnection("connection_string");
        // ... database logic
        // Send email
        emailSender.Send("Order created!");
        // Log
        logger.Log("Order created");
    }
}