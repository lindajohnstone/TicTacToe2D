using System;
using Xunit;

namespace TicTacToe2D.Tests
{
    public class GamePredicateTests
    {
        [Theory]
        [InlineData(0, 0, 1, 0, 2, 0, true)]
        [InlineData(0, 1, 1, 1, 2, 1, true)]
        [InlineData(0, 2, 1, 2, 2, 2, true)]
        public void GamePredicate_Is_a_winning_column(int x1, int y1, int x2, int y2, int x3, int y3, bool expected)
        {
            var win = new GamePredicate();
            var board = new Board(3);
            // win if position(0,0), position(1,0) && position(2,0) all have FieldContents == 'x'
            var pos1 = new Position(x1, y1);
            var pos2 = new Position(x2, y2);
            var pos3 = new Position(x3, y3);
            board.Dictionary[pos1] = FieldContents.x;
            board.Dictionary[pos2] = FieldContents.x;
            board.Dictionary[pos3] = FieldContents.x;
            var result = win.IsAWinningColumn(board);
            Assert.Equal(expected, result);
        }
    }
}