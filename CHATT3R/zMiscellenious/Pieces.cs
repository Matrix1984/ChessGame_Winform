using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication1
{
    [Serializable]
    public abstract class Pieces
    {
        public abstract string pieceName();
        public abstract bool pieceCollision(Pieces[,] pieces, int rowStart, int columnStart, int rowEnd, int columnEnd);
        public abstract bool pieceMovement(Pieces[,] pieces, int rowStart, int columnStart, int rowEnd, int columnEnd);
        public abstract Image print();
        public abstract bool piecesDevour(Pieces[,] pieces, int rowStart, int columnStart, int rowEnd, int columnEnd);
    }
}
