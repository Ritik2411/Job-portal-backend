using System.Collections.Generic;
using System.Threading.Tasks;
using JobseekerModule.context;
using JobseekerModule.models;
using Microsoft.AspNetCore.Http;

namespace JobseekerModule.repository{
    public interface ICv{
        Task<bool> AddFileAsync(string user_id,IFormFile file);
        Task<List<CV>> getCVByUserIdAsync(string userid);
        Task<bool> deleteCVByIdAsync(DeleteCvModel deleteCvModel, int id);
    }
}