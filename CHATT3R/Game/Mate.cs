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

    class Mate
    {
        

        public bool MateF(Pieces[,] pieces, int kingRow, int kingColumn)
        {
            bool mate = false;
            bool dynamicCheck = false;
            int b = 1;
            int m = 1;
            int f = 1;
            int l = 1;
            CheckAlgorithm checkAlgo = new CheckAlgorithm();
            bool safeRange = false;
            int[] kingRowArray = new int[9];
            int[] kingColumnArray = new int[9];
            int[] kingRowArray2 = new int[9];
            int[] kingColumnArray2 = new int[9];
            int threatenedRow = 0;
            int threatenedColumn = 0;
            b = 1;
            m = 1;
            f = 1;
            l = 1;
            int RealKingRow = kingRow;
            int RealKingColumn = kingColumn;
            ChessBoard chess = new ChessBoard();
            bool kingIsWhite = false;
            if (pieces[RealKingRow, RealKingColumn].pieceName()[0] == 'W')
            {
                kingIsWhite = true;
            }
            int numberOfPossibilities = 0;
            //////////////SEARCHING THE LEGAL KING MOVES/////////////////////////////////////////////////////////////////////////////////////////	    
            for (int z1 = 1; z1 < 9; z1++)
            {  //Find all potential king positions
                for (int j = 1; j < 9; j++)
                {
                    if (pieces[kingRow, kingColumn] != null && pieces[kingRow, kingColumn].pieceCollision(pieces, kingRow, kingColumn, z1, j))
                    {
                        try
                        {
                            kingRowArray[f++] = z1;
                            kingColumnArray[l++] = j;
                            numberOfPossibilities = f;
                        }
                        catch (Exception d)
                        {
                            kingRowArray[8] = z1;
                            kingColumnArray[8] = j;
                        }
                    }
                }
            }

            char d2 = ' ';
            bool noCollision = false;
            bool MovementValid = false;
            bool safe = false;
            bool lettersDifferent = false;
            bool terminateLoopKingCanMoveNowhere = false;




            do
            {
                //////////////RELEASING THE LEGAL KING MOVES/////////////////////////////////////////////////////////////////////////////////////////	
                if (b < 8 && kingRowArray[b] != 0 && kingColumnArray[b] != 0)
                {
                    try
                    {
                        kingRow = kingRowArray[b];
                        kingColumn = kingColumnArray[b];
                    }
                    catch (Exception c)
                    {
                        kingRow = kingRowArray[8];
                        kingColumn = kingColumnArray[8];
                    }
                }
                else
                {
                    terminateLoopKingCanMoveNowhere = true;
                    break;
                }


             

                if (kingRow > 0 && kingColumn > 0 && kingRow < 9 && kingColumn < 9)
                {
                    safeRange = true;
                }
                else
                {
                    safeRange = false;
                }

                safe = false;
                lettersDifferent = false;
                bool kingIsMatedInThatPositionAnyway = false;
                dynamicCheck = false;
                d2 = ' ';

                noCollision = false;
                MovementValid = false;

                if (!terminateLoopKingCanMoveNowhere)
                {
                    for (int z1 = 1; z1 < 9; z1++)
                    {
                        for (int j = 1; j < 9; j++)
                        {
                            safe = false;
                            lettersDifferent = false;
                            bool kingIsUnderCollisionThreat = false;
                            dynamicCheck = false;
                            d2 = ' ';
                            noCollision = false;
                            MovementValid = false;

                            if (pieces[z1, j] != null && pieces[RealKingRow, RealKingColumn] != null && b<9)
                            {
                                safe = true;
                            }

                            if (safe && pieces[z1, j].pieceName()[0] != pieces[RealKingRow, RealKingColumn].pieceName()[0])
                            {
                                lettersDifferent = true;
                            }

                     
                            if (safe && lettersDifferent && pieces[z1, j].pieceCollision(pieces, z1, j, kingRow, kingColumn))
                            {
                                kingIsUnderCollisionThreat = true;
                            }

                            //Checks if the king moved and would be checked anyway!!!checkAlgo.CantMoveIfCreatedCheck(pieces, RealKingRow, RealKingColumn, kingRow, kingColumn) ||
                            if (!pieces[RealKingRow, RealKingColumn].pieceMovement(pieces, RealKingRow, RealKingColumn, kingRow, kingColumn))
                            {
                                kingIsMatedInThatPositionAnyway = true;
                            }


                            //if (kingIsStillInTrouble)
                            //{
                            //    if (checkIfOtherPiecesCanMoveToRescueKing(pieces, kingIsWhite, RealKingRow, RealKingColumn))
                            //    {//There is another piece that can rescue the king
                            //        dynamicCheck = true;
                            //        break;
                            //    }
                            //}


                            bool kingIsStillInTrouble = false;
                            if ((kingIsMatedInThatPositionAnyway || kingIsUnderCollisionThreat)) //|| !terminateLoopKingCanMoveNowhere))
                            {//Other pieces threaten the king to move.
                                kingIsStillInTrouble = true;
                            }
                            else
                            {
                                //If the king is not in trouble break the loop
                                int qq = kingRow;
                                int dd = kingColumn;
                                int mm = RealKingRow;
                                int ll = RealKingColumn;
                                dynamicCheck = true;
                                break;
                            }


                            kingIsMatedInThatPositionAnyway = false;
                        }
                        if (dynamicCheck)
                        {
                            mate = false;
                            break;
                        }
                    }


                    if (dynamicCheck)
                    {
                        mate = false;
                        break;
                    }
                }
                b++;
            } while (b <= 8);

            if (!dynamicCheck &&  !checkIfOtherPiecesCanMoveToRescueKing(pieces, kingIsWhite, RealKingRow, RealKingColumn))
            {//There is another piece that can rescue the king
                mate = true;
                chess.Lost();
            }

            return mate;
        }

        bool checkIfOtherPiecesCanMoveToRescueKing(Pieces[,] pieces, bool whiteKing, int kingRow, int kingColumn)
        {
            bool PieceCanRescure = false;
            int[] threateningPiece = new int[2];
            if (whiteKing)
            {
                threateningPiece = checkWhoThreatensWhitePiece(pieces, kingRow, kingColumn);
                if (threateningPiece[0] != 0)
                {
                    PieceCanRescure = SolveThreateningPositions(pieces, threateningPiece[0], threateningPiece[1], kingRow, kingColumn);
                }
            }
            else
            {
                threateningPiece = checkWhoThreatensBlackPiece(pieces, kingRow, kingColumn);
                if (threateningPiece[0] != 0)
                {
                    PieceCanRescure = SolveThreateningPositions(pieces, threateningPiece[0], threateningPiece[1], kingRow, kingColumn);
                }
            }
            return PieceCanRescure;
        }

        bool SolveThreateningPositions(Pieces[,] pieces, int threateningRow, int threateningColumn, int kingRow, int kingcolumn)
        {
            bool noRescuingPieceCanGetInside = false;
            //Rook Threat
            if (threateningRow > kingRow && threateningColumn == kingcolumn)
            {//problem here:false  pieces:true
                noRescuingPieceCanGetInside = RookThreatDown(pieces, threateningRow, threateningColumn, kingRow, kingcolumn);
            }

            if (threateningColumn < kingcolumn && threateningRow == kingRow)
            {//king only:false   pieces:true
                noRescuingPieceCanGetInside = RookThreatRight(pieces, threateningRow, threateningColumn, kingRow, kingcolumn);
            }

            if (threateningRow < kingRow && threateningColumn == kingcolumn)
            {//king only:false   pieces:true
                noRescuingPieceCanGetInside = RookThreatUp(pieces, threateningRow, threateningColumn, kingRow, kingcolumn);
            }

            if (threateningColumn > kingcolumn && threateningRow == kingRow)
            {//king only:false pieces:true
                noRescuingPieceCanGetInside = RookThreatLeft(pieces, threateningRow, threateningColumn, kingRow, kingcolumn);
            }

            //Bishop Threat
            // North-West
            if (threateningRow < kingRow && threateningColumn < kingcolumn)
            {//king only:false pieces:true
                noRescuingPieceCanGetInside = BishopNorthWest(pieces, threateningRow, threateningColumn, kingRow, kingcolumn);
            }
            // North-East
            if (threateningRow < kingRow && threateningColumn > kingcolumn)
            {//king only:false pieces:true
                noRescuingPieceCanGetInside = BishopNorthEast(pieces, threateningRow, threateningColumn, kingRow, kingcolumn);
            }
            // South-West 
            if (threateningRow > kingRow && threateningColumn < kingcolumn)
            {//king only:false pieces:true
                noRescuingPieceCanGetInside = BishopSouthWest(pieces, threateningRow, threateningColumn, kingRow, kingcolumn);
            }
            // South-East
            if (threateningRow > kingRow && threateningColumn > kingcolumn)
            {//king only:false pieces:true
                noRescuingPieceCanGetInside = BishopSouthEast(pieces, threateningRow, threateningColumn, kingRow, kingcolumn);
            }
            return noRescuingPieceCanGetInside;
        }

        bool RookThreatUp(Pieces[,] pieces, int rowStart, int columnStart, int kingRow, int kingColumn)
        {
            bool rescuingPieceCanPenetrate = false;
            int threateningRow = rowStart;
            int threateningColumn = columnStart;
            while (kingRow > rowStart)
            {
                for (int i = 1; i < 9; i++)
                {
                    for (int j = 1; j < 9; j++)
                    {
                        if (pieces[i, j] != null && !(pieces[i, j] is King) && pieces[threateningRow, threateningColumn].pieceName()[0] != pieces[i, j].pieceName()[0])
                        {
                            if (pieces[i, j].pieceCollision(pieces, i, j, rowStart, columnStart))
                            {
                                rescuingPieceCanPenetrate = true;
                                break;
                            }
                        }
                    }
                }
                rowStart = (rowStart += 1) < 8 ? rowStart : 8;
            }
            return rescuingPieceCanPenetrate;
        }

        bool RookThreatDown(Pieces[,] pieces, int rowStart, int columnStart, int kingRow, int kingColumn)
        {
            bool rescuingPieceCanPenetrate = false;
            int threateningRow = rowStart;
            int threateningColumn = columnStart;
            while (kingRow < rowStart)
            {
                for (int i = 1; i < 9; i++)
                {
                    for (int j = 1; j < 9; j++)
                    {
                        if (pieces[i, j] != null && !(pieces[i, j] is King) && pieces[threateningRow, threateningColumn].pieceName()[0] != pieces[i, j].pieceName()[0])
                        {
                            if (pieces[i, j].pieceCollision(pieces, i, j, rowStart, columnStart))
                            {
                                rescuingPieceCanPenetrate = true;
                                break;
                            }
                        }
                    }
                }
                rowStart = (rowStart -= 1) > 1 ? rowStart : 1;
            }
            return rescuingPieceCanPenetrate;
        }
        bool RookThreatRight(Pieces[,] pieces, int rowStart, int columnStart, int kingRow, int kingColumn)
        {
            bool rescuingPieceCanPenetrate = false;
            int threateningRow = rowStart;
            int threateningColumn = columnStart;
            while (kingColumn > columnStart)
            {
                for (int i = 1; i < 9; i++)
                {
                    for (int j = 1; j < 9; j++)
                    {
                        if (pieces[i, j] != null && !(pieces[i, j] is King) && pieces[threateningRow, threateningColumn].pieceName()[0] != pieces[i, j].pieceName()[0])
                        {
                            if (pieces[i, j].pieceCollision(pieces, i, j, rowStart, columnStart))
                            {
                                rescuingPieceCanPenetrate = true;
                                break;
                            }
                        }
                    }
                }
                columnStart = (columnStart += 1) < 8 ? columnStart : 8;
            }
            return rescuingPieceCanPenetrate;
        }

        bool RookThreatLeft(Pieces[,] pieces, int rowStart, int columnStart, int kingRow, int kingColumn)
        {
            bool rescuingPieceCanPenetrate = false;
            int threateningRow = rowStart;
            int threateningColumn = columnStart;
            while (kingColumn < columnStart)
            {
                for (int i = 1; i < 9; i++)
                {
                    for (int j = 1; j < 9; j++)
                    {
                        if (pieces[i, j] != null && !(pieces[i, j] is King) && pieces[threateningRow, threateningColumn].pieceName()[0] != pieces[i, j].pieceName()[0])
                        {
                            if (pieces[i, j].pieceCollision(pieces, i, j, rowStart, columnStart) )
                            {
                                rescuingPieceCanPenetrate = true;
                                break;
                            }
                        }
                    }
                }
                columnStart = (columnStart -= 1) > 1 ? columnStart : 1;
            }
            return rescuingPieceCanPenetrate;
        }

        bool BishopNorthEast(Pieces[,] pieces, int rowStart, int columnStart, int kingRow, int kingColumn)
        {
            bool rescuingPieceCanPenetrate = false;
            int threateningRow = rowStart;
            int threateningColumn = columnStart;

            while (kingRow > rowStart && kingColumn < columnStart)
            {
                for (int i = 1; i < 9; i++)
                {
                    for (int j = 1; j < 9; j++)
                    {
                        if (pieces[i, j] != null && !(pieces[i, j] is King) && pieces[threateningRow, threateningColumn].pieceName()[0] != pieces[i, j].pieceName()[0])
                        {
                            if (pieces[i, j].pieceCollision(pieces, i, j, rowStart, columnStart))
                            {
                                rescuingPieceCanPenetrate = true;
                                break;
                            }
                        }
                    }
                }
                rowStart = (rowStart += 1) < 8 ? rowStart : 8;
                columnStart = (columnStart -= 1) > 1 ? columnStart : 1;
            }
            return rescuingPieceCanPenetrate;
        }

        bool BishopNorthWest(Pieces[,] pieces, int rowStart, int columnStart, int kingRow, int kingColumn)
        {
            bool rescuingPieceCanPenetrate = false;
            int threateningRow = rowStart;
            int threateningColumn = columnStart;
            while (kingRow > rowStart && kingColumn > columnStart)
            {
                for (int i = 1; i < 9; i++)
                {
                    for (int j = 1; j < 9; j++)
                    {
                        if (pieces[i, j] != null && !(pieces[i, j] is King) && pieces[threateningRow, threateningColumn].pieceName()[0] != pieces[i, j].pieceName()[0])
                        {
                            if (pieces[i, j].pieceCollision(pieces, i, j, rowStart, columnStart))
                            {
                                rescuingPieceCanPenetrate = true;
                                break;
                            }
                        }
                    }
                }
                rowStart = (rowStart += 1) < 8 ? rowStart : 8;
                columnStart = (columnStart += 1) < 8 ? columnStart : 8;
            }
            return rescuingPieceCanPenetrate;
        }

        bool BishopSouthEast(Pieces[,] pieces, int rowStart, int columnStart, int kingRow, int kingColumn)
        {
            bool rescuingPieceCanPenetrate = false;
            int threateningRow = rowStart;
            int threateningColumn = columnStart;
            while (kingRow < rowStart && kingColumn < columnStart)
            {
                for (int i = 1; i < 9; i++)
                {
                    for (int j = 1; j < 9; j++)
                    {
                        if (pieces[i, j] != null && !(pieces[i, j] is King) && pieces[threateningRow, threateningColumn].pieceName()[0] != pieces[i, j].pieceName()[0])
                        {
                            if (pieces[i, j].pieceCollision(pieces, i, j, rowStart, columnStart))
                            {
                                rescuingPieceCanPenetrate = true;
                                break;
                            }
                        }
                    }
                }
                rowStart = (rowStart - 1) > 1 ? rowStart : 1;
                columnStart = (columnStart -= 1) > 1 ? columnStart : 1;
            }
            return rescuingPieceCanPenetrate;
        }

        bool BishopSouthWest(Pieces[,] pieces, int rowStart, int columnStart, int kingRow, int kingColumn)
        {
            bool rescuingPieceCanPenetrate = false;
            int threateningRow = rowStart;
            int threateningColumn = columnStart;
            while (kingRow < rowStart && kingColumn > columnStart)
            {
                for (int i = 1; i < 9; i++)
                {
                    for (int j = 1; j < 9; j++)
                    {
                        if (pieces[i, j] != null && !(pieces[i, j] is King) && pieces[threateningRow, threateningColumn].pieceName()[0] != pieces[i, j].pieceName()[0])
                        {
                            if (pieces[i, j].pieceCollision(pieces, i, j, rowStart, columnStart))
                            {
                                rescuingPieceCanPenetrate = true;
                                break;
                            }
                        }
                    }
                }
                rowStart = (rowStart -= 1) > 1 ? rowStart : 1;
                columnStart = (columnStart += 1) < 8 ? columnStart : 8;
            }

            return rescuingPieceCanPenetrate;
        }

        int[] checkWhoThreatensBlackPiece(Pieces[,] pieces, int kingRow, int kingColumn)
        {
            int[] pieceThreatensKing = new int[2];
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if (pieces[i, j] != null  && pieces[i, j].pieceName()[0] == 'W' && pieces[i, j].pieceCollision(pieces, i, j, kingRow, kingColumn))
                    {
                        pieceThreatensKing[0] = i;
                        pieceThreatensKing[1] = j;
                    }
                }
            }
            return pieceThreatensKing;
        }

        int[] checkWhoThreatensWhitePiece(Pieces[,] pieces, int kingRow, int kingColumn)
        {
            int[] pieceThreatensKing = new int[2];

            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if (pieces[i, j] != null && pieces[i, j].pieceName()[0] == 'B' && pieces[i, j].pieceCollision(pieces, i, j, kingRow, kingColumn))
                    {
                        pieceThreatensKing[0] = i;
                        pieceThreatensKing[1] = j;
                    }
                }
            }
            return pieceThreatensKing;
        }

    }
    
     
}
