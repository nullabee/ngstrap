using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace api.Models
{
    public enum Priority
    {
        Normal, High
    }

    public class Nuance
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        //[JsonProperty("nuance_id")]
        public int NuanceID { get; set; }

        [Required]
        //[JsonProperty("title")]
        public string Title { get; set; }

        [Required]
        //[JsonProperty("descr")]
        public string Description { get; set; }

        [Required]
        //[JsonProperty("user_id")]
        public string UserID { get; set; }

        [Required]
        //[JsonProperty("created_dt")]
        public DateTime CreatedDT { get; set; }

        [Required]
        //[JsonProperty("due_dt")]
        public DateTime DueDT { get; set; }

        [Required]
        //[JsonProperty("priority")]
        public Priority Priority { get; set; }

        //[JsonProperty("platform")]
        public Platform Platform { get; set; }

        [Required] // only for mock seeding
        //[JsonProperty("platform_id")]
        public int PlatformID { get; set; }

    }

}
