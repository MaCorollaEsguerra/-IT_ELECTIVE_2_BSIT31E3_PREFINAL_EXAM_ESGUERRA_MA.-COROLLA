# IT Elective 2 – Prefinal Exam (MVC Answer Sheet)

**Esguerra, Ma. Corolla** &nbsp;|&nbsp; BSIT-3.1E3 &nbsp;|&nbsp; IT Elective 2 – Web System and Technologies

---

## About this project

This is an ASP.NET Core **MVC** application that displays all 20 items of the
IT Elective 2 Prefinal Examination (Multiple Choice) together with the answer
I selected for each one, styled like a shaded exam answer sheet.

- **Model** – `Models/Question.cs` describes one exam item (text, choices, my
  selected answer, the correct answer, and a short explanation).
- **View** – `Views/Exam/Index.cshtml` (the answer sheet grid) and
  `Views/Exam/Details.cshtml` (a per-item breakdown with the explanation).
- **Controller** – `Controllers/ExamController.cs` reads the questions from an
  in-memory repository and passes them to the views.
- **No database.** All 20 items live in code, inside
  `Data/QuestionRepository.cs`.

## Project structure

```
├── Controllers/
│   ├── ExamController.cs      # Index (answer sheet) + Details (single item)
│   └── HomeController.cs
├── Data/
│   └── QuestionRepository.cs  # in-memory list of all 20 questions
├── Models/
│   └── Question.cs
├── Views/
│   ├── Exam/
│   │   ├── Index.cshtml
│   │   └── Details.cshtml
│   ├── Home/
│   │   └── Index.cshtml
│   └── Shared/
│       └── _Layout.cshtml
└── wwwroot/css/site.css       # exam-paper theme
```

## Running locally

```bash
dotnet restore
dotnet run
```

Then open the URL shown in the console and go to **Answer Sheet** in the nav
bar, or straight to `/Exam`.

## Commit history

Each of the 20 exam items was added as its own commit
(`Add Item N - <topic>`), on top of an initial commit that scaffolds the
MVC project (models, controllers, views, styling).
