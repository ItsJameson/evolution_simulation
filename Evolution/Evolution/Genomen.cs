using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Evolution
{
    internal class Genome
    {
        public int[,] Board = new int[30, 55];
        private Dictionary<string, int> movementType;
        public Dictionary<string, int> MovementType
        {
            get { return movementType; }
            set { movementType = value; }
           
        }

        private int[] coord;
        public  int[] Coord
        {
            get { return coord; }
            set { coord = value; }
        }

        public Genome()
        {
            Coord = coordRandom();
            MovementType = Movement();

        }

        public Dictionary<string, int> Movement()
        {
            Random random = new Random();
            var newDict = new Dictionary<string, int>();
            int randomSelect = random.Next(1,4);
            int minValue = -2;
            int maxValue = 2;
            int randomValue = random.Next(minValue, maxValue);

            if (randomSelect == 1)
            {
                newDict.Add("MX", randomValue);
                return newDict;
            }
            else if (randomSelect == 2)
            {
                newDict.Add("MY", randomValue);
                return newDict;
            }
            else
            {
                newDict.Add("MR", randomValue);
                return newDict;
            }
        }
     
        public int[] coordRandom()
        {
            Random random = new Random();
            int[] outArray = new int[2];
            
            outArray[0] = random.Next(0, Board.GetLength(0));
            outArray[1] = random.Next(0, Board.GetLength(1));

            return outArray;
        }
    }

}
