using System;
using System.Collections.Generic;

namespace TicTacToe
{
	class Game
	{
		const int NumberOfSquares = 9;
		const char Empty = ' ';
		const char Draw = 'D';
		const char None = ' ';
		static void PrintInstructions()
		{
			Console.WriteLine("Welcome to the game. To declare your move, you should enter a number [1 - 9] ");
			Console.WriteLine("\t1 | 2 | 3");
			Console.WriteLine("\t---------");
			Console.WriteLine("\t4 | 5 | 6");
			Console.WriteLine("\t---------");
			Console.WriteLine("\t7 | 8 | 9\n");
			Console.WriteLine("Let's begin.\n\n\n");
		}
		static char GetMoveOrder()
		{
			Console.WriteLine("Do you want to move first? (enter y/n)");
			ConsoleKeyInfo yn = Console.ReadKey();

			while (yn.Key != ConsoleKey.Y && yn.Key != ConsoleKey.N)
			{
				Console.WriteLine("\nYou entered neither y nor n. Please enter the key again");
				yn = Console.ReadKey();
			}

			if (yn.Key == ConsoleKey.Y)
			{
				return 'X';
			}
			else if (yn.Key == ConsoleKey.N)
			{
				return 'O';
			}

			return ' ';
		}
		static void DisplayBoard(char[] board)
		{
			Console.WriteLine("\t1 | 2 | 3");
			Console.WriteLine("\t---------");
			Console.WriteLine("\t4 | 5 | 6");
			Console.WriteLine("\t---------");
			Console.WriteLine("\t7 | 8 | 9\n\n\n");

			Console.WriteLine("\n\t" + board[0] + " | " + board[1] + " | " + board[2]);
			Console.WriteLine("\t---------");
			Console.WriteLine("\t" + board[3] + " | " + board[4] + " | " + board[5]);
			Console.WriteLine("\t---------");
			Console.WriteLine("\t" + board[6] + " | " + board[7] + " | " + board[8]);
			Console.WriteLine("\n\n");
		}
		static char GetWinner(char[] board)
		{
			if (board[0] == board[4] && board[4] == board[8] && board[0] != Empty)
			{
				return board[0];
			}
			if (board[2] == board[4] && board[4] == board[6] && board[2] != Empty)
			{
				return board[2];
			}

			for (int x = 0; x < 3; x++)
			{
				if (board[x] == board[3 + x] && board[3 + x] == board[6 + x] && board[x] != ' ')
				{
					return board[x];
				}
			}

			for (int y = 0; y < 3; y++)
			{
				if (board[y * 3] == board[y * 3 + 1] && board[y * 3 + 1] == board[y * 3 + 2] && board[y * 3] != ' ')
				{
					return board[y * 3];
				}
			}

			int EmptyCells = 0;

			for (int i = 0; i < board.Length; i++)
			{
				if (board[i] == Empty)
				{
					EmptyCells++;
				}
			}

			if (EmptyCells == 0)
			{
				return Draw;
			}

			return None;
		}
		static char Opponent(char pl)
		{
			if (pl == 'X')
			{
				return 'O';
			}

			return 'X';
		}
		static bool IsOccupied(int move, char[] board)
		{
			return board[move] != Empty;
		}
		static int GetNumber1to9()
		{
			Console.WriteLine("Enter a number (1 - 9): ");
			ConsoleKeyInfo a = Console.ReadKey();

			while (a.Key < ConsoleKey.D1 || a.Key > ConsoleKey.D9)
			{
				Console.WriteLine("\nPlease repeat the input. Enter a number from 1 to 9");
				a = Console.ReadKey();
			}

			int num = a.Key - ConsoleKey.D1;

			return num;
		}
		static int GetHumanMove(char[] board)
		{
			int move = GetNumber1to9();

			while (IsOccupied(move, board))
			{
				Console.WriteLine("\nThe cell is already occupied. Please repeat the input");
				move = GetNumber1to9();
			}

			return move;
		}
		static void Swap(ref int a1, ref int a2)
		{
			int temp = a1;
			a1 = a2;
			a2 = temp;
		}
		static int GetResultOfMove(int move, char turn, char[] board)
		{
			char[] boardCopy = new char[9];

			for (int i = 0; i < 9; i++)
			{
				boardCopy[i] = board[i];
			}

			boardCopy[move] = turn;
			turn = Opponent(turn);

			if (GetWinner(boardCopy) == None)
			{
				List<int> possibleMoves = new List<int>();

				for (int i = 0; i < 9; i++)
				{
					if (IsOccupied(i, boardCopy))
					{
						continue;
					}

					possibleMoves.Add(i);
				}

				int[] movesResults = new int[possibleMoves.Count];

				for (int i = 0; i < possibleMoves.Count; i++)
				{
					movesResults[i] = GetResultOfMove(possibleMoves[i], turn, boardCopy);
				}

				int iRet = 0;

				for (int i = 1; i < possibleMoves.Count; i++)
				{
					if (turn == 'X')
					{
						if (movesResults[iRet] > movesResults[i])
						{
							Swap(ref iRet, ref i);
						}
					}
					else
					{
						if (movesResults[iRet] < movesResults[i])
						{
							Swap(ref iRet, ref i);
						}
					}
				}

				return movesResults[iRet];
			}
			else
			{
				if (GetWinner(boardCopy) == 'X')
				{
					return -1;
				}
				else if (GetWinner(boardCopy) == 'O')
				{
					return 1;
				}
				else
				{
					return 0;
				}
			}
		}
		static int GetComputerMove(char[] board, char computer)
		{
			int move;
			List<int> possibleMoves = new List<int>();

			for (int i = 0; i < 9; i++)
			{
				if (IsOccupied(i, board)) { continue; }

				possibleMoves.Add(i);
			}

			int[] movesResults = new int[possibleMoves.Count];

			for (int i = 0; i < possibleMoves.Count; i++)
			{
				movesResults[i] = GetResultOfMove(possibleMoves[i], computer, board);
			}

			int iBestMove = 0;

			for (int i = 1; i < possibleMoves.Count; i++)
			{
				if (computer == 'X')
				{
					if (movesResults[iBestMove] > movesResults[i])
					{
						Swap(ref iBestMove, ref i);
					}
				}
				else
				{
					if (movesResults[iBestMove] < movesResults[i])
					{
						Swap(ref iBestMove, ref i);
					}
				}
			}

			Random rand = new Random();

			if (rand.Next(6) == 0)
			{
				move = possibleMoves[0];
			}
			else
			{
				move = possibleMoves[iBestMove];
			}

			return move;
		}
		static void PrintWinner(char winner, char human, char computer)
		{
			if (winner == human)
			{
				Console.WriteLine("You won");

			}
			else if (winner == computer)
			{
				Console.WriteLine("You lost");

			}
			else
			{
				Console.WriteLine("Draw");

			}
		}
		static void Main()
		{
			PrintInstructions();

			char human = GetMoveOrder();
			char computer = Opponent(human);

			char[] board = new char[NumberOfSquares];

			for (int i = 0; i < NumberOfSquares; i++)
			{
				board[i] = Empty;
			}

			Console.Clear();
			DisplayBoard(board);

			char turn = 'X';

			while (GetWinner(board) == None)
			{
				if (turn == human)
				{
					int move = GetHumanMove(board);
					board[move] = human;
				}
				else
				{
					int move = GetComputerMove(board, computer);
					board[move] = computer;
				}

				turn = Opponent(turn);
				Console.Clear();
				DisplayBoard(board);
			}

			PrintWinner(GetWinner(board), human, computer);
			Console.ReadKey(true);
		}
	}
}