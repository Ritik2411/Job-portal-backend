using System.ComponentModel.DataAnnotations;

namespace JobseekerModule.models{
    public class DeleteCvModel{
        [Required]
        public string filename { get;set; }
    }
}