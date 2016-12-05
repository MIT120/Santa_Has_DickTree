using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1_v4
{
    class Instruction
    {
        public char rotation;
        public int distances;
        List<char> Rotations = new List<char>();
        List<int> Distance = new List<int>();
        public Instruction(char rotate, int distance)
        {

            rotation = rotate;
            Rotations.Add(rotation);
            distances = distance;
            Distance.Add(this.distances);
        }
    }
}
