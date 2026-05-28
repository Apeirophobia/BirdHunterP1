using System;
using System.Collections.Generic;
using System.Text;

namespace BirdHunterP.Models
{
    public class Bird
    {
        public int value;
        public Image image;

        public Bird()
        {
            value = 1;
            image = new Image 
            { 
                Source = "birb.png",
                HeightRequest = 150,
                WidthRequest = 150
            };

            

        }


    }
}
