using System;
using System.Collections.Generic;
using System.Text;

namespace StarWarsAPI
{
    class Starship
    {
        public string name { get; set; }
        public string model { get; set; }
        public string manufacturer { get; set; }
        public string cost_in_credits { get; set; }
        public string length { get; set; }
        public string max_atmosphering_speed { get; set; }
        public string crew { get; set; }
        public string passengers { get; set; }
        public string cargo_capacity { get; set; }
        public string consumables { get; set; }
        public string hyperdrive_rating { get; set; }
        public string MGLT { get; set; }
        public string starship_class { get; set; }
        public List<string> pilots { get; set; }
        public List<string> films { get; set; }
        public DateTime created { get; set; }
        public DateTime edited { get; set; }
        public string url { get; set; }

        //default constructor with no parameters.
        public Starship()
        {
            this.name = "";
            this.model = "";
            this.manufacturer = "";
            this.cost_in_credits = "";
            this.length = "";
            this.max_atmosphering_speed = "";
            this.crew = "";
            this.passengers = "";
            this.cargo_capacity = "";
            this.consumables = "";
            this.hyperdrive_rating = "";
            this.MGLT = "";
            this.starship_class = "";
            this.pilots = new List<string>();
            this.films = new List<string>();
            this.created = new DateTime();
            this.edited = new DateTime();
            this.url = "";
        }

        //constructor withparameters.
        public Starship(string _name, string _model, string _manufacturer, string _cost_in_credits, string _length, string _max_atmosphering_speed, string _crew, string _passengers, string _cargo_capacity, string _consumables, string _hyperdrive_rating, string _MGLT, string _starship_class, List<string> _pilots, List<string> _films, DateTime _created, DateTime _edited, string _url)
        {
            this.name = _name;
            this.model = _model;
            this.manufacturer = _manufacturer;
            this.cost_in_credits = _cost_in_credits;
            this.length = _length;
            this.max_atmosphering_speed = _max_atmosphering_speed;
            this.crew = _crew;
            this.passengers = _passengers;
            this.cargo_capacity = _cargo_capacity;
            this.consumables = _consumables;
            this.hyperdrive_rating = _hyperdrive_rating;
            this.MGLT = _MGLT;
            this.starship_class = _starship_class;
            this.pilots = _pilots;
            this.films = _films;
            this.created = _created;
            this.edited = _edited;
            this.url = _url;
        }
    }
}
