using Xunit;
using TicTacToe;
using TicTacToe.Players;
using TicTacToe.Boards;

namespace TicTacToe.Tests
{
    public class RandomPlayerTests
    {
        [Fact]
        public void GetNextMove_ShouldReturnValidMove()
        {
            // Arrange
            var randomPlayer = new RandomPlayer(PlayerConstants.PlayerOneIcon);

            // Act
            var result = randomPlayer.GetNextMove();

            // Assert
            Assert.True(result.IsSuccess);
            Assert.InRange(result.Value.Row, 1, 3);
            Assert.InRange(result.Value.Column, 1, 3);
        }
    }
}
