using System.ComponentModel.DataAnnotations.Schema;

namespace JobseekerModule.context{
    //Column for Qualification table
    public class Qualification{
        public int id { get;set; }

        public string qualification { get;set; }
        
        public string name { get;set; }

        public string university { get;set; }

        public string yearOfCompletion { get;set; }
        
        public string grade { get;set; }

        [ForeignKey("jobSeeker")]
        //Foreign key column from jobseeker detail table
        public string user_id { get;set; }

        //Foreign attribute from jobseeker detail table
        public JobSeekerDetail jobSeeker { get;set; }
    }
}