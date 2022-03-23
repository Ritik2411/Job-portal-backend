using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobseekerModule.context;
using Microsoft.EntityFrameworkCore;

namespace JobseekerModule.repository{
    public class QualificationRepository : IQualification{
        private readonly QualificationContext _context;
        public QualificationRepository(QualificationContext context){
            _context = context;
        }

        public async Task AddQualificationAsync(QualificationModel qualificationModel){
            var qualification = new Qualification(){
                user_id = qualificationModel.userId,
                qualification = qualificationModel.qualification,
                name = qualificationModel.name,
                university = qualificationModel.university,
                yearOfCompletion = qualificationModel.yearOfCompletion,
                grade = qualificationModel.grade
            };

            _context.qualification.Add(qualification);            
            await _context.SaveChangesAsync();
        }

        public async Task<List<Qualification>> GetQualicationByUserId(string user_id){
            var qualification_data = await _context.qualification.Where(x => x.user_id == user_id).Select(x => new Qualification(){
                id = x.id,
                user_id = x.user_id,
                qualification = x.qualification,
                name = x.name,
                university = x.university,
                yearOfCompletion = x.yearOfCompletion,
                grade = x.grade
            }).ToListAsync();

            return qualification_data;
        } 

        public async Task UpdateQualificaitonAsync(int id,QualificationModel qualificationModel){
            var qualification = await _context.qualification.FindAsync(id);

            if(qualification != null){
                qualification.qualification = qualificationModel.qualification;
                qualification.university = qualificationModel.university;
                qualification.yearOfCompletion = qualificationModel.yearOfCompletion;
                qualification.grade = qualificationModel.grade;

                await _context.SaveChangesAsync();
            }
        }

        public async Task deleteQualificationByIdAsync(int id){
            var qualification = new Qualification(){
                id = id
            };

            _context.qualification.Remove(qualification);
            await _context.SaveChangesAsync();
        }
    }
}