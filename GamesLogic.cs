using System;
using CommonScripts;
using System.Security.Cryptography;

public class GeneralGameScripts
{
    public void DepositSelect(in PlayerInfo player, out int deposit)
    {
        Console.Clear();
        Console.CursorVisible = true;
        while (true)
        {
            CustomParsing.ParseString($"Insert how many point you want to deposit (no more than {player.balance}): ", out deposit);
            Console.Clear();
            if (!(deposit <= player.balance))
            {
                Console.WriteLine("Deposit cant exceed your balance or be smaller than 1.");
                continue;
            }
            return;
        }
    }

    public void ChangeBalance(ref PlayerInfo player, in int deposit, in bool isWinner)
    {
        if (isWinner)
        {
            player.balance = player.balance + deposit;
        }
        else
        {
            player.balance = player.balance - deposit;
        }
    }
}

public class IndividualGameMenus
{
    public void BlackjackMenu(ref PlayerInfo player)
    {
        Console.WriteLine("Blackjack isn't done yet. Sorry.");
        Console.ReadKey();
    }

    public void SlotsMenu(ref PlayerInfo player)
    {
        Console.WriteLine("Slots aren't done yet. Sorry.");
        Console.ReadKey();
    }

    public void CoinflipMenu(ref PlayerInfo player)
    {
        GeneralGameScripts generalScripts = new();
        IndividualGamesLogic gameLogic = new();

        Console.Clear();
        Console.Write($"Welcome to the coinflip game, {player.nickname}!\n" +
            $"Coinflip is a game where you and your opponent deposit " +
            $"the same amount of money, and " +
            $"the flipped coin decides who will get all the points (50/50).\n" +
            $"When you're done reading this, press any key...");
        Console.ReadKey();

        generalScripts.DepositSelect(player, out int deposit);
        gameLogic.CoinflipGame(ref player, deposit);
    }
}

public class IndividualGamesLogic
{
    public void CoinflipGame(ref PlayerInfo player, in int deposit)
    {
        Console.Clear();
        Random random = new();
        CasinoInfo info = new();
        GeneralGameScripts generalScripts = new();

        string opponentName = info.NPCNames[random.Next(info.NPCNames.Length)];

        Console.Write($"Coinflip\n" +
            $"\tYour deposit: {deposit}\n" +
            $"\tYour coin side: heads\n\n");
        Thread.Sleep(2000);

        Console.Write($"Your opponent's name: {opponentName}\n" +
            $"\tOpponent's deposit: {deposit}\n" +
            $"\tOpponent's coin side: tails\n\n");
        Thread.Sleep(2000);
        Console.Clear();

        Console.WriteLine("Your side: heads\n\nThe coin is flipped...");
        Thread.Sleep(1000);
        Console.Write("And it lands on... ");

        int coinSide = RandomNumberGenerator.GetInt32(2);
        if (coinSide == 0)
        {
            generalScripts.ChangeBalance(ref player, deposit, true);
            Console.Write($"Heads!\n\n" +
                $"{player.nickname} won the game!\n" +
                $"Their deposit was {deposit}\n" +
                $"And now their balance is {player.balance}");
        }
        else
        {
            generalScripts.ChangeBalance(ref player, deposit, false);
            Console.Write($"Tails!\n\n" +
                $"{player.nickname} lost the game!\n" +
                $"Their deposit was {deposit}\n" +
                $"And now their balance is {player.balance}");
        }
        Console.WriteLine("\nPress any key to go back to menu... ");
        Console.ReadKey(intercept: true);
    }
}