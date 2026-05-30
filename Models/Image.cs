namespace BulitForHumans.Models;
using System.ComponentModel.DataAnnotations;

public class Image
{
    [Key]
    private int Id { get; set; }

    [Required]
    [MaxLength(500)]
    public string FilePath  { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Caption { get; set; }
    
    [Required]
    public bool IsPerson { get; set; }
    
    public int? ProjectId { get; set; }

    public int? PersonId { get; set; }
}