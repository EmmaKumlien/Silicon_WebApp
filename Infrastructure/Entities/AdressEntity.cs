﻿using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

public class AdressEntity
{
    [Key]
    public int Id { get; set; }
    public string AdressLine_1 { get; set; } = null!;
    public string? AdressLine_2 { get; set; } 
    public string Postalcode { get; set; } = null!;
    public string City { get; set; } = null!;
}
