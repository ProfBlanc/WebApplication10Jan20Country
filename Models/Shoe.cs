using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication10Jan20Country.Models
{
    public class Shoe
    {

        [Key]
        public int ShoeID { get; set; }
        [Required]
        public string ShoeName { get; set; }
        [Required]
        public string ShoeColor { get; set; }

      
        [ForeignKey("Country")]
        public int ShoeOrginCountry { get; set; }


        [ValidateNever]
        public Country Country { get; set; }

    }
}
