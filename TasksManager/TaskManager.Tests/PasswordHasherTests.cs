using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TaskManager.ApplicationServices.Components.Authorization;

namespace TaskManager.Tests
{
    [TestClass]
    public class PasswordHasherTests
    {
        public TestContext TestContext { get; set; }
        private const string GoodPassword = "CARPCARPCARPCARPCARPCARPCARP";

        private const string BadPassword = "PIKEPIKEPIKEPIKEPIKEPIKEPIKE";


        [TestMethod]
        [Owner("Wojtek")]
        [Priority(1)]
        public void HashingNotNull()
        {
            //Arrange
            PasswordHasher passwordHasher = new PasswordHasher();

            //Assert
            TestContext.WriteLine("Checking password: " + GoodPassword);
            Assert.IsNotNull(passwordHasher.Hash(GoodPassword));
        }

        [TestMethod]
        [Owner("Wojtek")]
        [Priority(1)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void HashingCheckBadSaltFormat()
        {
            //Arrange
            PasswordHasher passwordHasher = new PasswordHasher();

            //Act

            TestContext.WriteLine("Checking password: " + GoodPassword);
            passwordHasher.HashToCheck(GoodPassword, GoodPassword);
        }

        [TestMethod]
        [Owner("Wojtek")]
        [Priority(2)]
        public void HashingAndCheckHashingIsTrue()
        {
            //Arrange
            PasswordHasher passwordHasher = new PasswordHasher();
            string[] hashedPasswordAndSalt;
            string hashedPassword;

            //Act
            TestContext.WriteLine("Checking password: " + GoodPassword);
            hashedPasswordAndSalt = passwordHasher.Hash(GoodPassword);
            hashedPassword = passwordHasher.HashToCheck(GoodPassword, hashedPasswordAndSalt[1]);

            //Assert

            Assert.AreEqual(hashedPassword, hashedPasswordAndSalt[0]);
        }
        
        [TestMethod]
        [Owner("Wojtek")]
        [Priority(2)]
        public void HashingAndCheckHashingIsFalse()
        {
            //Arrange
            PasswordHasher passwordHasher = new PasswordHasher();
            string[] hashedPasswordAndSalt;
            string hashedPassword;

            //Act
            TestContext.WriteLine("Checking password: " + GoodPassword);
            hashedPasswordAndSalt = passwordHasher.Hash(GoodPassword);
            hashedPassword = passwordHasher.HashToCheck(BadPassword, hashedPasswordAndSalt[1]);

            //Assert

            Assert.AreNotEqual(hashedPassword, hashedPasswordAndSalt[0]);
        }
    }
}
