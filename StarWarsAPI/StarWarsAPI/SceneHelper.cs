using System;
using System.Collections.Generic;
using System.Text;

namespace StarWarsAPI
{
    public class SceneHelper
    {
        public static string[] protagonistDialogue = {"I won't let you get away with this!", "Your treachery ends here!", "Good always triumphs over evil.", "You're completely insane!", "You killed my father!"};
        public static string[] antagonistDialogue = { "I am antagonizing you.", "I am your father.", "Join the evil side!", "Pathetic.", "Actually, morality is subjective, so there's no way to prove that your morals are good and mine are evil." };
        public static string[] relations = { "enemy", "arch-rival", "nemesis", "least-favorite person", "opposite-of-friend" };

        public abstract class Character
        {
            public Person person { get; set; }

            //default constructor with no parameters.
            public Character()
            {
                this.person = new Person();
            }

            //constructor with parameters.
            public Character(Person _person)
            {
                this.person = _person;
            }

            //returns part of a story based on character type.
            virtual public string GenerateStoryPart()
            {
                if(person.name != null && person.name.Length > 0)
                {
                    return (person.name + " was present.");
                }
                else
                {
                    return "An unnamed character was present";
                }
            }

            //returns a random relation from the relations array.
            public string GetRelation()
            {
                Random rand = new Random();
                return relations[rand.Next(relations.Length)];
            }

            //used in subclasses. 
            virtual public string GetDialogue()
            {
                return "";
            }
        }

        public class Protagonist : Character
        {

            //default constructor with no parameters.
            public Protagonist()
            {
                this.person = new Person();
            }

            //constructor with parameters.
            public Protagonist(Person _person)
            {
                this.person = _person;
            }

            //returns part of a story based on character type.
            override public string GenerateStoryPart()
            {
                string name;
                if (person.name != null && person.name.Length > 0)
                {
                    name = person.name;
                }
                else
                {
                    name = "The protagonist";
                }

                return (name + " scanned their surroundings, and noticed their " + GetRelation() + " poised to strike! " + name + " readied for battle, and said '" + GetDialogue() + "'");
            }

            //return a string from the protagonistDialogue array. 
            override public string GetDialogue()
            {
                Random rand = new Random();
                return protagonistDialogue[rand.Next(protagonistDialogue.Length)];
            }
        }

        public class Antagonist : Character
        {

            //default constructor with no parameters.
            public Antagonist()
            {
                this.person = new Person();
            }

            //constructor with parameters.
            public Antagonist(Person _person)
            {
                this.person = _person;
            }

            //returns part of a story based on character type.
            override public string GenerateStoryPart()
            {
                string name;
                if (person.name != null && person.name.Length > 0)
                {
                    name = person.name;
                }
                else
                {
                    name = "The antagonist";
                }

                return ("'" + GetDialogue() + "' replied " + name + ".");
            }

            //return a string from the protagonistDialogue array. 
            override public string GetDialogue()
            {
                Random rand = new Random();
                return antagonistDialogue[rand.Next(antagonistDialogue.Length)];
            }
        }
    }
}
