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
            Add(new Question
            {
                Number = 2,
                Text = "Which approach is being used when an existing database is used to generate EF Core entity classes?",
                Choices = new Dictionary<string, string>
                {
                        ["A"] = "Code-First",
                        ["B"] = "Database-First",
                        ["C"] = "Model-First",
                        ["D"] = "Controller-First"
                },
                SelectedAnswer = "B",
                CorrectAnswer = "B",
                Topic = "Relational Data Modeling",
                Explanation = "Database-First reverse-engineers an existing schema into C# entity classes."
            });
            Add(new Question
            {
                Number = 3,
                Text = "What is the primary purpose of Entity Framework Core?",
                Choices = new Dictionary<string, string>
                {
                        ["A"] = "To create HTML pages automatically",
                        ["B"] = "To replace the MVC Controller",
                        ["C"] = "To map objects in code to relational database data",
                        ["D"] = "To replace the C# compiler"
                },
                SelectedAnswer = "C",
                CorrectAnswer = "C",
                Topic = "Relational Data Modeling",
                Explanation = "EF Core is an ORM: it maps C# objects to rows in a relational database."
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
