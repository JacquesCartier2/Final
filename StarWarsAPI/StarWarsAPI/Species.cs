using System;
using System.Collections.Generic;
using System.Text;

namespace StarWarsAPI
{
    public class Species
    {
        public string name { get; set; }
        public string classification { get; set; }
        public string designation { get; set; }
        public string average_height { get; set; }
        public string skin_colors { get; set; }
        public string hair_colors { get; set; }
        public string eye_colors { get; set; }
        public string average_lifespan { get; set; }
        public string homeworld { get; set; }
        public string language { get; set; }
        public List<string> people { get; set; }
        public List<string> films { get; set; }
        public DateTime created { get; set; }
        public DateTime edited { get; set; }
        public string url { get; set; }

        //default constructor with no parameters
        public Species()
        {
            this.name = "";
            this.classification = "";
            this.designation = "";
            this.average_height = "";
            this.skin_colors = "";
            this.hair_colors = "";
            this.eye_colors = "";
            this.average_lifespan = "";
            this.homeworld = "";
            this.language = "";
            this.people = new List<string>();
            this.films = new List<string>();
            this.created = new DateTime();
            this.edited = new DateTime();
            this.url = "";
        }

        //constructor with parameters
        public Species(string _name, string _classification, string _designation, string _average_height, string _skin_colors, string _hair_colors, string _eye_colors, string _average_lifespan, string _homeworld, string _language, List<string> _people, List<string> _films, DateTime _created, DateTime _edited, string _url)
        {
            this.name = _name;
            this.classification = _classification;
            this.designation = _designation;
            this.average_height = _average_height;
            this.skin_colors = _skin_colors;
            this.hair_colors = _hair_colors;
            this.eye_colors = _eye_colors;
            this.average_lifespan = _average_lifespan;
            this.homeworld = _homeworld;
            this.language = _language;
            this.people = _people;
            this.films = _films;
            this.created = _created;
            this.edited = _edited;
            this.url = _url;
        }
    }
}
