using CSharpFunctionalExtensions;
using TicTacToe.Boards;
using TicTacToe.Players;

namespace TicTacToe;

public class RandomPlayer : Player
{
    public override char Icon { get; }

    public RandomPlayer(char icon)
    {
        this.Icon = icon;
    }

    public override async Task<Result<PlayerMove>> GetNextMove()
    {
        var loaderTask = ShowLoader(1000); // Afficher le loader pendant 1 seconde
        await Task.Delay(1000); // Ajouter un délai de 1 seconde
        await loaderTask; // Attendre que le loader se termine

        var random = new Random();
        int row = random.Next(1, 4);
        int column = random.Next(1, 4);

        return Result.Success(new PlayerMove(row, column));
    }

    private async Task ShowLoader(int delay)
    {
        var loaderChars = new[] { '|', '/', '-', '\\' };
        int loaderIndex = 0;

        for (int i = 0; i < delay / 100; i++)
        {
            Console.Write($"\rThinking... {loaderChars[loaderIndex]}");
            loaderIndex = (loaderIndex + 1) % loaderChars.Length;
            await Task.Delay(100);
        }

        Console.Write("\rThinking... Done!   \n");
    }

}