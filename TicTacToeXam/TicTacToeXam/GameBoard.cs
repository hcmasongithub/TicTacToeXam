using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace TicTacToeXam { 
    public class GameBoard : ContentPage
    {
        string[,] tictac_board = new string[3, 3];
        bool gameOver = false;
        bool crossesWon = false;
        bool noughtsWon = false;
        public const int EOF = -1;
        public const int ONE_PLAYER = 1;
        public const int TWO_PLAYERS = 2;
        int play_mode = TWO_PLAYERS;
        bool play_easy = true;
        int which_player = ONE_PLAYER; // player 1 starts first
        string which_symbol = " ";
        public const int ROWS = 3;
        public const int COLS = 3;
        public const string CROSSES = "X";
        public const string NOUGHTS = "O";
        string whichsymbol = " ";

        public void OnResetButtonClicked(object sender, EventArgs e)
        {
            Initialize_Board();
            gameOver = false;
            crossesWon = false;
            noughtsWon = false;
        }
        public void Initialize_Board()
        {
            tictac_board[0, 0] = "1";
            tictac_board[0, 1] = "2";
            tictac_board[0, 2] = "3";
            tictac_board[1, 0] = "4";
            tictac_board[1, 1] = "5";
            tictac_board[1, 2] = "6";
            tictac_board[2, 0] = "7";
            tictac_board[2, 1] = "8";
            tictac_board[2, 2] = "9";
            foreach (var theView in gameGrid.Children)
            {
                int row = 0, column = 0;
                Button theButton = theView as Button; // cast View to Button
                if (theButton == ticButtonUpperLeft)
                {
                    row = 0;
                    column = 0;
                }
                if (theButton == ticButtonUpperMiddle)
                {
                    row = 0;
                    column = 1;
                }
                if (theButton == ticButtonUpperRight)
                {
                    row = 0;
                    column = 2;
                }
                if (theButton == ticButtonCenterLeft)
                {
                    row = 1;
                    column = 0;
                }
                if (theButton == ticButtonCenterMiddle)
                {
                    row = 1;
                    column = 1;
                }
                if (theButton == ticButtonCenterRight)
                {
                    row = 1;
                    column = 2;
                }
                if (theButton == ticButtonBottomLeft)
                {
                    row = 2;
                    column = 0;
                }
                if (theButton == ticButtonBottomMiddle)
                {
                    row = 2;
                    column = 1;
                }
                if (theButton == ticButtonBottomRight)
                {
                    row = 2;
                    column = 2;
                }
                SetButtonText(theButton, row, column);
            }

        }
        Label playModeLabel = new Label
        {
            Text = "Press Switch On for Single Player Mode"
        };
        static Color backGroundColor = Device.OnPlatform<Color>(
            Color.Green,
            Color.Green,
            Color.Green);
        static double buttonHeight = Device.OnPlatform<double>
          (
            50, // iOS
            50, // Android
            80  // Windows Phone

         );

        static Color textColor = Device.OnPlatform<Color>(
               Color.Black,
               Color.Black,
               Color.Black
            );
        Switch playerModeSwitch = new Switch
        {
            HorizontalOptions = LayoutOptions.Start,
            VerticalOptions = LayoutOptions.Center
        };
        Label difficultPlayLabel = new Label
        {
            Text = "Press Switch On for Difficult Mode"
        };
        Switch difficultModeSwitch = new Switch
        {
            HorizontalOptions = LayoutOptions.Start,
            VerticalOptions = LayoutOptions.Center
        };
       
        Button returnButton = new Button
        {
        
            Text = "Return to Top",
            Style = new Style(typeof(Button))
            {
                Setters = {
                  new Setter {Property = Button.BackgroundColorProperty, Value = backGroundColor },
                  new Setter {Property = Button.BorderRadiusProperty, Value = 0},
                  new Setter {Property = Button.HeightRequestProperty, Value = buttonHeight},
                  new Setter {Property = Button.TextColorProperty, Value = textColor }
                }
            }
        };
        Button ticButtonUpperLeft = new Button
        {
            Text = "UL",
            BackgroundColor = Color.Yellow,
            TextColor = Color.Black,
            WidthRequest = 100
        };
        Button ticButtonUpperMiddle = new Button
        {
            Text = "UM",
            BackgroundColor = Color.Yellow,
            TextColor = Color.Black,
            WidthRequest = 100
        };
        Button ticButtonUpperRight = new Button
        {
            Text = "UR",
            BackgroundColor = Color.Yellow,
            TextColor = Color.Black,
            WidthRequest = 100
        };
        Button ticButtonCenterLeft = new Button
        {
            Text = "CL",
            WidthRequest = 100,
            BackgroundColor = Color.Yellow,
            TextColor = Color.Black
        };
        Button ticButtonCenterMiddle = new Button
        {
            Text = "CM",
            BackgroundColor = Color.Yellow,
            TextColor = Color.Black,
            WidthRequest = 100
        };
        Button ticButtonCenterRight = new Button
        {
            Text = "CR",
            BackgroundColor = Color.Yellow,
            TextColor = Color.Black,
            WidthRequest = 100
        };
        Button ticButtonBottomLeft = new Button
        {
            Text = "BL",
            BackgroundColor = Color.Yellow,
            TextColor = Color.Black,
            WidthRequest = 100
        };
        Button ticButtonBottomMiddle = new Button
        {
            Text = "BM",
            BackgroundColor = Color.Yellow,
            TextColor = Color.Black,
            WidthRequest = 100
        };
        Button ticButtonBottomRight = new Button
        {
            Text = "BR",
            BackgroundColor = Color.Yellow,
            TextColor = Color.Black,
            WidthRequest = 100
        };
        Button resetGame = new Button
        {
            Text = "Reset Game",
            Style = new Style(typeof(Button))
            {
                Setters = {
                  new Setter {Property = Button.BackgroundColorProperty, Value = backGroundColor},
                  new Setter {Property = Button.BorderRadiusProperty, Value = 0},
                  new Setter {Property = Button.HeightRequestProperty, Value = buttonHeight},
                  new Setter {Property = Button.TextColorProperty, Value = textColor }
                }
            }
        };
        Grid gameGrid = new Grid
        {
            RowDefinitions =
            {
                new RowDefinition { Height = GridLength.Auto },
                new RowDefinition { Height = GridLength.Auto },
                new RowDefinition { Height  = GridLength.Auto }
            },
            ColumnDefinitions =
            {
                new ColumnDefinition { Width = GridLength.Auto  },
                new ColumnDefinition { Width = GridLength.Auto  },
                new ColumnDefinition { Width = GridLength.Auto  }
            }
        };


        void OnTicButtonUpperLeftClicked(object sender, EventArgs e)
        {
            int square = 1;
            GameButtonPressedLogic(sender, square);
           
        }

       void OnTicButtonUpperMiddleClicked(object sender, EventArgs e)
        {
            int square = 2;
            GameButtonPressedLogic(sender, square);
            
        }

        void OnTicButtonUpperRightClicked(object sender, EventArgs e)
        {
            int square = 3;
            GameButtonPressedLogic(sender, square);
        }

        void OnTicButtonCenterLeftClicked(object sender, EventArgs e)
        {
            int square = 4;
            GameButtonPressedLogic(sender, square);
        }
        void OnTicButtonCenterMiddleClicked(object sender, EventArgs e)
        {
            int square = 5;
            GameButtonPressedLogic(sender, square);
        }
        void OnTicButtonCenterRightClicked(object sender, EventArgs e)
        {
            int square = 6;
            GameButtonPressedLogic(sender, square);
        }
        void OnTicButtonBottomLeftClicked(object sender, EventArgs e)
        {
            int square = 7;
            GameButtonPressedLogic(sender, square);
        }
        void OnTicButtonBottomMiddleClicked(object sender, EventArgs e)
        {
            int square = 8;
            GameButtonPressedLogic(sender, square);
        }
        void OnTicButtonBottomRightClicked(object sender, EventArgs e)
        {
            int square = 9;
            GameButtonPressedLogic(sender, square);
        }
        /*
	 * function already_occupied
	 *
	 * parameter tictac_board = two dimension array model of board
	 *
	 * parameter square = contains 1 thru 9 indicating which square
	 * to check to see if it already has an X or an O.
	 *
	 * Checks square to see if it is already taken.  Will return
	 * true if X or O there.  Else returns false.
	 */
        bool already_occupied(int square)
        {
            bool something_there = false;
            int row = 0, col = 0;
            // map from square to array coordinates using brute force
            if (square == 1)
            {
                row = col = 0; // first array row and column
            }
            if (square == 2)
            {
                row = 0;      // first row second column
                col = 1;
            }
            if (square == 3)
            {
                row = 0;    // first row third column
                col = 2;
            }
            if (square == 4)
            { // second row, first column
                row = 1;
                col = 0;
            }
            if (square == 5)
            { // second row, second col
                row = 1;
                col = 1;
            }
            if (square == 6)
            { // second row, third col
                row = 1;
                col = 2;
            }
            if (square == 7)
            { // third row, first column
                row = 2;
                col = 0;
            }
            if (square == 8)
            { // third row, second col
                row = 2;
                col = 1;
            }
            if (square == 9)
            { // third row, third col
                row = 2;
                col = 2;
            }
            // already occupied if contains X or contains O
            if (tictac_board[row, col] == CROSSES ||
               tictac_board[row, col] == NOUGHTS)
                something_there = true; // X or O already there.
                                        // if X or O there return true, else false
            return something_there;
        }
        async void DisplayMessages(string title, string message)
        {
            await DisplayAlert(title, message, "OK", "Cancel");
        }
        void GameButtonPressedLogic(object sender, int square)
        {
               if (gameOver)
            {
                DisplayMessages("Game Over", "Reset Game to start another game");
                return;
            }

            if(already_occupied(square))
            {
                DisplayMessages("Square Occupied", "Square Occupied already");
                return;
            }

            if(check_for_cats_game())
            {
                DisplayMessages("Cats Game", "CATS Game");
                return;
            }

            if (play_mode == TWO_PLAYERS)
            {
                if (which_player == 1)
                {
                    Button theButton = sender as Button;
                    theButton.Text = CROSSES;
                    set_square(square, CROSSES);
                    which_player = 2;

                }
                else
                {
                    Button theButton = sender as Button;
                    theButton.Text = NOUGHTS;
                    set_square(square, NOUGHTS);
                    which_player = 1;

                }
                if (check_for_cats_game())
                {
                    DisplayMessages("Cats Game", "CATS Game");
                    return;
                }
                if (gameOver = is_there_a_winner())
                {
                    string the_Winner = "The winner";

                    if (whichsymbol == NOUGHTS)
                    {
                        the_Winner = "Noughts Won!, Press Reset to restart game...";
                    }
                    else
                    {
                        the_Winner = "Crosses Won!, Press Reset to restart game...";
                    }
                    DisplayMessages("Game Over", the_Winner);
                    return;
                }
            }


            if (play_mode == ONE_PLAYER)
            {
                Button theButton = sender as Button;
                theButton.Text = CROSSES;
                set_square(square, CROSSES);
                which_player = 2;
                gameOver = false;
                if (check_for_cats_game())
                {
                    DisplayMessages("Cats Game", "CATS Game");
                    return;
                } // end if cats game
                if (gameOver = is_there_a_winner())
                {
                    string the_Winner = "The winner";

                    if (whichsymbol == NOUGHTS)
                    {
                        the_Winner = "Noughts Won!, Press Reset to restart game...";
                    }
                    else
                    {
                        the_Winner = "Crosses Won!, Press Reset to restart game...";
                    }
                    DisplayMessages("Game Over", the_Winner);
                    return;
                } // end came over
                doComputerTicTacToeLogic();
                if (check_for_cats_game())
                {
                    DisplayMessages("Cats Game", "CATS Game");
                    return;
                } // end check for cats game
                if (gameOver = is_there_a_winner())
                {
                    string the_Winner = "The winner";

                    if (whichsymbol == NOUGHTS)
                    {
                        the_Winner = "Noughts Won!, Press Reset to restart game...";
                    }
                    else
                    {
                        the_Winner = "Crosses Won!, Press Reset to restart game...";
                    }
                    DisplayMessages("Game Over", the_Winner);
                    return;
                } // end check if a winner

            } // end One Player mode

         
        } // end game button pressed


        async void OnReturnButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
       

        void doComputerTicTacToeLogic()
        {
            int next_square = 0;
            //		if(play_level_difficulty == EASY_MODE) {
            // get a random square...
            next_square = get_next_computer_square();

            if (next_square == EOF)
            {
                // no move possible
                which_player = 1;
                return;
            }

            switch (next_square)
            {

                case 1:
                    set_square(next_square, NOUGHTS);
                    ticButtonUpperLeft.Text = NOUGHTS;
               //     tictacNOUGHTS));
                    break;
                case 2:
                    set_square(next_square, NOUGHTS);
                    //      buttonTwo.setText(String.valueOf(NOUGHTS
                    ticButtonUpperMiddle.Text = NOUGHTS;
                    break;
                case 3:
                    set_square(next_square, NOUGHTS);
                    ticButtonUpperRight.Text = NOUGHTS;
                    //     buttonThree.setText(String.valueOf(NOUGHTS));
                    break;
                case 4:
                    set_square(next_square, NOUGHTS);
                    ticButtonCenterLeft.Text = NOUGHTS;
                    //     buttonFour.setText(String.valueOf(NOUGHTS));
                    break;
                case 5:
                    set_square(next_square, NOUGHTS);
                    ticButtonCenterMiddle.Text = NOUGHTS;
                    //   buttonFive.setText(String.valueOf(NOUGHTS));
                    break;
                case 6:
                    set_square(next_square, NOUGHTS);
                    ticButtonCenterRight.Text = NOUGHTS;
                    //buttonSix.setText(String.valueOf(NOUGHTS));
                    break;
                case 7:
                    set_square(next_square, NOUGHTS);
                    ticButtonBottomLeft.Text = NOUGHTS;
                    //buttonSeven.setText(String.valueOf(NOUGHTS));
                    break;
                case 8:
                    set_square(next_square, NOUGHTS);
                    ticButtonBottomMiddle.Text = NOUGHTS;
                    //buttonEight.setText(String.valueOf(NOUGHTS));
                    break;
                case 9:
                    set_square(next_square, NOUGHTS);
                    ticButtonBottomRight.Text = NOUGHTS;
                 //   buttonNine.setText(String.valueOf(NOUGHTS));
                    break;
                default:
                    break;

            }
        }
        int get_next_computer_square()
        {
            int which_square = 0, random_square = 0, last_random_value = 0;
            bool square_valid = false;
            if (check_for_cats_game())
            {
                which_square = EOF;
                square_valid = true;
            }
            // if not easy, then use strategy such as look for three in a row chance
            // or blocking the opponent.
            if (!play_easy)
            {
                // try and find two in a row of noughts.  If you find it,
                // and there is a free square, try and mark that square
                // and set square_valid to true and which_square to the
                // one found
                if ((which_square = try_for_three_noughts()) != 0)
                {
                    square_valid = true; // found a possible 3 in a row
                                         // bypass below random move generator since computer won!
                }
                else
                {
                    // if we can't win with 3 in a row, try and block the opponent
                    if ((which_square = try_to_block_crosses()) != 0)
                        square_valid = true;
                }
            }
            Random localRand = new Random();


            // perform until we get a valid square value which we will return
            // as the computers move
            while (square_valid == false)
            {
                // if easy find random number move, or if not easy play and we
                // didn't find a move before...
                if (play_easy == true || ((play_easy == false) && !square_valid))
                {
                    random_square = localRand.Next(10); //replaced the C rand function
                                                            // should be between 0 and 9
                    if (random_square == 0)
                        random_square = 1;
                    which_square = random_square;
                    // try and get around endless loop due to rand sending
                    // back same number several times in a row...but i guess this
                    // maybe can still loop if rand keeps returning
                    // only numbers that resolve to 1 thru 5 somehow...
                    if (which_square == last_random_value)
                    {
                        which_square++; // add 1 to which_square
                        if (which_square == 10)
                            which_square = 1;
                    }
                }
                last_random_value = which_square;
                if (already_occupied(which_square))
                {
                    square_valid = false;
                }
                else
                {
                    square_valid = true;
                }
            }

            return which_square;

            //boolean already_occupied(int square)	
        }
        int try_for_three_noughts()
        {
            int which_square = 0;
            which_square = find_block_or_win_square(NOUGHTS);
            return which_square;
        }

        int try_to_block_crosses()
        {
            int which_square = 0;


            which_square = find_block_or_win_square(CROSSES);

            return which_square;
        }

        int find_block_or_win_square(string check_char)
        {
            int which_square = 0;

            // for all the if statements below.  If two of same X or O symbol
            // in a row or column, and the third square empty, we can
            // use that square to either win or block, so set which_square
            // to it and then return it eventually.

            // row 1.  left upper square of board
            if (tictac_board[0,0] == "1" &&
               tictac_board[0,1] == check_char &&
               tictac_board[0,2] == check_char)
            {
                which_square = 1;
            }
            // row 1.  top middle square
            if (tictac_board[0,0] == check_char &&
               tictac_board[0,1] == "2" &&
               tictac_board[0,2] == check_char)
            {
                which_square = 2;
            }
            // row 1.  right corner square
            if (tictac_board[0,0] == check_char &&
               tictac_board[0,1] == check_char &&
               tictac_board[0,2] == "3")
            {
                which_square = 3;
            }
            // row 2.  left center square
            if (tictac_board[1,0] == "4" &&
               tictac_board[1,1] == check_char &&
               tictac_board[1,2] == check_char)
            {
                which_square = 4;
            }
            // row 2.  bulls eye middle area
            if (tictac_board[1,0] == check_char &&
               tictac_board[1,1] == "5" &&
               tictac_board[1,2] == check_char)
            {
                which_square = 5;
            }
            // row 2.  right middle square
            if (tictac_board[1,0] == check_char &&
               tictac_board[1,1] == check_char &&
               tictac_board[1,2] == "6")
            {
                which_square = 6;
            }
            // row 3.  left bottom square
            if (tictac_board[2,0] == "7" &&
               tictac_board[2,1] == check_char &&
               tictac_board[2,2] == check_char)
            {
                which_square = 7;
            }
            // row 3.  middle bottom square
            if (tictac_board[2,0] == check_char &&
               tictac_board[2,1] == "8" &&
               tictac_board[2,2] == check_char)
            {
                which_square = 8;
            }
            // row 3. corner right square
            if (tictac_board[2,0] == check_char &&
               tictac_board[2,1] == check_char &&
               tictac_board[2,2] == "9")
            {
                which_square = 9;
            }
            // Now for the columns as the brute force continues...
            // column 1.  top square
            if (tictac_board[0,0] == "1" &&
               tictac_board[1,0] == check_char &&
               tictac_board[2,0] == check_char)
            {
                which_square = 1;
            }
            // column 1.  middle left square
            if (tictac_board[0,0] == check_char &&
               tictac_board[1,0] == "4" &&
               tictac_board[2,0] == check_char)
            {
                which_square = 4;
            }
            // column 1.  bottom left square
            if (tictac_board[0,0] == check_char &&
               tictac_board[1,0] == check_char &&
               tictac_board[2,0] == "7")
            {
                which_square = 7;
            }
            // column 2.  top middle square
            if (tictac_board[0,1] == "2" &&
               tictac_board[1,1] == check_char &&
               tictac_board[2,1] == check_char)
            {
                which_square = 2;
            }
            // column 2.  the middle square
            if (tictac_board[0,1] == check_char &&
               tictac_board[1,1] == "5" &&
               tictac_board[2,1] == check_char)
            {
                which_square = 5;
            }
            // column 2. last square
            if (tictac_board[0,1] == check_char &&
               tictac_board[1,1] == check_char &&
               tictac_board[2,1] == "8")
            {
                which_square = 8;
            }
            // column 3 first square on row 1
            if (tictac_board[0,2] == "3" &&
               tictac_board[1,2] == check_char &&
               tictac_board[2,2] == check_char)
            {
                which_square = 3;
            }
            // column 3 continued.
            if (tictac_board[0,2] == check_char &&
               tictac_board[1,2] == "6" &&
               tictac_board[2,2] == check_char)
            {
                which_square = 6;
            }
            // column 3 last square.
            if (tictac_board[0,2] == check_char &&
               tictac_board[1,2] == check_char &&
               tictac_board[2,2] == "9")
            {
                which_square = 9;
            }
            // diagonal top left to bottom right
            if (tictac_board[0,0] == "1" &&
               tictac_board[1,1] == check_char &&
               tictac_board[2,2] == check_char)
            {
                which_square = 1;
            }
            // diagonal top left to bottom right
            if (tictac_board[0,0] == check_char &&
               tictac_board[1,1] == "5" &&
               tictac_board[2,2] == check_char)
            {
                which_square = 5;
            }
            // diagonal top left to bottom right
            if (tictac_board[0,0] == check_char &&
               tictac_board[1,1] == check_char &&
               tictac_board[2,2] == "9")
            {
                which_square = 9;
            }
            // diagonal bottom left to top right
            if (tictac_board[2,0] == "7" &&
               tictac_board[1,1] == check_char &&
               tictac_board[0,2] == check_char)
            {
                which_square = 7;
            }
            // diagonal bottom left to top right
            if (tictac_board[2,0] == check_char &&
               tictac_board[1,1] == "5" &&
               tictac_board[0,2] == check_char)
            {
                which_square = 5;
            }
            // diagonal bottom left to top right
            if (tictac_board[2,0] == check_char &&
               tictac_board[1,1] == check_char &&
               tictac_board[0,2] == "3")
            {
                which_square = 3;
            }

            return which_square;
        }
        bool is_there_a_winner()
        {
            bool three_in_a_row = false;

            // check for three X in a row/col/diagonal
            if (check_for_three(CROSSES))
            {
                // X wins, notify calling function
                whichsymbol = CROSSES;
                three_in_a_row = true;
            }

            // check for noughts
            // check for three X in a row/col/diagonal
            if (check_for_three(NOUGHTS))
            {
                // Noughts O wins, tell calling function
                whichsymbol = NOUGHTS;
                three_in_a_row = true;
            }

            // returns true if 3 in a row, otherwise false
            return three_in_a_row;
        }
        void set_square(int square, string whichsymbol)
        {
            int row = 0, col = 0;
            // map from square to array coordinates using brute force
            if (square == 1)
            {
                row = col = 0; // first array row and column
            }
            if (square == 2)
            {
                row = 0;      // first row second column
                col = 1;
            }
            if (square == 3)
            {
                row = 0;    // first row third column
                col = 2;
            }
            if (square == 4)
            { // second row, first column
                row = 1;
                col = 0;
            }
            if (square == 5)
            { // second row, second col
                row = 1;
                col = 1;
            }
            if (square == 6)
            { // second row, third col
                row = 1;
                col = 2;
            }
            if (square == 7)
            { // third row, first column
                row = 2;
                col = 0;
            }
            if (square == 8)
            { // third row, second col
                row = 2;
                col = 1;
            }
            if (square == 9)
            { // third row, third col
                row = 2;
                col = 2;
            }
            // set the square to either X or O
            tictac_board[row,col] = whichsymbol;
        }
        bool check_for_three(string crossornoughts)
        {
            bool three_in_a_row = false;
            // check for three in first row
            if (tictac_board[0,0] == crossornoughts &&
               tictac_board[0,1] == crossornoughts &&
               tictac_board[0,2] == crossornoughts)
            {
                three_in_a_row = true;
            }
            // check for three in second row
            if (tictac_board[1,0] == crossornoughts &&
                tictac_board[1,1] == crossornoughts &&
                tictac_board[1,2] == crossornoughts)
            {
                three_in_a_row = true;
            }
            // check for three in a row in third row
            if (tictac_board[2,0] == crossornoughts &&
                tictac_board[2,1] == crossornoughts &&
                tictac_board[2,2] == crossornoughts)
            {
                three_in_a_row = true;
            }
            // check for three next to each other in first column
            if (tictac_board[0,0] == crossornoughts &&
                tictac_board[1,0] == crossornoughts &&
                tictac_board[2,0] == crossornoughts)
            {
                three_in_a_row = true;
            }
            // check for three contiguous in second column
            if (tictac_board[0,1] == crossornoughts &&
               tictac_board[1,1] == crossornoughts &&
               tictac_board[2,1] == crossornoughts)
            {
                three_in_a_row = true;
            }
            // check for tic tac toe in third column
            if (tictac_board[0,2] == crossornoughts &&
               tictac_board[1,2] == crossornoughts &&
               tictac_board[2,2] == crossornoughts)
            {
                three_in_a_row = true;
            }
            // check for tic tac toe in first diagonal left to bottom
            if (tictac_board[0,0] == crossornoughts &&
               tictac_board[1,1] == crossornoughts &&
               tictac_board[2,2] == crossornoughts)
            {
                three_in_a_row = true;
            }
            // check for tic tac toe diagonal top right to bottom left
            if (tictac_board[0,2] == crossornoughts &&
               tictac_board[1,1] == crossornoughts &&
               tictac_board[2,0] == crossornoughts)
            {
                three_in_a_row = true;
            }

            // return true if three in a row, otherwise false
            return three_in_a_row;
        }
        public void SetButtonText(Button button, int row, int column)
        {
            button.Text = tictac_board[row, column];
        }
        bool check_for_cats_game()
        {
            bool cats_game = true;
            int row, col;

            // look at each character in the array. and if you find
            // one square containing something besides X or O then
            // return false.  Otherwise, return true since no
            // square unoccupied by X or O.
            // for each row, check until end of row, and haven"t
            // set cats_game to false.
            for (row = 0; row < ROWS && cats_game == true; row++)
            {
                // for each cell check to see if cross or nought
                for (col = 0; col < COLS; col++)
                {
                    if (tictac_board[row, col] == CROSSES ||
                       tictac_board[row, col] == NOUGHTS)
                        continue; // could still be cats game..check further
                    else
                    {
                        // found a square without X nor O
                        // so the board isn"t full yet
                        cats_game = false;
                        // break out since found one available square
                        break;
                    }

                }
            }

            return cats_game;
        }
        public GameBoard()
        {
            // initial array
            Initialize_Board();
            // first Row of Buttons
            gameGrid.Children.Add(ticButtonUpperLeft, 0, 0);
            gameGrid.Children.Add(ticButtonUpperMiddle,1, 0);
            gameGrid.Children.Add(ticButtonUpperRight, 2, 0);

            // middle row of buttons
            gameGrid.Children.Add(ticButtonCenterLeft, 0, 1);
            gameGrid.Children.Add(ticButtonCenterMiddle, 1, 1);
            gameGrid.Children.Add(ticButtonCenterRight, 2, 1);

            // last Grid row of buttons
            gameGrid.Children.Add(ticButtonBottomLeft, 0, 2);
            gameGrid.Children.Add(ticButtonBottomMiddle, 1, 2);
            gameGrid.Children.Add(ticButtonBottomRight, 2, 2);

            foreach (var theView in gameGrid.Children)
            {
                int row = 0, column = 0;
                Button theButton = theView as Button; // cast View to Button
                if (theButton == ticButtonUpperLeft)
                {
                    row = 0;
                    column = 0;
                }
                if (theButton == ticButtonUpperMiddle)
                {
                    row = 0;
                    column = 1;
                }
                if (theButton == ticButtonUpperRight)
                {
                    row = 0;
                    column = 2;
                }
                if (theButton == ticButtonCenterLeft)
                {
                    row = 1;
                    column = 0;
                }
                if (theButton == ticButtonCenterMiddle)
                {
                    row = 1;
                    column = 1;
                }
                if (theButton == ticButtonCenterRight)
                {
                    row = 1;
                    column = 2;
                }
                if (theButton == ticButtonBottomLeft)
                {
                    row = 2;
                    column = 0;
                }
                if (theButton == ticButtonBottomMiddle)
                {
                    row = 2;
                    column = 1;
                }
                if (theButton == ticButtonBottomRight)
                {
                    row = 2;
                    column = 2;
                }
                SetButtonText(theButton, row, column);
            }


           
            ticButtonUpperLeft.Clicked += OnTicButtonUpperLeftClicked;

          
            ticButtonUpperMiddle.Clicked += OnTicButtonUpperMiddleClicked;

     
            ticButtonUpperRight.Clicked += OnTicButtonUpperRightClicked;

            ticButtonCenterLeft.Clicked -= OnTicButtonCenterLeftClicked;
            ticButtonCenterLeft.Clicked += OnTicButtonCenterLeftClicked;

            ticButtonCenterMiddle.Clicked += OnTicButtonCenterMiddleClicked;
            ticButtonCenterRight.Clicked += OnTicButtonCenterRightClicked;

            ticButtonBottomLeft.Clicked += OnTicButtonBottomLeftClicked;
            ticButtonBottomMiddle.Clicked += OnTicButtonBottomMiddleClicked;

           // ticButtonBottomRight.Clicked -= OnTicButtonBottomRightClicked;
            ticButtonBottomRight.Clicked += OnTicButtonBottomRightClicked;
            resetGame.Clicked += OnResetButtonClicked;
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "GameBoard Page" },
                    returnButton,
                    gameGrid,
                    new StackLayout{
                        Orientation = StackOrientation.Horizontal,
                        Children =
                        {
                            playModeLabel,
                            playerModeSwitch,
                        }
                    },
                    resetGame,
                    new StackLayout {
                        Orientation = StackOrientation.Horizontal,
                        Children = {
                          difficultPlayLabel,
                          difficultModeSwitch
                        }
                    }
                }
            };
            returnButton.Clicked += OnReturnButtonClicked;
            playerModeSwitch.Toggled += OnPlayerModeSwitchToggle;
            difficultModeSwitch.Toggled += OnHardPlaySwitchToggle;

        }
        // Change how many players are playing
        void OnPlayerModeSwitchToggle(object sender, ToggledEventArgs e)
        {
            if (e.Value == true)
            {
                play_mode = ONE_PLAYER;
            }else
            {
                play_mode = TWO_PLAYERS;
            }
        }
        // Change how many players are playing
        void OnHardPlaySwitchToggle(object sender, ToggledEventArgs e)
        {
            if (e.Value == true)
            {
                play_easy = false;
            }
            else
            {
                play_easy = true;
            }
        }
    }
}
