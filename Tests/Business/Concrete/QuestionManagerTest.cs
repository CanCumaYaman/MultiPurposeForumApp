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
        private readonly Mock<IQuestionDal> _mockDal;
        private readonly Mock<IGenericRepository<Question>> _mockRepository;
        public QuestionManagerTest()
        {
            _mockDal = new Mock<IQuestionDal>();
            _fixture = new Fixture();
            _service = new QuestionManager(_mockDal.Object);
            _mockRepository = new Mock<IGenericRepository<Question>>();
        }
        [Fact]
        public void Add_WhenQuestionIsValid_ReturnSuccess()
        {
            //Arrange            
            //Act 
            Question question = new Question { Title = "test", Body = _fixture.Create<string>(), Topic = _fixture.Create<string>().Substring(0, 5) };
            _mockRepository.Setup(m => m.Find(p => p.Title == "test")).Returns((Question)null).Verifiable();
            _mockRepository.Setup(m => m.Add(question)).Verifiable();
            _mockDal.Setup(m => m.Find(p=>p.Title == "test")).Returns((Question)null).Verifiable();
            _mockDal.Setup(m => m.Add(new Question())).Verifiable();
            _service.Find(p => p.Title == "test");
            var result = _service.Add(question);
            //Assert
           // result.ShouldBe(new SuccessResult("Your Question successfully posted"));
            result.ShouldBeEquivalentTo(new SuccessResult("Your Question successfully posted"));
            _mockDal.Verify(m => m.Find(p => p.Title == "test"), Times.Once);
            _mockDal.Verify(m => m.Add(question), Times.Once);


        }

    }
}
