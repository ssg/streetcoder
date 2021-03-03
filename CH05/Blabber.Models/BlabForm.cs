using System.ComponentModel.DataAnnotations;

namespace Blabber
{
    public class BlabForm
    {
        public const int MaxContentLength = 300;

        [Required]
        [MaxLength(MaxContentLength)]
        public string Content { get; set; }
    }
}