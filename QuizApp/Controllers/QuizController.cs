using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Models;

namespace QuizAppProject.Controllers
{

    public class QuizController : Controller
    {
        private readonly IQuizRepository repo;
        public QuizController(IQuizRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            var quiz = repo.GetAllQuizInfo();
            return View(quiz);
        }
        public IActionResult ViewQuizInfo(int id)
        {
            var quiz = repo.GetQuizInfo(id);
            return View(quiz);
        }
        public IActionResult UpdateQuizInfo(int id)
        {
            Quiz quiz = repo.GetQuizInfo(id);
            if (quiz == null)
            {
                return View("QuizNotFound");
            }
            return View(quiz);
        }

        public IActionResult UpdateQuizInfoToDatabase(Quiz quiz)
        {
            repo.UpdateQuizInfo(quiz);

            return RedirectToAction("ViewQuizInfo", new { id = quiz.QuestionNumber });
        }  

        public IActionResult InsertQuizInfo()
        {
            return View();
        }


        public IActionResult InsertQuizInfoToDatabase(Quiz quizInfoToInsert)
        {
            repo.InsertQuizInfo(quizInfoToInsert);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteQuizInfo(Quiz quiz)
        {
            repo.DeleteQuizInfo(quiz);
            return RedirectToAction("Index");
        }
    }
}