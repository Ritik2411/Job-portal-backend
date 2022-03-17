using System.IO;
using System.Threading;
using System.Threading.Tasks;
using JobseekerModule.models;
using JobseekerModule.repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace JobseekerModule.controller{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CvController : ControllerBase{
        private readonly ICv _cv;

        public CvController(ICv cv){
            _cv = cv;
        }

        [HttpPost("{user_id}")]
        public async Task<IActionResult> AddFiles(string user_id, IFormFile files){
            var result  = await _cv.AddFileAsync(user_id, files);
            
            if(result){
                return Ok(true);
            }

            else{
                return BadRequest("File Size Should less than 900 KB and must be a PDF file.");
            }
        }

        [HttpGet("{filename}")]
        public async Task<IActionResult> DownloadFile([FromRoute]string filename){
            var path = Path.Combine(Directory.GetCurrentDirectory()+ "\\Upload\\CVs", filename);
            var provider = new FileExtensionContentTypeProvider();

            if(!provider.TryGetContentType(path, out var contentType)){
                contentType = "application/octet-stream";
            }
            
            var bytes = await System.IO.File.ReadAllBytesAsync(path);
            return File(bytes,contentType, Path.GetFileName(path));
        } 

        [HttpGet("user/{user_id}")]
        public async Task<IActionResult> getCVByUserId([FromRoute]string user_id){
            var result = await _cv.getCVByUserIdAsync(user_id);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteCvId([FromBody]DeleteCvModel deleteCvModel, [FromRoute]int id){
            var result = await _cv.deleteCVByIdAsync(deleteCvModel, id);
            
            if(result){
                return Ok(result);
            }
            else{
                return BadRequest("File does not exists.");
            }
        }
    }
}