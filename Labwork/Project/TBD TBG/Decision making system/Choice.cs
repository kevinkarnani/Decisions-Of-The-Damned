using System;
using System.Collections.Generic;
using System.Linq;

namespace TBD_TBG
{
    public class Choice
    {
        //TODO: ADD Combat value Yes/No for every decision
        //      ADD morality value for every decision

        public string Description { get; set; } // Initialized Description property by using getter and setter
        public Dictionary<string, Choice> Choices { get; set; } // Initialized Choices property by using getter and setter
        public int Morality { get; set; }

        //Class Constructor, takes in description parameter and sets it to class instance of Description
        public Choice(string des)
        {
            Description = des;
        }

        // setter method for Choices Dictionary, takes a dictionary of strings and choices, sets it to class instance
        public void SetChoices(Dictionary<string, Choice> choices)
        {
            Choices = choices;
        }

        public void SetMorality(int morality)
        {
            Morality = morality;
        }

        public int GetMorality()
        {
            return Morality;
        }

        //returns true if there exists any number of objects greater than 0 in the dictionary
        public bool CheckChoice()
        {
            return Choices.Count > 0;
        }

        //parses string into int, then returns the values of the dictionary as a choice object
        public Choice GetChoice(string selection)
        {
            int num = Int32.Parse(selection) - 1;
            return Choices.Values.ElementAt(num);
        } 
    }
}
