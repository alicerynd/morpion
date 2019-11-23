using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace morpion
{
    public partial class Morpion : Form
    {
        private bool gameStarted = false;
        private string turn;
        private string player1;
        private string player2;
        private int player1_score = 0;
        private int player2_score = 0;
        private string playerWon;

        public Morpion()
        {
            InitializeComponent();
        }

        private void buttonValidate_Click(object sender, EventArgs e)
        {
            if (input_player1.Text != "" && input_player2.Text != "")
            {
                player1 = input_player1.Text;
                player2 = input_player2.Text;
                input_player1.BackColor = Color.White;
                input_player2.BackColor = Color.White;
                input_player1.Enabled = false;
                input_player2.Enabled = false;
                buttonValidate.Enabled = false;
                buttonValidate.Text = "C'est parti !";

                player1_score_input.Text = player1 + " : " + player1_score;
                player2_score_input.Text = player2 + " : " + player2_score;

                gameStarted = true;
                turn = player1;
                message.Visible = true;
                message.Text = "C'est au tour de " + turn;
            }
            else
            {
                input_player1.BackColor = Color.Red;
                input_player2.BackColor = Color.Red;
            }
        }

        private void morpionClick(object sender, EventArgs en)
        {
            if (gameStarted)
            {
                Button morpionButton = sender as Button;

                if (turn == player1)
                {
                    morpionButton.Text = "X";
                    turn = player2;
                }
                else
                {
                    morpionButton.Text = "O";
                    turn = player1;
                }

                morpionButton.Enabled = false;
                message.Text = "C'est au tour de " + turn;

                if (someoneWin())
                {
                    if (turn == player1)
                    {
                        playerWon = player2;
                        message.Text = playerWon + " a gagné !";
                        player2_score = player2_score + 1;
                    }
                        
                    else
                    {
                        playerWon = player1;
                        message.Text = playerWon + " a gagné !";
                        player1_score = player1_score + 1;
                    }

                    player1_score_input.Text = player1 + " : " + player1_score;
                    player2_score_input.Text = player2 + " : " + player2_score;

                    retry_button.Visible = true;
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                    button5.Enabled = false;
                    button6.Enabled = false;
                    button7.Enabled = false;
                    button8.Enabled = false;
                    button9.Enabled = false;
                }

                if (draw())
                {
                    playerWon = player1;
                    message.Text = "Match nul !";
                    retry_button.Visible = true;

                    player1_score_input.Text = player1 + " : " + player1_score;
                    player2_score_input.Text = player2 + " : " + player2_score;
                }
            }
        }

        private bool someoneWin()
        {
            // lignes horizontales
            if (button1.Text == button2.Text && button2.Text == button3.Text && button2.Text != "")
                return true;
            if (button4.Text == button5.Text && button5.Text == button6.Text && button5.Text != "")
                return true;
            if (button7.Text == button8.Text && button8.Text == button9.Text && button8.Text != "")
                return true;
            // lignes verticales
            if (button1.Text == button4.Text && button4.Text == button7.Text && button4.Text != "")
                return true;
            if (button2.Text == button5.Text && button5.Text == button8.Text && button5.Text != "")
                return true;
            if (button3.Text == button6.Text && button6.Text == button9.Text && button6.Text != "")
                return true;
            // diagonales
            if (button1.Text == button5.Text && button5.Text == button9.Text && button5.Text != "")
                return true;
            if (button3.Text == button5.Text && button5.Text == button7.Text && button5.Text != "")
                return true;

            return false;

        }

        private bool draw()
        {
            if (button1.Text != "" && button2.Text != "" && button3.Text != "" && button4.Text != "" && button5.Text != "" && button6.Text != "" && button7.Text != "" && button8.Text != "" && button9.Text != "" && someoneWin() == false)
                return true;

            return false;
        }

        private void retry_button_Click(object sender, EventArgs e)
        {

            turn = playerWon;
            message.Text = "C'est au tour de " + turn;

            button1.Enabled = true;
            button1.Text = "";

            button2.Enabled = true;
            button2.Text = "";

            button3.Enabled = true;
            button3.Text = "";

            button4.Enabled = true;
            button4.Text = "";

            button5.Enabled = true;
            button5.Text = "";

            button6.Enabled = true;
            button6.Text = "";

            button7.Enabled = true;
            button7.Text = "";

            button8.Enabled = true;
            button8.Text = "";

            button9.Enabled = true;
            button9.Text = "";
        }
    }
}
