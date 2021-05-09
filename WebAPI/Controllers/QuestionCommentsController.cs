﻿using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionCommentsController : ControllerBase
    {
        private readonly IQuestionCommentService _questionCommentService;

        public QuestionCommentsController(IQuestionCommentService questionCommentService)
        {
            _questionCommentService = questionCommentService;
        }
        
        [HttpGet("getall")]

        public IActionResult GetQuestionComments()
        {
            var result = _questionCommentService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcommentbyid")]
        public IActionResult GetQuestionCommentsByQuestionId(int questionId)
        {
            var result = _questionCommentService.GetAll(p => p.QuestionId == questionId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]

        public IActionResult Add(QuestionComment questionComment)
        {
            var result = _questionCommentService.Add(questionComment);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }
    }
}
