namespace QuizApp.Models
{
    public class Quiz
    {
        public Quiz()
        {

        }

        public int QuestionNumber { get; set; }

        public string? Questions { get; set; }

        public string Answers { get; set; }

        public string WrongAnswers { get; set; }

    }
}
