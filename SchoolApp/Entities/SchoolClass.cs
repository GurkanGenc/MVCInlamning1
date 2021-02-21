using SchoolApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SchoolApp.Entities
{
    public partial class SchoolClass
    {
        public SchoolClass()
        {
            SchoolClassesCourses = new HashSet<SchoolClassesCourse>();
            SchoolClassesStudents = new HashSet<SchoolClassesStudent>();
        }

        public Guid Id { get; set; }

        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 5)]
        [DisplayName("Class")]
        public string ClassName { get; set; }

        [DisplayName("Teacher")] // Show "Teacher" instead of TeacherId.
        public string TeacherId { get; set; }

        public virtual AppUser Teacher { get; set; } // Gets all the users

        public virtual ICollection<SchoolClassesCourse> SchoolClassesCourses { get; set; }
        public virtual ICollection<SchoolClassesStudent> SchoolClassesStudents { get; set; }
    }
}
