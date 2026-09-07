namespace ExamMvc.Models
{
    /// <summary>
    /// Represents a single multiple-choice item from the
    /// IT Elective 2 (Web System and Technologies) Prefinal Exam,
    /// together with the answer that was chosen for it.
    /// This is a plain in-memory model - no database is involved.
    /// </summary>
    public class Question
    {
        public int Number { get; set; }
        public string Text { get; set; } = string.Empty;

        // Key = choice letter (A, B, C, D), Value = choice text
        public Dictionary<string, string> Choices { get; set; } = new();

        public string SelectedAnswer { get; set; } = string.Empty;
        public string CorrectAnswer { get; set; } = string.Empty;
        public string Explanation { get; set; } = string.Empty;
        public string Topic { get; set; } = string.Empty;

        public bool IsCorrect => SelectedAnswer == CorrectAnswer;
    }
}
