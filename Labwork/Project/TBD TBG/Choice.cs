using System;
using System.Collections.Generic;
using System.Linq;

namespace TBD_TBG
{
    public class Choice
    {
        //TODO: ADD Combat value Yes/No for every decision
        //      ADD morality value for every decision

        public string Description { get; set; }
        public Dictionary<string, Choice> Choices { get; set; }
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
