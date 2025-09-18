using System.Collections.ObjectModel;
using System.Windows.Input;
using Application.DTO;
using Application.Service;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace QMaster.ViewModels;

public sealed partial class MainWindowViewModel : ObservableObject
{
    private readonly QuizService quizService;

    public ICommand NewCommand { get; set; }
    public ICommand DeleteCommand { get; set; }

    public ObservableCollection<QuestionDTO> Questions { get; set; }

    [ObservableProperty]
    private QuestionDTO? selectedQuestion;

    public MainWindowViewModel()
    {
        this.quizService = new QuizService();


        this.Questions = this.quizService.GetQuestions();

        this.NewCommand = new RelayCommand(NewQuestion);
        this.DeleteCommand = new RelayCommand<QuestionDTO>(DeleteQuestion);
    }

    private void NewQuestion()
    {
        var newQuestion = new QuestionDTO
        {
            Titre = "Quelle est la capitale de la France ?",
            Reponses = new List<ReponseDTO>
            {
                new ReponseDTO { Text = "Paris", IsCorrect = true },
                new ReponseDTO { Text = "Lyon", IsCorrect = false },
                new ReponseDTO { Text = "Marseille", IsCorrect = false },
                                new ReponseDTO { Text = "Toulouse", IsCorrect = false }
            }
        };

        this.quizService.AddQuestion(newQuestion);
        this.Questions.Add(newQuestion);
    }

    private void DeleteQuestion(QuestionDTO? question)
    {
        if (question == null) return;

        this.quizService.RemoveQuestion(question.Id);
        this.Questions.Remove(question);
    }
}
