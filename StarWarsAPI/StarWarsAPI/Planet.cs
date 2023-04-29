using System;
using System.Collections.Generic;
using System.Text;

namespace StarWarsAPI
{
    public class Planet
    {
        public string name { get; set; }
        public string rotation_period { get; set; }
        public string orbital_period { get; set; }
        public string diameter { get; set; }
        public string climate { get; set; }
        public string gravity { get; set; }
        public string terrain { get; set; }
        public string surface_water { get; set; }
        public string population { get; set; }
        public List<string> residents { get; set; }
        public List<string> films { get; set; }
        public DateTime created { get; set; }
        public DateTime edited { get; set; }
        public string url { get; set; }

        //default constructor with no parameters.
        public Planet()
        {
            this.name = "";
            this.rotation_period = "";
            this.orbital_period = "";
            this.diameter = "";
            this.climate = "";
            this.gravity = "";
            this.terrain = "";
            this.surface_water = "";
            this.population = "";
            this.residents = new List<string>();
            this.films = new List<string>();
            this.created = new DateTime();
            this.edited = new DateTime();
            this.url = "";
        }

        //constructor with parameters.
        public Planet(string _name, string _rotation_period, string _orbital_period, string _diameter, string _climate, string _gravity, string _terrain, string _surface_water, string _population, List<string> _residents, List<string> _films, DateTime _created, DateTime _edited, string _url)
        {
            this.name = _name;
            this.rotation_period = _rotation_period;
            this.diameter = _diameter;
            this.climate = _climate;
            this.gravity = _gravity;
            this.terrain = _terrain;
            this.surface_water = _surface_water;
            this.population = _population;
            this.residents = _residents;
            this.films = _films;
            this.created = _created;
            this.edited = _edited;
            this.url = _url;
        }
    }
}
