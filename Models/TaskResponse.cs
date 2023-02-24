using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mission08_group3_02.Models
{
    public class TaskResponse
    {
        [Key]
        [Required]
        public int TaskId { get; set; }

        public string Task { get; set; }
        [DataType(DataType.Date)]

        public DateTime? DueDate { get; set; }

        [Required]
        public int Quadrant { get; set; }
        public bool Completed { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
