using System;
using System.ComponentModel.DataAnnotations;

namespace Cw3.Models
{
    public class Studies
    {
        [Required(ErrorMessage = "First name is required")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
        ErrorMessage = "Characters are not allowed.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "First name is required")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
        ErrorMessage = "Characters are not allowed.")]
        public string Mode { get; set; }

        public Studies(string name, string mode)
        {
            Name = name;
            Mode = mode;
        }
        public override string ToString()
        {
            return String.Join(",", Name, Mode);
        }
    }
}