using System.ComponentModel.DataAnnotations;

namespace JobseekerModule.context{
    public class CV {
        public int id { get;set; }

        [Required]
        [MaxLength(100)]    
        public string name { get;set; }

        [Required]
        [MaxLength(100)]
        public string FileType { get;set; } 
        
        [Required]
        public string user_id { get;set; }

        [Required]
        public long file_size { get;set; }
    }
}