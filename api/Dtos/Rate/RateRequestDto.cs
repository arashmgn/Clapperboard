using System.ComponentModel.DataAnnotations;
using api.Enums;

namespace api.Dtos;

public class RateRequestDto
{
    [Required(ErrorMessage = "Score is required")]
    [Range(1, 5, ErrorMessage = "Score must be between 1 and 5")]
    public int Score { get; set; }
} 