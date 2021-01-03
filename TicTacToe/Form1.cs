using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        public bool turn = true;
        private int turn_count = 0;
        public Form1()
        {
            InitializeComponent();
        }
        
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By Cristian Chira", "X O About");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            
            Button b = (Button)sender;
            if (turn)
                b.Text = "X";
            else
                b.Text = "O";

            b.Enabled = false;
            turn_count++;
            check_winner();
            turn = !turn;
        }

        private void check_winner()
        {
            bool winner = false;
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                winner = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                winner = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                winner = true;
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                winner = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled))
                winner = true;
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                winner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                winner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                winner = true;
            if (winner == true)
            {
                var winnner = "";
                if (turn)
                    winnner = "X";
                else winnner = "O";
                MessageBox.Show(winnner + " Wins!", "Result");
                disable_buttons();
            }
            else if (turn_count == 9)
                MessageBox.Show("It's a draw", "Result");

        }

        private void disable_buttons()
        {
            foreach (Control c in Controls)
            {
                Button b = (Button) c;
                b.Enabled = false;
            }
        }

        private void reset_buttons()
        {
            foreach (Control c in Controls)
            {
                Button b = (Button) c;
                b.Text = "";
                b.Enabled = true;
            }
        }
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;
            reset_buttons();

        }
    }
}