using Dapper;
using System.Data;

namespace QuizApp.Models
{
    public class QuizRepository : IQuizRepository
    {
        private readonly IDbConnection _conn;

        public QuizRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        public IEnumerable<Quiz> GetAllQuizInfo()
        {
            return _conn.Query<Quiz>("SELECT * FROM quiz;");
        }
        public Quiz GetQuizInfo(int id)
        {
            return _conn.QuerySingle<Quiz>("SELECT * FROM QUIZ WHERE QuestionNumber = @id", new { id = id });

        }
        public void UpdateQuizInfo(Quiz quiz)
        {
            _conn.Execute("UPDATE quiz SET Questions = @questions, Answers = @answers, WrongAnswers = @wronganswers WHERE QuestionNumber = @id",
            new { questions = quiz.Questions, answers = quiz.Answers, wronganswers = quiz.WrongAnswers, id = quiz.QuestionNumber });
        }

        public void InsertQuizInfo(Quiz quizInfoToInsert)
        {
            _conn.Execute("INSERT INTO quiz ( Questions, Answers, WrongAnswers) VALUES ( @questions, @answers, @wronganswers);",
                new { questions = quizInfoToInsert.Questions, answers = quizInfoToInsert.Answers, wronganswers = quizInfoToInsert.WrongAnswers });
        }

        public void DeleteQuizInfo(Quiz quiz)
        {
            _conn.Execute("DELETE FROM Quiz WHERE QuestionNumber = @id;", new { id = quiz.QuestionNumber });
            
        }
    }
}
