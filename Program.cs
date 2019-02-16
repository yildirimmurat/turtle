using System;
using System.Collections.Generic;
using System.Linq;

namespace turtle
{

    public enum Instruction
    {
        F,
        R,
        L,
        X
    }

    public enum FacingDirection
    {
        Right,
        Down,
        Left,
        Up
    }

    public class Turtle
    {
        public int turtlePositionX { get; set; }//burdaki get set ten nasıl faydalanabiliriz?
        public int turtlePositionY { get; set; }
        //public int turtleForwardPositionX { get; set; }
        //public int turtleForwardPositionY { get; set; }
        public FacingDirection facingDirection;
        //public PuzzleElement FindForwardElement();//null exception


        public Turtle(int posX, int posY, FacingDirection facing)
        {
            this.turtlePositionX = posX;
            this.turtlePositionY = posY;
            this.facingDirection = facing;
        }



        public void Play(List<Instruction> instructionList)
        {

            foreach (Instruction instruction in instructionList)
            {
                if (instruction == Instruction.R)
                {
                    Console.WriteLine("R pressed");

                    if (this.facingDirection == FacingDirection.Right)
                        this.facingDirection = FacingDirection.Down;
                    else if (this.facingDirection == FacingDirection.Down)
                        this.facingDirection = FacingDirection.Left;
                    else if (this.facingDirection == FacingDirection.Left)
                        this.facingDirection = FacingDirection.Up;
                    else if (this.facingDirection == FacingDirection.Up)
                        this.facingDirection = FacingDirection.Right;
                    else
                        Console.WriteLine("unknown facing direction!");

                    Console.WriteLine("turtle's facing direction is now to: " + this.facingDirection);
                }
                else if (instruction == Instruction.L)
                {
                    Console.WriteLine("L pressed");

                    if (this.facingDirection == FacingDirection.Right)
                        this.facingDirection = FacingDirection.Up;
                    else if (this.facingDirection == FacingDirection.Up)
                        this.facingDirection = FacingDirection.Left;
                    else if (this.facingDirection == FacingDirection.Left)
                        this.facingDirection = FacingDirection.Down;
                    else if (this.facingDirection == FacingDirection.Down)
                        this.facingDirection = FacingDirection.Right;
                    else
                        Console.WriteLine("unknown facing direction!");

                    Console.WriteLine("turtle's facing direction is now to: " + this.facingDirection);
                }

                else if (instruction == Instruction.F)
                {
                    if (this.forwardElement.Contains() == ElementSpace.Empty)
                    {
                        this.MoveForward();
                    }
                    else
                    {
                        Console.WriteLine("Bug!");
                    }
                }
                else
                    Console.WriteLine("unknown instruction type: use R or L");
            }

        }

        public void MoveForward()
        {
            if (this.facingDirection == FacingDirection.Down)
            {
                this.turtlePositionY--;
            }
            else if (this.facingDirection == FacingDirection.Left)
            {
                this.turtlePositionX--;
            }
            else if (this.facingDirection == FacingDirection.Right)
            {
                this.turtlePositionX++;
            }
            else if (this.facingDirection == FacingDirection.Up)
            {
                this.turtlePositionY++;
            }

        }

        public bool CanShoot()
        {
            return true;//if ice than return true if not return false   
        }

        public void Shoot()
        {
            //ice returns to empty
        }
    }

    public enum ElementSpace
    {
        Castle,//C
        Ice,//I
        Empty,//.
        Diamond,//D
        Turtle//T
    }

    public class PuzzleElement
    {
        private int puzzleElementPosX;
        private int puzzleElementPosY;
        private ElementSpace elementSpace;

        public PuzzleElement(int posX, int posY, ElementSpace elementSpace)
        {
            this.puzzleElementPosX = posX;
            this.puzzleElementPosY = posY;
            this.elementSpace = elementSpace;
        }

        public int GetPositionX()
        {
            return this.puzzleElementPosX;
        }

        public int GetPositionY()
        {
            return this.puzzleElementPosY;
        }

        public ElementSpace Contains()
        {
            return this.elementSpace;
        }
    }


    class MainClass
    {
        //private static object element;

        public static void Main(string[] args)
        {

            List<Instruction> myInstructionList = new List<Instruction>();//en fazla 60 tane olabilir

            List<PuzzleElement> puzzleElementsList = new List<PuzzleElement>();

            char [,] inputKey = new char[8, 8];

            for(int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    char pressedKey = Console.ReadKey().KeyChar;
                    if(!Char.IsWhiteSpace(pressedKey))
                    {
                        inputKey[i, j] = pressedKey;
                        if (pressedKey == '.')
                        {
                            PuzzleElement element = new PuzzleElement(i, j, ElementSpace.Empty);
                            puzzleElementsList.Add(element);
                        }
                        else if (pressedKey == 'C' || pressedKey == 'c')
                        {
                            PuzzleElement element = new PuzzleElement(i, j, ElementSpace.Castle);
                            puzzleElementsList.Add(element);
                        }
                        else if (pressedKey == 'I' || pressedKey == 'i')
                        {
                            PuzzleElement element = new PuzzleElement(i, j, ElementSpace.Ice);
                            puzzleElementsList.Add(element);
                        }
                        else if (pressedKey == 'D' || pressedKey == 'd')
                        {
                            PuzzleElement element = new PuzzleElement(i, j, ElementSpace.Diamond);
                            puzzleElementsList.Add(element);
                        }
                        else if (pressedKey == 'T' || pressedKey == 't')
                        {
                            PuzzleElement element = new PuzzleElement(i, j, ElementSpace.Turtle);
                            puzzleElementsList.Add(element);
                            //Turtle t = new Turtle(i, j, FacingDirection.Right);//buna gerek yok gibi
                        }
                        else
                        {
                            if (j!=8)
                                Console.WriteLine("unkown space variable!");
                        }
                    }
                    else
                    {
                        j--;
                    }
                }
            }

            Turtle t = new Turtle(0, 7, FacingDirection.Right);

            //char[] userInstruction = new char[60];
            Console.WriteLine("\n");

            char enterKey= Console.ReadKey().KeyChar;
            char userInst = Console.ReadKey().KeyChar;
            do
            {
                if (userInst == 'R')
                {
                    myInstructionList.Add(Instruction.R);
                }
                else if (userInst == 'L')
                {
                    myInstructionList.Add(Instruction.L);
                }
                else if (userInst == 'F')
                {
                    myInstructionList.Add(Instruction.F);
                }
                else if (userInst == 'X')
                {
                    myInstructionList.Add(Instruction.X);
                }
                else
                {

                    Console.WriteLine("Unidentified instruction!");
                }

                userInst = Console.ReadKey().KeyChar;

            } while (!Char.IsWhiteSpace(userInst));

            t.Play(myInstructionList);

            //find forward element
                int forwardElementPosX = t.turtlePositionX;
                int forwardElementPosY = t.turtlePositionY;

                if (t.facingDirection == FacingDirection.Down)
                {
                    forwardElementPosX = t.turtlePositionX;
                    forwardElementPosY = t.turtlePositionY--;
                }
                else if (t.facingDirection == FacingDirection.Left)
                {
                    forwardElementPosX = t.turtlePositionX--;
                    forwardElementPosY = t.turtlePositionY;
                }
                else if (t.facingDirection == FacingDirection.Right)
                {
                    forwardElementPosX = t.turtlePositionX++;
                    forwardElementPosY = t.turtlePositionY;
                }
                else if (t.facingDirection == FacingDirection.Up)
                {
                    forwardElementPosX = t.turtlePositionX;
                    forwardElementPosY = t.turtlePositionY++;
                }

            //object element = null;
                var myQuery =
                    from element in puzzleElementsList
                    where (element.GetPositionX() == forwardElementPosX && element.GetPositionY() == forwardElementPosY)
                    select element;

                if (element.Contains() == ElementSpace.Empty)
                {
                    Console.WriteLine("It is empty, go through!");
                }

        }


            //for (int i=0; i<8; i++) { }
            //string userString = Console.ReadLine();

            //Console.WriteLine(userString);
        }
    }
}
