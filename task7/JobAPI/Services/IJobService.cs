using Microsoft.EntityFrameworkCore;
using JobAPI.Data;
using Microsoft.AspNetCore.Mvc;
namespace JobAPI.Services
{
    public interface IJobService
    {
        IEnumerable<JobListing> GetAllActive();
        JobListing GetById(int id);
        void Create(JobListing job);
        void Update(int id, JobListing job);
        void SoftDelete(int id);
    }
}