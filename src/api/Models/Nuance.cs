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
        [JsonProperty("id")]
        public int NuanceID { get; set; }

        [Required]
        [JsonProperty("title")]
        public string Title { get; set; }

        [Required]
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("tptId")]
        public string UserId { get; set; }

        [JsonProperty("createdDt")]
        public DateTime CreatedDT { get; set; }

        [JsonProperty("systId")]
        public string SystId { get; set; }

        [JsonProperty("dueDt")]
        public DateTime DueDT { get; set; }

        [JsonProperty("priority")]
        public Priority Priority { get; set; }

        [JsonProperty("details")]
        public string Details { get; set; }

        [JsonProperty("joSize")]
        public int JoSize { get; set; }

        [JsonProperty("joIndex")]
        public int JoIndex { get; set; }

        [JsonProperty("routeItems")]
        public Waypoint[] Waypoints { get; set; }

    }

}
