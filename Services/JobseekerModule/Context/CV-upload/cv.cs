using System.ComponentModel.DataAnnotations;

namespace JobseekerModule.context{
    public class Cv {
        [Key]
        public int id { get;set; }

        [MaxLength(100)]    
        public string name { get;set; }

        [MaxLength(100)]
        public string FileType { get;set; } 
    }
}