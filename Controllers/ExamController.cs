using ExamMvc.Data;
using Microsoft.AspNetCore.Mvc;

namespace ExamMvc.Controllers
{
    public class ExamController : Controller
    {
        private readonly QuestionRepository _repository;

        public ExamController(QuestionRepository repository)
        {
            _repository = repository;
        }

        // GET: /Exam  -> full answer sheet
        public IActionResult Index()
        {
            var questions = _repository.GetAll();
            ViewBag.TotalItems = _repository.TotalItems;
            ViewBag.TotalCorrect = _repository.TotalCorrect;
            return View(questions);
        }

        // GET: /Exam/Details/5 -> single item, its choices and the answer
        public IActionResult Details(int id)
        {
            var question = _repository.GetByNumber(id);
            if (question == null)
            {
                return NotFound();
            }
            return View(question);
        }
    }
}
