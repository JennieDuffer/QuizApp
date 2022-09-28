
namespace QuizApp.Models
{
    public interface IQuizRepository
    {
        public IEnumerable<Quiz> GetAllQuizInfo();
        public Quiz GetQuizInfo(int id);

        public void UpdateQuizInfo(Quiz quiz);

        public void InsertQuizInfo(Quiz quizInfoToInsert);

        public void DeleteQuizInfo(Quiz quiz);


    }
}
