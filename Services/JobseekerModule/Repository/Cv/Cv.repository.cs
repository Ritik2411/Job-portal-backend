using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using JobseekerModule.context;
using JobseekerModule.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;

namespace JobseekerModule.repository{
    public class CvRepository : ICv{
        private readonly CvContext _cv;

        public CvRepository(CvContext cv){
            _cv = cv;
        }

        public async Task<bool> AddFileAsync(string user_id,IFormFile file){
            string fileName = "";

            if(file.Length < 900000 && file.ContentType == "application/pdf"){
                try{
                    var extension = "." + file.FileName.Split(".")[file.FileName.Split(".").Length - 1];
                    fileName = file.FileName.Split(".")[0] + '-' +DateTime.Now.Ticks + extension;

                    var pathBuilt = Path.Combine(Directory.GetCurrentDirectory() + "\\Upload\\CVs");
                    if(!Directory.Exists(pathBuilt)){
                        Directory.CreateDirectory(pathBuilt);
                    }
                    var path = Path.Combine(Directory.GetCurrentDirectory() + "\\Upload\\CVs", fileName);

                    using(var stream = new FileStream(path, FileMode.Create)){
                        await file.CopyToAsync(stream);
                        
                    };

                    var cvData = new CV(){
                        user_id = user_id,
                        name = fileName,
                        FileType = file.ContentType,
                        file_size = file.Length
                    };

                    _cv.cv.Add(cvData);
                    await _cv.SaveChangesAsync();
                    return true;
                }

                catch(Exception e){
                    
                }
            }

            return false;
        }

        public async Task<List<CV>> getCVByUserIdAsync(string userid){
            var result = await _cv.cv.Where(x => x.user_id == userid).Select(x => new CV(){
                id = x.id,
                user_id =x.user_id,
                FileType = x.FileType,
                name = x.name,
                file_size = x.file_size
            }).ToListAsync();

            return result;
        }

        public async Task<bool> deleteCVByIdAsync(DeleteCvModel deleteCvModel, int id){
            var data = new CV(){
                id = id
            };

            string path = Directory.GetCurrentDirectory() + "\\Upload\\CVs\\" + deleteCvModel.filename;
            if(File.Exists(path)){
                File.Delete(path);
                _cv.cv.Remove(data);
                await _cv.SaveChangesAsync();                   
                return true;
            }

            return false;
        }
    }
}