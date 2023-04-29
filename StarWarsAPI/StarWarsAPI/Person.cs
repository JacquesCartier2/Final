using System;
using System.Collections.Generic;
using System.Text;

namespace StarWarsAPI
{
    public class Person
    {
        public string name { get; set; }
        public string height { get; set; }
        public string mass { get; set; }
        public string hair_color { get; set; }
        public string skin_color { get; set; }
        public string eye_color { get; set; }
        public string birth_year { get; set; }
        public string gender { get; set; }
        public string homeworld { get; set; }
        public List<string> films { get; set; }
        public List<object> species { get; set; }
        public List<string> vehicles { get; set; }
        public List<string> starships { get; set; }
        public DateTime created { get; set; }
        public DateTime edited { get; set; }
        public string url { get; set; }

        //default constructor with no parameters.
        public Person()
        {
            this.name = "";
            this.height = "";
            this.mass = "";
            this.hair_color = "";
            this.skin_color = "";
            this.eye_color = "";
            this.birth_year = "";
            this.gender = "";
            this.homeworld = "";
            this.films = new List<string>();
            this.species = new List<object>();
            this.vehicles = new List<string>();
            this.starships = new List<string>();
            this.created = new DateTime();
            this.edited = new DateTime();
            this.url = "";

        }

        //constructor withparameters.
        public Person(string _name, string _height, string _mass, string _hair_color, string _skin_color, string _eye_color, string _birth_year, string _gender, string _homeworld, List<string> _films, List<object> _species, List<string> _vehicles, List<string> _starships, DateTime _created, DateTime _edited, string _url)
        {
            this.name = _name;
            this.height = _height;
            this.mass = _mass;
            this.hair_color = _hair_color;
            this.skin_color = _skin_color;
            this.eye_color = _eye_color;
            this.birth_year = _birth_year;
            this.gender = _gender;
            this.homeworld = _homeworld;
            this.films = _films;
            this.species = _species;
            this.vehicles = _vehicles;
            this.starships = _starships;
            this.created = _created;
            this.edited = _edited;
            this.url = _url;
        }
    }
}
