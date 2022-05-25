using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Cw4.Models
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class Animal
    {
        [JsonProperty("IdAnimal")]
        public int IdAnimal { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MinLength(5, ErrorMessage = "Name must be longer than 5 letter")]
        [MaxLength(100, ErrorMessage = "Name must be shorter than 101 letter")]
        [JsonProperty("Name")]
        public string Name { get; set; }
        // [Required] - nullable
        //[MinLength(5)]
        //[MaxLength(100)]
        [JsonProperty("Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Category is required")]
        [JsonProperty("Category")]
        public string Category { get; set; }
        [Required(ErrorMessage = "Area is required")]
        [JsonProperty("Area")]
        public string Area { get; set; }

        public override string ToString()
        {
            return string.Join(",", IdAnimal, Name, Description, Category, Area);
        }
    }



}
