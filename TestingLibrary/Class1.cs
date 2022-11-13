using NUnit;
using NUnit.Framework;
using SWP391_HealthCareProject.DataAccess;
using SWP391_HealthCareProject.Models;
using System.Data;

namespace TestingLibrary
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void testUser()
        {
            var volunteer = VolunteerDAO.GetVolunteerByUserId(1);
            var result = "Bach";
            Assert.AreEqual(volunteer.LastName, result);
        }

    }
}