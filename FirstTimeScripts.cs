using System;

public class FirstTime
{
    private void FillNickname(ref PlayerInfo player)
    {
        while (true)
        {
            Console.Write("Enter your nickname: ");
            string inputName = Console.ReadLine() ?? string.Empty;
            Console.Clear();
            if (inputName == "")
            {
                Console.WriteLine("Wrong input.");
                continue;
            }
            player.nickname = inputName;
            return;
        }
    }

    private void Tutorial(in PlayerInfo player)
    {
        CasinoInfo info = new();
        Console.Write($"Welcome to the casino, {player.nickname}.\n" +
            $"Here, you can experience 3 different games which are\n" +
            $"Blackjack, slots and coinflip.\n" +
            $"Feel free to play any game at any time but remember that\n" +
            $"Once you lost all money, the game is over.\n" +
            $"At the start you'll be given {info.startingBalance} points.\n" +
            $"When you're done reading this, press any key...");
        Console.ReadKey();
        Console.Clear();
    }

    private void ChangeStartBalance(ref PlayerInfo player)
    {
        CasinoInfo info = new();
        player.balance = info.startingBalance;
    }

    public void StartNewGame(ref PlayerInfo player)
    {
        FillNickname(ref player);
        Tutorial(player);
        ChangeStartBalance(ref player);
    }
}
