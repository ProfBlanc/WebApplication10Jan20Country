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

        [Display(Name ="Shoe Name", Order = 1)]
        public string ShoeName { get; set; }
        [Required]
        [Display(Name ="Shoe Color")]
        public string ShoeColor { get; set; }

      
        [ForeignKey("Country")]
        [Display(Name ="City Orgin")]
        public int ShoeOrginCountry { get; set; }




        [ValidateNever]
        public Country Country { get; set; }

        [ValidateNever]
        [NotMapped]
        public IFormFile ShoeImageUpload { get; set; }

        [ValidateNever]
        [Display(Name = "Photo")]
        public string ShoeImage { get; set; }

    }
}
