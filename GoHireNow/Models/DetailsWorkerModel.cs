using System;
using System.Collections.Generic;

namespace GoHireNow.Models
{
    public class DetailsWorkerModel
    {
        public double TotalWorkers { get; set; }

        public string JobDescripton { get; set; }

        public string JobTitle { get; set; }

        public string JobBigTitle { get; set; }

        public string FriendlyUrl { get; set; }

        public Worker[] Workers { get; set; }

        public string seotext { get; set; }

        public string video { get; set; }

    }
    public class RelatedWorkersModel
    {
        public Worker[] Workers { get; set; }
    }

    public class Worker
    {
        public Guid UserId { get; set; }

        public long UserUniqueId { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public long CountryId { get; set; }

        public string CountryName { get; set; }

        public Skill[] Skills { get; set; }

        public string Salary { get; set; }

        public long SalaryTypeId { get; set; }

        public string Availability { get; set; }

        public DateTime LastLoginDate { get; set; }

        public Uri ProfilePicturePath { get; set; }

        public string Education { get; set; }

        public string Experience { get; set; }

        public long Featured { get; set; }

        public double Rating { get; set; }
    }

    public class Skill
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string friendlyUrl { get; set; }

        public double jobTitleId { get; set; }
    }
}
