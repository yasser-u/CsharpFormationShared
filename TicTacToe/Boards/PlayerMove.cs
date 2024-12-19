﻿namespace TicTacToe.Boards;

public record PlayerMove(int Row, int Column)
{
    public static PlayerMove Random
        => new PlayerMove(System.Random.Shared.Next(1, 4), System.Random.Shared.Next(1, 4));
}