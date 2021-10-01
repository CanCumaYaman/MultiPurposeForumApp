using AutoFixture;
using Business.Concrete;
using Core.DataAccess.Abstract;
using Core.DataAccess.Concrete.EntityFramework;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Shouldly;

using Xunit;

namespace Tests.Business.Concrete
{
    public class QuestionManagerTest
    {
        private readonly QuestionManager _service;
        private readonly Fixture _fixture;
        private readonly Mock<IQuestionDal> _mock;
        private readonly Mock<SuccessResult> _mockResult;
        public QuestionManagerTest()
        {
            _mock = new Mock<IQuestionDal>();
            _fixture = new Fixture();
            _service = new QuestionManager(_mock.Object);
        }
        [Fact]
        public void Add_WhenQuestionIsValid_ReturnSuccess()
        {
            //Arrange            
            //Act
            _mock.Setup(m => m.Find(p=>p.Title == "test")).Returns((Question)null).Verifiable();
            _mock.Setup(m => m.Add(new Question())).Verifiable();
            var result = _service.Add(new Question { Title = "test", Topic = _fixture.Create<string>(), Body = _fixture.Create<string>() });
            //Assert
           // result.ShouldBe(new SuccessResult("Your Question successfully posted"));
            result.ShouldBeEquivalentTo(new SuccessResult("Your Question successfully posted"));

            
        }

    }
}
