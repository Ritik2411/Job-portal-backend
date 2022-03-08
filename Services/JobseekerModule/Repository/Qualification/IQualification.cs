using System.Collections.Generic;
using System.Threading.Tasks;
using JobseekerModule.context;

namespace JobseekerModule.repository{
    public interface IQualification{
        Task AddQualificationAsync(QualificationModel qualificationModel);
        Task<List<Qualification>> GetQualicationByUserId(string id);
        Task UpdateQualificaitonAsync(int id,QualificationModel qualificationModel);
        Task deleteQualificationByIdAsync(int id);
    }
}