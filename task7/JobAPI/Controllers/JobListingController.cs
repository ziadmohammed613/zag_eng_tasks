using Microsoft.AspNetCore.Mvc;
using JobAPI.Data;
using JobAPI.Services;
using JobAPI.Filters;
namespace JobAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobListingController : ControllerBase
    {
        public readonly AppDbContext _context;
        public readonly IJobService _jobService;
        public JobListingController(AppDbContext context, IJobService jobService)
        {
            _context = context;
            _jobService = jobService;
        }
        [HttpGet]
        public ActionResult GetJobListings()
        {
            return Ok(_jobService.GetAllActive());
        }
        [HttpGet("{id}")]
        public ActionResult GetJobListing(int id)
        {
            return Ok(_jobService.GetById(id));
        }
        [HttpPost]
        [Route("")]
        [ValidateJobFilter]
        public ActionResult CreateJobListing(JobListing jobListing)
        {
            _jobService.Create(jobListing);
            return Ok();
        }
        [HttpPut("{id}")]
        [ValidateJobFilter]
        public ActionResult UpdateJobListing(int id , JobListing jobListing)
        {
            _jobService.Update(id, jobListing);
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteJobListing(int id)
        {
            _jobService.SoftDelete(id);
            return Ok();
        }
    }
}