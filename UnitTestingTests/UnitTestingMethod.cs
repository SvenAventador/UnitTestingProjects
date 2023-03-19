using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Controls;
using UnitTestingApplication;
using UnitTestingApplication.Classes;
using UnitTestingApplication.Models;
using UnitTestingApplication.Pages.UserPage;

namespace UnitTestingTests
{
    [TestClass]
    public class UnitTestingMethod
    {
        [TestMethod]
        public void ValidAuthUserTest()
        {
            using (var db = new UnitTestingDatabaseEntities())
            {

            }
            var actual = Methods.AuthUser("asumilkin67@gmail.com", "123sasasa!");
            var expected = "Success!";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ValidRegistrationTest()
        {
            var expected = "Success!";
            var actual = Methods.RegUser("asumilkin69@gmail.com", "123sasasa!");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InvalidAuthorizationTest()
        {
            var expected = "Failed!";
            var actual = Methods.AuthUser("123.com", "12");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void InvalidRegistrationTest()
        {
            var expected = "Failed!";
            var actual = Methods.RegUser("123.com", "12");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UserAuthorization()
        {
            Methods.AuthUser("asumilkin67@gmail.com", "123sasasa!")
            var actual = Manager.CheckUserRole;
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AdminAuthorization()
        {
            Methods.AuthUser("asumilkin68@gmail.com", "123sasasa!");
            var actual = Manager.CheckUserRole;
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AddGoodTest()
        {
            var good = new Goods
            {
                GoodsName = "IPhone 11 Pro",
                GoodsPrice = 80000,
                GoodsCount = 4,
            };
            var tb = new TextBox();
            tb.Text = ".........";
            var actual = Methods.AddAndEditData(good, tb);
            var expected = "Success!";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetGoodTest()
        {
            var dbGrid = new DataGrid();
            var actual = Methods.GetContextIntoDataGrid(dbGrid);
            var expected = "Failed!";
            Assert.AreEqual(expected, actual);
        }
    }
}
