using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication10Jan20Country.Models
{
    public class Country
    {
            [Key]
            public int CountryID {get;set;}
            [Required]
            [MinLength(4)]
            public string CountryName{get;set;}
    
            [Required]
            [MinLength(4)]
            public string Continent {get; set;}
            [Required]
            [MinLength(4)]

            public string CapitalCityName {get; set;}

            [Required]
            [Length(2,5)]
                    
            public string IsoCode {get; set;}

            [NotMapped]
            public string DisplayNameForFKDropDown { get => $"{CapitalCityName}, {CountryName}"; }


    }
}
