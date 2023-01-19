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
    class Game
    {
        //int rowStart;    
        //int columnStart;
        //int rowEnd;
        //int columnEnd;
        //Pieces[,] piece;
        //ChessBoard chess = new ChessBoard();
        //CheckAlgorithm checkAlgorithm = new CheckAlgorithm();
        //Class2 rightPositions = new Class2();
        //public static bool WasntSerialized;
        //int[] ArrayOfRightPositions;
        //public static Dictionary<int, int[]> positionArray = new Dictionary<int, int[]>();
        //public static int b;
        //bool nullCantMove;
        //bool TurnValid=false;
        //static ChessBoard chessReference;

        int rowStart;
        int columnStart;
        int rowEnd;
        int columnEnd;
        Pieces[,] piece;
        static ChessBoard chessReference;
         CheckAlgorithm checkAlgorithm = new CheckAlgorithm();
        public static bool WasntSerialized;
        int[] ArrayOfRightPositions;
        public static Dictionary<int, int[]> positionArray = new Dictionary<int, int[]>();
        public static int b;
        bool nullCantMove;
        bool TurnValid = false;

        public Game(ChessBoard chessForm)
        {
            chessReference = chessForm;
        }

        public Game(Pieces[,] pieceArray, int rowS, int columnS, int rowE, int columnE)
        {
            this.rowStart = rowS;
            this.columnStart = columnS;
            this.rowEnd = rowE;
            this.columnEnd = columnE;
            this.piece = pieceArray;
        }



        public bool WhoseTurn()
        {
            if (!Class2.replayIsOn)
            {
                if (Class2.counter % 2 == 0 && piece[rowStart, columnStart] != null && piece[rowStart, columnStart].pieceName()[0] == 'B')
                {
                    TurnValid = true;
                    // chess.YourTurn(true);

                }
                else if (Class2.counter % 2 != 0 && piece[rowStart, columnStart] != null && piece[rowStart, columnStart].pieceName()[0] == 'W')
                {
                    TurnValid = true;
                    // chess.YourTurn(false);
                }
                else
                {
                    TurnValid = false;
                    chessReference.OtherPlayersTurn();
                }
            }
            else
            {
                TurnValid = true;
                Class2.counter += 1;
            }
            return TurnValid;
        }

        public Pieces[,] makeMove()
        {

            if (Class2.CheckedMustMove)
            {
                if (!checkAlgorithm.SpecialCheck(piece, rowStart, columnStart))
                {
                    Class2.CheckedMustMove = false;
                }
            }
            if (piece[rowStart, columnStart] == null)
            {
                nullCantMove = true;
            }
            else
            {
                nullCantMove = false;
            }

            //WhoseTurn() &&

       
            
           
            bool youCanMovePieceWhileInCheck = false;
            bool moveWasValid = false;
            bool doubleClickWasntAllowed = false;
            bool startPositionNotNull = false;
            if (piece[rowStart, columnStart] != null)
            {
                startPositionNotNull = true;
            }
            if (!checkAlgorithm.CantMoveIfCreatedCheckAtStart(piece, rowStart, columnStart, rowEnd, columnEnd))
            {
                youCanMovePieceWhileInCheck = true;
            }
           // 
            if (startPositionNotNull && piece[rowStart, columnStart].pieceMovement(piece, rowStart, columnStart, rowEnd, columnEnd))
            {
                moveWasValid = true;
            }

            if (!doubleClickShouldntBeAllowed(piece, rowStart, columnStart, rowEnd, columnEnd))
            {
                doubleClickWasntAllowed = true;
            }
            //if (piece[rowStart, columnStart] is King)
            //{
            //    if(CastlingMeh.castlingMoveMade && !piece[rowStart,columnStart].pieceMovement(piece,rowStart,columnStart,rowEnd,columnEnd))
            //    MessageBox.Show("Kings move was invalid, because it was illegal or the position was threatening");
            //}
            bool kingNearKing = false;
            if (!nullCantMove && piece[rowStart, columnStart] is King)
            {
                if (moveWasValid && piece[rowStart, columnStart].pieceName() == "WK")
                {
                    King.x++;
                }

                if (moveWasValid && piece[rowStart, columnStart].pieceName() == "BK")//|| CastlingMeh.castlingMoveMade
                {
                    King.y++;
                }
                King k =(King) piece[rowStart, columnStart];
                if (k.KingCantApproachKing(piece, rowStart, columnStart, rowEnd, columnEnd))
                {
                    kingNearKing = true;
                }
            }
            bool isWhite = false;
            if (!kingNearKing && !Class2.MATE && !Class2.Stalemated && WhoseTurn() && !nullCantMove && (moveWasValid ) && doubleClickWasntAllowed && !Class2.CheckedMustMove && startPositionNotNull && youCanMovePieceWhileInCheck)
            {
                isWhite = piece[rowStart, columnStart].pieceName()[0] == 'W' ? true : false;
                ChessBoard.moveValidity = "valid";
                piece[rowEnd, columnEnd] = piece[rowStart, columnStart];
                piece[rowStart, columnStart] = null;
                Class2.counter += 1;
                ArrayOfRightPositions = new int[] { rowStart, columnStart, rowEnd, columnEnd };//rowStart

                
                    Stalemate stalemate = new Stalemate();
                    //noPieceCanMove = true;
                   // stalemate.StalemateManager(piece);
                

                if (!Class2.replayIsOn)
                {
                    // Serializing data
                    if (WasntSerialized)
                    {
                        chessReference.DeSierializeNow();
                        WasntSerialized = false;
                    }



                    if (!WasntSerialized)
                    {
                        b++;
                        // positionArray.Add(b, ArrayOfRightPositions);
                        try
                        {
                            Class2.rightPositions.Add(b++, ArrayOfRightPositions);
                            chessReference.activateMySavedPositions();// before serialization, it will go to the function and get the dictionary
                            chessReference.SerializeNow();
                        }
                        catch (Exception c)
                        {
                            new ChessBoard().Error(c.StackTrace);
                        
                        }
                        WasntSerialized = true;
                    }
                }
            }
            else
            {
                ChessBoard.moveValidity = "Invalid";
            }

          
            return piece;
        }

        public static bool noPieceCanMove = false;

        public bool doubleClickShouldntBeAllowed(Pieces[,] pieceArray2Click, int rowS2Click, int columnS2Click, int rowE2Click, int columnE2Click)
        {
            bool SameRowColumn = false;
            bool bothNull = false;
            bool beginingNotNull = false;
            bool endNotNull = false;
            try
            {
                if (pieceArray2Click[rowS2Click, columnS2Click] != null)
                {
                    beginingNotNull = true;
                }
                if (pieceArray2Click[rowE2Click, columnE2Click] != null)
                {
                    endNotNull = true;
                }

                if (beginingNotNull && endNotNull && pieceArray2Click[rowS2Click, columnS2Click].pieceName()[0] == pieceArray2Click[rowE2Click, columnE2Click].pieceName()[0])
                {
                    SameRowColumn = true;
                }
            }
            catch (Exception e)
            {

            }
            return SameRowColumn;
        }

    }

}
