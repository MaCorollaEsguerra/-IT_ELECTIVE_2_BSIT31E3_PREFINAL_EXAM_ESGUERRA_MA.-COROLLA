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
        }

        public IReadOnlyList<Question> GetAll() => _questions.OrderBy(q => q.Number).ToList();

        public Question? GetByNumber(int number) => _questions.FirstOrDefault(q => q.Number == number);

        public int TotalItems => _questions.Count;

        public int TotalCorrect => _questions.Count(q => q.IsCorrect);

        private void Add(Question question) => _questions.Add(question);
    }
}
