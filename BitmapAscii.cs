using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ascii_Generator
{
    class BitmapAscii
    {
        private int _kernalWidth, _kernalHeight;
        public BitmapAscii(int kernalWidth, int kernalHeight)
        { 
            _kernalWidth = kernalWidth;
            _kernalHeight = kernalHeight;
        }

 
        public double AveragePixel(int r, int g, int b)
        {
            //doin' the math
            double avg = (r + g + b)/3;
            avg = avg / 255;
            return avg;
        }


        static string ToString(double avg)
        {
            //initialize ascii string
            string asciiArt = "";

            //build ascii string based on parameters of grayscale
            if (avg == 0)
            {
                asciiArt += "#";

            }
            else if (avg >= 0 && avg <= 0.2)
            {
                asciiArt += "?";
            }
            else if (avg >= 0.2 && avg <= 0.4)
            {
                asciiArt += "/";
            }
            else if (avg >= 0.4 && avg <= 0.6)
            {
                asciiArt += "+";
            }
            else if (avg >= 0.6 && avg <= 0.8)
            {
                asciiArt += ".";
            }
            else
            {
                asciiArt+= " ";
            }

            return asciiArt;

        }

        public string Asciitize(Bitmap image1)
        {
            //create variables
            int x = (int)_kernalWidth;
            int y = (int)_kernalHeight;
            string newString = "";
            int temp = image1.Width;
            int temp2 = image1.Height;
            List<Color> colors = new List<Color>();

            //determine if kernal is used
            if (_kernalHeight > 1 && _kernalWidth > 1)
            {
                //loop through pixel rox
                for (int j = 0; j < image1.Height; j += _kernalHeight)
                {
                    //loop trough pixel column
                    for (int i = 0; i < image1.Width; i += _kernalWidth)
                    {
                        //loop through kernal row
                        for (int kernalY = 0; kernalY < _kernalHeight; kernalY++)
                        {
                            //loop through kernal column
                            for (int kernalX = 0; kernalX < _kernalWidth; kernalX++)
                            {
                                //Get and combine pixel color
                                Color clrCurrent = image1.GetPixel(i, j);
                                colors.Add(clrCurrent);
                            }
                        }
                        //transfer to grayscale
                        double grayscale = AvgColor(colors);
                        colors.Clear();
                        //add new character to string
                        newString += ToString(grayscale);
                    }
                    //start new line with each row
                    newString += "\n";
                }
            }
            else
            {
                //loop through pixel row
                for (y = 0; y < image1.Height; y++)
                {
                    //loop through pixel column
                    for (x = 0; x < image1.Width; x++)
                    {
                        //Pull RGB values
                        Color pixelColor = image1.GetPixel(x, y);
                        int r = pixelColor.R;
                        int g = pixelColor.G;
                        int b = pixelColor.B;

                        double newAvg = AveragePixel(r, g, b);

                        newString += ToString(newAvg);

                    }
                    //create new line after each row
                    newString += "\n";
                }
            }
            return newString;
        }


        public double AvgColor(List <Color> colors)
        {
            //create class variables
            List<Color> colors0 = new List <Color>();
            double avg = 0;
            Color[] colors1 = colors.ToArray();
            double totalGray = 0; 

            //loop through color list
            for (int i = 0; i < colors1.Length; i++)
            {
                //determine rgb values
                avg = AveragePixel(colors1[i].R, colors1[i].B, colors1[i].G);
                //combine values for use to grayscale
                totalGray =+ avg; 
            }
            return totalGray;
        }
    }
}
