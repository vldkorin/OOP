namespace Lab1
{
    class Program
    {
        static void Main()
        {
            GameAccount player1 = new GameAccount("Player1", 1000);
            GameAccount player2 = new GameAccount("Player2", 900);

            player1.WinGame("Maksym", 50);
            player1.LoseGame("Yarylo", 30);
            player2.WinGame("Artem", 20);
            player2.WinGame("Anna", 80);
            player2.WinGame("Yelyzaveta", 35);

            player1.GetStats();
            Console.WriteLine();
            player2.GetStats();
        }
    }
}