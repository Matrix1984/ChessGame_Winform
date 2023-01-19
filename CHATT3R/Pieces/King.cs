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
    class King : Pieces
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
        public static int y;
        public static int x;

        public King(string s)
        {
            this.name = s;
        }

        public override Image print()
        {
            if (name[0] == 'W')
            {
                return Properties.Resources.WQueen;
            }
            else
            {
                return Properties.Resources.BQueen;
            }
        }

        public override string pieceName()
        {
            return this.name;
        }

        public override bool pieceCollision(Pieces[,] pieces, int rowStart, int columnStart, int rowEnd, int columnEnd)
        {
            bool KingMoved = false;
            int b = 0;
            bool rowUpperRangeLimit = false;
            bool columnUpperRangeLimit = false;
            bool rowLowerRangeLimit = false;
            bool columnLowerRangeLimit = false;
            bool kingCantMoveCauseWillGetChecked = false;

            if (rowEnd <= 8)
            {
                rowUpperRangeLimit = true;
            }
            if (rowEnd >= 1)
            {
                rowLowerRangeLimit = true;

            }
            if (columnEnd <= 8)
            {
                columnUpperRangeLimit = true;
            }
            if (columnEnd >= 1)
            {
                columnLowerRangeLimit = true;
            }
            if (rowUpperRangeLimit == true && rowStart + 1 == rowEnd && columnStart == columnEnd)
            {//Down

                b = 1;
            }
            else if (rowLowerRangeLimit == true && rowStart - 1 == rowEnd && columnStart == columnEnd)
            {//Up

                b = 1;
            }
            else if (columnUpperRangeLimit == true && columnStart + 1 == columnEnd && rowStart == rowEnd)
            {//Right

                b = 1;
            }
            else if (columnLowerRangeLimit == true && columnStart - 1 == columnEnd && rowStart == rowEnd)
            {// Left

                b = 1;
            }
            else if (columnUpperRangeLimit == true && rowUpperRangeLimit == true && rowStart + 1 == rowEnd && columnStart + 1 == columnEnd)
            {//NorthEast

                b = 1;
            }
            else if (columnUpperRangeLimit == true && rowLowerRangeLimit == true && rowStart - 1 == rowEnd && columnStart + 1 == columnEnd)
            {//SouthEast

                b = 1;
            }
            else if (columnLowerRangeLimit == true && rowUpperRangeLimit == true && rowStart + 1 == rowEnd && columnStart - 1 == columnEnd)
            {//NorthWest

                b = 1;
            }
            else if (columnLowerRangeLimit == true && rowLowerRangeLimit == true && rowStart - 1 == rowEnd && columnStart - 1 == columnEnd)
            {//SouthWest

                b = 1;
            }
            else
            {

                b = 0;
            }
            //rowX!=0)?(b!=rowX):(b!=columnY)	
            if (b == 0)
            {
                KingMoved = false;

            }
            else if (pieces[rowEnd, columnEnd] != null && piecesDevour(pieces, rowStart, columnStart, columnEnd, rowEnd))
            {
                KingMoved = true;

            }	 // IF B SMALLER THAN THE DIFFERENCE BETWEEN COLUMNSTART & COLUMNEND (SPACESY) , GIVE FALSE. OTHERWISE GIVE TRUE.
            else if (pieces[rowEnd, columnEnd] == null && b == 1)
            {
                KingMoved = true;

            }
            else
            {
                KingMoved = false;

            }
            if ((Class2.counter % 2 != 0) && pieces[rowStart, columnStart] is King && pieces[rowStart, columnStart] != null && pieces[rowStart, columnStart].pieceName()[0] == 'W' && KingMoved)
            {
               // y++;
            }
            if ((Class2.counter % 2 == 0) && pieces[rowStart, columnStart] is King && pieces[rowStart, columnStart] != null && pieces[rowStart, columnStart].pieceName()[0] == 'B' && KingMoved)
            {
                //x++;
            }
            //CheckAlgorithm checkAlgorithm = new CheckAlgorithm();
            //if (checkAlgorithm.checkCheck(pieces, rowStart, columnStart, rowStart, columnStart))
            //{
            //    kingCantMoveCauseWillGetChecked = true;
            //}
       
            return KingMoved ;
        }

       




        /////////End King Piece Collision//////////////////////////End King Piece Collision////////////////////////
        public static int getX()
        {
            return x;

        }
        public static int getY()
        {
            return y;
        }
        //at il.co.King.King.piecesDevour(King.java:285)
        //at il.co.King.King.piecesCollision(King.java:193)
        ////////Castling///////////////////////////////Castling////////////////////////////////////////////////	

        /////////////////Piece Endevour////////////////////////////////////////////////////////////////////////


        public override bool piecesDevour(Pieces[,] pieces, int rowStart, int columnStart, int columnEnd, int rowEnd)
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
            bool pieceNotThreatened = true;

      
            return pieceDevour ;
        }

    
        public override bool pieceMovement(Pieces[,] pieces, int rowStart, int columnStart, int rowEnd, int columnEnd)
        {
            bool pieceNotThreatened = true;
            CheckAlgorithm checkA = new CheckAlgorithm();
            for (int z1 = 1; z1 < 9; z1++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if (pieces[z1, j] != null && pieces[z1, j].pieceName()[0] != pieces[rowStart, columnStart].pieceName()[0] && checkA.CantMoveIfCreatedCheck(pieces,rowStart,columnStart,rowEnd,columnEnd ))
                    {
                        pieceNotThreatened = false;
                        break;
                    }
                }
                if (!pieceNotThreatened) { break; }
            }
            //bool kingNearKing = false;
            //if (KingCantApproachKing(pieces, rowStart, columnStart, rowEnd, columnEnd))
            //{
            //    kingNearKing = true;
            //}
            return  pieceNotThreatened && pieceCollision(pieces, rowStart, columnStart, rowEnd, columnEnd) ;
        }

        public bool KingCantApproachKing(Pieces[,] pieces, int rowStart, int columnStart, int rowEnd, int columnEnd)
        {
            bool cantDevourKing = false;
            if (pieces[rowStart, columnStart].pieceName() == "WK")
            {
                for (int i = 1; i < 9; i++)
                {
                    for (int j = 1; j < 9; j++)
                    {
                        if (pieces[i, j] != null && pieces[i, j].pieceName() == "BK" && pieces[i, j].pieceMovement(pieces, i, j, rowEnd, columnEnd))
                        {
                            
                            cantDevourKing = true;
                            break;

                        }
                    }
                    if (cantDevourKing) {  break; }
                }
            }

            if (pieces[rowStart, columnStart].pieceName() == "BK")
            {
                for (int i = 1; i < 9; i++)
                {
                    for (int j = 1; j < 9; j++)
                    {
                        if (pieces[i, j] != null && pieces[i, j].pieceName() == "WK" && pieces[i, j].pieceMovement(pieces, i, j, rowEnd, columnEnd))
                        {
                            cantDevourKing = true;
                            break;

                        }
                    }
                    if (cantDevourKing) {  break; }
                }

            }
            return cantDevourKing; 
        }

       
    }

}
