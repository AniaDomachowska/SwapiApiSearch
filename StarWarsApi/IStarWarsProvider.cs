using System.Linq;
using StarwarsApi.Controllers;

namespace StarwarsApi
{
    public interface IStarWarsProvider
    {
        IQueryable<Person> GetPeople(string search);
        Person GetPerson(int id);
    }
}