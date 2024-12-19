using Xunit;
using TicTacToe.Boards;
using TicTacToe.Display;
using Moq;
using TicTacToe.Players;

namespace TicTacToe.Tests
{
    public class BoardTests
    {
        [Fact]
        public void Board_ShouldInitializeWithEmptyCells()
        {
            // Arrange
            var mockDisplay = new Mock<IDisplay>();

            // Act
            var board = new Board(mockDisplay.Object);

            // Assert
            Assert.True(board.IsBoardEmpty());
        }

        [Fact]
        public void Board_ShouldDetectWin()
        {
            // Arrange
            var mockDisplay = new Mock<IDisplay>();
            var board = new Board(mockDisplay.Object);
            var player = new Mock<IPlayer>();
            player.Setup(p => p.Icon).Returns(PlayerConstants.PlayerOneIcon);

            // Simulate a winning condition
            board.PlayMoveOnBoard(new PlayerMove(1, 1), player.Object.Icon);
            board.PlayMoveOnBoard(new PlayerMove(1, 2), player.Object.Icon);
            board.PlayMoveOnBoard(new PlayerMove(1, 3), player.Object.Icon);

            // Act
            var result = board.IsGameOver(player.Object);

            // Assert
            Assert.True(result.HasValue);
            Assert.Equal($"Player {player.Object} has won the game !!!!", result.Value);
        }

        [Fact]
        public void Board_ShouldDetectDraw()
        {
            // Arrange
            var mockDisplay = new Mock<IDisplay>();
            var board = new Board(mockDisplay.Object);
            var player1 = new Mock<IPlayer>();
            var player2 = new Mock<IPlayer>();
            player1.Setup(p => p.Icon).Returns(PlayerConstants.PlayerOneIcon);
            player2.Setup(p => p.Icon).Returns(PlayerConstants.PlayerTwoIcon);

            // Simulate a draw condition
            board.PlayMoveOnBoard(new PlayerMove(1, 1), player1.Object.Icon);
            board.PlayMoveOnBoard(new PlayerMove(1, 2), player2.Object.Icon);
            board.PlayMoveOnBoard(new PlayerMove(1, 3), player1.Object.Icon);
            board.PlayMoveOnBoard(new PlayerMove(2, 1), player1.Object.Icon);
            board.PlayMoveOnBoard(new PlayerMove(2, 2), player2.Object.Icon);
            board.PlayMoveOnBoard(new PlayerMove(2, 3), player1.Object.Icon);
            board.PlayMoveOnBoard(new PlayerMove(3, 1), player2.Object.Icon);
            board.PlayMoveOnBoard(new PlayerMove(3, 2), player1.Object.Icon);
            board.PlayMoveOnBoard(new PlayerMove(3, 3), player2.Object.Icon);

            // Act
            var result = board.IsGameOver(player1.Object);

            // Assert
            Assert.True(result.HasValue);
            Assert.Equal("it's a draw!", result.Value);
        }

        [Fact]
        public void Board_ShouldNotAllowInvalidMove()
        {
            // Arrange
            var mockDisplay = new Mock<IDisplay>();
            var board = new Board(mockDisplay.Object);
            var playerMove = new PlayerMove(1, 1);

            // Act
            board.PlayMoveOnBoard(playerMove, PlayerConstants.PlayerOneIcon);
            var result = board.PlayMoveOnBoard(playerMove, PlayerConstants.PlayerTwoIcon);

            // Assert
            Assert.False(result);
        }
    }
}
