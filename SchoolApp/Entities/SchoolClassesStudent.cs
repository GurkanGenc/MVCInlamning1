using SchoolApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace SchoolApp.Entities
{
    public partial class SchoolClassesStudent
    {
        [DisplayName("Students")]
        public string StudentId { get; set; }

        [DisplayName("Classes")]
        public Guid SchoolClassId { get; set; }

        public virtual SchoolClass SchoolClass { get; set; }

        // Somehow it hinders the page to work!! Search!!!
        //public virtual AppUser Student { get; set; } // Gets all the users
    }
}
