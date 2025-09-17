

namespace Models;

public class Question
{
    public int Id { get; set; }
    public string Titre { get; set; } = string.Empty;

    public List<Reponse> Reponses { get; set; } = new();


}
