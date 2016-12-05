using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1_V2
{
    class Day1
    {
        string input = "R5, L2, L1, R1, R3, R3, L3, R3, R4, L2, R4, L4, R4, R3, L2, L1, L1, R2, R4, R4, L4, R3, L2, R1, L4, R1, R3, L5, L4, L5, R3, L3, L1, L1, R4, R2, R2, L1, L4, R191, R5, L2, R46, R3, L1, R74, L2, R2, R187, R3, R4, R1, L4, L4, L2, R4, L5, R4, R3, L2, L1, R3, R3, R3, R1, R1, L4, R4, R1, R5, R2, R1, R3, L4, L2, L2, R1, L3, R1, R3, L5, L3, R5, R3, R4, L1, R3, R2, R1, R2, L4, L1, L1, R3, L3, R4, L2, L4, L5, L5, L4, R2, R5, L4, R4, L2, R3, L4, L3, L5, R5, L4, L2, R3, R5, R5, L1, L4, R3, L1, R2, L5, L1, R4, L1, R5, R1, L4, L4, L4, R4, R3, L5, R1, L3, R4, R3, L2, L1, R1, R2, R2, R2, L1, L1, L2, L5, L3, L1";

        // Make a list of moves to use for solving
        List<Instruction> Directions = new List<Instruction>();

        // We need to know where we are
        int x;
        int y;

        // And also where we are facing
        
        enum Facing { NORTH, SOUTH, EAST, WEST };
        Facing face = Facing.NORTH;
        public Day1()
        {
            
            string[] inputArray = input.Split(',');

          
            for (int i = 0; i < inputArray.Length; i++)
            {
           
                inputArray[i] = inputArray[i].Trim();
                
                Directions.Add(new Instruction() { Rotation = inputArray[i].Substring(0, 1).ToCharArray()[0], Distance = int.Parse(inputArray[i].Substring(1)) });
            }
        }

        public void Solve()
        {
           
            List<Position> placesWeHaveBeen = new List<Position>();
            
            placesWeHaveBeen.Add(new Position(0, 0));

            

            bool duplicatePlaceFound = false;
          
            foreach (Instruction i in Directions)
            {
               
                this.face = Face(this.face, i.Rotation);

             
                for (int c = 0; c < i.Distance; c++)
                {
                    Move(1, this.face);

                   
                    foreach (Position p in placesWeHaveBeen)
                    {
                        if (this.x == p.X && this.y == p.Y)
                        {
                            // we have been here before!
                            duplicatePlaceFound = true;
                            break;
                        }
                    }
                    
                    placesWeHaveBeen.Add(new Position(this.x, this.y));
                    if (duplicatePlaceFound)
                        break;
                }
                if (duplicatePlaceFound)
                    break;
            }
            Console.WriteLine("The end is {0} blocks away from here.", Math.Abs(this.x) + Math.Abs(this.y));
        }


        private Facing Face(Facing face, char turn)
        {
            if (turn == 'R')
            {
                if (face == Facing.NORTH)
                {
                    return Facing.EAST;
                }
                else if (face == Facing.EAST)
                {
                    return Facing.SOUTH;
                }
                else if(face == Facing.SOUTH)
                {
                    return Facing.SOUTH;
                }
                else if (face == Facing.WEST)
                {
                    return Facing.NORTH;
                }
                else
                {
                    return face;
                }
            }
            else
            {
                if (face == Facing.NORTH)
                {
                  return  Facing.WEST;
                }
                else if (face == Facing.WEST)
                {
                    return Facing.SOUTH;
                }
                else if (face == Facing.SOUTH)
                {
                    return Facing.EAST;
                }
                else if (face == Facing.EAST)
                {
                    return Facing.NORTH;
                }
                else
                {
                    return face;
                }
            }
        }
        private void Move(int blocks, Facing face)
        {
            switch (face)
            {
                case Facing.NORTH:
                    this.x = this.x + blocks;
                    break;
                case Facing.SOUTH:
                    this.x = this.x - blocks;
                    break;
                case Facing.EAST:
                    this.y = this.y + blocks;
                    break;
                case Facing.WEST:
                    this.y = this.y - blocks;
                    break;
                default:
                    break;
            }
        }

        class Instruction
        {
            public char Rotation;
            public int Distance;
        }
        class Position
        {
            public int X;
            public int Y;
            public Position(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
        }
    }
}
