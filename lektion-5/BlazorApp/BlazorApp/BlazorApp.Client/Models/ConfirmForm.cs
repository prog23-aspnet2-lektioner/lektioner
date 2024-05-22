using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Client.Models;

public class ConfirmForm
{
    public string Email { get; set; } = null!;

    [Display(Name = "Confirmation code", Prompt = "Enter your confirmation code")]
    [Required(ErrorMessage = "Confirmation code is required")]
    public string Code { get; set; } = null!;
}
