namespace TicTacToe2D
{
    public interface IInputParser
    {
        public Position GetPlayerMove(string input);
        public bool PlayerEndsGame(Player player, char input);
    }
}