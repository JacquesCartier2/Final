using System;
using System.Collections.Generic;
using System.Text;

namespace StarWarsAPI
{
    class AllSpecies
    {
        public int count { get; set; }
        public string next { get; set; }
        public object previous { get; set; }
        public List<Species> results {get; set;}

        //default constructor with no parameters.
        public AllSpecies()
        {
            this.count = 0;
            this.next = "";
            this.previous = "";
            this.results = new List<Species>();
        }

        //constructor withparameters.
        public AllSpecies(int _count, string _next, string _previous, List<Species> _results)
        {
            this.count = _count;
            this.next = _next;
            this.previous = _previous;
            this.results = _results;
        }
    }
}
