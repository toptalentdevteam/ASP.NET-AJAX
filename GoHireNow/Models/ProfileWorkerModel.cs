using System;
using System.Collections.Generic;

namespace GoHireNow.Models
{
    public class SocialMediaLinks
    {
        public string facebool { get; set; }
        public string skype { get; set; }
        public string linkedIn { get; set; }
    }

    public class Portfolio
    {
        public int id { get; set; }
        public string fileName { get; set; }
        public string filePath { get; set; }
        public string thumbnail { get; set; }
        public string fileExtension { get; set; }
    }

    public class ProfileWorkerModel
    {
        public string userId { get; set; }
        public int userUniqueId { get; set; }
        public string fullName { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime memberSince { get; set; } = DateTime.Now;
        public string availability { get; set; }
        public string education { get; set; }
        public string experience { get; set; }
        public int featured { get; set; }
        public double rating { get; set; }
        public int countryId { get; set; }
        public string countryName { get; set; }
        public string profilePicturePath { get; set; }
        public string salary { get; set; }
        public DateTime lastLoginTime { get; set; }
        public List<Skill> skills { get; set; }
        public SocialMediaLinks socialMediaLinks { get; set; }
        public List<Portfolio> portfolios { get; set; }
        public bool isFavorite { get; set; }
        public bool enableMessage { get; set; }
    }


}
