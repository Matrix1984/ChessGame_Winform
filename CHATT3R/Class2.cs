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
     public class Class2
     {
        public static int counter;
        public static bool MATE;
        Pieces[,] pieces;
        Pieces[,] piece;
        public static bool CheckedMustMove;
        public static bool Stalemated;
        public static Dictionary<int, int[]> rightPositions=new Dictionary<int,int[]>();
        public static bool promotionIsOn;
        public static bool replayIsOn;
        Game g;
        Stalemate stalemate = new Stalemate();
        ChessBoard chess;

        public Class2(ChessBoard chessBoardForm)
        {
           
            chess = chessBoardForm;
        }

        public void ExecuteAll(int rowStart,int columnStart,int rowEnd,int columnEnd)
        {
            ChessBoard chess = new ChessBoard();
            chess.YourTurn();
 
            if (rowStart > 80)
            {
                promotionIsOn = true;
                replayTakeCareOfPromotion(pieces, rowStart, columnStart, rowEnd, columnEnd);// will find the position where the piece is located and it will replay the game.
            }
            if (!promotionIsOn)
            {
             
                g = new Game(piece, rowStart, columnStart, rowEnd, columnEnd);
                pieces = g.makeMove();

                //Castling
                CastlingMeh castle = new CastlingMeh();
                pieces = castle.CastlingCheck(pieces, rowStart, columnStart, rowEnd, columnEnd);

                //Promotion
                PiecePromotion promo = new PiecePromotion();
                if (promo.promotionHappened())
                {
                    pieces = promo.returnPromotion();
                    PiecePromotion.promoExists = false;
                }
                else
                {
                    promo.Promotion(pieces, rowStart, columnStart, rowEnd, columnEnd);
                }
                if (!replayIsOn)
                {
                    //CheckManager
                    if (!Class2.CheckedMustMove)
                    {
                        CheckManager.CheckOrMate(pieces, rowStart, columnStart, rowEnd, columnEnd);
                        if (!Class2.MATE)
                        {
                           stalemate.StalemateManager(pieces);
                        }
                    }
                }
                piece = GiveMePieces(pieces);
            }
            promotionIsOn = false;
                              
        }

        public  void DealWithTurnReset(int rowStartChessboard, int columnStartChessboard)
        {
           
                Class2.counter=0;
           
        }

        public  Pieces[,] PieceState()
        {           
            return piece;
        }

        public void setPieces(Pieces[,] piecesSet)
        {
            pieces = piecesSet;
            piece = piecesSet;
        }

        public Pieces[,] FirstTimeLoad()
        {
            pieces = ChessBoardDisplay();
            piece = ChessBoardDisplay();
            return pieces;
        }

        public Pieces[,] GiveMePieces(Pieces[,] pieces)
        {
            return pieces;
        }
   
        public static Pieces[,] ChessBoardDisplay()
        {
            Pieces[,] piece2 = new Pieces[9, 9];

            piece2[8, 1] = new Rook("WR");
            piece2[8, 2] = new Knight("WKN");
            piece2[8, 3] = new Bishop("WB");
            piece2[8, 5] = new Queen("WQ");
            piece2[8, 4] = new King("WK");
            piece2[8, 6] = new Bishop("WB");
            piece2[8, 7] = new Knight("WKN");
            piece2[8, 8] = new Rook("WR");

            piece2[7, 1] = new Pawn("WP");
            piece2[7, 2] = new Pawn("WP");
            piece2[7, 3] = new Pawn("WP");
            piece2[7, 4] = new Pawn("WP");
            piece2[7, 5] = new Pawn("WP");
            piece2[7, 6] = new Pawn("WP");
            piece2[7, 7] = new Pawn("WP");
            piece2[7, 8] = new Pawn("WP");

            piece2[1, 1] = new Rook("BR");
            piece2[1, 2] = new Knight("BKN");
            piece2[1, 3] = new Bishop("BB");
            piece2[1, 5] = new Queen("BQ");
            piece2[1, 4] = new King("BK");
            piece2[1, 6] = new Bishop("BB");
            piece2[1, 7] = new Knight("BKN");
            piece2[1, 8] = new Rook("BR");

            piece2[2, 1] = new Pawn("BP");
            piece2[2, 2] = new Pawn("BP");
            piece2[2, 3] = new Pawn("BP");
            piece2[2, 4] = new Pawn("BP");
            piece2[2, 5] = new Pawn("BP");
            piece2[2, 6] = new Pawn("BP");
            piece2[2, 7] = new Pawn("BP");
            piece2[2, 8] = new Pawn("BP");

            return piece2;

        }

        public Pieces[,] replayTakeCareOfPromotion(Pieces[,] pieces, int rowStartPromo, int columnStartPromo, int rowEndpromo, int columnEndpromo)
        {

            switch (rowStartPromo)
            {
                case 86:
                    pieces[rowEndpromo, columnEndpromo] = new Rook("BR3");
                    break;
                case 87:
                    pieces[rowEndpromo, columnEndpromo] = new Knight("BN3");
                    break;
                case 88:
                    pieces[rowEndpromo, columnEndpromo] = new Bishop("BB3");
                    break;
                case 89:
                    pieces[rowEndpromo, columnEndpromo] = new Queen("BQueen2");
                    break;
                case 96:
                    pieces[rowEndpromo, columnEndpromo] = new Rook("WR3");
                    break;
                case 97:
                    pieces[rowEndpromo, columnEndpromo] = new Bishop("WB3");
                    break;
                case 98:
                    pieces[rowEndpromo, columnEndpromo] = new Knight("WN3");
                    break;
                case 99:
                    pieces[rowEndpromo, columnEndpromo] = new Queen("WQueen2");
                    break;
                default:
                    ChessBoard.moveValidity = "Invalid Choice";
                    break;
            }
            return pieces;
        }
}

public enum STATE { DONOTHING, PROMOTION, CASTLING, CHECK, CHECKMATE };
public enum PromotionPieces { RESET, ROOK, BISHOP, KNIGHT, QUEEN };

}
