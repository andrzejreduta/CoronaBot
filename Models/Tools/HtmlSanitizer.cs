using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaBot.Models.Tools
{
    public class HtmlSanitizer
    {

        public int SanitizeInt(string input)
        {
            input = input.Trim();
            input = input.Replace("+","");
            input = input.Replace(",", "");
            input = input.Replace(".", "");

            if (input == "" || string.IsNullOrEmpty(input))
                return 0;

            return int.Parse(input);
        }

    }


    

}

