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

    class PiecePromotion
    {

        ChessBoard chess = new ChessBoard();
        public static int rowEndpromo;
        public static int columnEndpromo;
        int[] ArrayOfRightPositions;
        public static bool promoPresentStartProcess;
        public static Pieces[,] promoPieces;
        public static bool promoExists;
        public static bool blackPromo;
        int rowStart;
        int columnStart;

        // checks if there is promotion
        public void Promotion(Pieces[,] pieces, int rowStarto, int columnStarto, int rowEnd, int columnEnd)
        {
            promoPieces = pieces;
            rowEndpromo = rowEnd;
            columnEndpromo = columnEnd;
            rowStart = rowStarto;
            columnStart = columnStarto;

            if (pieces[rowEndpromo, columnEndpromo] != null && pieces[rowEndpromo, columnEndpromo].pieceName()[1] == 'P' && (rowEndpromo == 1 || rowEndpromo == 8))
            {
                MessageBox.Show("You must promote the piece right now. See the right side panel");
                promoPresentStartProcess = true;
                ChessBoard chess = new ChessBoard();


                blackPromo = false;
                if (pieces[rowEnd, columnEnd].pieceName()[0] == 'B')
                {
                    blackPromo = true;
                }
                chess.piecePromotionChange(promoPieces, rowEndpromo, columnEndpromo, blackPromo);
            }
            else
            {
                promoPresentStartProcess = false;
            }

        }



        // assigns a new array that is promoted
        public void promotionPresentation(Pieces[,] pieces, int rowEnd, int columnEnd, bool blackOrNot)
        {
            ChessBoard.moveValidity = "Piece Promotion";


            try
            {

                if (blackPromo)
                {
                    switch (ChessBoard.PromotedPiece)
                    {
                        case PromotionPieces.ROOK:
                            promoPieces[rowEndpromo, columnEndpromo] = new Rook("BR3");
                            rowStart = 86;// rowStart acts as an indicator to signal piece promotion.
                            break;
                        case PromotionPieces.BISHOP:
                            promoPieces[rowEndpromo, columnEndpromo] = new Knight("BN3");
                            rowStart = 87;
                            break;
                        case PromotionPieces.KNIGHT:
                            promoPieces[rowEndpromo, columnEndpromo] = new Bishop("BB3");
                            rowStart = 88;
                            break;
                        case PromotionPieces.QUEEN:
                            promoPieces[rowEndpromo, columnEndpromo] = new Queen("BQueen2");
                            rowStart = 89;
                            break;
                        default:
                            ChessBoard.moveValidity = "Invalid Choice";
                            break;
                    }
                }

                else
                {
                    switch (ChessBoard.PromotedPiece)
                    {
                        case PromotionPieces.ROOK:
                            promoPieces[rowEndpromo, columnEndpromo] = new Rook("WR3");
                            rowStart = 96;
                            break;
                        case PromotionPieces.BISHOP:
                            promoPieces[rowEndpromo, columnEndpromo] = new Knight("WN3");
                            rowStart = 97;
                            break;
                        case PromotionPieces.KNIGHT:
                            promoPieces[rowEndpromo, columnEndpromo] = new Bishop("WB3");
                            rowStart = 98;
                            break;
                        case PromotionPieces.QUEEN:
                            promoPieces[rowEndpromo, columnEndpromo] = new Queen("WQueen2");
                            rowStart = 99;
                            break;
                        default:
                            ChessBoard.moveValidity = "Invalid Choice";
                            break;
                    }
                }
            }
            catch (Exception E)
            {
                MessageBox.Show("You cant promote the pawn yet");
            }

            Game.b++;
            ArrayOfRightPositions = new int[] { rowStart, columnStart, rowEndpromo, columnEndpromo };//deliver the piece saved/replayed to the rowEndpromo/columnEndpromo
            chess.DeSierializeNow();
            Class2.rightPositions.Add(Game.b, ArrayOfRightPositions);
            chess.activateMySavedPositions();
            chess.SerializeNow();

        }

        public Pieces[,] returnPromotion()
        {

            return promoPieces;
        }

        public bool promotionHappened()
        {
            return promoExists;
        }

    }

}
