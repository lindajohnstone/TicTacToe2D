using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe2D
{
    public class GameContext
    {
        // stores Board, Player, game state
        // accesses board, player, validations?
        public Board2D GameBoard { get; private set; }
        public List<Player> Players { get; private set; } 
        private Validations _validations;
        
        public TurnQueue TurnQueue { get; set; }
        
        public GameContext(Board2D board, List<Player> players) 
        {
            var validations = new Validations();
            Initialize(players, board, validations);
        }
        
        public void Initialize(List<Player> players, Board2D board, Validations validations)
        {
            GameBoard = board;
            Players = players;
            _validations = validations;
            TurnQueue = new TurnQueue(players);
        }

        public Player GetCurrentPlayer()
        {
           return TurnQueue.GetCurrentPlayer();
        }

        public Player SetNextPlayer()
        {
            return TurnQueue.SetNextPlayer();
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
    }
}