﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace TBD_TBG
{
    public class Choice
    {
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

        public Choice GetChoice(string selection)
        {
            int num = Int32.Parse(selection) - 1;
            return this.Choices.Values.ElementAt(num);
        }
    }
}
