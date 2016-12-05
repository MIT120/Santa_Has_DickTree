using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProektMarto
{
    class Methods
    {
        private string fullString = "R5,L2,L1,R1,R3,R3,L3,R3,R4,L2,R4,L4,R4,R3,L2,L1,L1,R2,R4,R4,L4,R3,L2,R1,L4,R1,R3,L5,L4,L5,R3,L3,L1,L1,R4,R2,R2,L1,L4,R191,R5,L2,R46,R3,L1,R74,L2,R2,R187,R3,R4,R1,L4,L4,L2,R4,L5,R4,R3,L2,L1,R3,R3,R3,R1,R1,L4,R4,R1,R5,R2,R1,R3,L4,L2,L2,R1,L3,R1,R3,L5,L3,R5,R3,R4,L1,R3,R2,R1,R2,L4,L1,L1,R3,L3,R4,L2,L4,L5,L5,L4,R2,R5,L4,R4,L2,R3,L4,L3,L5,R5,L4,L2,R3,R5,R5,L1,L4,R3,L1,R2,L5,L1,R4,L1,R5,R1,L4,L4,L4,R4,R3,L5,R1,L3,R4,R3,L2,L1,R1,R2,R2,R2,L1,L1,L2,L5,L3,L1";
        private List<string> separeteStrings = new List<string>();
        private string tempFractureString = "";
        private int initialX, initialY = 0;
        private int orientation = 1;
        private List<string> xAndY = new List<string>();



        public void SplitStringToList()
        {
            for (int i = 0; i < fullString.Length; i++)
            {
                string temp = fullString[i].ToString();
                
                if (temp == ",")
                {
                    separeteStrings.Add(tempFractureString);
                    tempFractureString = null;
                }
                else
                {
                    tempFractureString += temp;
                }
                
            }
        }


        public void Update()
        {

            for (int i = 0; i < separeteStrings.Count; i++)
            {
                if (separeteStrings[i].Contains("L"))
                {
                    if (orientation > 0)
                        orientation--;
                    else
                        orientation = 3;
                }
                else if (separeteStrings[i].Contains("R"))
                {
                    if (orientation < 4)
                        orientation++;
                    else
                        orientation = 0;
                }

                switch (orientation)
                {
                    case 0:
                        MoveToNext(-DetermineSteps(separeteStrings[i]), 0);
                        Console.WriteLine("X: " + initialX + "   Y: " + initialY + "  LEFT with " + DetermineSteps(separeteStrings[i]));
                        break;                        
                    case 1:
                        MoveToNext(0, DetermineSteps(separeteStrings[i]));
                        Console.WriteLine("X: " + initialX + "   Y: " + initialY + "  UP with " + DetermineSteps(separeteStrings[i]));
                        break;
                    case 2:
                        MoveToNext(DetermineSteps(separeteStrings[i]), 0);
                        Console.WriteLine("X: " + initialX + "   Y: " + initialY + "  RIGHT with " + DetermineSteps(separeteStrings[i]));
                        break;
                    case 3:
                        MoveToNext(0, -DetermineSteps(separeteStrings[i]));
                        Console.WriteLine("X: " + initialX + "   Y: " + initialY+"  DOWN with " + DetermineSteps(separeteStrings[i]));
                        break;
                }
                xAndY.Add("X: " + initialX + "   Y: " + initialY);
            }
        }




        private int DetermineRotation()
        {
            //AKA direction of X and Y
            return 0;
        }

        private int DetermineSteps(string coordinates)
        {
            return GetNumberFromString(coordinates);
        }

        private int GetNumberFromString(string toDetermine)
        {
            string temp = "";
            for (int i = 0; i < toDetermine.Length; i++)
            {
                if (Char.IsDigit(toDetermine[i]))
                    temp += toDetermine[i];
            }
            return Convert.ToInt16(temp);
        }


        private void MoveToNext(int x, int y)
        {
            initialX += x;
            initialY += y;
        }

        public void Display()
        {
            
            
            //for (int i = 0; i < xAndY.Count; i++)
            //{
            //    Console.WriteLine(xAndY[i]);
            //}
            Console.WriteLine("X: " + initialX + "   Y: " + initialY);
        }
    }
}
