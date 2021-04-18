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
        IQuestionCommentService _questionCommentService;
        public MainController(IQuestionService questionService, IQuestionCommentService questionCommentService)
        {
            _questionService = questionService;
            _questionCommentService = questionCommentService;
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
        [HttpPost]
        public IActionResult AddComment(QuestionComment questionComment )
        {
            var addedQuestionComment = new QuestionComment
            {
                Comment = questionComment.Comment,
                 UserId=questionComment.UserId,
                 QuestionId=questionComment.QuestionId,
                  CreatedDate=DateTime.UtcNow,
                 
                 
            };
            var result = _questionCommentService.Add(addedQuestionComment);
            if (result.Success)
            {
                return RedirectToAction("Index", "Home");
            }
            return View("AskQuestion");
        }
    }
}
