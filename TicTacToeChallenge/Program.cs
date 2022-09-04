using System;

namespace TicTacToeChallenge
{
    internal class Program
    {
        static bool gameHasNotReset = true;

        static char[,] playField =
        {
            {'1', '2', '3'},
            {'4', '5', '6'},
            {'7', '8', '9'}
        };

        static int turns = 1;

        public static void SetField()
        {
            Console.WriteLine("   |   |   ");
            Console.WriteLine($" {playField[0, 0]} | {playField[0, 1]} | {playField[0, 2]}");
            Console.WriteLine("---|---|---");
            Console.WriteLine($" {playField[1, 0]} | {playField[1, 1]} | {playField[1, 2]}");
            Console.WriteLine("---|---|---");
            Console.WriteLine($" {playField[2, 0]} | {playField[2, 1]} | {playField[2, 2]}");
            Console.WriteLine("   |   |   ");
        }

        public static void ResetField()
        {
            char[,] initialPlayField =
            {
                {'1', '2', '3'},
                {'4', '5', '6'},
                {'7', '8', '9'}
            };
            playField = initialPlayField;
            turns = 1;
            gameHasNotReset = true;
            WhoWouldLikeToBegin();
            SetField();
        }

        public static void EnterXOrO(int playerTurn, int positionChoice)
        {
            char playerCallSign = ' ';
            if(playerTurn == 1)
            {
                playerCallSign = 'X';
            }
            if(playerTurn == 2)
            {
                playerCallSign = 'O';
            }
            switch(positionChoice)
            {
                case 1:
                    playField[0, 0] = playerCallSign;
                    turns++;
                    break;
                case 2:
                    playField[0, 1] = playerCallSign;
                    turns++;
                    break;
                case 3:
                    playField[0, 2] = playerCallSign;
                    turns++;
                    break;
                case 4:
                    playField[1, 0] = playerCallSign;
                    turns++;
                    break;
                case 5:
                    playField[1, 1] = playerCallSign;
                    turns++;
                    break;
                case 6:
                    playField[1, 2] = playerCallSign;
                    turns++;
                    break;
                case 7:
                    playField[2, 0] = playerCallSign;
                    turns++;
                    break;
                case 8:
                    playField[2, 1] = playerCallSign;
                    turns++;
                    break;
                case 9:
                    playField[2, 2] = playerCallSign;
                    turns++;
                    break;
                default:
                    Console.WriteLine("Wrong Input Please try again!");
                    break;
            }
            Console.Clear();
            SetField();
        }

        public static void WhoWouldLikeToBegin()
        {
            Console.Clear();
            bool choiceSelected = true;
            int playerWhoBegins = 1; 
            Console.Write("Who would like to begin: ");
            do
            {
                try
                {
                    playerWhoBegins = Convert.ToInt32(Console.ReadLine());
                    choiceSelected = true;
                }
                catch
                {
                    Console.WriteLine("Wrong Input Detected! Please Enter a number 1 for player 1 or 2 for player 2!!");
                }
                if(playerWhoBegins == 1)
                {
                    GameStart(playerWhoBegins);
                }
                else if(playerWhoBegins == 2)
                {
                    GameStart(playerWhoBegins);
                }
                else if(playerWhoBegins !=1 && playerWhoBegins !=2)
                {
                    Console.WriteLine("Wrong Player! Only two players can play this game!! Please re-enter your starting player: ");
                    choiceSelected = false;
                }
            } while (!choiceSelected);
        }

        public static void GameStart(int playerWhoPlays)
        {
            char[] playerSigns = {'X', 'O'};
            int choiceOfPlayer = 0;
            bool isInputCorrect = true;
            do
            {
                if(playerWhoPlays == 2)
                {
                    playerWhoPlays = 1;
                    EnterXOrO(playerWhoPlays, choiceOfPlayer);
                }
                else if(playerWhoPlays == 1)
                {
                    playerWhoPlays = 2;
                    EnterXOrO(playerWhoPlays, choiceOfPlayer);
                }

                //Checking Winning Condition here
                foreach(char c in playerSigns)
                {
                    Console.WriteLine(turns);
                    if ((playField[0, 0] == c && playField[1, 0] == c && playField[2, 0] == c) || (playField[0, 1] == c && playField[1, 1] == c && playField[2, 1] == c) || (playField[0, 2] == c && playField[1, 2] == c && playField[2, 2] == c) || (playField[0, 0] == c && playField[0, 1] == c && playField[0, 2] == c) || (playField[1, 0] == c && playField[1, 1] == c && playField[1, 2] == c) || (playField[2, 0] == c && playField[2, 1] == c && playField[2, 2] == c) || (playField[0, 0] == c && playField[1, 1] == c && playField[2, 2] == c) || (playField[2, 0] == c && playField[1, 1] == c && playField[0, 2] == c))
                    {
                        if (c == 'X')
                        {
                            Console.WriteLine("Player 1 has won the game!");
                            Console.WriteLine("Press any key to reset the game");
                            Console.ReadKey();
                            gameHasNotReset = false;
                            ResetField();
                        }
                        else if (c == 'O')
                        {
                            Console.WriteLine("Player 2 has won the game!");
                            Console.WriteLine("Press any key to reset the game");
                            Console.ReadKey();
                            gameHasNotReset = false;
                            ResetField();
                        }
                    }
                    else if (turns == 10)
                    {
                        Console.WriteLine("Match has come to a draw!");
                        Console.WriteLine("Press any key to reset the game");
                        Console.ReadKey();
                        gameHasNotReset = false;
                        ResetField();
                        Console.ReadKey();
                        WhoWouldLikeToBegin();
                    }
                }

                //Checking whether position is taken or not and taking user input
                do
                {
                    if (playerWhoPlays == 1)
                    {
                        Console.Write("Enter position player 1:");
                    }
                    else if (playerWhoPlays == 2)
                    {
                        Console.Write("Enter position player 2:");
                    }
                    try
                    {
                        choiceOfPlayer = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Wrong Input! Re-try!!");
                    }
                    if (choiceOfPlayer == 1 && playField[0, 0] == '1')
                    {
                        isInputCorrect = true;
                    }
                    else if (choiceOfPlayer == 2 && playField[0, 1] == '2')
                    {
                        isInputCorrect = true;
                    }
                    else if (choiceOfPlayer == 3 && playField[0, 2] == '3')
                    {
                        isInputCorrect = true;
                    }
                    else if (choiceOfPlayer == 4 && playField[1, 0] == '4')
                    {
                        isInputCorrect = true;
                    }
                    else if (choiceOfPlayer == 5 && playField[1, 1] == '5')
                    {
                        isInputCorrect = true;
                    }
                    else if (choiceOfPlayer == 6 && playField[1, 2] == '6')
                    {
                        isInputCorrect = true;
                    }
                    else if (choiceOfPlayer == 7 && playField[2, 0] == '7')
                    {
                        isInputCorrect = true;
                    }
                    else if (choiceOfPlayer == 8 && playField[2, 1] == '8')
                    {
                        isInputCorrect = true;
                    }
                    else if (choiceOfPlayer == 9 && playField[2, 2] == '9')
                    {
                        isInputCorrect = true;
                    }
                    else
                    {
                        isInputCorrect = false;
                    }
                    if (!isInputCorrect)
                    {
                        Console.WriteLine("Position Taken try again!!");
                    }
                } while (!isInputCorrect);
            } while (gameHasNotReset);
        }

        static void Main(string[] args)
        {
            int gameHasStarted;
            bool forGameStart;

            Console.WriteLine("Welcome to Console Based TicTacToe!!");
            Console.WriteLine("Grid is shown below. Select your position by entering the number and press enter!");
            Console.WriteLine("Player 1 is O and Player 2 is X");

            Console.WriteLine(" ");
            SetField();
            Console.WriteLine(" ");
            Console.Write("Press 1 to start the game and 0 to exit: ");

            forGameStart = int.TryParse(Console.ReadLine(), out gameHasStarted);

            if(forGameStart && gameHasStarted == 1)
            {
                WhoWouldLikeToBegin();
            }
            else if(forGameStart && gameHasStarted == 0)
            {
                Console.WriteLine("Entered 0! Closing Application!!");
            }
            else if(!forGameStart)
            {
                Console.WriteLine("Wrong Input Detected! Closing Application!!");
            }
        }
    }
}
