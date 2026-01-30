using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace AquaHub.Shared.Models;

public class AppUser : IdentityUser
{
    [Required]
    [Display(Name = "First Name")]
    [StringLength(50, ErrorMessage = "First name must be between 2 and 50 characters.", MinimumLength = 2)]
    public string Firstname { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Last Name")]
    [StringLength(50, ErrorMessage = "Last name must be between 2 and 50 characters.", MinimumLength = 2)]
    public string Lastname { get; set; } = string.Empty;

    [NotMapped]
    public string FullName => $"{Firstname} {Lastname}";

    // Navigation property for tanks
    public ICollection<Tank> Tanks { get; set; } = new List<Tank>();
}
