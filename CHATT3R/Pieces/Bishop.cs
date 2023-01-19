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
    class Bishop : Pieces
    {
        string name;
        int columnEnd;
        int columnStart;
        int rowStart;
        bool valid;
        char firstLetter;
        char secondLetter;
        bool pieceDevour;
        string chessPiece;
        bool secondLetterNotNull;

        public Bishop(string piece)
        {
            name = piece;
        }

        public override Image print()
        {
            if (name[0] == 'W')
            {
                return Properties.Resources.WBishop;
            }
            else
            {
                return Properties.Resources.BBishop;
            }
        }

        public override string pieceName()
        {
            return this.name;
        }



        public override bool pieceCollision(Pieces[,] pieces, int rowStart, int columnStart, int rowEnd, int columnEnd)
        {
            int columnX = columnEnd - columnStart;
            int rowY = rowEnd - rowStart;
            bool BishopNorthEast = false;
            bool BishopNorthWest = false;
            bool BishopSouthWest = false;
            bool BishopSouthEast = false;
            int a = 0;

            int deltaX = columnEnd - columnStart;
            deltaX = deltaX < 0 ? -deltaX : deltaX;
            int deltaY = rowEnd - rowStart;
            deltaY = deltaY < 0 ? -deltaY : deltaY;
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
            return deltaY == deltaX && ( BishopSouthWest || BishopNorthEast || BishopSouthEast || BishopNorthWest);
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
            return  pieceCollision(pieces,rowStart,columnStart,rowEnd,columnEnd);
        }
    }
}
