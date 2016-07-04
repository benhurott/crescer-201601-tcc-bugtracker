using BugTracker.Domain.Entity;
using BugTracker.Domain.Service;
using BugTracker.Interface.Presentation.Test.Mocks;
using Interface.Presentation.Controllers;
using Interface.Presentation.Models.User;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BugTracker.Interface.Presentation.Test.UnitTests
{
    [TestClass]
    public class LoginControllerTest
    {

        private UserRepositoryMock UserRepositoryMock;
        private LoginController LoginController;

        [TestInitialize()]
        public void setController()
        {
            this.UserRepositoryMock = new UserRepositoryMock();
            this.LoginController = new LoginController(new UserService(UserRepositoryMock));
        }
        
        //TODO: nescessario uso da encrpitação
        /*
        [TestMethod]
        public void LoginWithAcountNotConfirmed()
        {
            var userUnconfirmed = new User(3, "User Test 3", "teste@3", "test password", "default", "hash", null, false, false);
            UserRepositoryMock.Add(userUnconfirmed);

            var signInModel = new UserLoginViewModel();
            signInModel.Email = "teste@3";
            signInModel.Password = "test password";

            var viewResult = LoginController.SignIn(signInModel) as ViewResult;
            var errorModel = viewResult.ViewData.ModelState.FirstOrDefault(x => x.Key == "INVALID_USER");
            Assert.AreEqual(errorModel.Value.Errors.First().ErrorMessage, "Please active your account, an e - mail has been sent to your inbox");
        }
        */

        [TestMethod]
        public void LoginWithAcountInexistent()
        {
            var signInModel = new UserLoginViewModel();
            signInModel.Email = "invalidEmail";
            signInModel.Password = "invalidPassword";

            var viewResult = LoginController.SignIn(signInModel) as ViewResult;
            var errorModel = viewResult.ViewData.ModelState.FirstOrDefault(x => x.Key == "INVALID_USER");
            Assert.AreEqual(errorModel.Value.Errors.First().ErrorMessage, "Email or password is invalid");
        }

    }
}
