using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public enum Priority
    {
        Normal, High
    }

    public class Task
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int TaskID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string UserID { get; set; }

        [Required]
        public DateTime CreatedDT { get; set; }

        [Required]
        public DateTime DueDT { get; set; }

        [Required]
        public Priority Priority { get; set; }
        
        public Platform Platform { get; set; }

        [Required] // only for mock seeding
        public int PlatformID { get; set; }

    }

}
