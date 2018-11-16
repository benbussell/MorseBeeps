using System;
using System.Collections.Generic;
using System.Text;

namespace TranslateToMorse
{

    public class RootObject
    {
        public Quote[] Quotes { get; set; }
    }

    public class Quote
    {
        public string Likes { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
    }
    //models json object from dataset to instances of class Quote

}
