using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using  System.Runtime.Serialization;
using  System.Runtime.Serialization.Formatters.Binary ;
using System.IO;
using System.Threading;


namespace WindowsFormsApplication1
{
    [Serializable] 
    public partial class ChessBoard: Form
    {

        public ChessBoard()
        {
            InitializeComponent();
            setTitleBar();
        }
                     
        public void setTitleBar()
        {
            Text = "Chess";
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
   
        }

   
        public static bool NextTurn;
        public int columnStart;
        public int columnEnd;
        public int rowEnd;
        public int rowStart;
        Class2 codeFile;

        private void a1_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {
                columnEnd = 1;
                rowEnd = 1;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " +numberConversion(columnEnd);
                YourTurn();
            }
            else
            {          
                columnStart = 1;
                rowStart = 1;
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }

        }
 
        private void b1_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {
               
                columnEnd = 2;
                rowEnd = 1;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 2;
                rowStart = 1;             
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void c1_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {
                columnEnd = 3;
                rowEnd = 1;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {             
                columnStart = 3;
                rowStart = 1;           
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void d1_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {
                columnEnd = 4;
                rowEnd = 1;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {             
                columnStart = 4;
                rowStart = 1;           
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void e1_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {
                columnEnd = 5;
                rowEnd = 1;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
            
                columnStart = 5;
                rowStart = 1;
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void f1_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {             
                columnEnd = 6;
                rowEnd = 1;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 6;
                rowStart = 1;         
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void g1_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {
                columnEnd = 7;
                rowEnd = 1;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
               
                columnStart = 7;
                rowStart = 1;
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void h1_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {
             
                columnEnd = 8;
                rowEnd = 1; 
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 8;
                rowStart = 1;       
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void a2_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {
             
                columnEnd = 1;
                rowEnd = 2;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 1;
                rowStart = 2;          
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void b2_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {
             
                columnEnd = 2;
                rowEnd = 2;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 2;
                rowStart = 2;              
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void c2_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {
                columnEnd = 3;
                rowEnd = 2;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();

            }
            else
            {
           
                columnStart = 3;
                rowStart = 2;
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void d2_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {
             
                columnEnd = 4;
                rowEnd = 2;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 4;
                rowStart = 2;        
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void e2_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {              
                columnEnd = 5;
                rowEnd = 2;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 5;
                rowStart = 2;             
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void f2_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {
          
                columnEnd = 6;
                rowEnd = 2;    
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
                }
            else
            {
                columnStart = 6;
                rowStart = 2;       
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void g2_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {
                columnEnd = 7;
                rowEnd = 2;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 7;
                rowStart = 2;
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void h2_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {           
                columnEnd = 8;
                rowEnd = 2;  
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 8;
                rowStart = 2;
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void a3_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {
                columnEnd = 1;
                rowEnd = 3;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {             
                columnStart = 1;
                rowStart = 3;
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void b3_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {
                columnEnd = 2;
                rowEnd = 3;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 2;
                rowStart = 3;
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void c3_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {              
                columnEnd = 3;
                rowEnd = 3;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 3;
                rowStart = 3;
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void d3_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {       
                columnEnd = 4;
                rowEnd = 3;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 4;
                rowStart = 3;
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void e3_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {       
                columnEnd = 5;
                rowEnd = 3;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 5;
                rowStart = 3;
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void f3_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {               
                columnEnd = 6;
                rowEnd = 3;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 6;
                rowStart = 3;
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void g3_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {           
                columnEnd = 7;
                rowEnd = 3;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 7;
                rowStart = 3;
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void h3_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {              
                columnEnd = 8;
                rowEnd = 3;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 8;
                rowStart = 3;
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void a4_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {             
                columnEnd = 1;
                rowEnd = 4;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 1;
                rowStart = 4;
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void b4_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {            
                columnEnd = 2;
                rowEnd = 4;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 2;
                rowStart = 4;
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void c4_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {
              
                columnEnd = 3;
                rowEnd = 4;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 3;
                rowStart = 4;               
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void d4_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {                
                columnEnd = 4;
                rowEnd = 4;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());

                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 4;
                rowStart = 4;
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void e4_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {              
                columnEnd = 5;
                rowEnd = 4;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 5;
                rowStart = 4;
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void f4_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {
                columnEnd = 6;
                rowEnd = 4;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 6;
                rowStart = 4;
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void g4_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {

                columnEnd = 7;
                rowEnd = 4;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 7;
                rowStart = 4;
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void h44_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {         
                columnEnd = 8;
                rowEnd = 4;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 8;
                rowStart = 4;
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void a5_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {
            
                columnEnd = 1;
                rowEnd = 5;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();

            }
            else
            {
                columnStart = 1;
                rowStart = 5;
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void b5_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {           
                columnEnd = 2;
                rowEnd = 5;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 2;
                rowStart = 5;
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void c5_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {
            
                columnEnd = 3;
                rowEnd = 5;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 3;
                rowStart = 5;
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void d5_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {
                columnEnd = 4;
                rowEnd = 5;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
             
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 4;
                rowStart = 5;
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void e5_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {
               
                columnEnd = 5;
                rowEnd = 5;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 5;
                rowStart = 5;
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void f5_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {
     
                columnEnd = 6;
                rowEnd = 5;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 6;
                rowStart = 5;
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void g5_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {               
                columnEnd = 7;
                rowEnd = 5;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
             
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 7;
                rowStart = 5;
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void h5_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {
                columnEnd = 8;
                rowEnd = 5;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 8;
                rowStart = 5;
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void a6_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {
                columnEnd = 1;
                rowEnd = 6;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 1;
                rowStart = 6;
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void b6_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {           
                columnEnd = 2;
                rowEnd = 6;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 2;
                rowStart = 6;
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void c6_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {
                columnEnd = 3;
                rowEnd = 6;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 3;
                rowStart = 6;
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void d6_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {              
                columnEnd = 4;
                rowEnd = 6;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
        
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 4;
                rowStart = 6;
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void e6_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {          
                columnEnd = 5;
                rowEnd = 6;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();

            }
            else
            {
                columnStart = 5;
                rowStart = 6;
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);

               
            }
        }

        private void f6_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {
                columnEnd = 6;
                rowEnd = 6; 
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 6;
                rowStart = 6;
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void g6_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {
                columnEnd = 7;
                rowEnd = 6;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 7;
                rowStart = 6;
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void h6_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {
                columnEnd = 8;
                rowEnd = 6;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 8;
                rowStart = 6;
                 NextTurn = true;
                 MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void a7_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {          
                columnEnd = 1;
                rowEnd = 7;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 1;
                rowStart = 7;
                 NextTurn = true;
                 MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void b7_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {
                columnEnd = 2;
                rowEnd = 7;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 2;
                rowStart = 7;
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void c7_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {           
                columnEnd = 3;
                rowEnd = 7;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 3;
                rowStart = 7;
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void d7_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {
                columnEnd = 4;
                rowEnd = 7;
              
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 4;
                rowStart = 7;
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void e7_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {
           
                columnEnd = 5;
                rowEnd = 7;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 5;
                rowStart = 7;
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void f7_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {          
                columnEnd = 6;
                rowEnd = 7;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 6;
                rowStart = 7;
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);

            }
        }

        private void g7_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {
                columnEnd = 7;
                rowEnd = 7;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 7;
                rowStart = 7;
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void h7_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {
                columnEnd = 8;
                rowEnd = 7;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 8;
                rowStart = 7;
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void a8_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {
                columnEnd = 1;
                rowEnd = 8;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 1;
                rowStart = 8;
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void b8_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {
                columnEnd = 2;
                rowEnd = 8;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 2;
                rowStart = 8;
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void c8_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {
                columnEnd = 3;
                rowEnd = 8;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 3;
                rowStart = 8;
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void d8_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {       
                columnEnd = 4;
                rowEnd = 8;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 4;
                rowStart = 8;
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void e8_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            { 
                columnEnd = 5;
                rowEnd = 8;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 5;
                rowStart = 8;
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void f8_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            { 
                columnEnd = 6;
                rowEnd = 8;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 6;
                rowStart = 8;
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        private void g8_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {
                columnEnd = 7;
                rowEnd = 8;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 7;
                rowStart = 8;
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
             
            }
        }

        private void h8_Click(object sender, EventArgs e)
        {
            if (NextTurn)
            {
                columnEnd = 8;
                rowEnd = 8;
                codeFile.ExecuteAll(rowStart, columnStart, rowEnd, columnEnd);
                PrintPieces(codeFile.PieceState());
                update();
                NextTurn = false;
                MoveToPosition.Text = rowEnd.ToString() + " " + numberConversion(columnEnd);
                YourTurn();
            }
            else
            {
                columnStart = 8;
                rowStart = 8;
                NextTurn = true;
                MoveFromPosition.Text = rowStart.ToString() + " " + numberConversion(columnStart);
            }
        }

        int randomSaveNumber;
        Game g;
        public static void YouCantMoveKingToCheckedPostition()
        {
           
            MessageBox.Show("You cant move your king to that position, because it is a threatened position");
        }

        public void Error(string errorOccured)
        {
            MessageBox.Show("Developer's Note: "+errorOccured);
            Error1.Text = errorOccured;
        }

        private void Chess_Load(object sender, EventArgs e)
        {
            
            Random randomReplaySave = new Random();
            randomSaveNumber=randomReplaySave.Next(10000);
            codeFile = new Class2(this);
            game2 = new GameSave();
            chessPics = Pattern();
            PrintPieces(codeFile.FirstTimeLoad());
            clearDictionary = true;
            Class2.MATE = false;
            Class2.Stalemated = false;
            codeFile.DealWithTurnReset(rowStart, columnStart);
            Class2.replayIsOn = false;
            Class2.rightPositions.Clear();
            Class2.Stalemated = false;
            Class2.promotionIsOn = false;
            Class2.counter = 0;
            Class2.CheckedMustMove = false;
             g = new Game(this);
      
        }
 
       

        public  void YourTurn()
        {
            if (!Class2.replayIsOn && Class2.counter % 2 == 0)
            {
              
                    PlayerA.Text = "Black turn";
                    PlayerB.Text = "Black inactive";
                    PlayerA.Invalidate();
             

            }
            else if (!Class2.replayIsOn && Class2.counter % 2 != 0)
            {
                PlayerB.Text = "White turn";
                PlayerA.Text = "White inactive";
                PlayerB.Invalidate();

            }
        }
        public void OtherPlayersTurn()
        {
            MessageBox.Show("It is the other player's turn");
        }
        public string numberConversion(int column)
        {
           string number;
           switch (column)
            {
                case 1: number = "a"; break;
                case 2: number = "b"; break;
                case 3: number = "c"; break;
                case 4: number = "d"; break;
                case 5: number = "e"; break;
                case 6: number = "f"; break;
                case 7: number = "g"; break;
                case 8: number = "h"; break;
                default: number = "nil"; break;
            }
            return number;
        }


        PictureBox[,] chessPics = new PictureBox[9, 9];
        public  void PrintPieces(Pieces [,] pieces)
        {      
            for (int i = 1; i < 9; i++)
            {             
                for (int j = 1; j < 9; j++)
                {
                    if (pieces[i, j] is Object )
                    {
                    
                            try
                            {
                                chessPics[i, j].Image = pieces[i, j].print();
                            }
                            catch (InvalidOperationException ex)
                            {
                                MessageBox.Show(ex.StackTrace);
                            }
                        
                    }
                    else
                    {
                        chessPics[i, j].Image = null;
                    }
                }             
            }
        }


    

        public PictureBox[ , ] Pattern()
        {
            chessPics[1, 1] = a1;
            chessPics[1, 2] = b1;
            chessPics[1, 3] = c1;
            chessPics[1, 4] = d1;
            chessPics[1, 5] = e1;
            chessPics[1, 6] = f1;
            chessPics[1, 7] = g1;
            chessPics[1, 8] = h1;
            chessPics[2, 1] = a2;
            chessPics[2, 2] = b2;
            chessPics[2, 3] = c2;
            chessPics[2, 4] = d2;
            chessPics[2, 5] = e2;
            chessPics[2, 6] = f2;
            chessPics[2, 7] = g2;
            chessPics[2, 8] = h2;
            chessPics[3, 1] = a3;
            chessPics[3, 2] = b3;
            chessPics[3, 3] = c3;
            chessPics[3, 4] = d3;
            chessPics[3, 5] = e3;
            chessPics[3, 6] = f3;
            chessPics[3, 7] = g3;
            chessPics[3, 8] = h3;
            chessPics[4, 1] = a4;
            chessPics[4, 2] = b4;
            chessPics[4, 3] = c4;
            chessPics[4, 4] = d4;
            chessPics[4, 5] = e4;
            chessPics[4, 6] = f4;
            chessPics[4, 7] = g4;
            chessPics[4, 8] = h44;
            chessPics[5, 1] = a5;
            chessPics[5, 2] = b5;
            chessPics[5, 3] = c5;
            chessPics[5, 4] = d5;
            chessPics[5, 5] = e5;
            chessPics[5, 6] = f5;
            chessPics[5, 7] = g5;
            chessPics[5, 8] = h5;
            chessPics[6, 1] = a6;
            chessPics[6, 2] = b6;
            chessPics[6, 3] = c6;
            chessPics[6, 4] = d6;
            chessPics[6, 5] = e6;
            chessPics[6, 6] = f6;
            chessPics[6, 7] = g6;
            chessPics[6, 8] = h6;
            chessPics[7, 1] = a7;
            chessPics[7, 2] = b7;
            chessPics[7, 3] = c7;
            chessPics[7, 4] = d7;
            chessPics[7, 5] = e7;
            chessPics[7, 6] = f7;
            chessPics[7, 7] = g7;
            chessPics[7, 8] = h7;
            chessPics[8, 1] = a8;
            chessPics[8, 2] = b8;
            chessPics[8, 3] = c8;
            chessPics[8, 4] = d8;
            chessPics[8, 5] = e8;
            chessPics[8, 6] = f8;
            chessPics[8, 7] = g8;
            chessPics[8, 8] = h8;
            return chessPics;
           
        }

        public PromotionPieces promoteMeh()
        {
            
            return PromotedPiece;
        }

        public static string moveValidity;

        public STATE Gamestate { set; get; }
        public static PromotionPieces PromotedPiece { set; get; }
   


        public void update()
        {
            move1.Text = moveValidity;       
        }

     
        public static  Pieces[,] promoPieces;
        public  int promotionRow;
        public int promotionColumn;
        bool black;

        public void piecePromotionChange(Pieces[,] pieces, int rowEnd2, int columnEnd2, bool blackOrNot)
        {
            PiecePromotion promotion = new PiecePromotion();
            PromotionTable.Invalidate();
            PromotionTable.Visible = true;
            promoPieces=pieces;
            promotionRow = rowEnd;
            promotionColumn = columnEnd;
            black = blackOrNot;
         
        }

        private void PromotionChoice_Click(object sender, EventArgs e)
        {
            if (PiecePromotion.promoPresentStartProcess)
            {
                PiecePromotion promotion = new PiecePromotion();
                promotion.promotionPresentation(promoPieces, promotionRow, promotionColumn, black);
                PiecePromotion.promoExists = true;
            }
            else
            {
                MessageBox.Show("Promotion doesnt exist now");
            }
        }
 
        
        private void radioButtonQueen_CheckedChanged(object sender, EventArgs e)
        {
            PromotedPiece = PromotionPieces.QUEEN;         

        }

        private void radioButtonRook_CheckedChanged(object sender, EventArgs e)
        {
            PromotedPiece = PromotionPieces.ROOK;
        }

        private void radioButtonBishop_CheckedChanged(object sender, EventArgs e)
        {
            PromotedPiece = PromotionPieces.BISHOP;
        }

        private void radioButtonKnight_CheckedChanged(object sender, EventArgs e)
        {
            PromotedPiece = PromotionPieces.KNIGHT;
        }
  
        private void controlsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NextTurn = false;
        }

        public static void CheckMessage()
        {
            MessageBox.Show("You are in a check now you must make a move");
        }

        public void YouWillBeCheckedCantMove()
        {
            MessageBox.Show("You will be checked cant move");
        }

        public void Lost()
        {
            MessageBox.Show("You have lost the game");           
        }





        ClassMoveToSerialize serializeMeh = new ClassMoveToSerialize(new Dictionary<int, int[]>());//new List<Dictionary<int, int[]>>()
  
        public void activateMySavedPositions()
        {
           serializeMeh.MySavedPositions();
        }

        public void SerializeNow()
        {
            serializeMeh.serializedCounter = Class2.counter;
            FileStream f = new FileStream(@"C:\"+ randomSaveNumber+".dat", FileMode.Create);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(f, serializeMeh);
            f.Close();
        }

        public void DeSierializeNow()
        {
            try
            {
                FileStream f = new FileStream(@"C:\" + randomSaveNumber + ".dat", FileMode.Open);
                BinaryFormatter b = new BinaryFormatter();
                serializeMeh = (ClassMoveToSerialize)b.Deserialize(f);
                f.Close();
 
            }
            catch
            {
                move1.Text = "File not found";
            }
         
        }

       
       public Dictionary<int, int[]> replay=new Dictionary<int,int[]>();

   
        public void ReplayGame()
        {
         
            if (Class2.replayIsOn && !backgroundWorker1.IsBusy)
            {
                replay = serializeMeh.giveBackDictionary();
                backgroundWorker1.WorkerSupportsCancellation = true;
                backgroundWorker1.RunWorkerAsync();
            }        
        }
  
        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Game.WasntSerialized = true;
            DeSierializeNow();
            PrintPieces(codeFile.FirstTimeLoad());
            Class2.MATE = false;
            Class2.Stalemated = false;
            Class2.replayIsOn = false;
            codeFile.DealWithTurnReset(rowStart, columnStart);
            replay.Clear();
            serializeMeh.setDictionary();
            Class2.rightPositions.Clear();
            SerializeNow();
        }


        private void replayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeSierializeNow();
            Class2.MATE = false;
            Class2.Stalemated = false;
            PrintPieces(codeFile.FirstTimeLoad());
            Class2.replayIsOn = true;
            ReplayGame();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          
       
        }
        public static bool openOrCloseThread;
        public static bool clearDictionary;
        private readonly object myLock = new object();
        SynchronizationContext uiCtx = SynchronizationContext.Current;
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
                int[] makeSelfMoves = new int[4];
          
                lock (replay)
                {
                        foreach (KeyValuePair<int, int[]> item in replay)// count should be more than 2
                        {

                                makeSelfMoves = replay[item.Key];
                                codeFile.ExecuteAll(makeSelfMoves[0], makeSelfMoves[1], makeSelfMoves[2], makeSelfMoves[3]);
                            
                                    uiCtx.Post(o =>
                                    {
                                        PrintPieces(codeFile.PieceState());
                                    }, null);
                               
                               
                                System.Threading.Thread.Sleep(1000);
                           
                           
                        }
                        Class2.counter = serializeMeh.serializedCounter;
                        Class2.replayIsOn = false;
                        Game.WasntSerialized = true;
                }
              
                //backgroundWorker1.CancelAsync();
            
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = @"c:\";
            Class2.replayIsOn = false;
            DialogResult result= saveFileDialog1.ShowDialog();
           if (result == DialogResult.OK)
           {
               saveToFile(saveFileDialog1.FileName);
           }
           
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @"c:\";
            Class2.replayIsOn = false;
            DialogResult result= openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                openFile(openFileDialog1.FileName);
            }
        }

        GameSave game2;
        public void saveToFile(string s)
        {
            game2.getTurn();// gets whose turn and sets it in the class
            game2.setLoadedPieces(codeFile.PieceState());// will pass the current pieces state
            FileStream f = new FileStream(s, FileMode.Create);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(f, game2);// will save the reference and the stream
            f.Close();
        }

        public void openFile(string s)
        {
            FileStream f = new FileStream(s, FileMode.Open);// will open the file and the stream
            BinaryFormatter b = new BinaryFormatter();
            game2 = (GameSave)b.Deserialize(f);// will load the stream
            f.Close();
            game2.setTurn();// sets the turn that used to be before the class was saved.
            codeFile.setPieces(game2.getLoadedPieces());// sets the board to the loaded pieces.
            PrintPieces(game2.getLoadedPieces());//prints the existing loaded pieces.
        }
        
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
        public void Stalemate()
        {
            MessageBox.Show("Stalemate");
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
      
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

      
        
    }

    [Serializable] 
    class ClassMoveToSerialize
    {
        public int serializedCounter{ get; set; }

        Dictionary<int, int[]> serialized;

        public ClassMoveToSerialize(Dictionary<int, int[]> serialized2)
        {
            this.serialized = serialized2;
        }
       
        public void MySavedPositions()
        {
           serialized=Class2.rightPositions;  
        }

        public Dictionary<int, int[]> giveBackDictionary()
        {
            return serialized;
        }
        public void setDictionary()
        {
             Class2.rightPositions.Clear();
             serialized.Clear();
        }

       
     
    }

    [Serializable] 
    class GameSave
    {
        Pieces[,] pieces;
        int turn;
        GameSave gameSave;
        public void setLoadedPieces(Pieces[,] serializedSavedPieces) // set the pieces array  to be saved
        {       
            this.pieces = serializedSavedPieces; 
        }
        public Pieces[,] getLoadedPieces() // returns the pieces array
        {
            return pieces;
        }
        public void getTurn()
        {
            turn = Class2.counter;
        }
        public void setTurn()
        {
            Class2.counter = turn;
            getGameSaveReference(this);
        }
     
        public static void getGameSaveReference(GameSave gs)
        {
    
        }
    }
}
