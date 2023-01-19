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

    class CheckManager
    {
        public static void CheckOrMate(Pieces[,] pieces, int rowStart, int columnStart, int rowEnd, int columnEnd)
        {

            CheckAlgorithm checkAlgorithm = new CheckAlgorithm();
            //Check where the king is?
            int[] threatenedPosition = new int[2];
            threatenedPosition = checkAlgorithm.checkKingPosition(pieces, rowStart, columnStart, rowEnd, columnEnd);
            //Check whether the king is threatened?
            if (checkAlgorithm.checkCheck(pieces, threatenedPosition[0], threatenedPosition[1], threatenedPosition[2], threatenedPosition[3]))
            {
                if (WindowsFormsApplication1.Class2.MATE == false)
                {
                    ChessBoard.CheckMessage();
                    Class2.CheckedMustMove = true;
                }
                else
                {
                    Class2.CheckedMustMove = false;
                }
            }

        }
    }


}
