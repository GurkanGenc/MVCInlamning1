using SchoolApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;

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

        [DisplayName("Class")]
        public string ClassName { get; set; }

        [DisplayName("Teacher")] // Show "Teacher" instead of TeacherId.
        public string TeacherId { get; set; }

        public virtual AppUser Teacher { get; set; } // Gets all the users

        public virtual ICollection<SchoolClassesCourse> SchoolClassesCourses { get; set; }
        public virtual ICollection<SchoolClassesStudent> SchoolClassesStudents { get; set; }
    }
}
