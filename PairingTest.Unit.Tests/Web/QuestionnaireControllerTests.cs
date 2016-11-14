using System.Web.Mvc;
using NUnit.Framework;
using PairingTest.Web.Controllers;
using PairingTest.Web.Models;

namespace PairingTest.Unit.Tests.Web
{
    [TestFixture]
    public class QuestionnaireControllerTests
    {
        [Test]
        public void ShouldGetExpectedQuestionnaire()
        {
            //Arrange
            var questionnaireController = new QuestionnaireController();

            //Act
            var viewResult = questionnaireController.Index() as ViewResult;
            var viewModel = (QuestionnaireViewModel)viewResult.Model;

            //Assert
            Assert.That(viewModel.QuestionnaireTitle, Is.EqualTo("Geography Questions"));
            Assert.That(viewModel.QuestionsText[0], Is.EqualTo("What is the capital of Cuba?"));
            Assert.That(viewModel.QuestionsText[1], Is.EqualTo("What is the capital of France?"));
            Assert.That(viewModel.QuestionsText[2], Is.EqualTo("What is the capital of Poland?"));
            Assert.That(viewModel.QuestionsText[3], Is.EqualTo("What is the capital of Germany?"));
        }
    }
}