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
    class Queen : Pieces
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

        public Queen(string s)
        {
            name = s;
        }

        public override Image print()
        {
            if (name[0] == 'W')
            {
                return Properties.Resources.WKing;
            }
            else
            {
                return Properties.Resources.BKing;
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


            int columnX = columnEnd - columnStart;
            int rowY = rowEnd - rowStart;
            bool BishopNorthEast = false;
            bool BishopNorthWest = false;
            bool BishopSouthWest = false;
            bool BishopSouthEast = false;
           

            // //////////////////BishopNorthWest////////////////////////////////////
            // BishopNorthWest////////////////////////////////////////
            // BishopNorthWest///////////////////////////
            // 1--

            if (columnX < 0 && rowY < 0)
            {
                try
                {
                    while (pieces[rowStart - 1 - a, columnStart - 1 - a] == null && (columnStart - 1 - a) != columnEnd && (rowStart - 1 - a) != rowEnd)
                    {

                        a++;
                    }
                    a = a + 1;
                }
                catch (Exception e)
                {
                    if (rowStart < 1)
                    {
                        while (pieces[8, columnEnd] == null)
                        {
                            a++;
                        }
                    }
                    else if (columnStart < 1)
                    {
                        while (pieces[rowEnd, 8] == null)
                        {
                            a++;
                        }
                    }
                    else
                    {
                        while (pieces[8, 8] == null)
                        {
                            a++;
                        }
                    }
                }



                if (rowY < 0)
                {
                    rowY = rowY * (-1);
                }
                if (columnX < 0)
                {
                    columnX = columnX * (-1);
                }
                if (a != rowY && a != columnX)
                {
                    BishopNorthWest = false;
                }
                else if (pieces[rowEnd, columnEnd] != null && (piecesDevour(pieces, rowStart, columnStart, rowEnd, columnEnd) && (a == rowY && a == columnX)))
                {
                    BishopNorthWest = true;
                }
                else if (pieces[rowEnd, columnEnd] == null && (a == rowY && a == columnX))
                {
                    BishopNorthWest = true;
                }
                else
                {
                    BishopNorthWest = false;
                }

                rowY = rowY * (-1);

                columnX = columnX * (-1);
            }


            if (rowY > 0 && columnX > 0)
            {
                try
                {
                    while (pieces[rowStart + 1 + a, columnStart + 1 + a] == null && (columnStart + 1 + a) != columnEnd && (rowStart + 1 + a) != rowEnd)
                    {

                        a++;
                    }
                    a = a + 1;
                }
                catch (Exception e)
                {
                    if (rowStart > 8)
                    {
                        while (pieces[8, columnEnd] == null)
                        {

                            a++;
                        }


                    }
                    else if (columnStart > 8)
                    {
                        while (pieces[rowEnd, 8] == null)
                        {

                            a++;
                        }


                    }
                    else
                    {
                        while (pieces[8, 8] == null)
                        {

                            a++;
                        }

                    }

                }

                if ((a != rowY && a != columnX))
                {
                    BishopSouthEast = false;
                }
                else if (pieces[rowEnd, columnEnd] != null && (piecesDevour(pieces, rowStart, columnStart, rowEnd, columnEnd) && (a == rowY && a == columnX)))
                {
                    BishopSouthEast = true;
                }
                else if (pieces[rowEnd, columnEnd] == null && (a == rowY && a == columnX))
                {
                    BishopSouthEast = true;
                }
                else
                {
                    BishopSouthEast = false;
                }
            }

            // /////////////////////
            // BishopSouthWest//////////////////////////////////////

            if (rowY > 0 && columnX < 0)
            {
                try
                {
                    while (pieces[rowStart + 1 + a, columnStart - 1 - a] == null && (columnStart - 1 - a) != columnEnd && (rowStart + 1 + a) != rowEnd)
                    {

                        a++;
                    }
                    a = a + 1;
                    //  System.out.println(" The value of a is: "+a + "The value of rowY is: "+ rowY +" The value of columnX is" + columnX );
                }

                catch (Exception e)
                {
                    if (rowStart > 8)
                    {
                        while (pieces[8, columnEnd] == null)
                        {
                            a++;
                        }
                    }
                    else if (columnStart < 1)
                    {
                        while (pieces[rowEnd, 8] == null)
                        {

                            a++;
                        }
                    }
                    else
                    {
                        while (pieces[8, 8] == null)
                        {

                            a++;
                        }

                    }
                }
                if (rowY < 0)
                {
                    rowY = rowY * (-1);
                }
                if (columnX < 0)
                {
                    columnX = columnX * (-1);
                }

                if ((a != rowY && a != columnX))
                {

                }
                else if (pieces[rowEnd, columnEnd] != null && (piecesDevour(pieces, rowStart, columnStart, rowEnd, columnEnd) && (a == rowY && a == columnX)))
                {
                    // System.out.println(" The value of a is: "+a);
                    BishopSouthWest = true;
                }
                else if (pieces[rowEnd, columnEnd] == null && (a == rowY && a == columnX))
                {
                    BishopSouthWest = true;
                }
                else
                {
                    BishopSouthWest = false;
                }
                columnX = columnX * (-1);

            }
            // /////////////////////////BishopNorthEast
            // ////////////////////////////////////////BishopSouthWest///////////////////////////////////////////BishopSouthWest////////////////////////////
            // 4+-
            if (rowY < 0 && columnX > 0)
            {
                try
                {
                    while (pieces[rowStart - 1 - a, columnStart + 1 + a] == null && (columnStart + 1 + a) != columnEnd && (rowStart - 1 - a) != rowEnd)
                    {

                        a++;
                    }
                    a = a + 1;
                }
                catch (Exception e)
                {
                    if (rowStart < 1)
                    {
                        while (pieces[8, columnEnd] == null)
                        {
                            a++;
                        }
                    }
                    else if (columnStart > 8)
                    {
                        while (pieces[rowEnd, 8] == null)
                        {

                            a++;
                        }
                    }
                    else
                    {
                        while (pieces[8, 8] == null)
                        {
                            a++;
                        }
                    }
                }
                if (rowY < 0)
                {
                    rowY = rowY * (-1);
                }
                if (columnX < 0)
                {
                    columnX = columnX * (-1);
                }
                if ((a != rowY && a != columnX))
                {
                    BishopNorthEast = false;
                }
                else if (pieces[rowEnd, columnEnd] != null && pieces[rowStart, columnStart] != null && (piecesDevour(pieces, rowStart, columnStart, rowEnd, columnEnd) && (a == rowY && a == columnX)))
                {
                    BishopNorthEast = true;
                }
                else if (pieces[rowEnd, columnEnd] == null && (a == rowY && a == columnX))
                {
                    BishopNorthEast = true;
                }
                else
                {
                    BishopNorthEast = false;
                }
            }
           
            
            return BishopSouthWest || BishopNorthEast || BishopSouthEast || BishopNorthWest|| isRookMovingUp || isRookMovingDown || isRookMovingLeft || isRookMovingRight;
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
