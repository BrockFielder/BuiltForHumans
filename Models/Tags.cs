using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulitForHumans.Models;

public class Tags
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string name { get; set; }
}