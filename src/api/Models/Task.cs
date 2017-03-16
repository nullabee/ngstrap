using System;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public enum Priority
    {
        Normal, High
    }

    public class Task
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public DateTime CreatedDT { get; set; }

        [Required]
        public DateTime DueDT { get; set; }

        [Required]
        public Priority Priority { get; set; }

        [Required]
        public string SystId { get; set; }
        
    }

}
