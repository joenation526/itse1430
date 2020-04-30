using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieLibrary.WebApp.Models
{
    public class MovieModel
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }

        public string Description { get; set; }

        [DisplayName("Run Length (in min)")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Run length must be >= 0.")]
        public int RunLength { get; set; }

        [DisplayName("Release Year")]
        [RangeAttribute(1900, Int32.MaxValue, ErrorMessage = "Release year must be >= 1900.")]
        public int ReleaseYear { get; set; }

        [DisplayName("Classic ? ")]
        public bool IsClassic { get; set; }

        public string Genre { get; set; }
    }
}