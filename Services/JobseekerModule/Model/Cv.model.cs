using System.ComponentModel.DataAnnotations;

namespace JobseekerModule.models{
    public class CvModel{

        [Required]
        public string filename { get;set; }

        [Required]
        public string filetype { get;set; }
    }
}