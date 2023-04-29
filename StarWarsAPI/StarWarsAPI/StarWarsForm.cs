using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StarWarsAPI
{
    public partial class StarWarsForm : Form
    {
        //used to keep track of what still needs to be done to make the scene.
        string sceneStatus = "start";
        SceneHelper.Protagonist protagonist;
        SceneHelper.Antagonist antagonist;

        public StarWarsForm()
        {
            InitializeComponent();
        }

        //get a planet based on the entered value and show it's information. 
        private async void btn_Planet_Click(object sender, EventArgs e)
        {
            Planet planet = new Planet();
            try
            {
                planet = await JSONHelper.GetPlanet(int.Parse(txb_Input.Text));
                ShowPlanet(planet);
            }
            catch
            {
                MessageBox.Show(txb_Input.Text + " is not a valid planet.");
            }
        }

        //get a person based on the entered value and show it's information.
        private async void btn_Person_Click(object sender, EventArgs e)
        {
            Person person = new Person();
            try
            {
                person = await JSONHelper.GetPerson(int.Parse(txb_Input.Text));
                ShowPerson(person);
            }
            catch
            {
                MessageBox.Show(txb_Input.Text + " is not a valid person.");
            }
        }

        //get all species and show their information.
        private async void btn_Species_Click(object sender, EventArgs e)
        {
            AllSpecies allSpecies = new AllSpecies();
            try
            {
                allSpecies = await JSONHelper.GetSpecies();
                ShowAllSpecies(allSpecies);
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        //this manages the extra functionality part of the project. 
        //either start scene creation, add a protagonist, or add an antagonist/finish the scene based on sceneStatus.
        private async void btn_Scene_Click(object sender, EventArgs e)
        {
            //start scene creation by clearing the existing pro/antagonists and instructing the user to add a protagonist. 
            if(sceneStatus == "start")
            {
                lbx_Output.Items.Clear();
                protagonist = new SceneHelper.Protagonist();
                antagonist = new SceneHelper.Antagonist();

                lbx_Output.Items.Add("Enter the protagonist's ID and press the button again.");

                btn_Scene.Text = "Add Protagonist";
                sceneStatus = "protagonist";
            }
            //set the protagonist to the person who's ID the user entered.
            else if(sceneStatus == "protagonist")
            {
                lbx_Output.Items.Clear();

                try
                {
                    protagonist.person = await JSONHelper.GetPerson(int.Parse(txb_Input.Text));

                    lbx_Output.Items.Add("Enter the antagonist's ID and press the button again.");

                    btn_Scene.Text = "Add Antagonist";
                    sceneStatus = "antagonist";
                }
                catch
                {
                    MessageBox.Show(txb_Input.Text + " is not a valid person.");
                }
            }
            //set the antagonist to the person who's ID the user entered then generate the scene and reset the status to 'start'.
            else if (sceneStatus == "antagonist")
            {
                lbx_Output.Items.Clear();

                try
                {
                    antagonist.person = await JSONHelper.GetPerson(int.Parse(txb_Input.Text));

                    lbx_Output.Items.Add(protagonist.GenerateStoryPart());
                    lbx_Output.Items.Add(antagonist.GenerateStoryPart());

                    btn_Scene.Text = "Create Scene";
                    sceneStatus = "start";
                }
                catch
                {
                    MessageBox.Show(txb_Input.Text + " is not a valid person.");
                }
            }
        }

        //clear the listbox, then show the information for a planet.
        void ShowPlanet(Planet _planet)
        {
            lbx_Output.Items.Clear();

            lbx_Output.Items.Add("Name: " + _planet.name);
            lbx_Output.Items.Add("Rotation Period: " + _planet.rotation_period);
            lbx_Output.Items.Add("Orbital Period: " + _planet.orbital_period);
            lbx_Output.Items.Add("Diameter: " + _planet.diameter);
            lbx_Output.Items.Add("Climate: " + _planet.climate);
            lbx_Output.Items.Add("Gravity: " + _planet.gravity);
            lbx_Output.Items.Add("Terrain: " + _planet.terrain);
            lbx_Output.Items.Add("Surface_Water: " + _planet.surface_water);
            lbx_Output.Items.Add("Population: " + _planet.population);
        }

        //clear the listbox, then show the information for a planet.
        async void ShowPerson(Person _person)
        {
            string starshipNames = await GetStarships(_person);
            string homeWorld = await GetHomeworldFromPerson(_person);

            lbx_Output.Items.Clear();

            lbx_Output.Items.Add("Name: " + _person.name);
            lbx_Output.Items.Add("Height: " + _person.height);
            lbx_Output.Items.Add("Mass: " + _person.mass);
            lbx_Output.Items.Add("Hair Color: " + _person.hair_color);
            lbx_Output.Items.Add("Skin Color: " + _person.skin_color);
            lbx_Output.Items.Add("Eye Color: " + _person.eye_color);
            lbx_Output.Items.Add("Birth Year: " + _person.birth_year);
            lbx_Output.Items.Add("Gender: " + _person.gender);
            lbx_Output.Items.Add("Homeworld: " + homeWorld);
            lbx_Output.Items.Add("Starships: " + starshipNames);
        }

        //clear the listbox, then show the information for all species.
        async void ShowAllSpecies(AllSpecies _allSpecies)
        {
            lbx_Output.Items.Clear();

            foreach (Species species in _allSpecies.results)
            {
                string homeWorld = await GetHomeworldFromSpecies(species);

                lbx_Output.Items.Add("Name: " + species.name);
                lbx_Output.Items.Add("Classification: " + species.classification);
                lbx_Output.Items.Add("Designation: " + species.designation);
                lbx_Output.Items.Add("Average Height: " + species.average_height);
                lbx_Output.Items.Add("Skin Colors: " + species.skin_colors);
                lbx_Output.Items.Add("Hair Colors: " + species.hair_colors);
                lbx_Output.Items.Add("Eye Colors: " + species.eye_colors);
                lbx_Output.Items.Add("Average Lifespan: " + species.average_lifespan);
                lbx_Output.Items.Add("Homeworld: " + homeWorld);
                lbx_Output.Items.Add("Language: " + species.language);
                lbx_Output.Items.Add(" ");
            }

        }

        //return the name of each starship the person is associated with.
        async Task<string> GetStarships(Person _person)
        {
            string output = "";

            if(_person.starships != null && _person.starships.Count > 0)
            {
                //for every starship a person has, get its ID, then use the ID to get the starship class using the JSONHelper, then add the name from the starship class to the output.
                foreach (string starship in _person.starships)
                {
                    Starship starshipClass = new Starship();
                    string ID = "";

                    foreach(char character in starship)
                    {
                        //this may look ridiculous, but the char cannot be directly parsed as an in when done in a foreach like this, so I convert it into a string then parse it. If it is a number then it will
                        //be parsed correctly and added to the ID after being converted back to a string. If it is a letter the parse will fail and it will not be added to the ID. 
                        try
                        {
                            ID += int.Parse(character.ToString()).ToString();
                        }
                        catch
                        {

                        }
                    }

                    if(ID.Length > 0)
                    {
                        try
                        {
                            starshipClass = await JSONHelper.GetStarship(int.Parse(ID));
                            output += starshipClass.name + "   ";
                        }
                        catch
                        {

                        }
                    }
                }
            }

            return output;
        }

        //return the name of person's homeworld by getting its ID, using JSONHelper to get the planet's class, then returning the class' name. 
        async Task<string> GetHomeworldFromPerson(Person _person)
        {
            string output = "";
            Planet homeWorld = new Planet();
            string ID = "";

            if(_person.homeworld == null)
            {
                return output;
            }

            foreach (char character in _person.homeworld)
            {
                //this may look ridiculous, but the char cannot be directly parsed as an in when done in a foreach like this, so I convert it into a string then parse it. If it is a number then it will
                //be parsed correctly and added to the ID after being converted back to a string. If it is a letter the parse will fail and it will not be added to the ID. 
                try
                {
                    ID += int.Parse(character.ToString()).ToString();
                }
                catch
                {

                }
            }

            if (ID.Length > 0)
            {
                try
                {
                    homeWorld = await JSONHelper.GetPlanet(int.Parse(ID));
                    output += homeWorld.name + "   ";
                }
                catch
                {

                }
            }

            return output;
        }

        //return the name of species' homeworld by getting its ID, using JSONHelper to get the planet's class, then returning the class' name. 
        async Task<string> GetHomeworldFromSpecies(Species _species)
        {
            string output = "";
            Planet homeWorld = new Planet();
            string ID = "";

            if (_species.homeworld == null)
            {
                return output;
            }

            foreach (char character in _species.homeworld)
            {
                //this may look ridiculous, but the char cannot be directly parsed as an in when done in a foreach like this, so I convert it into a string then parse it. If it is a number then it will
                //be parsed correctly and added to the ID after being converted back to a string. If it is a letter the parse will fail and it will not be added to the ID. 
                try
                {
                    ID += int.Parse(character.ToString()).ToString();
                }
                catch
                {

                }
            }

            if (ID.Length > 0)
            {
                try
                {
                    homeWorld = await JSONHelper.GetPlanet(int.Parse(ID));
                    output += homeWorld.name;
                }
                catch
                {

                }
            }

            return output;
        }
    }
}
