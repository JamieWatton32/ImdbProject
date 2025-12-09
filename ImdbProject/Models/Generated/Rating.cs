
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImdbProject.Models;

public partial class Rating
{
    [Key]
    [Column("titleID")]
    [StringLength(10)]
    [Unicode(false)]
    public string TitleId { get; set; } = null!;

    [Column("averageRating", TypeName = "numeric(4, 2)")]
    public decimal? AverageRating { get; set; }

    [Column("numVotes")]
    public int? NumVotes { get; set; }

    [ForeignKey("TitleId")]
    [InverseProperty("Rating")]
    public virtual Title Title { get; set; } = null!;
}
