using System.Collections.ObjectModel;
using Application.DTO;
using Application.Repository;
using Models;

namespace Application.Service
{
    public class QuizService
    {
        private readonly QuestionRepository _questionRepo;
        private readonly ReponseRepository _reponseRepo;

        public QuizService(QuestionRepository questionRepo, ReponseRepository reponseRepo)
        {
            _questionRepo = questionRepo;
            _reponseRepo = reponseRepo;
        }

        public QuizService()
        {
        }


        public ObservableCollection<QuestionDTO> GetQuestions()
        {
            var questions = _questionRepo.GetAllQuestionsAsync().GetAwaiter().GetResult();

            return new ObservableCollection<QuestionDTO>(
                questions.Select(q => new QuestionDTO
                {
                    Id = q.Id,
                    Titre = q.Titre,
                    Reponses = q.Reponses.Select(r => new ReponseDTO
                    {
                        Id = r.Id,
                        Text = r.Text,
                        IsCorrect = r.IsCorrect
                    }).ToList()
                })
            );
        }


        public void AddQuestion(QuestionDTO dto)
        {
            var question = new Question
            {
                Titre = dto.Titre,
                Reponses = dto.Reponses.Select(r => new Reponse
                {
                    Text = r.Text,
                    IsCorrect = r.IsCorrect
                }).ToList()
            };

            _questionRepo.AddQuestionAsync(question).Wait();
        }


        public void RemoveQuestion(int id)
        {
            _questionRepo.DeleteQuestionAsync(id).Wait();
        }
    }
}
