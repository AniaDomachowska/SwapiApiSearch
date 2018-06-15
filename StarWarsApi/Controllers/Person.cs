using System.ComponentModel.DataAnnotations;

namespace StarwarsApi.Controllers
{
    /// <summary>
    /// A person within the Star Wars universe
    /// </summary>
    public class Person
    {
        /// <summary>
        /// The Gender of this person (if known).
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// The Height of this person in meters.
        /// </summary>
        public string Height { get; set; }

        /// <summary>
        /// The hair color of this person.
        /// </summary>
        public string hair_color { get; set; }

        /// <summary>
        /// The skin color of this person.
        /// </summary>
        public string SkinColor { get; set; }

        /// <summary>
        /// The Name of this person.
        /// </summary>
        [Key]
        public string Name { get; set; }

        /// <summary>
        /// The birth year of this person. BBY (Before the Battle of Yavin) or ABY (After the Battle of Yavin).
        /// </summary>
        public string birth_year { get; set; }

        /// <summary>
        /// The url of the planet resource that this person was born on.
        /// </summary>
        public string homeworld { get; set; }

        /// <summary>
        /// The eye color of this person.
        /// </summary>
        public string eye_color { get; set; }

        /// <summary>
        /// The mass of this person in kilograms.
        /// </summary>
        public string mass { get; set; }
    }
}