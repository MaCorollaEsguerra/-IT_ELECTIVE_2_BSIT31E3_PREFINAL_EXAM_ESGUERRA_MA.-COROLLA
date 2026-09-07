import subprocess, textwrap

REPO = "/home/claude/examrepo"
FILE = f"{REPO}/Data/QuestionRepository.cs"

questions = [
    (1, "What is the main problem solved by using a database instead of an in-memory collection?",
     {"A": "It makes C# code shorter", "B": "It prevents the application from restarting",
      "C": "It allows data to persist after the application stops", "D": "It removes the need for MVC"},
     "C", "Relational Data Modeling",
     "In-memory collections disappear when the app stops; a database keeps the data around after that."),
    (2, "Which approach is being used when an existing database is used to generate EF Core entity classes?",
     {"A": "Code-First", "B": "Database-First", "C": "Model-First", "D": "Controller-First"},
     "B", "Relational Data Modeling",
     "Database-First reverse-engineers an existing schema into C# entity classes."),
    (3, "What is the primary purpose of Entity Framework Core?",
     {"A": "To create HTML pages automatically", "B": "To replace the MVC Controller",
      "C": "To map objects in code to relational database data", "D": "To replace the C# compiler"},
     "C", "Relational Data Modeling",
     "EF Core is an ORM: it maps C# objects to rows in a relational database."),
    (4, "Which EF Core component is primarily responsible for communicating with the database?",
     {"A": "DbContext", "B": "DbSetView", "C": "ControllerContext", "D": "RazorContext"},
     "A", "Relational Data Modeling",
     "DbContext manages the connection and change-tracking between entities and the database."),
    (5, "What does the following command primarily do?\n\ndotnet ef dbcontext scaffold \"ConnectionString\" Microsoft.EntityFrameworkCore.SqlServer -o Models",
     {"A": "Deletes the database", "B": "Creates a new MVC project",
      "C": "Generates EF Core models and a DbContext from an existing database", "D": "Starts the MVC application"},
     "C", "Model Binding and Controller Actions",
     "The `dbcontext scaffold` command reverse-engineers an existing database into EF Core model classes."),
    (6, "Where is a database connection string commonly stored in an ASP.NET Core MVC application?",
     {"A": "Program.cs only", "B": "appsettings.json", "C": "Index.cshtml", "D": "Student.cs"},
     "B", "Conceptual Data Architecture",
     "Connection strings live in configuration (appsettings.json), not hard-coded in a view or model."),
    (7, "A Student belongs to exactly one Section, while a Section can contain many students. What type of relationship is this?",
     {"A": "One-to-One", "B": "One-to-Many", "C": "Many-to-Many", "D": "Many-to-One only"},
     "B", "Conceptual Data Architecture: Designing ERDs",
     "One Section has many Students, and each Student has one Section - a classic One-to-Many relationship."),
    (8, "In the following example, what is SectionId?\n\npublic int SectionId { get; set; }\npublic Section Section { get; set; }",
     {"A": "Primary key of Student", "B": "Foreign key referencing Section",
      "C": "Navigation property", "D": "Database connection string"},
     "B", "Conceptual Data Architecture: Designing ERDs",
     "SectionId is the shadow/explicit foreign key that points back to the related Section row."),
    (9, "What is the purpose of a navigation property such as public Section Section { get; set; }?",
     {"A": "It stores the database password", "B": "It represents a relationship to another entity",
      "C": "It creates a new database", "D": "It validates the student's name"},
     "B", "Razor Syntax and Dynamic Rendering",
     "Navigation properties let EF Core traverse from one entity to its related entity in code."),
    (10, "What does .Include() generally allow EF Core to do?",
     {"A": "Delete the Section table", "B": "Load related Section data together with Students",
      "C": "Create a new Student", "D": "Validate Student input"},
     "B", "Razor Syntax and Dynamic Rendering",
     "Include() eagerly loads a related navigation property in the same query."),
    (11, "Why might a ViewModel be used when displaying Student and Section information?",
     {"A": "To replace the database", "B": "To combine or shape the data specifically needed by the view",
      "C": "To automatically create database tables", "D": "To prevent controllers from using LINQ"},
     "B", "Data Normalization & Structural Integrity",
     "A ViewModel tailors/combines entity data into exactly the shape a view needs, nothing more."),
    (12, "Consider this query:\n\nvar students = _context.Students.Include(s => s.Section).ToList();\n\nWhat is the main benefit of Include(s => s.Section)?",
     {"A": "It loads the related Section navigation property", "B": "It creates a Section object manually",
      "C": "It removes the foreign key", "D": "It prevents the query from accessing the database"},
     "A", "Data Normalization & Structural Integrity",
     "Include(s => s.Section) tells EF Core to eager-load each Student's related Section in the same query."),
    (13, "Which type of validation occurs in the browser before a request is sent to the server?",
     {"A": "Database-level validation", "B": "Client-side validation",
      "C": "Server-side validation", "D": "EF Core migration validation"},
     "B", "Data Validation and ModelState",
     "Client-side validation runs in the browser (e.g. via JavaScript) before the form is submitted."),
    (14, "Why is server-side validation still necessary if client-side validation exists?",
     {"A": "Client-side validation can be bypassed", "B": "Client-side validation automatically modifies the database",
      "C": "Server-side validation only works with SQLite", "D": "Client-side validation cannot display messages"},
     "A", "Data Validation and ModelState",
     "Client-side checks can be disabled or bypassed, so the server must re-validate every request."),
    (15, "A school requires every student to have a unique Student Number. Which rule best represents this requirement?",
     {"A": "Student Number should always be nullable", "B": "Student Number should be unique",
      "C": "Student Number should always be the same", "D": "Student Number should contain only spaces"},
     "B", "Data Validation and ModelState",
     "The business rule directly maps to a uniqueness constraint on Student Number."),
    (16, "Which is the best reason for having a database-level unique constraint on StudentNumber?",
     {"A": "It protects data integrity even if application-level validation is bypassed",
      "B": "It makes Razor Views render faster", "C": "It removes the need for a Controller",
      "D": "It automatically creates a ViewModel"},
     "A", "Introduction to SQL",
     "A DB-level constraint is the last line of defense, guaranteeing integrity regardless of app-layer bugs."),
    (17, "What is the purpose of a try...catch block in a controller?",
     {"A": "To create navigation properties", "B": "To catch and handle exceptions that may occur during execution",
      "C": "To generate database tables", "D": "To perform client-side validation"},
     "B", "Introduction to SQL",
     "try...catch lets a controller gracefully handle runtime errors instead of crashing the request."),
    (18, "Which middleware is commonly used in ASP.NET Core for centralized exception handling?",
     {"A": "UseDatabase()", "B": "UseExceptionHandler()", "C": "UseValidationHandler()", "D": "UseMvcDatabase()"},
     "B", "In-Memory Data Storage and CRUD Operations",
     "UseExceptionHandler() routes unhandled exceptions to a single error-handling pipeline/page."),
    (19, "A user requests /Student/999, but Student 999 does not exist. What would be the most appropriate response?",
     {"A": "Display the student's information anyway", "B": "Display a Not Found (404) response/page",
      "C": "Delete Student 999", "D": "Create Student 999 automatically"},
     "B", "In-Memory Data Storage and CRUD Operations",
     "A missing resource should correctly return an HTTP 404 Not Found response."),
    (20, "A student already belongs to Section A for a particular subject. The application attempts to assign the same student to Section A again. What is the primary concern?",
     {"A": "Data integrity", "B": "HTML formatting", "C": "CSS inheritance", "D": "Razor syntax"},
     "A", "In-Memory Data Storage and CRUD Operations",
     "A duplicate assignment risks inconsistent/duplicate records - a data integrity concern."),
]


def cs_string(s: str) -> str:
    return s.replace("\\", "\\\\").replace("\"", "\\\"").replace("\n", "\\n")


def build_add_call(number, text, choices, correct, topic, explanation):
    choice_lines = ",\n".join(
        f'                        ["{k}"] = "{cs_string(v)}"' for k, v in choices.items()
    )
    return textwrap.dedent(f"""\
            Add(new Question
            {{
                Number = {number},
                Text = "{cs_string(text)}",
                Choices = new Dictionary<string, string>
                {{
{choice_lines}
                }},
                SelectedAnswer = "{correct}",
                CorrectAnswer = "{correct}",
                Topic = "{cs_string(topic)}",
                Explanation = "{cs_string(explanation)}"
            }});
            // SEED_MARKER""")


for number, text, choices, correct, topic, explanation in questions:
    with open(FILE, "r") as f:
        content = f.read()

    add_call = build_add_call(number, text, choices, correct, topic, explanation)
    # indent to match constructor body (12 spaces)
    indented = "\n".join(
        ("            " + line if line.strip() else line)
        for line in add_call.splitlines()
    )
    new_content = content.replace("            // SEED_MARKER", indented)

    with open(FILE, "w") as f:
        f.write(new_content)

    short = text.splitlines()[0]
    if len(short) > 60:
        short = short[:57] + "..."
    msg = f"Add Item {number} - {short}"

    subprocess.run(["git", "add", "-A"], cwd=REPO, check=True)
    subprocess.run(["git", "commit", "-q", "-m", msg], cwd=REPO, check=True)

print("done")
