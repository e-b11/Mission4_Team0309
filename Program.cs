﻿
//Eliza Sorensen, Emma Bastian, Josh Michaelson, Javier De los Reyes

//Methods: printBoard(board) take 1 parameter of board array
//          getBoard(board) takes 1 parameter of board array and returns it         
//          gameResult(string[] board, string turn, int turns) take in board array, whose turn it is ("X" or "O"), and how many turns there have been

using Mission4;
using System;


class Program {
    static void Main(string[] args) {
        //Create instance of suppporting class
        TicTacTools ttt = new TicTacTools();

        //Possible board array, so player can choose a position. They'll know they can't use it once an X or O is in there
        string[] board = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        //Game Logic

        Console.WriteLine("Welcome to tic tac toe!");
        Console.WriteLine("For each players turn, enter the number on the board you would like to play.");
        Console.WriteLine("Here is the board, X's go first!");

        // initialize game stuffs
        int numTurns = 0;
        bool gameOver = false;
        string turn = "X";

        //create a list to keep track of used slots on the board
        List<int> usedMoves = new List<int>();

        //do while game is in play
        while (!gameOver)
        {

            Console.WriteLine(ttt.printBoard(board));
            // Get player input

            Console.WriteLine(turn + "'s turn!");

            string moveStr = Console.ReadLine();

            //look to see if input is/could be an integer
            if (!int.TryParse(moveStr, out int move))
            {
                Console.WriteLine("Please Enter a valid number input");
                continue;
            }

            //make string input an integer
            int moveInt = int.Parse(moveStr) - 1;

            //look to see if position number is in the array of used spots, if not allow the user to play it and add it to array of used slots,
            //or make them enter a new number if the slot has already been used

            if (usedMoves.Contains(moveInt))
            {
                Console.WriteLine("Please Pick a Slot that has not been used");

            }
            else
            {
                usedMoves.Add(moveInt);
                board[moveInt] = turn;
                numTurns++;
                gameOver = ttt.gameResult(board, turn, numTurns);
                turn = (turn == "X") ? "O" : "X";


            }
        }

            Console.WriteLine(ttt.printBoard(board));

            //see if the user wants to play again and based off the response either reset game or thank them for playing
            //if the user does want to play again, reset all varaibles and arguments

            while (gameOver)
            {
                Console.WriteLine("Do you want to play again? (y/n)");
                string playAgain = Console.ReadLine();
                if (playAgain.ToLower() == "y")
                {
                
                    gameOver = false;
                    Array.Fill(board, " ");
                    turn = "X";
                    numTurns = 0;
                    usedMoves.Clear();
                    Main(args);
                }
                else
                {
                    Console.WriteLine("Thanks for playing!");
                    
                      
                }
            }
       
    } 
}

