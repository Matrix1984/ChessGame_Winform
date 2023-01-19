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
    class CastlingMeh
    {

        public bool Castling(Pieces[,] pieces, int rowStart, int columnStart, int rowEnd, int columnEnd, bool BlackKingToMoveRIGHT, bool BlackKingToMoveLEFT, bool WhiteKingToMoveRIGHT, bool whiteKingToMoveLEFT)
        {
            bool right = columnEnd > columnStart;
            bool left = columnEnd < columnStart;
            bool fieldClearRIGHT = false;
            bool fieldClearLEFT = false;
            bool castling2 = false;



            if ((rowStart == 8 && columnStart == 4 && (columnEnd == 6 || columnEnd == 2)) || (rowStart == 1 && columnStart == 4 && (columnEnd == 6 || columnEnd == 2)))
            {
                castling2 = true;

            }

            if (castling2  && right)
            {
                if (pieces[8, 4] == pieces[rowStart, columnStart])
                {
                    if (WhiteKingToMoveRIGHT == true && pieces[8, 5] == null && pieces[8, 6] == null && pieces[8, 7] == null && pieces[8, 8] is Rook)
                        fieldClearRIGHT = true;
                }
                else if (BlackKingToMoveRIGHT == right && pieces[1, 4] == pieces[rowStart, columnStart] && (pieces[1, 5] == null && pieces[1, 6] == null && pieces[1, 7] == null && pieces[1, 8] is Rook))
                {
                    fieldClearRIGHT = true;

                }
                else
                {
                    fieldClearRIGHT = false;
                }
            }
            if (castling2  && left)
            {
                if (pieces[8, 4] == pieces[rowStart, columnStart])
                {
                    if (whiteKingToMoveLEFT == true && pieces[8, 3] == null && pieces[8, 2] == null && pieces[8, 1] is Rook)
                    {
                        fieldClearLEFT = true;
                    }
                }
                else if (BlackKingToMoveLEFT == true && pieces[1, 4] == pieces[rowStart, columnStart] && (pieces[1, 3] == null && pieces[1, 2] == null && pieces[1, 1] is Rook))
                {
                    fieldClearLEFT = true;
                }
            }
            return fieldClearRIGHT || fieldClearLEFT;
        }



        public Pieces[,] CastlingCheck(Pieces[,] pieces, int rowStart, int columnStart, int rowEnd, int columnEnd)
        {
            bool BlackKingToMoveRIGHT = false;
            bool BlackKingToMoveLEFT = false;
            bool WhiteKingToMoveRIGHT = false;
            bool whiteKingToMoveLEFT = false;
            int whiteMoveCount = King.getX();
            int blackMoveCount = King.getY();
            int[] thePositions = new int[4];
            ChessBoard chess = new ChessBoard();
            int[] ArrayOfRightPositions;

            if ((rowStart == 8 && columnStart == 4 && (columnEnd == 6 || columnEnd == 2)) || (rowStart == 1 && columnStart == 4 && (columnEnd == 6 || columnEnd == 2)))
            {
                bool right = columnEnd > columnStart;
                bool left = columnEnd < columnStart;

                if (left)
                {
                    whiteKingToMoveLEFT = true;
                    if (whiteMoveCount == 0 && rowStart == 8 & rowEnd == 8 & columnStart == 4 & columnEnd == 2 && Castling(pieces, rowStart, columnStart, rowEnd, columnEnd, BlackKingToMoveRIGHT, BlackKingToMoveLEFT, WhiteKingToMoveRIGHT, whiteKingToMoveLEFT))
                    {//Check if position is not threatened..
                        if (CheckIfCastlingPositionIsNotThreatened(pieces, true, false, false, true))
                        {
                            pieces[8, 3] = new Rook("WR2");
                            pieces[8, 1] = null;
                            pieces[8, 2] = new King("WK");
                            pieces[8, 4] = null;

                            Class2.counter++;
                     
                        }
                    }

                    whiteKingToMoveLEFT = false;
                    BlackKingToMoveLEFT = true;

                    if (blackMoveCount == 0 && rowStart == 1 & rowEnd == 1 & columnStart == 4 & columnEnd == 2 && Castling(pieces, rowStart, columnStart, rowEnd, columnEnd, BlackKingToMoveRIGHT, BlackKingToMoveLEFT, WhiteKingToMoveRIGHT, whiteKingToMoveLEFT))
                    {//Check if position is not threatened..
                        if (CheckIfCastlingPositionIsNotThreatened(pieces, false, true, false, true))
                        {
                            pieces[1, 3] = new Rook("BR2");
                            pieces[1, 1] = null;
                            pieces[1, 2] = new King("BK");
                            pieces[1, 4] = null;
                            Class2.counter++;
                     
                        }
                    }
                }
                if (right)
                {
                    whiteKingToMoveLEFT = false;
                    BlackKingToMoveLEFT = false;
                    WhiteKingToMoveRIGHT = true;

                    if (whiteMoveCount == 0 && rowStart == 8 & rowEnd == 8 & columnStart == 4 & columnEnd == 6 && Castling(pieces, rowStart, columnStart, rowEnd, columnEnd, BlackKingToMoveRIGHT, BlackKingToMoveLEFT, WhiteKingToMoveRIGHT, whiteKingToMoveLEFT))
                    {
                        if (CheckIfCastlingPositionIsNotThreatened(pieces, true, false, true, false))
                        {
                            pieces[8, 5] = new Rook("WR1");
                            pieces[8, 8] = null;
                            pieces[8, 6] = new King("WK");
                            pieces[8, 4] = null;
                            Class2.counter++;
                       
                        }
                    }
                    whiteKingToMoveLEFT = false;
                    BlackKingToMoveLEFT = false;
                    WhiteKingToMoveRIGHT = false;
                    BlackKingToMoveRIGHT = true;

                    if (blackMoveCount == 0 && rowStart == 1 & rowEnd == 1 & columnStart == 4 & columnEnd == 6 && Castling(pieces, rowStart, columnStart, rowEnd, columnEnd, BlackKingToMoveRIGHT, BlackKingToMoveLEFT, WhiteKingToMoveRIGHT, whiteKingToMoveLEFT))
                    {
                        if (CheckIfCastlingPositionIsNotThreatened(pieces, false, true, true, false))
                        {
                            pieces[1, 5] = new Rook("BR1");
                            pieces[1, 8] = null;
                            pieces[1, 6] = new King("BK");
                            pieces[1, 4] = null;
                            Class2.counter++;
                        }
                    }
                }
            }
            return pieces;
        }
        int[,] WHITE_CASTLING_RIGHT = { { 8, 5 }, { 8, 6 }, { 8, 7 }, { 8, 8 } };
        int[,] WHITE_CASTLING_LEFT = { { 8, 4 }, { 8, 3 }, { 8, 2 }, { 8, 1 } };
         int[,] BLACK_CASTLING_RIGHT = { { 1, 5 }, { 1, 6 }, { 1, 7 }, { 1, 8 } };
        int[,] BLACK_CASTLING_LEFT ={ { 1, 4 }, { 1, 3 }, { 1, 2 }, { 1, 1 } };
        public static bool castlingMoveMade = false;
        public bool CheckIfCastlingPositionIsNotThreatened(Pieces[,] pieces, bool whiteKing,bool blackKing, bool rightSideCastling, bool leftSideCastling)
        {
            bool isTheCastlingUnsafe = false;
           
            if (whiteKing && rightSideCastling)
            {
                isTheCastlingUnsafe = CheckIfPositionsThreatenedWhiteKingRightSideCastling(pieces, WHITE_CASTLING_RIGHT);
            }

            if (whiteKing && leftSideCastling)
            {
                isTheCastlingUnsafe = CheckIfPositionsThreatenedWhiteKingLeftSideCastling(pieces, WHITE_CASTLING_LEFT);
            }

            if (blackKing && rightSideCastling)
            {
                isTheCastlingUnsafe = CheckIfPositionsThreatenedBlackKingRightSideCastling(pieces, BLACK_CASTLING_RIGHT);
              
            }

            if (blackKing && leftSideCastling)
            {
                isTheCastlingUnsafe = CheckIfPositionsThreatenedBlackKingLeftSideCastling(pieces, BLACK_CASTLING_LEFT);
            }
            castlingMoveMade = isTheCastlingUnsafe;
            if (!isTheCastlingUnsafe ) { MessageBox.Show("Note: 1)Cant use Castling, while a threat exists. 2)It isnt your turn. "); }
            return isTheCastlingUnsafe ;
        }

        public bool CheckIfPositionsThreatenedWhiteKingRightSideCastling(Pieces[,] pieces, int[,] checkThisArray)
        {
            int a=0;
            bool positionIsSafe = true;
            while (3 > a)
            {
             
                for (int i = 1; i < 9; i++)
                {
                    for (int j = 1; j < 9; j++)
                    {
                        if (pieces[i, j] != null && pieces[i, j].pieceName()[0] == 'B' && pieces[i, j].pieceCollision(pieces, i, j, checkThisArray[a, 0], checkThisArray[a, 1]))
                        {
                            positionIsSafe = false;
                            break;
                        }
                    }
                }
                a++;
            }
            return positionIsSafe && (Class2.counter % 2 != 0);
        }

        public bool CheckIfPositionsThreatenedWhiteKingLeftSideCastling(Pieces[,] pieces, int[,] checkThisArray)
        {
            int a = 0;
            bool positionIsSafe = true;
            while (3 > a)
            {
               
                for (int i = 1; i < 9; i++)
                {
                    for (int j = 1; j < 9; j++)
                    {
                        if (pieces[i, j] != null && pieces[i, j].pieceName()[0] == 'B' && pieces[i, j].pieceCollision(pieces, i, j, checkThisArray[a, 0], checkThisArray[a, 1]))
                        {
                            positionIsSafe = false;
                            break;
                        }
                    }
                }
                a++;
            }
            bool whatSide = Class2.counter % 2 != 0;
            return positionIsSafe && (Class2.counter % 2 != 0);
        }

        public bool CheckIfPositionsThreatenedBlackKingRightSideCastling(Pieces[,] pieces, int[,] checkThisArray)
        {
            int a = 0;
            bool positionIsSafe = true;
            while (3 > a)
            {
              
                for (int i = 1; i < 9; i++)
                {
                  
                    for (int j = 1; j < 9; j++)
                    {
                      
                        if (pieces[i, j] != null && pieces[i, j].pieceName()[0] == 'W' && pieces[i, j].pieceCollision(pieces, i, j, checkThisArray[a, 0], checkThisArray[a, 1]))
                        {
                            positionIsSafe = false;
                            break;
                        }
                    }
                }
                a++;
            }
            return positionIsSafe && (Class2.counter % 2 == 0);
        }

        public bool CheckIfPositionsThreatenedBlackKingLeftSideCastling(Pieces[,] pieces, int[,] checkThisArray)
        {
            int a = 0;
            bool positionIsSafe = true;
            while (3 > a)
            {
               
                for (int i = 1; i < 9; i++)
                {
                    for (int j = 1; j < 9; j++)
                    {
                        if (pieces[i, j] != null && pieces[i, j].pieceName()[0] == 'W' && pieces[i, j].pieceCollision(pieces, i, j, checkThisArray[a, 0], checkThisArray[a, 1]))
                        {
                            positionIsSafe = false;
                            break;
                        }
                    }
                }
                a++;
            }
            return positionIsSafe && (Class2.counter % 2 == 0);
        }
    }
}
