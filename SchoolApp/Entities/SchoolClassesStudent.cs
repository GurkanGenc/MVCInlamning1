using SchoolApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace SchoolApp.Entities
{
    public partial class SchoolClassesStudent
    {
        //public SchoolClassesStudent()
        //{
        //    SchoolClassesCourses = new HashSet<SchoolClassesCourse>();
        //    SchoolClassesTeachers = new HashSet<AppUser>();
        //}

        [DisplayName("Student")]
        public string StudentId { get; set; }

        [DisplayName("Classes")]
        public Guid SchoolClassId { get; set; }

        [DisplayName("Class")]
        public virtual SchoolClass SchoolClass { get; set; }

        // Somehow it hinders the page to work!! Search!!!
        //public virtual AppUser Student { get; set; } // Gets all the users

        //public HashSet<SchoolClassesCourse> SchoolClassesCourses { get; }
        //public HashSet<AppUser> SchoolClassesTeachers { get; }
    }
}
