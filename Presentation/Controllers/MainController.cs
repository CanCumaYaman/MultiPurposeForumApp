using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class MainController : Controller
    {
        IQuestionService _questionService;
        public MainController(IQuestionService questionService)
        {
            _questionService = questionService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AskQuestion()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AskedQuestion(Question question)
        {
            var addedQuestion = new Question
            {
                 Title=question.Title,
                  Body=question.Body,
                   CreatedDate=DateTime.UtcNow,
                    Topic=question.Topic,
                     UserId=question.UserId
            };
           var result=_questionService.Add(addedQuestion);
            if (result.Success)
            {
                return RedirectToAction("Index", "Home");
            }
            return View("AskQuestion");
        }
    }
}
