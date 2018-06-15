using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SharpTrooper.Entities;
using StarwarsApi.Controllers;

namespace StarwarsApi
{
    public class StarWarsProvider : IStarWarsProvider 
    {
        public IQueryable<Person> GetPeople(string search)
        {
            var sharpTrooperCore = new SharpTrooper.Core.SharpTrooperCore();

            var results = new List<People>();

            SharpEntityResults<People> peopleResults = null;
            var nextPageNo = "";
            while (peopleResults == null || peopleResults.next != null)
            {
                peopleResults = sharpTrooperCore.GetAllPeople(nextPageNo, search);
                nextPageNo = peopleResults.nextPageNo;
                results.AddRange(peopleResults.results);
            }

            return results
                .Select(element=>Mapper.Map<Person>(element))
                .AsQueryable<Person>();
        }

        public Person GetPerson(int id)
        {
            var sharpTrooperCore = new SharpTrooper.Core.SharpTrooperCore();
            var people = sharpTrooperCore.GetPeople(id.ToString());
            return Mapper.Map<Person>(people);
        }
    }
}