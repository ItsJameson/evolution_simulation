using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Evolution
{
    internal class Community
    {
        private Organism[,] organismArray = new Organism[5, 10];
        public Organism[,] OrganismArray
        {
            get { return organismArray; }
            set { organismArray = value; }
        }

        private Organism organismTrait;

        public Organism OrganismTrait
        {
            get { return organismTrait; }
            set { organismTrait = value; }
        }

        public Community()
        {
            this.OrganismTrait = new Organism();
            this.OrganismArray = InitializeOrgArray();
        }

        public Organism[,] InitializeOrgArray()
        {
            for (int i = 0; i < OrganismArray.GetLength(0); i++)
            {
                for (int j = 0; j < OrganismArray.GetLength(1); j++)
                {
                    OrganismArray[i, j] = new Organism();
                }
            }
            return OrganismArray;
        }

        public static void ShowMovement()
        {
            Community newComm = new Community();
            int movementSteps = 75;
            
            bool isWritten = false;

            // Show organisms in the console for x amount of movement steps:
            for (int k = 0; k < movementSteps; k++)
            {
                Thread.Sleep(50);
                Console.Clear();
                for (int i = 0; i < newComm.organismTrait.GenomeTrait.Board.GetLength(0); i++)
                {

                    for (int j = 0; j < newComm.organismTrait.GenomeTrait.Board.GetLength(1); j++)
                    {
                        isWritten = false;
                        foreach (var item in newComm.OrganismArray)
                        {
                            if (i == item.GenomeTrait.Coord[0] && j == item.GenomeTrait.Coord[1])
                            {
                                Console.Write("O");
                                isWritten = true;
                            }
                        }
                        if (!isWritten)
                        {
                            Console.Write(" ");
                        }
                    }
                    Console.WriteLine();
                }

                // Now each organims will move itself according to it's movement type genome:
                foreach (var item in newComm.OrganismArray)
                {
                    if (item.GenomeTrait.MovementType.ContainsKey("MX"))
                    {
                        if (item.GenomeTrait.Coord[0] != 0 && item.GenomeTrait.Coord[0] < item.GenomeTrait.Board.GetLength(0) - 1 && item.GenomeTrait.MovementType["MX"] != 0)
                        {
                            item.GenomeTrait.Coord[0] += item.GenomeTrait.MovementType["MX"];
                        }
                    }
                    else if (item.GenomeTrait.MovementType.ContainsKey("MY"))
                    {
                        if (item.GenomeTrait.Coord[1] != 0 && item.GenomeTrait.Coord[1] < item.GenomeTrait.Board.GetLength(1) - 1 && item.GenomeTrait.MovementType["MY"] != 0)
                        {
                            item.GenomeTrait.Coord[1] += item.GenomeTrait.MovementType["MY"];
                        }
                    }
                    else if (item.GenomeTrait.MovementType.ContainsKey("MR"))
                    {
                        if (item.GenomeTrait.Coord[1] != 0 && item.GenomeTrait.Coord[1] < item.GenomeTrait.Board.GetLength(1) - 1 && item.GenomeTrait.MovementType["MR"] != 0 && item.GenomeTrait.Coord[0] != 0 && item.GenomeTrait.Coord[0] < item.GenomeTrait.Board.GetLength(0) - 1)
                        {
                            Random rand = new Random();

                            item.GenomeTrait.Coord[rand.Next(0,2)] += item.GenomeTrait.MovementType["MR"];
                        }
                    }
                }
            }
        }
    }
}
