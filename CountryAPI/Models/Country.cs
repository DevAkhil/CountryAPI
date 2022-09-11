using System.ComponentModel.DataAnnotations;

namespace CountryAPI.Models
{
    /// <summary>
    /// Country
    /// </summary>
    public class Country
    {
        /// <summary>
        /// ALPHA-3 code (https://en.wikipedia.org/wiki/ISO_3166-1_alpha-3)
        /// </summary>

        [Required]
        [StringLength(3, ErrorMessage = "Three-digit numeric (ISO 3166-1 numeric) code is required", MinimumLength = 3)]
        public string? Code { get; set; }
        /// <summary>
        /// Country name
        /// </summary>
        [Required]
        [StringLength(60, ErrorMessage = "A Maximum length of 60 characters is allowed")]
        public string? Name { get; set; }
        /// <summary>
        /// Country region (Asia, Africa, North America, South America,Antarctica, Europe, and Australia)
        /// </summary>
        [Required]
        [StringLength(30, ErrorMessage = "A Maximum length of 60 characters is allowed")]
        public string? Region { get; set; }
    }
}
