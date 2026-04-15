using Microsoft.EntityFrameworkCore;
using JobAPI.Data;
using Microsoft.AspNetCore.Mvc;
namespace JobAPI.Services
{
    public class JobService : IJobService
    {
        public readonly AppDbContext _context;
        public JobService(AppDbContext context) {
            _context = context;
        }
        public IEnumerable<JobListing> GetAllActive()
        {
            var jobs = _context.Set<JobListing>().Where(j => j.IsActive).ToList();
            return jobs;
        }
        public JobListing GetById(int id)
        {
            var job = _context.Set<JobListing>().FirstOrDefault(j => j.Id == id && j.IsActive);
            if (job == null) return null;
            return job;
        }
        public void Create(JobListing job)
        {
            job.Id = 0;
            _context.Set<JobListing>().Add(job);
            _context.SaveChanges();
        }
        public void Update(int id, JobListing job)
        {
            var existingJob = _context.Set<JobListing>().FirstOrDefault(j => j.Id == id && j.IsActive);
            _context.Entry(existingJob).CurrentValues.SetValues(job);
            _context.SaveChanges();
        }
        public void SoftDelete(int id)
        {
            var job = _context.Set<JobListing>().FirstOrDefault(j => j.Id == id && j.IsActive);
            job.IsActive = false;
            _context.SaveChanges();
        }

    }
}