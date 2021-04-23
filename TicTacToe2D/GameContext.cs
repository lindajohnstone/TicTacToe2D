using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe2D
{
    public class GameContext
    {
        // stores Board, Player, game state
        // accesses board, player, validations?
        public Board GameBoard { get; private set; }
        public List<Player> Players { get; private set; } 
        private Validations _validations;
        public IInput ConsoleInput { get; private set; }
        public IOutput ConsoleOutput { get; private set; }
        
        public GameContext(Board board, List<Player> players) 
        {
            var validations = new Validations();
            Initialize(players, board, validations);
        }
        
        public void Initialize(List<Player> players, Board board, Validations validations)
        {
            var input = new ConsoleInput();
            var output = new ConsoleOutput();
            GameBoard = board;
            Players = players;
            _validations = validations;
            ConsoleInput = input;
            ConsoleOutput = output;
        }

        public Player GetCurrentPlayer()
        {
            // check how many empty fields in board
            // if modulus == 1, Player == X, else Y 
            if (GameBoard.GetAllPositions().Where((x) => GameBoard.GetField(x) == FieldContents.empty).Count() % 2 == 1)
            {
                return Players[0];
            }
            else 
            {
                return Players[1];
            }
        }

        public List<Player> GetPlayers()
        {
            Players = new List<Player>();
            foreach(Player player in Enum.GetValues(typeof(Player)))
            {
                Players.Add(player);
            }
            return Players;
        }

        public FieldContents PlayerFieldContents(Player player)
        {
            FieldContents fieldContents;
            if (player == Players[0])
            {
                fieldContents = FieldContents.x;
            }
            else
            {
                fieldContents = FieldContents.y;
            }

            return fieldContents;
        }

        public int GameState() // used int 0 & 1 - may need to use flags from Player
        {
            var player = GetCurrentPlayer();
            var condition = new GamePredicate();
            if (condition.IsWinningBoard(GameBoard, GameBoard.GetWinningLines(), PlayerFieldContents(player)))
            {
                OutputFormatter.PrintWinGame(player, ConsoleOutput);
                return 0;
            }
            if (condition.IsADraw(GameBoard))
            {
                OutputFormatter.PrintDrawnGame(ConsoleOutput);
                return 0;
            }
            return 1;
        }

        public override bool Equals(object obj)
        {
            return obj is GameContext context &&
                   EqualityComparer<Board>.Default.Equals(GameBoard, context.GameBoard) &&
                   Players == context.Players &&
                   EqualityComparer<Validations>.Default.Equals(_validations, context._validations);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(GameBoard, Players, _validations);
        }
    }
}