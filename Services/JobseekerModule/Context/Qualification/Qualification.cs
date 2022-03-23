using System.ComponentModel.DataAnnotations.Schema;

namespace JobseekerModule.context{
    public class Qualification{
        public int id { get;set; }

        public string qualification { get;set; }
        
        public string name { get;set; }

        public string university { get;set; }

        public string yearOfCompletion { get;set; }
        
        public string grade { get;set; }

        [ForeignKey("jobSeeker")]
        public string user_id { get;set; }
        public JobSeekerDetail jobSeeker { get;set; }
    }
}