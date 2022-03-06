using System.Threading.Tasks;
using JobseekerModule.context;
using JobseekerModule.repository;
using Microsoft.AspNetCore.Mvc;

namespace JobseekerModule.controller{
    [ApiController]
    [Route("[action]")]
    public class QualificationController : ControllerBase{
         private readonly IQualification _qualification;
         public QualificationController(IQualification qualification){
             _qualification = qualification;
         }   

         [HttpPost]   
         public async Task<IActionResult> AddQualification([FromBody]QualificationModel qualificationModel){
             await _qualification.AddQualificationAsync(qualificationModel);
             return Ok(true);
         }

         [HttpGet("{id}")]
         public async Task<IActionResult> getQualificaitionByUserId([FromRoute]string id){
             var result = await _qualification.GetQualicationByUserId(id);
             return Ok(result);   
         }

         [HttpPut("{id}")]
         public async Task<IActionResult> updateQualification([FromRoute]int id,[FromBody] QualificationModel qualificationModel){
             await _qualification.UpdateQualificaitonAsync(id,qualificationModel);
             return Ok(true);
         }   
    }
}