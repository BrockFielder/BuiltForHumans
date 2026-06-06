namespace BulitForHumans.Models;
using System.ComponentModel.DataAnnotations;

public class Person
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
   
    [Required]
    [MaxLength(100)]
    public string Title { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Location { get; set; }
    
    [Required]
    [MaxLength(100)]
    public Boolean ActiveEmployee { get; set; }
    
    [Required]
    [MaxLength(100)]
    public DateTime StartDate { get; set; }
    
    [MaxLength(100)]
    public DateTime? EndDate { get; set; }

    [MaxLength(1000)] 
    public String? Bio { get; set; }
}