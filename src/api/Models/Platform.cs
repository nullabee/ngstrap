using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Platform
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int PlatformID { get; set; }

        [Required]
        public string PlatformName { get; set; }
        
        public ICollection<Task> Tasks { get; set; }
    }
}
