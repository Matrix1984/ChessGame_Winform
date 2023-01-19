using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace WindowsFormsApplication1
{

    [Serializable]
    class Rook : Pieces
    {
        int columnEnd;
        int rowEnd;
        int columnStart;
        int rowStart;
        string name;
        bool valid;
        char firstLetter;
        char secondLetter;
        bool pieceDevour;
        string chessPiece;
        bool secondLetterNotNull;

        public Rook(string s)
        {
            name = s;
        }

        public override Image print()
        {
            if (name[0] == 'W')
            {
                return Properties.Resources.WRook;
            }
            else
            {
                return Properties.Resources.BRook;
            }
        }

        public override string pieceName()
        {
            return this.name;
        }

        public override bool pieceCollision(Pieces[,] pieces, int rowStart, int columnStart, int rowEnd, int columnEnd)
        {
        

            int a = 0;



            bool isRookMovingRight = false;
            bool isRookMovingLeft = false;
            bool isRookMovingDown = false;
            bool isRookMovingUp = false;


            int b = 0;
            int rowX = rowEnd - rowStart;

            int columnY = columnEnd - columnStart;





            ////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (columnY > 0 & rowX == 0)
            { // RIGHT SIDE (CHECK FOR NULL)




                try
                {
                    while (pieces[rowStart, columnStart + b + 1] == null && columnStart + b + 1 < columnEnd)
                    {
                        b++;

                    }
                    b = b + 1;
                }
                catch (Exception e)
                {
                    while (pieces[rowStart, 8] == null && columnStart + b != columnEnd)
                    {
                        b++;

                    }

                }


                if (b != columnY)
                {
                    isRookMovingRight = false;
                }
                else if (pieces[rowEnd, columnEnd] != null && piecesDevour(pieces, rowStart, columnStart, rowEnd, columnEnd) && columnY == b)
                {
                    isRookMovingRight = true;
                }	 // IF B SMALLER THAN THE DIFFERENCE BETWEEN COLUMNSTART & COLUMNEND (SPACESY) , GIVE FALSE. OTHERWISE GIVE TRUE.

                else if (pieces[rowEnd, columnEnd] == null && ((columnY == b)))
                {
                    isRookMovingRight = true;
                }
                else
                {
                    isRookMovingRight = false;
                }
            }


            //////////////////////////////////////////////////////////////////////////////////////////////////////




            if (columnY < 0 & rowX == 0)
            { // LEFT SIDE (CHECK FOR NULL)


                try
                {
                    while (pieces[rowStart, columnStart - b - 1] == null && columnStart - b - 1 != columnEnd)
                    {
                        b++;

                    }
                    b = b + 1;
                }
                catch (Exception e)
                {
                    while (pieces[rowStart, 1] == null && columnStart - b != columnEnd)
                    {
                        b++;

                    }
                }



                columnY = columnY * (-1);
                if (b != columnY)
                {
                    isRookMovingLeft = false;
                }
                else if (pieces[rowEnd, columnEnd] != null && piecesDevour(pieces, rowStart, columnStart, rowEnd, columnEnd) && columnY == b)
                {
                    isRookMovingLeft = true;
                }
                else if (pieces[rowEnd, columnEnd] == null && ((columnY == b)))
                {
                    isRookMovingLeft = true;
                }
                else
                {
                    isRookMovingLeft = false;
                }
                columnY = columnY * (-1);

            }






            //////////////////////////////////////////////////////////////////////////////////////////////////////////

            if (columnY == 0 & rowX > 0)
            { // DOWN SIDE (CHECK FOR NULL)



                try
                {
                    while (pieces[rowStart + b + 1, columnStart] == null && rowStart + b + 1 != rowEnd)
                    { // CHECKS THE down ROW.
                        b++;
                    }
                    b = b + 1;
                }
                catch (Exception e)
                {
                    while (pieces[8, columnStart] == null && rowStart + b != rowEnd)
                    { // CHECKS THE down ROW.
                        b++;
                    }
                }
                if (b != rowX)
                {
                    isRookMovingDown = false;
                }
                else if (pieces[rowEnd, columnEnd] != null && piecesDevour(pieces, rowStart, columnStart ,rowEnd,columnEnd) && rowX == b)
                {
                    isRookMovingDown = true;
                }
                else if (pieces[rowEnd, columnEnd] == null && ((rowX == b)))
                {
                    isRookMovingDown = true;
                }
                else
                {
                    isRookMovingDown = false;
                }
            }

            /////////////////////////////////////////////////////////////////////////////////////						  
            if (columnY == 0 & rowX < 0)
            { // UP SIDE (CHECK FOR NULL)			  
                // (array[columnStart-b]!=0 && array[columnStart-b]!=array[columnEnd]&& array[columnEnd]!=0 )	
                try
                {
                    while (pieces[rowStart - b - 1, columnStart] == null && rowStart - b - 1 != rowEnd)
                    { // CHECKS THE UPPER ROW.
                        b++;
                    }
                    b = b + 1;
                }
                catch (Exception e)
                {
                    while (pieces[1, columnStart] == null && rowStart - b != rowEnd)
                    { // CHECKS THE UPPER ROW.
                        b++;
                    }
                }
                rowX = rowX * (-1);

                if (b != rowX)
                {
                    isRookMovingUp = false;
                }
                else if (pieces[rowEnd, columnEnd] != null && piecesDevour(pieces, rowStart, columnStart, rowEnd, columnEnd) && rowX == b)
                {
                    isRookMovingUp = true;

                }
                else if (pieces[rowEnd, columnEnd] == null && ((rowX == b)))
                {
                    isRookMovingUp = true;
                }
                else
                {
                    isRookMovingUp = false;
                }
            }



            
            return isRookMovingUp || isRookMovingDown || isRookMovingLeft || isRookMovingRight;
        }


        public override bool piecesDevour(Pieces[,] pieces, int rowStart, int columnStart, int rowEnd, int columnEnd)
        {
            firstLetter = pieces[rowStart, columnStart].pieceName()[0];

            if (pieces[rowEnd, columnEnd] != null)
            {
                secondLetterNotNull = true;
                secondLetter = pieces[rowEnd, columnEnd].pieceName()[0];
            }
            else
            {
                secondLetterNotNull = false;
            }

            if (secondLetter != firstLetter && secondLetterNotNull == true)
            {
                pieceDevour = true;
            }
            else
            {
                pieceDevour = false;
            }
            return pieceDevour;
        }

        public override bool pieceMovement(Pieces[,] pieces, int rowStart, int columnStart, int rowEnd, int columnEnd)
        {

            return pieceCollision( pieces,  rowStart,  columnStart,  rowEnd,  columnEnd);
        }



    }

}
