using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Windows.Controls;

namespace UnitTest
{
    public class UnitX
    {
        [Fact]
        public void SignInCheckLogin_Test()
        {
            // arrange
            string login = "yayaya";
            bool expected = true;

            // act
            bool res = new Otchetnost.SignUpControl().SignUpCheckLogin(login);

            // assert
            Assert.True(res);
        }

        [Fact]
        public void SignInCheckPassword_Test()
        {
            // arrange
            string password = "123456";
            bool expected = true;

            // act
            bool res = new Otchetnost.SignUpControl().SignInCheckPassword(password);

            // assert
            Assert.Equal(res, expected);
        }

        [Fact]
        public void SignUpCheckLogin_Test()
        {
            // arrange
            string login = "yayaya";
            bool expected = true;

            // act
            bool res = new Otchetnost.SignUpControl().SignUpCheckLogin(login);

            // assert
            Assert.True(res);
        }

        [Fact]
        public void SignUpCheckPassword_Test()
        {
            // arrange
            string password = "123456";
            string passwordConfirn = "123456";
            bool expected = true;

            // act
            bool res = new Otchetnost.SignUpControl().SignUpCheckPassword(password, passwordConfirn);

            // assert
            Assert.Equal(res, expected);
        }

        [Fact]
        public void GetGroups_More_Zero()
        {
            // arrange
            int expected = 0;

            // act
            var res = new Otchetnost.Profile().GetCourses();

            // assert
            Assert.True(res.Count > expected);
        }

        [Fact]
        public void EditTaskVerification_True()
        {
            // arrange
            bool expected = true;

            // act
            var res = new Otchetnost.ControlVerification().EditTaskVerification("fffffffffffff");

            // assert
            Assert.Equal(expected, res);
        }

        [Fact]
        public void AddTaskVerification_True()
        {
            // arrange
            bool expected = true;

            // act
            var res = new Otchetnost.ControlVerification().AddTaskVerification("MyInsaneTask");

            // assert
            Assert.Equal(expected, res);
        }

    }
}
