using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Platform
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int PlatformID { get; set; }

        [Required]
        public string PlatformName { get; set; }
        
        public ICollection<Nuance> Tasks { get; set; }
    }
}
