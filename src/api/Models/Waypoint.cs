using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace api.Models
{
    public class Waypoint
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        [JsonProperty("id")]
        public int WaypointID { get; set; }

        [Required]
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("departDT")]
        public string DepartDT { get; set; }

        [JsonProperty("arriveDT")]
        public string ArriveDT { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("point")]
        public int Point { get; set; }

        [JsonProperty("blockchain")]
        public int BlockChain { get; set; }


        public int NuanceID { get; set; }

    }
}
