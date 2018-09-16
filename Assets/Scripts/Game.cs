using ChessDotNet; // the namespace of Chess.NET
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    class Game
    {
        public Game()
        {
            ChessGame game = new ChessGame();

            //Move movement = new Move(SelectedSpace, TargetSpace, game.WhoseTurn);
            Move move = new Move("A0", "A1", game.WhoseTurn);
            bool isValid = game.IsValidMove(move);

            if (isValid == true)
            {
                MoveType type = game.ApplyMove(move, true);
            }

            if (game.IsInCheck(game.WhoseTurn) == true)
            {

            }

            bool gameOver = false;
            if (game.IsCheckmated(game.WhoseTurn) == true)
            {
                gameOver = true;
            }

            if (game.IsDraw() == true)
            {
                gameOver = true;
            }

            if (gameOver == true)
            {

            }
        }
    }
}
