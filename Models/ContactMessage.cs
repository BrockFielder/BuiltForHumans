namespace BulitForHumans.Models;
using System.ComponentModel.DataAnnotations;

public class ContactMessage
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string senderName { get; set; }
    
    [Required]
    [MaxLength(5000)]
    public string text { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string email { get; set; }
}