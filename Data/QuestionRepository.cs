using ExamMvc.Models;

namespace ExamMvc.Data
{
    /// <summary>
    /// In-memory "data source" for the exam questions and answers.
    /// Deliberately NOT a database - just a static list built up in code,
    /// per the exam requirements (no database needed).
    /// Questions are appended here one at a time, item by item.
    /// </summary>
    public class QuestionRepository
    {
        private readonly List<Question> _questions = new();

        public QuestionRepository()
        {
            // Items are seeded below, one per exam number.
            Add(new Question
            {
                Number = 1,
                Text = "What is the main problem solved by using a database instead of an in-memory collection?",
                Choices = new Dictionary<string, string>
                {
                        ["A"] = "It makes C# code shorter",
                        ["B"] = "It prevents the application from restarting",
                        ["C"] = "It allows data to persist after the application stops",
                        ["D"] = "It removes the need for MVC"
                },
                SelectedAnswer = "C",
                CorrectAnswer = "C",
                Topic = "Relational Data Modeling",
                Explanation = "In-memory collections disappear when the app stops; a database keeps the data around after that."
            });
            // SEED_MARKER
        }

        public IReadOnlyList<Question> GetAll() => _questions.OrderBy(q => q.Number).ToList();

        public Question? GetByNumber(int number) => _questions.FirstOrDefault(q => q.Number == number);

        public int TotalItems => _questions.Count;

        public int TotalCorrect => _questions.Count(q => q.IsCorrect);

        private void Add(Question question) => _questions.Add(question);
    }
}
