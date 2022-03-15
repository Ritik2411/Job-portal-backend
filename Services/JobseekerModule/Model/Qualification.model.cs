using System.ComponentModel.DataAnnotations;

namespace JobseekerModule.context{
    public class QualificationModel{
        public string userId { get;set; }
        [Required]
        public string qualification { get;set; }
        [Required]
        public string name { get;set; }
        [Required]
        public string university { get;set; }
        [Required]
        public string yearOfCompletion { get;set; }
        [Required]
        public string grade { get;set; }
    }
}