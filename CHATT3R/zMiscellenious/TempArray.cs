using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    [Serializable]
    class TempArray
    {
        Pieces[,] piecesTemp;
        public Pieces[,] MyProperty { get; set; }

        public TempArray(Pieces[,] piecesT)
        {
            this.piecesTemp = piecesT;
        }
        public Pieces[,] GetpiecesTemp()
        {
            return piecesTemp;
        }
    }
}
