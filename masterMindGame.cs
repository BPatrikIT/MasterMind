using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace MasterMind
{
    public partial class MasterMind : Form
    {
        public int maxLines = 12;
        public int maxColumns = 4;
        public int currentLine = 0;
        public int currentColumn = 0;
        public string[] colors = new string[4];
        public string[] answer = new string[4];

        public void disableButtons()
        {
            ballRed.Enabled = false;
            ballYellow.Enabled = false;
            ballGreen.Enabled = false;
            ballTeal.Enabled = false;
            ballBlue.Enabled = false;
            ballPurple.Enabled = false;
            buttonUndo.Enabled = false;
            buttonSubmit.Enabled = false;
        }

        public void checkAnswer(string[] tempAnswers, string[] guessColors)
        {
            string[] tempAnswersCopy = (string[])tempAnswers.Clone();

            int correctColor = 0;
            int correctPlace = 0;
            List<int> correctIndex = new List<int>();

            for (int i = 0; i < 4; i++)
            {
                if (tempAnswersCopy[i] == guessColors[i])
                {
                    correctPlace++;
                    tempAnswersCopy[i] = null;
                    guessColors[i] = null;
                }
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (guessColors[i] == tempAnswersCopy[j] && guessColors[i] != null)
                    {
                        correctColor++;
                        tempAnswersCopy[j] = null;
                        break;
                    }
                }
            }

            drawFeedback(correctColor, correctPlace);
            if (correctPlace == 4)
            {
                Thread th = new Thread(openWinScreen);
                th.Start();
                disableButtons();
            }
            else if (currentLine == maxLines - 1)
            {
                Thread th = new Thread(openLoseScreen);
                th.Start();
                disableButtons();
            }
            else
            {
                currentLine++;
                currentColumn = 0;
                colors[0] = null;
                colors[1] = null;
                colors[2] = null;
                colors[3] = null;
            }
        }

        private void openLoseScreen()
        {
            Application.Run(new loseScreen());
        }

        private void openWinScreen()
        {
            Application.Run(new winScreen());
        }

        public void drawFeedback(int drawCorrectColor, int drawCorrectPlace)
        {
            int currecntIndex = 0;
            for (int i = 0; i < drawCorrectPlace; i++)
            {
                ((PictureBox)this.Controls["answerBall" + Convert.ToString(currentLine) + Convert.ToString(i)]).BackgroundImage = new Bitmap("files\\images\\ballBlack.png");
                currecntIndex++;
            }

            for (int i = currecntIndex; i < drawCorrectColor+drawCorrectPlace; i++)
            {
                ((PictureBox)this.Controls["answerBall" + Convert.ToString(currentLine) + Convert.ToString(i)]).BackgroundImage = new Bitmap("files\\images\\ballWhite.png");
            }
        }

        public void generateAnswer()
        {
            Random rnd = new Random();
            for (int i = 0; i < 4; i++)
            {
                int temp = rnd.Next(6);
                switch (temp)
                {
                    case 0:
                        answer[i] = "ballRed";
                        break;
                    case 1:
                        answer[i] = "ballYellow";
                        break;
                    case 2:
                        answer[i] = "ballGreen";
                        break;
                    case 3:
                        answer[i] = "ballTeal";
                        break;
                    case 4:
                        answer[i] = "ballBlue";
                        break;
                    case 5:
                        answer[i] = "ballPurple";
                        break;
                }
            }
        }

        public void drawAnswer()
        {
            for (int i = 0; i < 4; i++)
            {
                string answerName = "answer" + Convert.ToString(i);
                ((PictureBox)this.Controls[answerName]).BackgroundImage = new Bitmap("files\\images\\" + answer[i] + ".png");
            }
        }

        public void addBall(int row, int column, string color)
        {
            string guessName = "guess" + Convert.ToString(row) + Convert.ToString(column);
            ((PictureBox)this.Controls[guessName]).BackgroundImage = new Bitmap("files\\images\\" + color + ".png");
            colors[column] = color; 
        }

        public void removeBall(int row, int column)
        {
            string guessName = "guess" + Convert.ToString(row) + Convert.ToString(column);
            ((PictureBox)this.Controls[guessName]).BackgroundImage = null;
            colors[column] = null;
        }

        public MasterMind()
        {
            InitializeComponent();
            generateAnswer();
            drawAnswer();
        }

        private void MasterMind_Load(object sender, EventArgs e)
        {

        }

        private void ballRed_Click(object sender, EventArgs e)
        {
            if (currentColumn < maxColumns)
            {
                addBall(currentLine, currentColumn, "ballRed");
                currentColumn++;
            }
        }

        private void ballYellow_Click(object sender, EventArgs e)
        {
            if (currentColumn < maxColumns)
            {
                addBall(currentLine, currentColumn, "ballYellow");
                currentColumn++;
            }
        }

        private void ballGreen_Click(object sender, EventArgs e)
        {
            if (currentColumn < maxColumns)
            {
                addBall(currentLine, currentColumn, "ballGreen");
                currentColumn++;
            }
        }

        private void ballTeal_Click(object sender, EventArgs e)
        {
            if (currentColumn < maxColumns)
            {
                addBall(currentLine, currentColumn, "ballTeal");
                currentColumn++;
            }
        }

        private void ballBlue_Click(object sender, EventArgs e)
        {
            if (currentColumn < maxColumns)
            {
                addBall(currentLine, currentColumn, "ballBlue");
                currentColumn++;
            }
        }

        private void ballPurple_Click(object sender, EventArgs e)
        {
            if (currentColumn < maxColumns)
            {
                addBall(currentLine, currentColumn, "ballPurple");
                currentColumn++;
            }
        }

        private void buttonUndo_Click(object sender, EventArgs e)
        {
            if (currentColumn > 0)
            {
                currentColumn--;
                removeBall(currentLine, currentColumn);
            }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (currentColumn >=3)
            {
                checkAnswer(answer, colors);
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            Close();
            Thread th = new Thread(gameRestart);
            th.Start();
        }

        private void gameRestart()
        {
            Application.Run(new MasterMind());
        }
    }
}