﻿using CSharpFunctionalExtensions;
using TicTacToe.Boards;
using TicTacToe.Display;
using TicTacToe.Players;

namespace TicTacToe;

public class Game
{
    private readonly IDisplay display;
    private readonly Board board;
    private readonly IPlayer player1;
    private readonly IPlayer player2;

    public IPlayer currentPlayer {  get; private set; }

    public Game(IDisplay display, IPlayer player1, IPlayer player2)
    {
        this.board = new Board(display);

        this.player1 = player1;
        this.player2 = player2;

        this.currentPlayer = this.player1;
        this.display = display;
    }

    public void Play()
    {
        this.board.DisplayGameBoard();

        while (true)
        {
            Result<PlayerMove> playerMoves = this.currentPlayer.GetNextMove();
            if (playerMoves.IsFailure)
            {
                this.display.WriteLine(playerMoves.Error);
                continue;
            }

            bool movePlayedSuccessfully = this.board.PlayMoveOnBoard(playerMoves.Value, this.currentPlayer.Icon);
            if (movePlayedSuccessfully is false)
            {
                this.display.WriteLine("Invalid move");
                continue;
            }
            this.board.DisplayGameBoard();

            Maybe<string> gameResult = this.board.IsGameOver(currentPlayer);
            if (gameResult.HasValue)
            {
                this.display.WriteLine(gameResult.Value);
                break;
            }

            this.SwitchPlayer();
        }
    }

    private void SwitchPlayer()
    {
        if (this.currentPlayer == player1)
            this.currentPlayer = player2;
        else
            this.currentPlayer = player1;
    }

}
