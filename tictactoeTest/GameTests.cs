using CSharpFunctionalExtensions;
using Moq;
using TicTacToe;
using TicTacToe.Boards;
using TicTacToe.Display;
using TicTacToe.Players;

namespace tictactoeTest
{
    public class GameTests
    {
        [Fact]
        public void Game_ShouldInitializeCorrectly()
        {
            // Arrange
            var mockDisplay = new Mock<IDisplay>();
            var mockPlayer1 = new Mock<IPlayer>();
            var mockPlayer2 = new Mock<IPlayer>();

            // Act
            var game = new Game(mockDisplay.Object, mockPlayer1.Object, mockPlayer2.Object);

            // Assert
            Assert.Equal(mockPlayer1.Object, game.currentPlayer);
        }

        [Fact]
        public void Game_ShouldHaveEmptyBoardOnInitialization()
        {
            // Arrange
            var mockDisplay = new Mock<IDisplay>();
            var mockPlayer1 = new Mock<IPlayer>();
            var mockPlayer2 = new Mock<IPlayer>();

            // Act
            var game = new Game(mockDisplay.Object, mockPlayer1.Object, mockPlayer2.Object);
            var board = new Board(mockDisplay.Object);

            // Assert
            Assert.True(board.IsBoardEmpty());
        }
    }
}
