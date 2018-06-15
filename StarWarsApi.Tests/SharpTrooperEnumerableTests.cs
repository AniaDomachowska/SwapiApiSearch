using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Primitives;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarwarsApi;
using StarwarsApi.Controllers;

namespace StarWars.Tests
{
    [TestClass]
    public class SharpTrooperEnumerableTests
    {
        [TestMethod]
        public void TestingWithoutSearchClause()
        {
            var starWarsProvider = new Moq.Mock<IStarWarsProvider>();
            starWarsProvider.SetupAllProperties();
            var expectedList = new []
            {
                new Person() {Name="Ziutek", SkinColor = "black"}
            }.AsQueryable();
            starWarsProvider.Setup(element => element.GetPeople("Ziu")).Returns(expectedList);

            var httpContextAccessor = new Moq.Mock<IHttpContextAccessor>();
            httpContextAccessor.SetupAllProperties();
            httpContextAccessor.SetupGet(element=>element.HttpContext.Request.Query).Returns(new QueryCollection(
                new Dictionary<string, StringValues>() {{"search", "Ziu"}}));

            var testee = new PeopleController(starWarsProvider.Object, httpContextAccessor.Object);
            var result = testee.Get();

            Assert.AreEqual(result.Count(), expectedList.Count());
        }

        [TestMethod]
        public void TestingWithSearchClause()
        {
        }
    }
}
