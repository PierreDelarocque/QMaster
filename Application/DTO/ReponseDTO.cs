﻿namespace Application.DTO;

public class ReponseDTO
{
    public int Id { get; set; }
    public string Text { get; set; } = null!;

    public bool IsCorrect { get; set; }
}
