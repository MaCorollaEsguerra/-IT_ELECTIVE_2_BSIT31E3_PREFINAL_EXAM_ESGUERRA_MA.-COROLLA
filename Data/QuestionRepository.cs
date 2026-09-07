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
            Add(new Question
            {
                Number = 4,
                Text = "Which EF Core component is primarily responsible for communicating with the database?",
                Choices = new Dictionary<string, string>
                {
                        ["A"] = "DbContext",
                        ["B"] = "DbSetView",
                        ["C"] = "ControllerContext",
                        ["D"] = "RazorContext"
                },
                SelectedAnswer = "A",
                CorrectAnswer = "A",
                Topic = "Relational Data Modeling",
                Explanation = "DbContext manages the connection and change-tracking between entities and the database."
            });
            Add(new Question
            {
                Number = 5,
                Text = "What does the following command primarily do?\n\ndotnet ef dbcontext scaffold \"ConnectionString\" Microsoft.EntityFrameworkCore.SqlServer -o Models",
                Choices = new Dictionary<string, string>
                {
                        ["A"] = "Deletes the database",
                        ["B"] = "Creates a new MVC project",
                        ["C"] = "Generates EF Core models and a DbContext from an existing database",
                        ["D"] = "Starts the MVC application"
                },
                SelectedAnswer = "C",
                CorrectAnswer = "C",
                Topic = "Model Binding and Controller Actions",
                Explanation = "The `dbcontext scaffold` command reverse-engineers an existing database into EF Core model classes."
            });
            Add(new Question
            {
                Number = 6,
                Text = "Where is a database connection string commonly stored in an ASP.NET Core MVC application?",
                Choices = new Dictionary<string, string>
                {
                        ["A"] = "Program.cs only",
                        ["B"] = "appsettings.json",
                        ["C"] = "Index.cshtml",
                        ["D"] = "Student.cs"
                },
                SelectedAnswer = "B",
                CorrectAnswer = "B",
                Topic = "Conceptual Data Architecture",
                Explanation = "Connection strings live in configuration (appsettings.json), not hard-coded in a view or model."
            });
            Add(new Question
            {
                Number = 7,
                Text = "A Student belongs to exactly one Section, while a Section can contain many students. What type of relationship is this?",
                Choices = new Dictionary<string, string>
                {
                        ["A"] = "One-to-One",
                        ["B"] = "One-to-Many",
                        ["C"] = "Many-to-Many",
                        ["D"] = "Many-to-One only"
                },
                SelectedAnswer = "B",
                CorrectAnswer = "B",
                Topic = "Conceptual Data Architecture: Designing ERDs",
                Explanation = "One Section has many Students, and each Student has one Section - a classic One-to-Many relationship."
            });
            Add(new Question
            {
                Number = 8,
                Text = "In the following example, what is SectionId?\n\npublic int SectionId { get; set; }\npublic Section Section { get; set; }",
                Choices = new Dictionary<string, string>
                {
                        ["A"] = "Primary key of Student",
                        ["B"] = "Foreign key referencing Section",
                        ["C"] = "Navigation property",
                        ["D"] = "Database connection string"
                },
                SelectedAnswer = "B",
                CorrectAnswer = "B",
                Topic = "Conceptual Data Architecture: Designing ERDs",
                Explanation = "SectionId is the shadow/explicit foreign key that points back to the related Section row."
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
