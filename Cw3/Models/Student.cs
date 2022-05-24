using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.ComponentModel.DataAnnotations;

namespace Cw3.Models
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class Student
    {

        [JsonProperty("fname")]
        [Required(ErrorMessage = "First name is required")]
        [RegularExpression(@"^\p{L}{1,40}$",
         ErrorMessage = "Characters are not allowed.")]
        public string FirstName { get; set; }
        [JsonProperty("lname")]
        [Required(ErrorMessage = "Last name is required")]
        [RegularExpression(@"^^\p{L}{1,40}$$",
         ErrorMessage = "Characters are not allowed.")]
        public string LastName { get; set; }
        [RegularExpression(@"^[sS][0-9]{5}$",
         ErrorMessage = "IndexNumber format is s00000")]
        [Required(ErrorMessage = "IndexNumber  is required")]
        public string IndexNumber { get; set; }
        [Format("dd/MM/yyyy")]
        [Required(ErrorMessage = "Birth Date is required")]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "Studies is required")]
        public Studies Studies { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Email address is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Mother name is required")]
        [RegularExpression(@"^\p{L}{1,40}$",
         ErrorMessage = "Characters are not allowed.")]
        public string MothersName { get; set; }
        [Required(ErrorMessage = "Father name is required")]
        [RegularExpression(@"^^\p{L}{1,40}$",
         ErrorMessage = "Characters are not allowed.")]
        public string FathersName { get; set; }


        public override string ToString()
        {
            return string.Join(",", FirstName, LastName, IndexNumber, BirthDate, Studies, Email, FathersName, MothersName);
        }
    }

}