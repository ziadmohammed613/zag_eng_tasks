using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
namespace JobAPI.Filters
{
    public class ValidateJobFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionArguments.TryGetValue("jobListing", out var model))
            {
                bool isValid = CheckData((JobListing)model);
                if (!isValid)
                {
                    context.Result = new BadRequestObjectResult("Invalid job data. Title, Company cannot be empty and Salary must be greater than 0.");
                }
            }
        }
        private bool CheckData(JobListing job)
        {
            if (string.IsNullOrEmpty(job.Title) || string.IsNullOrEmpty(job.Company) || job.Salary <= 0)
                return false;
            return true;
        }
    }
}