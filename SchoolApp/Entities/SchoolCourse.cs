using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolApp.Entities
{
    public partial class SchoolCourse
    {
        public SchoolCourse()
        {
            SchoolClassesCourses = new HashSet<SchoolClassesCourse>();
        }

        public Guid Id { get; set; }
        public string CourseName { get; set; }

        public virtual ICollection<SchoolClassesCourse> SchoolClassesCourses { get; set; }
    }
}
