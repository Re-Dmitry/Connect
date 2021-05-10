using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest
{
    public class UnitX
    {
        [Fact]
        public void AuthorizationUser_Successfull()
        {
            // arrange
            Otchetnost.UserSettings us = new Otchetnost.UserSettings();
            string json = " { 'login': 'evvvai', 'password': 'gg'}";

            // act
            bool res = new Otchetnost.Authorization().Auh(ref us, json);

            // assert
            Assert.True(res);
        }

        [Fact]
        public void AuthorizationAdmin_Successfull()
        {
            // arrange
            Otchetnost.UserSettings us = new Otchetnost.UserSettings();
            string json = " { 'login': 'evvvai', 'password': 'gg'}";
            var expected = "Admin";

            // act
            new Otchetnost.Authorization().Auh(ref us, json);

            // assert
            Assert.Equal(us.GetType().Name, expected);
        }

        [Fact]
        public void GetGroups_More_Zero()
        {
            // arrange
            int expected = 0;

            // act
            var res = new Otchetnost.Profile().GetCourses();

            // assert
            Assert.True(res.Count>expected);
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
