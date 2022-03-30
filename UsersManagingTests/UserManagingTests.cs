using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UserManaging.Model;

namespace UsersManagingTests
{
    [TestClass]
    public class UserManagingTests
    {
        private readonly UsersDAL _db = new UsersDAL();

        [TestMethod]
        public void DB_InsertValidUserData_ReturnsTrue()
        {
            //Arrange
            List<User> users = _db.GetUsers();
            int lastUserId = users.Last().Id;
            User expectedUser = new User
            {
                Id = lastUserId + 1,
                FirstName = "Александр",
                LastName = "Петров",
                MiddleName = "Иванович",
                Phone = "89824952282",
                Email = "twer@gdew.et"
            };
            bool expected = true;

            //Act
            _db.Insert(expectedUser);
            User actualUser = _db.GetUser(lastUserId + 1);
            UserEqualityComparer comparer = new UserEqualityComparer();
            bool actual = comparer.Equals(expectedUser, actualUser);

            //Assert
            Assert.AreEqual(expected, actual);
            _db.Delete(lastUserId + 1);
        }

        [TestMethod]
        public void DB_DeleteLastExistingUser_ReturnsFalse()
        {
            //Arrange
            List<User> users = _db.GetUsers();
            User lastUser = users.Last();
            bool expected = false;

            //Act
            _db.Delete(lastUser.Id);
            bool actual = _db.GetUsers().Last().Id == lastUser.Id;

            //Assert
            Assert.AreEqual(expected, actual);
            _db.Insert(lastUser);
        }

        [TestMethod]
        public void DB_UpdateLastUserWithValidData_ReturnsTrue()
        {
            //Arrange
            List<User> users = _db.GetUsers();
            User lastUser = users.Last();
            User expectedUser = new User
            {
                Id = lastUser.Id,
                FirstName = "Test",
                LastName = lastUser.LastName,
                MiddleName = lastUser.MiddleName,
                Phone = lastUser.Phone,
                Email = lastUser.Email
            };

            bool expected = true;

            //Act
            _db.Update(expectedUser);
            User actualUser = _db.GetUser(lastUser.Id);
            UserEqualityComparer comparer = new UserEqualityComparer();
            bool actual = comparer.Equals(expectedUser, actualUser);

            //Assert
            Assert.AreEqual(expected, actual);
            _db.Update(users.Last());
        }

        [TestMethod]
        public void DB_GetUsersWhichEmailEndsWithYaRu_ReturnsTrue()
        {
            //Arrange
            List<User> users = _db.GetUsers();
            List<User> expected = users.Where(u => u.Email.EndsWith("ya.ru"))
                                       .ToList();

            //Act
            List<User> actual = _db.GetUsersFromQuery(@"SELECT * " +
                                                       "FROM Users " +
                                                       "WHERE SUBSTRING(Email, -5, 5) = 'ya.ru'");

            //Assert
            Assert.IsTrue(expected.SequenceEqual(actual, new UserEqualityComparer()));
        }

        [TestMethod]
        public void DB_GetUsersWhichPhoneStartsWith83_ReturnsTrue()
        {
            //Arrange
            List<User> users = _db.GetUsers();
            List<User> expected = users.Where(u => u.Phone.StartsWith("83"))
                                       .ToList();
            

            //Act
            List<User> actual = _db.GetUsersFromQuery(@"SELECT * " +
                                                       "FROM Users " +
                                                       "WHERE SUBSTRING(Phone, 1, 2) = '83'");

            //Assert
            Assert.IsTrue(expected.SequenceEqual(actual, new UserEqualityComparer()));
        }

        [TestMethod]
        public void DB_GetUsersWhichPhoneStartsWith88_ReturnsTrue()
        {
            //Arrange
            List<User> users = _db.GetUsers();
            List<User> expected = users.Where(u => u.Phone.StartsWith("88"))
                                       .ToList();

            //Act
            List<User> actual = _db.GetUsersFromQuery(@"SELECT * " +
                                                       "FROM Users " +
                                                       "WHERE SUBSTRING(Phone, 1, 2) = '88'");

            //Assert
            Assert.IsTrue(expected.SequenceEqual(actual, new UserEqualityComparer()));
        }
    }
}
