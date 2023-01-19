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
    class Knight : Pieces
    {

        int columnEnd;
        int rowEnd;
        int columnStart;
        int rowStart;
        char firstLetter;
        char secondLetter;
        bool pieceDevour;
        string chessPiece;
        bool secondLetterNotNull;
        string name;

        public Knight(string piece)
        {
            this.name = piece;

        }

        public override Image print()
        {
            if (name[0] == 'W')
            {
                return Properties.Resources.WKnight;
            }
            else
            {
                return Properties.Resources.BKnight;
            }
        }

        public override string pieceName()
        {
            return this.name;
        }

        public override bool pieceCollision(Pieces[,] pieces, int rowStart, int columnStart, int rowEnd, int columnEnd)
        {
            bool isKnightMoving = false;
           
           
            if ( pieces[rowEnd, columnEnd] != null && piecesDevour(pieces, rowStart, columnStart, rowEnd, columnEnd))
            {//Move to kill
                isKnightMoving = true;

            }
            else if ( pieces[rowEnd, columnEnd] == null)
            {//Move to an empty space
                isKnightMoving = true;
            }
            else
            {//Invalid move
                isKnightMoving = false;
            }
            int deltaX = columnEnd - columnStart;
            deltaX = deltaX < 0 ? -deltaX : deltaX;
            int deltaY = rowEnd - rowStart;
            deltaY = deltaY < 0 ? -deltaY : deltaY;

            return (deltaY == 2 && deltaX == 1) || (deltaY == 1 && deltaX == 2) && isKnightMoving;


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
            return pieceCollision(pieces, rowStart, columnStart, rowEnd, columnEnd);
        }
    }
}
