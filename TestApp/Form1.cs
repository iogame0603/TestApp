namespace TestApp
{
    public partial class Form1 : Form
    {
        static short ROW = 10;
        static short COL = 10;

        static short row = 9;
        static short col = 9;

        static string FLAG   = "🚩";

        private string[,] gameBoard = new string [ROW, COL];
        private Button[,] buttons = new Button[ROW, COL];

        public Form1()
        {
            InitializeComponent();
        }

        private void createGameBoard()
        {
            Random rand = new Random();

            // create board
            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    gameBoard[i, j] = "0";
                }
            }

            // make mine
            for (int i = 0; i < 10; i++)
            {
                int a = rand.Next(0, ROW);
                int b = rand.Next(0, COL);

                if (gameBoard[a, b] == "X")
                {
                    i--;
                }
                else
                {
                    gameBoard[a, b] = "X";
                }
            }

            // make number
            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    int c = 0;

                    if (gameBoard[i, j] != "X")
                    {
                        c = Convert.ToInt32(gameBoard[i, j]);

                        if (i != row)
                        {
                            if (gameBoard[i + 1, j] == "X")
                            {
                                gameBoard[i, j] = Convert.ToString(c += 1);
                            }
                        }

                        if (i != 0)
                        {
                            if (gameBoard[i-1, j] == "X")
                            {
                                gameBoard[i, j] = Convert.ToString(c += 1);
                            }
                        }

                        if (j != col)
                        {
                            if (gameBoard[i, j + 1] == "X")
                            {
                                gameBoard[i, j] = Convert.ToString(c += 1);
                            }
                        }

                        if (j != 0)
                        {
                            if (gameBoard[i, j - 1] == "X")
                            {
                                gameBoard[i, j] = Convert.ToString(c += 1);
                            }
                        }

                        if (i >= 0 && i < row && j >= 0 && j < col)
                        {
                            if (gameBoard[i + 1, j + 1] == "X")
                            {
                                gameBoard[i, j] = Convert.ToString(c += 1);
                            }
                        }

                        if (i > 0 && i <= row && j > 0 && j <= col)
                        {
                            if (gameBoard[i - 1, j - 1] == "X")
                            {
                                gameBoard[i, j] = Convert.ToString(c += 1);
                            }
                        }

                        if (i > 0 && i <= row && j >= 0 && j < col)
                        {
                            if (gameBoard[i - 1, j + 1] == "X")
                            {
                                gameBoard[i, j] = Convert.ToString(c += 1);
                            }
                        }

                        if (i >= 0 && i < row && j > 0 && j <= col)
                        {
                            if (gameBoard[i + 1, j - 1] == "X")
                            {
                                gameBoard[i, j] = Convert.ToString(c += 1);
                            }
                        }
                    }

                }
            }
        }

        private void createButton()
        {
            int xpos = 35;
            int ypos = 20;

            for (int i = 0; i < buttons.GetLength(0); i++)
            {
                for (int j = 0; j < buttons.GetLength(1); j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].TabStop = false;
                    buttons[i, j].BackColor= Color.Gray;
                    buttons[i, j].Location = new Point(xpos + (i * 50), ypos + (j * 50));
                    buttons[i, j].Size = new Size(60, 60);
                    buttons[i, j].Name = $"{i}{j}";
                    panel1.Controls.Add(buttons[i, j]);

                    // buttons[i, j].Click += new EventHandler(boardClick);
                    buttons[i, j].MouseDown += new MouseEventHandler(boardClick);
                }
            }
        }

        private void openBoard(int x, int y)
        {
            if (gameBoard[x, y] == "0")
            {
                if (x != 0)
                {
                    if (gameBoard[x - 1, y] == "0" && buttons[x - 1, y].BackColor == Color.Gray)
                    {
                        buttons[x - 1, y].BackColor = Color.White;
                        openBoard(x - 1, y);
                    }
                    else if (gameBoard[x - 1, y] != "X" && gameBoard[x - 1, y] != "0")
                    {
                        buttons[x - 1, y].BackColor = Color.White;
                        buttons[x - 1, y].Text = gameBoard[x - 1, y];
                    }
                }

                if (x != 9)
                {
                    if (gameBoard[x + 1, y] == "0" && buttons[x + 1, y].BackColor == Color.Gray)
                    {
                        buttons[x + 1, y].BackColor = Color.White;
                        openBoard(x + 1, y);
                    }
                    else if (gameBoard[x + 1, y] != "X" && gameBoard[x + 1, y] != "0")
                    {
                        buttons[x + 1, y].BackColor = Color.White;
                        buttons[x + 1, y].Text = gameBoard[x + 1, y];
                    }
                }

                if (y != 0)
                {
                    if (gameBoard[x, y - 1] == "0" && buttons[x, y - 1].BackColor == Color.Gray)
                    {
                        buttons[x, y - 1].BackColor = Color.White;
                        openBoard(x, y - 1);
                    }
                    else if (gameBoard[x, y - 1] != "X" && gameBoard[x, y - 1] != "0")
                    {
                        buttons[x, y - 1].BackColor = Color.White;
                        buttons[x, y - 1].Text = gameBoard[x, y - 1];
                    }
                }

                if (y != 9)
                {
                    if (gameBoard[x, y + 1] == "0" && buttons[x, y + 1].BackColor == Color.Gray)
                    {
                        buttons[x, y + 1].BackColor = Color.White;
                        openBoard(x, y + 1);
                    }
                    else if (gameBoard[x, y + 1] != "X" && gameBoard[x, y + 1] != "0")
                    {
                        buttons[x, y + 1].BackColor = Color.White;
                        buttons[x, y + 1].Text = gameBoard[x, y + 1];
                    }
                }

                if (x != 9 && y != 9)
                {
                    if (gameBoard[x + 1, y + 1] == "0" && buttons[x + 1, y + 1].BackColor == Color.Gray)
                    {
                        buttons[x + 1, y + 1].BackColor = Color.White;
                        openBoard(x + 1, y + 1);
                    }
                    else if (gameBoard[x + 1, y + 1] != "X" && gameBoard[x + 1, y + 1] != "0")
                    {
                        buttons[x + 1, y + 1].BackColor = Color.White;
                        buttons[x + 1, y + 1].Text = gameBoard[x + 1, y + 1];
                    }
                }

                if (x != 0 && y != 0)
                {
                    if (gameBoard[x - 1, y - 1] == "0" && buttons[x - 1, y - 1].BackColor == Color.Gray)
                    {
                        buttons[x - 1, y - 1].BackColor = Color.White;
                        openBoard(x - 1, y - 1);
                    }
                    else if (gameBoard[x - 1, y - 1]  != "X" && gameBoard[x - 1, y - 1] != "0")
                    {
                        buttons[x - 1, y - 1].BackColor = Color.White;
                        buttons[x - 1, y - 1].Text = gameBoard[x - 1, y - 1];
                    }
                }

                if (x != 9 && y != 0)
                {
                    if (gameBoard[x + 1, y - 1] == "0" && buttons[x + 1, y - 1].BackColor == Color.Gray)
                    {
                        buttons[x + 1, y - 1].BackColor = Color.White;
                        openBoard(x + 1, y - 1);
                    }
                    else if (gameBoard[x + 1, y - 1] != "X" && gameBoard[x + 1, y - 1] != "0")
                    {
                        buttons[x + 1, y - 1].BackColor = Color.White;
                        buttons[x + 1, y - 1].Text = gameBoard[x + 1, y - 1];
                    }
                }

                if (x != 0 && y != 9)
                {
                    if (gameBoard[x - 1, y + 1] == "0" && buttons[x - 1, y + 1].BackColor == Color.Gray)
                    {
                        buttons[x - 1, y + 1].BackColor = Color.White;
                        openBoard(x - 1, y + 1);
                    }
                    else if (gameBoard[x - 1, y + 1] != "X" && gameBoard[x - 1, y + 1] != "0")
                    {
                        buttons[x - 1, y + 1].BackColor = Color.White;
                        buttons[x - 1, y + 1].Text = gameBoard[x - 1, y + 1];
                    }
                }
            }
        }

        private void openBoard_Flag(int x, int y)
        {
            if (x != 0)
            {
                if (!flagCheck(x - 1, y))
                {
                    if (gameBoard[x - 1, y] == "0" && gameBoard[x - 1, y] != "X")
                    {
                        buttons[x - 1, y].Text = null;
                    }
                    else
                    {
                        buttons[x - 1, y].Text = gameBoard[x - 1, y];
                    }
                    buttons[x - 1, y].BackColor = Color.White;
                    openBoard(x - 1, y);
                }
            }

            if (x != row)
            {
                if (!flagCheck(x + 1, y))
                {
                    if (gameBoard[x + 1, y] == "0" && gameBoard[x + 1, y] != "X")
                    {
                        buttons[x + 1, y].Text = null;
                    }
                    else
                    {
                        buttons[x + 1, y].Text = gameBoard[x + 1, y];
                    }
                    buttons[x + 1, y].BackColor = Color.White;
                    openBoard(x + 1, y);
                }
            }

            if (y != 0)
            {
                if (!flagCheck(x , y - 1))
                {
                    if (gameBoard[x, y - 1] == "0" && gameBoard[x, y - 1] != "X")
                    {
                        buttons[x, y - 1].Text = null;
                    }
                    else
                    {
                        buttons[x, y - 1].Text = gameBoard[x, y - 1];
                    }
                    buttons[x, y - 1].BackColor = Color.White;
                    openBoard(x, y - 1);
                }
            }

            if (y != col)
            {
                if (!flagCheck(x, y + 1))
                {
                    if (gameBoard[x, y + 1] == "0" && gameBoard[x, y + 1] != "X")
                    {
                        buttons[x, y + 1].Text = null;
                    }
                    else
                    {
                        buttons[x, y + 1].Text = gameBoard[x, y + 1];
                    }
                    buttons[x, y + 1].BackColor = Color.White;
                    openBoard(x, y + 1);
                }
            }

            if (x != 0 && y != 0)
            {
                if (!flagCheck(x - 1, y - 1))
                {
                    if (gameBoard[x - 1, y - 1] == "0" && gameBoard[x - 1, y - 1] != "X")
                    {
                        buttons[x - 1, y - 1].Text = null;
                    }
                    else
                    {
                        buttons[x - 1, y - 1].Text = gameBoard[x - 1, y - 1];
                    }
                    buttons[x - 1, y - 1].BackColor = Color.White;
                    openBoard(x - 1, y - 1);
                }
            }

            if (x != row && y != col)
            {
                if (!flagCheck(x + 1, y + 1))
                {
                    if (gameBoard[x + 1, y + 1] == "0" && gameBoard[x + 1, y + 1] != "X")
                    {
                        buttons[x + 1, y + 1].Text = null;
                    }
                    else
                    {
                        buttons[x + 1, y + 1].Text = gameBoard[x + 1, y + 1];
                    }
                    buttons[x + 1, y + 1].BackColor = Color.White;
                    openBoard(x + 1, y + 1);
                }
            }

            if (x != row && y != 0)
            {
                if (!flagCheck(x + 1, y - 1))
                {
                    if (gameBoard[x + 1, y - 1] == "0" && gameBoard[x + 1, y - 1] != "X")
                    {
                        buttons[x + 1, y - 1].Text = null;
                    }
                    else
                    {
                        buttons[x + 1, y - 1].Text = gameBoard[x + 1, y - 1];
                    }
                    buttons[x + 1, y - 1].BackColor = Color.White;
                    openBoard(x + 1, y - 1);
                }
            }

            if (x != 0 && y != col)
            {
                if (!flagCheck(x - 1, y + 1))
                {
                    if (gameBoard[x - 1, y + 1] == "0" && gameBoard[x - 1, y + 1] != "X")
                    {
                        buttons[x - 1, y + 1].Text = null;
                    }
                    else
                    {
                        buttons[x - 1, y + 1].Text = gameBoard[x - 1, y + 1];
                    }
                    buttons[x - 1, y + 1].BackColor = Color.White;
                    openBoard(x - 1, y + 1);
                }
            }
        }

        private bool flagCheck(int x, int y)
        {
            if (buttons[x, y].Text == FLAG)
            {
                return true;
            }
            return false;
        }

        private void boardClick(object sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;
            int i = (int)char.GetNumericValue(btn.Name[0]);
            int j = (int)char.GetNumericValue(btn.Name[1]);

            // button click
            if (e.Button == MouseButtons.Left)
            {
                if (btn.BackColor == Color.Gray && btn.Text != FLAG)
                {
                    openBoard(i, j);
                    btn.BackColor = Color.White;
                    if (gameBoard[i, j] == "0")
                    {
                        btn.Text = null;
                    }
                    else
                    {
                        btn.Text = gameBoard[i, j];
                    }
                    btn.Font = new Font("맑은고딕", 10);
                }

                if (btn.BackColor == Color.White && gameBoard[i, j] != "0")
                {
                    int flag_cnt = 0;
                    int board_number = 0;
                    if (gameBoard[i, j] != null && gameBoard[i, j] != "X")
                    {
                        board_number = Convert.ToInt32(gameBoard[i, j]);
                    }

                    if (i != 0)
                    {
                        if (buttons[i - 1, j].Text == FLAG)
                        {
                            flag_cnt++;
                        }
                    }

                    if (i != row)
                    {
                        if (buttons[i + 1, j].Text == FLAG)
                        {
                            flag_cnt++;
                        }
                    }

                    if (j != 0)
                    {
                        if (buttons[i, j - 1].Text == FLAG)
                        {
                            flag_cnt++;
                        }
                    }

                    if (j != col)
                    {
                        if (buttons[i, j + 1].Text == FLAG)
                        {
                            flag_cnt++;
                        }
                    }

                    if (i != 0 && j != 0)
                    {
                        if (buttons[i - 1, j - 1].Text == FLAG)
                        {
                            flag_cnt++;
                        }
                    }

                    if (i != 9 && j != 9)
                    {
                        if (buttons[i + 1, j + 1].Text == FLAG)
                        {
                            flag_cnt++;
                        }
                    }

                    if (i != 0 && j != 9)
                    {
                        if (buttons[i - 1, j + 1].Text == FLAG)
                        {
                            flag_cnt++;
                        }
                    }

                    if (i != 9 && j != 0)
                    {
                        if (buttons[i + 1, j - 1].Text == FLAG)
                        {
                            flag_cnt++;
                        }
                    }

                    if (flag_cnt == board_number && gameBoard[i, j] != "X" && btn.BackColor == Color.White)
                    {
                        openBoard_Flag(i, j);
                    }
                }
            }

            // flag
            else if (e.Button == MouseButtons.Right && btn.BackColor == Color.Gray)
            {
                if (btn.Text == FLAG)
                {
                    btn.Text = null;
                }
                else
                {
                    btn.Text = FLAG;
                }
            }

            // game over
            for (int k = 0; k < gameBoard.GetLength(0); k++)
            {
                for (int f = 0; f < gameBoard.GetLength(0); f++)
                {
                    if (buttons[k, f].Text == "X" && buttons[k, f].BackColor == Color.White)
                    {
                        MessageBox.Show("Game Over!");
                        Application.Exit();
                    }
                }   
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            createGameBoard();
            createButton();
        }
    }
}