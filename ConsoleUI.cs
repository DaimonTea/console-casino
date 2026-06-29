using System;

public class CasinoUI
{
    private void EnterGeneralMenu(ref PlayerInfo player)
    {
        Console.CursorVisible = false;
        while (true)
        {
            Console.Clear();
            Console.Write($"{player.nickname} is in the casino menu.\n" +
                $"Your balance: {player.balance}\n\n" +
                $"1. Play a game\n" +
                $"2. Show statistics\n" +
                $"3. End the game");
            var key = Console.ReadKey(intercept: true);
            switch (key.Key)
            {
                case ConsoleKey.D1: EnterGameMenu(ref player); continue;
                case ConsoleKey.D2: ShowStatistics(ref player); continue;
                case ConsoleKey.D3: EndGame(); return;
                default: continue;
            }
        }
    }

    private void EnterGameMenu(ref PlayerInfo player)
    {
        IndividualGameMenus gameMenus = new();
        Console.Clear();
        while (true)
        {
            Console.Write($"{player.nickname}, select a game to play:\n\n" +
                $"1. Blackjack\n" +
                $"2. Slots\n" +
                $"3. Coinflip");
            var key = Console.ReadKey(intercept: true);
            switch (key.Key)
            {
                case ConsoleKey.D1: gameMenus.BlackjackMenu(ref player); return;
                case ConsoleKey.D2: gameMenus.SlotsMenu(ref player); return;
                case ConsoleKey.D3: gameMenus.CoinflipMenu(ref player); return;
                default: continue;
            }
        }
    }

    private void ShowStatistics(ref PlayerInfo player)
    {

    }

    private void EndGame()
    {

    }

    public void MainCycle()
    {
        FirstTime first = new();
        PlayerInfo player = new();
        CasinoUI UI = new();

        first.StartNewGame(ref player);
        while (true)
        {
            UI.EnterGeneralMenu(ref player);
        }
    }
}