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
    class CheckAlgorithm
    {
        bool checkCheckMeh;
        string checkOrpiece;
        bool checkOrPiece;
        string chessPiece;
        bool checkSafe;
        int kingRow;
        int kingColumn;
        int blackkingRow;
        int blackkingColumn;
        bool dynamicCheckBlack;
        int whitekingRow;
        int whitekingColumn;
        bool dynamicCheckWhite;
        bool mate;
        int kingRow2;
        int kingColumn2;
        bool pieceDoesntCollideKing;
        bool pieceMovesKing;
        Mate meh = new Mate();
        ChessBoard chess = new ChessBoard();
        int specialCheckRowEnd;
        int specialCheckColumnEnd;

        public int[] checkKingPosition(Pieces[,] pieces, int rowStart, int columnStart, int rowEnd, int columnEnd)
        {
            kingRow = 0;
            kingColumn = 0;
            bool notNull = false;
            int[] threatPosition = new int[4];
            chessPiece = "";
            bool WhiteKingSearch = false;
            bool BlackKingSearch = false;
            int specialCheckRowEnd = rowEnd;
            int specialCheckColumnEnd = columnEnd;
            chessPiece = "WK";
            for (int row = 1; row < 9; row++)
            {  //Find where the king.
                for (int column = 1; column < 9; column++)
                {
                    if (pieces != null && pieces[row, column] != null && pieces[row, column].pieceName() == chessPiece)
                    {
                        threatPosition[0] = row;
                        threatPosition[1] = column;
                    }
                }
            }

            chessPiece = "BK";
            for (int row = 1; row < 9; row++)
            {  //Find where the king.
                for (int column = 1; column < 9; column++)
                {
                    if (pieces != null && pieces[row, column] != null && pieces[row, column].pieceName() == chessPiece)
                    {
                        threatPosition[2] = row;
                        threatPosition[3] = column;

                    }
                }
            }

            this.whitekingRow = threatPosition[0];
            this.whitekingColumn = threatPosition[1];
            this.blackkingRow = threatPosition[2];
            this.blackkingColumn = threatPosition[3];

            return threatPosition;
        }

        public static bool blackKing;
        public static bool whiteKing;
        public bool checkCheck(Pieces[,] pieces, int whiteKingRow, int whiteKingColumn, int blackkingRow, int blackkingColumn)
        {
            dynamicCheckBlack = false;
            CheckManager manager = new CheckManager();

            for (int z1 = 1; z1 < 9; z1++)
            {  //Find Threatening piece
                for (int j = 1; j < 9; j++)
                {
                    if (pieces[z1, j] != pieces[blackkingRow, blackkingColumn] && pieces[z1, j] != null && pieces[z1, j].pieceName()[0] == 'W' && pieces[z1, j].pieceCollision(pieces, z1, j, blackkingRow, blackkingColumn))
                    {
                        dynamicCheckBlack = true;
                        blackKing = true;
                        whiteKing = false;
                        //  Console.WriteLine("Piece Threatening king :  " + pieces[z1, j].pieceName());

                        if (meh.MateF(pieces, blackkingRow, blackkingColumn))
                        {
                            WindowsFormsApplication1.Class2.MATE = true;
                            break;
                        }
                    }
                    if (WindowsFormsApplication1.Class2.MATE) { break; }
                }
                if (WindowsFormsApplication1.Class2.MATE) { break; }
            }

            ////////////////White check////////////////////////////////////White Check//////////////////////////////////////////
            for (int z1 = 1; z1 < 9; z1++)
            {  //Find Threatening piece
                for (int j = 1; j < 9; j++)
                {
                    if (pieces[z1, j] != pieces[whiteKingRow, whiteKingColumn] && pieces[z1, j] != null && pieces[z1, j].pieceName()[0] == 'B' && pieces[z1, j].pieceCollision(pieces, z1, j, whiteKingRow, whiteKingColumn))
                    {
                        whiteKing = true;
                        blackKing = false;
                        dynamicCheckBlack = true;
                        if (meh.MateF(pieces, whiteKingRow, whiteKingColumn))
                        {
                            WindowsFormsApplication1.Class2.MATE = true;
                            break;
                        }
                    }

                }
                if (WindowsFormsApplication1.Class2.MATE) { break; }
            }

            return dynamicCheckBlack;
        }

        public static bool piece;

        /*  Deleted CheckSafe method..Cause: Too repetitive*/

        public bool SpecialCheck(Pieces[,] pieces, int rowStart, int columnStart)
        {
            bool specialPieceCheck = false;

            if (pieces[whitekingRow, whitekingColumn] != null && pieces[rowStart, columnStart] != null && pieces[rowStart, columnStart].pieceName()[0] != pieces[whitekingRow, whitekingColumn].pieceName()[0] && pieces[rowStart, columnStart].pieceCollision(pieces, rowStart, columnStart, whitekingRow, whitekingColumn))
            {
                specialPieceCheck = true;
            }

            if (pieces[blackkingRow, blackkingColumn] != null && pieces[rowStart, columnStart] != null && pieces[rowStart, columnStart].pieceName()[0] != pieces[blackkingRow, blackkingColumn].pieceName()[0] && pieces[rowStart, columnStart].pieceCollision(pieces, rowStart, columnStart, blackkingRow, blackkingColumn))
            {
                specialPieceCheck = true;
            }

            return specialPieceCheck;
        }
        //bug

        public bool CantMoveIfCreatedCheck(Pieces[,] pieces, int rowStart, int columnStart, int rowEnd, int columnEnd)
        {
            bool canCheck = false;
            Pieces[,] temp;
            checkKingPosition(pieces, rowStart, columnStart, rowEnd, columnEnd);
            ChessBoard chess = new ChessBoard();
            bool whitePiece = false;
            bool blackPiece = false;



            if (pieces != null && pieces[rowStart, columnStart] != null && pieces[rowStart, columnStart].pieceName()[0] == 'W')
            {
                whitePiece = true;
            }
            else
            {
                blackPiece = true;
            }
            TempArray temporaryArray = new TempArray(pieces);

            temporaryArray = DeepClone<TempArray>(temporaryArray);
            temp = temporaryArray.GetpiecesTemp();

            temp[rowEnd, columnEnd] = temp[rowStart, columnStart];
            temp[rowStart, columnStart] = null;


            canCheck = false;
            if (whitePiece)
            {
                for (int z1 = 1; z1 < 9; z1++)
                {  //Find Threatening piece
                    for (int j = 1; j < 9; j++)
                    {
                        if (temp != null && temp[rowEnd, columnEnd] != null && temp[z1, j] != null && temp[z1, j].pieceName()[0] != temp[rowEnd, columnEnd].pieceName()[0] && temp[z1, j].pieceCollision(temp, z1, j, rowEnd, columnEnd) && temp[z1, j].pieceMovement(temp, z1, j, rowEnd, columnEnd))
                        {
                           // chess.YouWillBeCheckedCantMove();
                            canCheck = true;
                            break;
                       
                        }
                    }
                    if (canCheck) { break; }
                }
            }


            if (blackPiece)
            {
                for (int z1 = 1; z1 < 9; z1++)
                {  //Find Threatening piece
                    for (int j = 1; j < 9; j++)
                    {
                        if (temp != null && temp[rowEnd, columnEnd] != null && temp[z1, j] != null && temp[z1, j].pieceName()[0] != temp[rowEnd, columnEnd].pieceName()[0] && temp[z1, j].pieceCollision(temp, z1, j, rowEnd, columnEnd) && temp[z1, j].pieceMovement(temp, z1, j, rowEnd, columnEnd))
                        {
                            //chess.YouWillBeCheckedCantMove();
                            canCheck = true;
                            break;
                       
                        }
                    }
                    if (canCheck) { break; }
                }
            }
            return canCheck;
        }


        public static T DeepClone<T>(T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
               
                //int i = 0;
                //string presentThis = "Serialization size: ";
                //presentThis += ms.Position;
                //presentThis += " Number of calls: ";
                //presentThis += (i++).ToString();
                ms.Position = 0;
                //MessageBox.Show(presentThis);

                return (T)formatter.Deserialize(ms);
            }
        }



        public bool CantMoveIfCreatedCheckAtStart(Pieces[,] pieces, int rowStart, int columnStart, int rowEnd, int columnEnd)
        {
            bool canCheck = false;
            Pieces[,] temp;
            checkKingPosition(pieces, rowStart, columnStart, rowEnd, columnEnd);
            ChessBoard chess = new ChessBoard();
            bool whitePiece = false;
            bool blackPiece = false;



            if (pieces != null && pieces[rowStart, columnStart] != null && pieces[rowStart, columnStart].pieceName()[0] == 'W')
            {
                whitePiece = true;
            }
            else
            {
                blackPiece = true;
            }
            TempArray temporaryArray = new TempArray(pieces);

            temporaryArray = DeepClone<TempArray>(temporaryArray);
            temp = temporaryArray.GetpiecesTemp();

            temp[rowEnd, columnEnd] = temp[rowStart, columnStart];
            temp[rowStart, columnStart] = null;


            canCheck = false;
            if (whitePiece)
            {
                for (int z1 = 1; z1 < 9; z1++)
                {  //Find Threatening piece
                    for (int j = 1; j < 9; j++)
                    {
                        if (temp != null && temp[whitekingRow, whitekingColumn] != null && temp[z1, j] != null && temp[z1, j].pieceName()[0] != temp[whitekingRow, whitekingColumn].pieceName()[0] && temp[z1, j].pieceCollision(temp, z1, j, whitekingRow, whitekingColumn) && temp[z1, j].pieceMovement(temp, z1, j, whitekingRow, whitekingColumn))
                        {
                            chess.YouWillBeCheckedCantMove();
                            canCheck = true;
                            break;
                             
                        }
                    }
                }
            }


            if (blackPiece)
            {
                for (int z1 = 1; z1 < 9; z1++)
                {  //Find Threatening piece
                    for (int j = 1; j < 9; j++)
                    {
                        if (temp != null && temp[blackkingRow, blackkingColumn] != null && temp[z1, j] != null && temp[z1, j].pieceName()[0] != temp[blackkingRow, blackkingColumn].pieceName()[0] && temp[z1, j].pieceCollision(temp, z1, j, blackkingRow, blackkingColumn) && temp[z1, j].pieceMovement(temp, z1, j, blackkingRow, blackkingColumn))
                        {
                            chess.YouWillBeCheckedCantMove();
                            canCheck = true;
                            break;
                            
                        }
                    }
                }
            }
            return canCheck;
        }

    }
}
