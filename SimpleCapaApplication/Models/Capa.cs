﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SimpleCapaApplication.Models
{
    public class Capa
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("CAPA Name")]
        public string Name { get; set; }

        [DisplayName("UserId")]
        public string ApplicationUserId { get; set; }

        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser Owner { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}