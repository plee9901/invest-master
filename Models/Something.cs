using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("Somethings")]
    public class Something
    {
        [Key]
        public int Id { get; set; }
        public string SomethingName { get; set; }
    }
}