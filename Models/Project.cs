namespace BulitForHumans.Models;
using System.ComponentModel.DataAnnotations;

public class Project
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Title { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string _description { get; set; }
    
    [Required]
    public DateTime Date { get; set; }
    
   [Required]
   public List<Image> Images {get; set;}
   
   [Required]
   public String ProjectType { get; set; }
    
   [Required]
   public String Location { get; set; }
   
   [Required]
   public List<Tag> Tags { get; set; }
   
   [Required]
   [MaxLength(100)]
   public DateTime StartDate { get; set; }
   
   [Required]
   public Boolean IsFeatured { get; set; }
   
   [Required]
   public String Status {get; set;}
   

}