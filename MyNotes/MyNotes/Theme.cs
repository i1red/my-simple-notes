using System;
using System.Collections.Generic;
using System.Text;

namespace MyNotes
{
    public class Theme
    {
        public string MasterPageColor { get; set; }
        public string DetailPageColor { get; set; }
        public string BarColor { get; set; }
        public string TextColor { get; set; }

        public static Theme LightTheme
        {
            get { return new Theme() { MasterPageColor = "#ffe28c", DetailPageColor = "#ffffbd", BarColor = "#cab05d", TextColor = "#322e2c" }; }
        }
        public static Theme DarkTheme
        {
            get { return new Theme() { MasterPageColor = "#0d47a1", DetailPageColor = "#5472d3", BarColor = "#004080", TextColor = "#ffffff" }; }
        }
    }
}
