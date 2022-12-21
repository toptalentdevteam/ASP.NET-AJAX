using System;
using System.Collections.Generic;

namespace GoHireNow.Models
{
    public class JobTitleModel
    {
        public int id { get; set; }
        public string name { get; set; }

        public List<jobTitlesDetails> jobTitles { get; set; }
    }
    public class jobTitlesDetails
    {
        public int id { get; set; }
        public string name { get; set; }
        public string friendlyUrl { get; set; }
    }

}
