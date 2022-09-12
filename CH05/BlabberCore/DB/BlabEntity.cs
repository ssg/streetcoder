using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blabber.DB;

[Table("Blabs")]
public class BlabEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [StringLength(Blab.MaxContentLength)]
    [Required]
    public string Content { get; set; }

    /// <summary>
    /// We store DateTime instead of DateTimeOffset
    /// because SQLite doesn't support it. Instead, we
    /// convert to UTC back & forth to handle different timezones.
    /// </summary>
    [Required]
    public DateTime CreatedOn { get; set; }
}