using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ATMS_TestingSubject.Controllers;
using ATMS_TestingSubject.Models;
using ATMS_TestingSubject;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ATMS_TestingSubject.Classes;

namespace Atm_tests
{
    [TestClass]
    public class UserInfoTest
    {
        [TestMethod]
        public void Login_Test_get()
        {
            var controller = new HomeController();
            var result = controller.Login() as ViewResult;
            Assert.AreEqual("Login", result.ViewName);
        }
        [TestMethod]
        public void Login_Test_post()
        {
            var controller = new HomeController();
            UserLogin user = new UserLogin() {  Type = "Admin", Passward = "123456", Email = "mhmd@yahoo.com"};

            var result = controller.Login(user) as ViewResult;
            Assert.AreEqual("Login", result.ViewName);
        }
        [TestMethod]
        public void AdminDashboard_get()
        {
            var controller = new AdminController();
            var result = controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }
        [TestMethod]
        public void Details_get()
        {
            var controller = new AdminController();
            var result = controller.DetailsMe() as ViewResult;
            Assert.AreEqual("DetailsMe", result.ViewName);
        }
        [TestMethod]
        public void Create_get()
        {

            var controller = new HomeController();
            var result = controller.Register() as ViewResult;
            Assert.AreEqual("Register", result.ViewName);
        }

        [TestMethod]
        public void Create_post()
        {
            ATMS_Model repository = new ATMS_Model();
            var controller = new UserInfoController();
            UserInfo user = new UserInfo();
            repository.SaveChanges();
            List<UserInfo> users = repository.UserInfoes.ToList();
            Assert.IsFalse(users.Contains(user));
            // Assert.AreEqual("Create", result.ViewName);
        }
        [TestMethod]
        public void Edit_get()
        {
            var controller = new AdminController();
            var result = controller.EditMe() as ViewResult;
            Assert.AreEqual("EditMe", result.ViewName);
        }
        [TestMethod]
        public void Edit_post()
        {
            var controller = new AdminController();
            UserInfo user = new UserInfo() { Name = "Mohamed", Type = "Admin", Passward = "123456", Email = "mhmd@yahoo.com", Gender = "Male" };
            var result = controller.EditMe(user) as ViewResult;
                Assert.AreEqual("EditMe", result.ViewName);
        }


    }
}
