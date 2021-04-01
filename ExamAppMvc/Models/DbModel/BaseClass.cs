using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamAppMvc.Models.DbModel
{
    public class BaseClass
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

    }
}