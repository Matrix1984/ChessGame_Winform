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
    class Stalemate 
    {
        public int stalemateRow;
        public int stalemateColumn;
        public static bool WhitecheckIfAnyRemainingPiecesCanMove(Pieces[,] pieces)
        {
            bool noPieceCanMove=true;
            
                for (int i = 1; i < 9; i++)
                {
                    for (int j = 1; j < 9; j++)
                    {
                        if (pieces[i, j] != null && pieces[i, j].pieceName()[0] == 'W' && !(pieces[i, j] is King) )
                        {
                            for (int m = 1; m < 9; m++)
                            {
                                for (int n = 1; n < 9; n++)
                                {
                                    if (pieces[i, j].pieceCollision(pieces, i, j, m, n))
                                    {
                                        noPieceCanMove = false;
                                        break;
                                    }
                                }
                                if (!noPieceCanMove) { break; }
                            }
                            if (!noPieceCanMove) { break; }
                        }
                    }
                    if (!noPieceCanMove) { break; }
                }
            return  noPieceCanMove;
        }

        public static bool BlackcheckIfAnyRemainingPiecesCanMove(Pieces[,] pieces)
          {
                    bool noPieceCanMove=true;
                    for (int i = 1; i < 9; i++)
                    {
                        for (int j = 1; j < 9; j++)
                        {
                            if (pieces[i, j] != null && pieces[i, j].pieceName()[0] == 'B' && !(pieces[i, j] is King))
                            {
                                for (int m = 1; m < 9; m++)
                                {
                                    for (int n = 1; n < 9; n++)
                                    {
                                        if (pieces[i, j].pieceCollision(pieces, i, j, m, n))
                                        {
                                            //MessageBox.Show(pieces[i, j].pieceName() + " can move");
                                            noPieceCanMove = false;
                                            break;

                                        }
                                    }
                                    if (!noPieceCanMove) { break; }
                                }
                            }
                            if (!noPieceCanMove) { break; }
                        }
                        if (!noPieceCanMove) { break; }
                    }
   
            return noPieceCanMove;
        }

        public bool CheckForAnyBlackPawns(Pieces[,] pieces)
        {
            bool noPawnsExists = false;
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if (pieces[i, j] != null && pieces[i, j].pieceName() == "BP" )
                    {
                        noPawnsExists = true;
                        break;
                    }
                }
                if (noPawnsExists) { break; }
            }
            return noPawnsExists;
        }

        public bool CheckForAnyWhitePawns(Pieces[,] pieces)
        {
            bool noPawnsExists = false;
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if (pieces[i, j] != null && pieces[i, j].pieceName() == "WP")
                    {
                        noPawnsExists = true;
                        break;
                    }
                }
                if (noPawnsExists) { break; }
            }
            return noPawnsExists;
        }

        public bool StalemateManager(Pieces[,] pieces)
        {
            ChessBoard chess = new ChessBoard();


            if (StalemateIfExists(pieces) == 1)
            {
                if (StalemateIsKing(pieces, true))
                {
                    if (AllPositionsBlackKingMoveToCheckThreat(pieces))
                    {
                        Class2.Stalemated = true;
                        chess.Stalemate();
                    }
                }
            }
            else
            {
                if (CheckForAnyBlackPawns(pieces) && StalemateIsKing(pieces, true))
                {
                    if (BlackcheckIfAnyRemainingPiecesCanMove(pieces))
                    {
                        if (!IsBlackKingMovementPossible(pieces))
                        {
                            Class2.Stalemated = true;
                            chess.Stalemate();
                        }
                    }
                }
            }


            // if there is white piece
            if (StalemateIfExists(pieces) == 2)
            {
                if (StalemateIsKing(pieces, false))
                {
                    if (AllPositionsWhiteKingMoveToCheckThreat(pieces) )
                    {
                        Class2.Stalemated = true;
                        chess.Stalemate();
                    }
                }
            }
            else
            {
                if (CheckForAnyWhitePawns(pieces) && StalemateIsKing(pieces, false))
                {
                    if (WhitecheckIfAnyRemainingPiecesCanMove(pieces))
                    {
                        if (!IsWhiteKingMovementPossible(pieces))
                        {
                            Class2.Stalemated = true;
                            chess.Stalemate();
                        }
                    }
                }
            }



            return false;
        }

         public int StalemateIfExists(Pieces[,] pieces)
        {
            int countWhitePieces = 0;
            int countBlackPieces = 0;
            // scans to see if there is one piece on black of white side.
            for (int z1 = 1; z1 < 9; z1++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if (pieces[z1, j] != null && pieces[z1, j].pieceName()[0] == 'W')
                    {
                        countWhitePieces++;
                    }
                    if (pieces[z1, j] != null && pieces[z1, j].pieceName()[0] == 'B')
                    {
                        countBlackPieces++;
                    }
                }
            }

            if (countWhitePieces == 1)
            {
                return 2;
            }
            else if (countBlackPieces == 1)
            {
                return 1;
            }
            else if (countWhitePieces == 1 && countBlackPieces == 1)
            {
                return 3;
            }
            else
            {
                return 0;
            }
        }

        public bool StalemateIsKing(Pieces[,] pieces, bool BlackPiece)
        {
            bool whetherIsKing = false;
            //Finds the king and notifies whether it is a king piece.
            if (BlackPiece)
            {
                for (int z1 = 1; z1 < 9; z1++)//Find black King
                {
                    for (int j = 1; j < 9; j++)
                    {
                        if (pieces[z1, j]!=null && pieces[z1, j].pieceName() == "BK")
                        {
                            whetherIsKing = true;
                            stalemateRow = z1;
                            stalemateColumn = j;
                        }

                    }
                }
            }
            else
            {
                for (int z1 = 1; z1 < 9; z1++)//Find white King
                {
                    for (int j = 1; j < 9; j++)
                    {
                        if (pieces[z1, j] != null && pieces[z1, j].pieceName() == "WK")
                        {
                            whetherIsKing = true;
                            stalemateRow = z1;
                            stalemateColumn = j;
                        }

                    }
                }
            }

            return whetherIsKing;
        }

        public bool AllPositionsWhiteKingMoveToCheckThreat(Pieces[,] pieces)
        {
            bool WhiteIsInStalemate = false;
            int[] potentialRow = new int[9];
            int[] potentialColumn = new int[9];
            int potentialPositionCount = 0;
            int loopCount = 0;
            int numberPositionsThreatened = 0;
            int numberPositionsCanMoveTo = 0;

            for (int z1 = 1; z1 < 9; z1++)//Find if white King can move to other positions
            {
                for (int j = 1; j < 9; j++)
                {
                    if (pieces[stalemateRow, stalemateColumn].pieceCollision(pieces, stalemateRow, stalemateColumn, z1, j) && pieces[stalemateRow, stalemateColumn].pieceMovement(pieces, stalemateRow, stalemateColumn, z1, j))
                    {
                        numberPositionsCanMoveTo++;
                        potentialPositionCount++;
                        potentialRow[potentialPositionCount] = z1;
                        potentialColumn[potentialPositionCount] = j;
                    }
                }
            }

            while (potentialPositionCount > loopCount)
            {
                for (int z1 = 1; z1 < 9; z1++)//Scans through all potential white kings positions to see if they are safe or not.
                {
                    for (int j = 1; j < 9; j++)
                    {
                        try
                        {
                            if (pieces[z1, j] != null && pieces[z1, j].pieceCollision(pieces, z1, j, potentialRow[loopCount++], potentialColumn[loopCount++]) && pieces[z1, j].pieceMovement(pieces, z1, j, potentialRow[loopCount++], potentialColumn[loopCount++]))
                            {
                                numberPositionsThreatened++;
                            }
                         
                        }
                        catch (Exception e)
                        {
                            loopCount -= 1;
                        }

                    }
                }


            }

            if (numberPositionsThreatened == loopCount)
            {
                WhiteIsInStalemate = true;
            }

            return WhiteIsInStalemate;
        }

        public bool AllPositionsBlackKingMoveToCheckThreat(Pieces[,] pieces)
        {
            bool blackIsInStalemate = false;
            int numberPositionsThreatened = 0;
            int numberPositionsCanMoveTo = 0;
            int[] potentialRow = new int[9];
            int[] potentialColumn = new int[9];
            int potentialPositionCount = 0;
            int loopCount = 0;
            //Find if black King can move to other positions
            for (int z1 = 1; z1 < 9; z1++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if (pieces[stalemateRow, stalemateColumn].pieceCollision(pieces, stalemateRow, stalemateColumn, z1, j) && pieces[stalemateRow, stalemateColumn].pieceMovement(pieces, stalemateRow, stalemateColumn, z1, j))
                    {
                        //Finds the number of positions a king can move to.
                        numberPositionsCanMoveTo++;

                        // records those positions in the array
                        potentialPositionCount++;
                        potentialRow[potentialPositionCount] = z1;
                        potentialColumn[potentialPositionCount] = j;
                    }
                }
            }
            //The loop should run the times that the number 
            //of available positions are available for the king to move to.
            while (potentialPositionCount > loopCount)
            {
                //Scans through all potential black kings 
                //positions to see if they are safe or not.
                for (int z1 = 1; z1 < 9; z1++)
                {
                    for (int j = 1; j < 9; j++)
                    {
                        //Checks if the enemies pieces can move to the position the king can move to.
                        try
                        {
                            if (pieces[z1, j] != null && pieces[z1, j].pieceCollision(pieces, z1, j, potentialRow[loopCount++], potentialColumn[loopCount++]) && pieces[z1, j].pieceMovement(pieces, z1, j, potentialRow[loopCount++], potentialColumn[loopCount++]))
                            {
                                numberPositionsThreatened++;
                            }
                        }
                        catch (Exception e)
                        {
                            loopCount -= 1;
                        }
                    }
                }
            }
            // if the number of positions threatened equals to the number of kings 
            //potential moves then there is a stalemate
            if (numberPositionsThreatened == loopCount)
            {
                blackIsInStalemate = true;
            }

            return blackIsInStalemate ;
        }


        public bool IsWhiteKingMovementPossible(Pieces[,] pieces)
        {
            bool canMove=false;
             
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if(pieces[stalemateRow,  stalemateColumn].pieceMovement(pieces,stalemateRow,  stalemateColumn,i,j))
                    {
                        canMove=true;
                        break;
                    }
                }
                if (canMove) { break; }
            }
            return canMove;
        }
        public bool IsBlackKingMovementPossible(Pieces[,] pieces)
        {
            bool canMove = false;

            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if (pieces[stalemateRow, stalemateColumn].pieceMovement(pieces, stalemateRow, stalemateColumn, i, j))
                    {
                        canMove = true;
                        break;
                    }
                }
                if (canMove) { break; }
            }
            return canMove;
        }
    }
}

