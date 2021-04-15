using System;

namespace TicTacToe2D
{
    public static class OutputFormatter 
    {
        // print instructions to console
        // print board to console
        // print win (which player) or draw 
        public static void DrawBoard(Board board, IOutput output) // TODO: adding Noughts ('O') value adds extra column
        {
           
            for (var column = 0; column < board.Width; column++)
            {
                for (var row = 0; row < board.Width; row++)
                {
                    var position = board.GetField(new Position(column, row));
                    switch (position)
                    {
                        case (FieldContents.y):
                            output.ConsoleWrite("O  ");
                            break;
                        case (FieldContents.x):
                            output.ConsoleWrite("X  ");
                            break;
                        case (FieldContents.empty):
                            output.ConsoleWrite(".  ");
                            break;
                    }
                }
                output.ConsoleWriteLine("");
            }
        }

        public static void PrintBoard(Board board, IOutput output)
        {
            output.ConsoleWriteLine("Here's the current board:");
            DrawBoard(board, output);
        }
        public static void PrintInstructions(Player player)
        {
            var output = new ConsoleOutput();
            var playerId = (int)player;
            var message = String.Format("Player {0} enter a coord x,y to place your {1} or enter 'q' to give up: ", playerId, player);
            output.ConsoleWrite(message); 
        }

        public static void PrintEndGame(Player player, ConsoleOutput output)
        {
            var message = String.Format("Player {0} has ended the game.", player);
            output.ConsoleWriteLine(message);
        }

        private static void PrintPlayerMove(ConsoleOutput output)
        {
            throw new NotImplementedException();
        }
    }
}