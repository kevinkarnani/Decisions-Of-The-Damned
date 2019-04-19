using System;
using System.Collections.Generic;
using System.Linq;

namespace TBD_TBG
{
    public class Choice
    {
        public string Description { get; set; }
        public Dictionary<string, Choice> Choices { get; set; }
        /*
         * combat or not bool
         * int? nullable int (can be an int or null)
         * or 
         * new class
         * combat class from choice
         * store combat variables
         * if its a combat scenario, start combat loop
         * have a player class that tracks stats and inventory
         * 
         * necessary morality for choices
         * int? 
         * morality needed for this option to appear
         */
        public Choice(string des)
        {
            this.Description = des;
        }


        public void SetChoices(Dictionary<string, Choice> choices)
        {
            this.Choices = choices;
        }

        public string GetChoiceText()
        {
            string output = "";
            foreach (string s in this.Choices.Keys)
            {
                output += s + "\n";
            }
            return output;
        }

        public bool CheckChoice()
        {
            return (this.Choices.Count > 0);
        }

        public Choice GetChoice(string selection)
        {
            int num = Int32.Parse(selection) - 1;
            return this.Choices.Values.ElementAt(num);
        } 
    }
}
