namespace Application.DTO;

public class QuestionDTO
{
    public int Id { get; set; }
    public string Titre { get; set; } = null!;
    public List<ReponseDTO> Reponses { get; set; } = new();
}
