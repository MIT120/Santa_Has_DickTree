using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1_v4
{
   public class Day1
    {
        string input = "R5, L2, L1, R1, R3, R3, L3, R3, R4, L2, R4, L4, R4, R3, L2, L1, L1, R2, R4, R4, L4, R3, L2, R1, L4, R1, R3, L5, L4, L5, R3, L3, L1, L1, R4, R2, R2, L1, L4, R191, R5, L2, R46, R3, L1, R74, L2, R2, R187, R3, R4, R1, L4, L4, L2, R4, L5, R4, R3, L2, L1, R3, R3, R3, R1, R1, L4, R4, R1, R5, R2, R1, R3, L4, L2, L2, R1, L3, R1, R3, L5, L3, R5, R3, R4, L1, R3, R2, R1, R2, L4, L1, L1, R3, L3, R4, L2, L4, L5, L5, L4, R2, R5, L4, R4, L2, R3, L4, L3, L5, R5, L4, L2, R3, R5, R5, L1, L4, R3, L1, R2, L5, L1, R4, L1, R5, R1, L4, L4, L4, R4, R3, L5, R1, L3, R4, R3, L2, L1, R1, R2, R2, R2, L1, L1, L2, L5, L3, L1";
        int x;
        int y;
        string tempDirection;
        Instruction instructor;
        string[] CopyCart;
        Position place;
        List<Instruction> GoingTO = new List<Instruction>();
        enum Facing { NORTH, SOUTH, EAST, WEST };
        Facing face = Facing.NORTH;

        public Day1()
        {
            char[] myArray = new char[2];
            myArray[0] = ',';
            myArray[1] = ' ';

            CopyCart = input.Split(myArray);
            place = new Position(0, 0);
        }
        public void testk()
        {

            //    List<string> allString = new List<string>();

            for (int i = 0; i<input.Length; i++)
            {

                GoingTO.Add(new Instruction(input[i], int.Parse(CopyCart[i])));

                //GoingDirection.Add(instructor.Rotation = inputList[i].Substring(0, 1).
            }


}
public void Solve()
        {

            List<Position> placesWeHaveBeen = new List<Position>();

            placesWeHaveBeen.Add(place);



            bool samePlace = false;

            foreach (Instruction i in GoingTO)
            {

                this.face = Face(this.face, i.rotation);

                if (!samePlace)
                {
                    for (int c = 0; c < i.distances; c++)
                    {
                        Move(1, this.face);
                        if (!samePlace)
                        {
                            foreach (Position p in placesWeHaveBeen)
                            {
                                if (this.x == p.X && this.y == p.Y)
                                {
                                    
                                    samePlace = !samePlace;
                                }
                            }
                            placesWeHaveBeen.Add(new Position(this.x, this.y));
                        }

                     

                        
                      
                           
                    }
                }
                
               
            }
            Console.WriteLine(Math.Abs(this.x) + Math.Abs(this.y));
        }


         Facing Face(Facing face, char turn)
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
                else if (face == Facing.SOUTH)
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
                    return Facing.WEST;
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
         void Move(int blocks, Facing face)
        {
            if (face == Facing.NORTH)
            {
                x += blocks;
            }
            else if (face == Facing.SOUTH)
            {
                x += blocks;
            }
            else if (face == Facing.EAST)
            {
                y += blocks;
            }
            else if (face == Facing.WEST)
            {
                y += blocks;
            }
              
           
        }


    }
}
