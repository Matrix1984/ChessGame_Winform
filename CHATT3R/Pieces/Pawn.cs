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
    class Pawn : Pieces
    {
        int columnEnd;
        int rowEnd;
        int columnStart;
        int rowStart;
        string name;
        bool simpleMove;
        bool twoSquareMove;
        bool devourMove;
        bool valid;
        string chessPiece;
        bool pieceDevour;
        char firstLetter;
        char secondLetter;


        public Pawn(string piece)
        {
            this.name = piece;
        }

        public override Image print()
        {
            if (name[0] == 'W')
            {
                return Properties.Resources.WPawn;
            }
            else
            {
                return Properties.Resources.BPawn;
            }
        }

        public override string pieceName()
        {
            return this.name;
        }


        public override bool pieceCollision(Pieces[,] pieces, int rowStart, int columnStart, int rowEnd, int columnEnd)
        {
            bool isPawnMovingUP = false;
            bool calculationIsSafe = false;
            bool isPawnMovingRIGHT = false;
            bool isPawnMovingDOWN = false;
            bool isPawnMovingLEFT = false;
            bool cantDevourVertically = false;
            bool rangeSafe = false;
            if ((rowStart - 1) > 0 && (columnStart + 1) < 9)
            {
                calculationIsSafe = true;
            }
            if ((rowEnd - 1) > 0 && (columnEnd + 1) < 9)
            {
                rangeSafe = true;
            }
            ///White///////////////////////Moving up/////////////////////////Moving up/////////////////////////////////////
            ///
            if (pieces[rowEnd, columnEnd] == null)
            {
                cantDevourVertically = true;
            }

            if (pieces[rowStart, columnStart]!=null && pieces[rowStart, columnStart].pieceName() == "WP")
            {
                if (cantDevourVertically && pieces[rowEnd, columnEnd] == null && rowStart == 7 && (rowEnd == 6 || (rowEnd == 5 && pieces[6, columnEnd]==null)) && columnStart == columnEnd)
                {
                    isPawnMovingUP = true;

                }
                else
                {
                    isPawnMovingUP = false;
                }

                if ((rowStart - 1) == rowEnd && pieces[rowEnd, columnEnd] == null && columnStart == columnEnd)
                {
                    isPawnMovingUP = true;

                }


            }

            //Black//////////////////Moving Down/////////////////////////////////Moving Down//////////////////////////////// 

            if (cantDevourVertically && pieces[rowStart, columnStart].pieceName() == "BP")
            {

                if ((rowStart == 2 && ((rowEnd == 4 && pieces[3, columnEnd] == null) || rowEnd == 3)) && columnStart == columnEnd)
                {
                    isPawnMovingDOWN = true;
                }
                else if ( (rowStart + 1) == rowEnd && pieces[rowEnd, columnEnd] == null && columnStart == columnEnd)
                {
                    isPawnMovingDOWN = true;

                }

            }

            //White//////////////////Moving Left/////////////////////////////////Moving Left////////////////////////////////

            if (pieces[rowStart, columnStart].pieceName()[0] == 'W')
            {
                if ((rowStart - 1) == rowEnd && (columnStart - 1) == columnEnd && pieces[rowEnd, columnEnd] != null && piecesDevour(pieces, rowStart, columnStart, rowEnd, columnEnd) == true && columnStart != columnEnd)
                {
                    isPawnMovingLEFT = true;
                }
                else if ((rowStart - 1) == rowEnd && (columnStart + 1) == columnEnd && pieces[rowEnd, columnEnd] != null && piecesDevour(pieces, rowStart, columnStart, rowEnd, columnEnd) == true && columnStart != columnEnd)
                {
                    isPawnMovingRIGHT = true;
                }

            }


            //Black//////////////////Moving Left/////////////////////////////////Moving Left////////////////////////////////  
            //Black//////////////////Moving Left/////////////////////////////////Moving Left//////////////////////////////// 

            if (pieces[rowStart, columnStart].pieceName()[0] == 'B')
            {
                if ( (rowStart + 1) == rowEnd && (columnStart - 1) == columnEnd && pieces[rowEnd, columnEnd] != null && piecesDevour(pieces, rowStart, columnStart, rowEnd, columnEnd) == true && columnStart != columnEnd)
                {
                    isPawnMovingLEFT = true;
                }
                else if ((rowStart + 1) == rowEnd && (columnStart + 1) == columnEnd && pieces[rowEnd, columnEnd] != null && piecesDevour(pieces, rowStart, columnStart, rowEnd, columnEnd) == true && columnStart != columnEnd)
                {
                    isPawnMovingRIGHT = true;

                }

            }
            return (isPawnMovingLEFT || isPawnMovingRIGHT || isPawnMovingDOWN || isPawnMovingUP);
        }




        public override bool pieceMovement(Pieces[,] pieces, int rowStart, int columnStart, int rowEnd, int columnEnd)
        {
            return pieceCollision(pieces, rowStart, columnStart, rowEnd, columnEnd);
        }


        public override bool piecesDevour(Pieces[,] pieces, int rowStart, int columnStart, int rowEnd, int columnEnd)
        {
            bool secondLetterNotNull = false;

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
    }
}
