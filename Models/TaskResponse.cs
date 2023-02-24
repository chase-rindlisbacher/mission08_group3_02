using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mission08_group3_02.Models
{
        /*Will make a TaskResponse table in the database*/
    public class TaskResponse
    {
        /*Validates form inputs and sets them to the database*/
        [Key]
        [Required]
        public int TaskId { get; set; }

        public string Task { get; set; }
        [DataType(DataType.Date)]

        public DateTime? DueDate { get; set; }

        [Required]
        public int Quadrant { get; set; }
        public bool Completed { get; set; }

        /*Will link the Category ID as a Foreign Key from the Category table*/
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
