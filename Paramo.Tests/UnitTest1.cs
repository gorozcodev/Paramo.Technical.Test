using Newtonsoft.Json.Linq;
using Paramo.Api.Controllers;
using System;
using System.Net;
using System.Numerics;
using System.Security.Policy;
using System.Xml.Linq;
using Xunit;

namespace Paramo.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var userController = new UsersController();

            var result = userController.CreateUser("Mike", "mike@gmail.com", "Av. Juan G", "+349 1122354215", "Normal", "124");


            Assert.Equal(true, result.IsSuccess);
            Assert.Equal("User Created", result.Errors);
        }

        [Fact]
        public void Test2()
        {
            var userController = new UsersController();

            var result = userController.CreateUser("Agustina", "Agustina@gmail.com", "Av. Juan G", "+349 1122354215", "Normal", "124");


            Assert.Equal(false, result.IsSuccess);
            Assert.Equal("The user is duplicated", result.Errors);
        }

        [Fact]
        public void TestFactoryNormal()
        {
            //Arrange
            var name = "Agustina";
            var email = "Agustina@gmail.com";
            var address = "Av. Juan G";
            var phone = "+349 1122354215";
            var userType = "Normal";
            var money = "124";
            Normal obj = new Normal();

            //Act
            IUser user = UserFactory.getUser(name, email, address, phone, userType, money);

            //Assert
            Assert.IsType<Normal>(obj);
        }

        [Fact]
        public void TestFactoryPremium()
        {
            //Arrange
            var name = "Agustina";
            var email = "Agustina@gmail.com";
            var address = "Av. Juan G";
            var phone = "+349 1122354215";
            var userType = "Premium";
            var money = "124";
            Premium obj = new Premium();

            //Act
            IUser user = UserFactory.getUser(name, email, address, phone, userType, money);

            //Assert
            Assert.IsType<Premium>(obj);
        }

        [Fact]
        public void TestFactorySuperUser()
        {
            //Arrange
            var name = "Agustina";
            var email = "Agustina@gmail.com";
            var address = "Av. Juan G";
            var phone = "+349 1122354215";
            var userType = "SuperUser";
            var money = "124";
            SuperUser obj = new SuperUser();

            //Act
            IUser user = UserFactory.getUser(name, email, address, phone, userType, money);

            //Assert
            Assert.IsType<SuperUser>(obj);
        }

        [Fact]
        public void TestNormalMoneyGreaterthan100()
        {
            //Arrange
            var name = "Agustina";
            var email = "Agustina@gmail.com";
            var address = "Av. Juan G";
            var phone = "+349 1122354215";
            var userType = "Normal";
            var money = "124";

            var value = Convert.ToDecimal("124");
            var percentage = Convert.ToDecimal(0.12);
            var gif = value * percentage;
            var moneyResult = value + gif;

            //Act
            IUser user = UserFactory.getUser(name, email, address, phone, userType, money);

            //Assert
            Assert.Equal(user.Money, moneyResult);
        }


        [Fact]
        public void TestNormalMoneyEquals100()
        {
            //Arrange
            var name = "Agustina";
            var email = "Agustina@gmail.com";
            var address = "Av. Juan G";
            var phone = "+349 1122354215";
            var userType = "Normal";
            var money = "100";

            var moneyResult = 100;

            //Act
            IUser user = UserFactory.getUser(name, email, address, phone, userType, money);

            //Assert
            Assert.Equal(user.Money, moneyResult);
        }

        [Fact]
        public void TestNormalMoneyLess100()
        {
            //Arrange
            var name = "Agustina";
            var email = "Agustina@gmail.com";
            var address = "Av. Juan G";
            var phone = "+349 1122354215";
            var userType = "Normal";
            var money = "50";

            var value = Convert.ToDecimal("50");
            var percentage = Convert.ToDecimal(0.8);
            var gif = value * percentage;
            var moneyResult = value + gif;

            //Act
            IUser user = UserFactory.getUser(name, email, address, phone, userType, money);

            //Assert
            Assert.Equal(user.Money, moneyResult);
        }

        [Fact]
        public void TestNormalMoneyLess10()
        {
            //Arrange
            var name = "Agustina";
            var email = "Agustina@gmail.com";
            var address = "Av. Juan G";
            var phone = "+349 1122354215";
            var userType = "Normal";
            var money = "8";

            var moneyResult = 8;

            //Act
            IUser user = UserFactory.getUser(name, email, address, phone, userType, money);

            //Assert
            Assert.Equal(user.Money, moneyResult);
        }

    }
}
