// See https://aka.ms/new-console-template for more information



namespace Sokoban_2
{

    class Game
    {
        static void Main(string[] args)
        {
            Map.Instance.AllBox = Map.Instance.GetBoxPosition();
            Map.Instance.AllPoint = Map.Instance.GetPointPosition();
            bfs bfs = new bfs();
            bfs._BFS_();
            /*Player player = new Player();
           player.PlayerPos = Map.Instance.GetPlayerPos();
           Map.Instance.AllBox = Map.Instance.GetBoxPosition();
           Map.Instance.AllPoint = Map.Instance.GetPointPosition();
           Console.CursorVisible = false;
           while (true)
           {
               if (Map.Instance.IsWin())
               {
                   Console.WriteLine("WIn!");
                   return;
               }

               Console.Clear();
               Map.Instance.DrawMap(Map.LevelMap);
               ConsoleKeyInfo key = Console.ReadKey(true);
               player.HireHero();
               if (key.Key == ConsoleKey.W || key.Key == ConsoleKey.UpArrow)
               {
                   player.MovePlayer(player.PlayerPos,(0,-1));

               }
               if (key.Key == ConsoleKey.S || key.Key == ConsoleKey.DownArrow)
               {
                   player.MovePlayer(player.PlayerPos,(0,1));

               }
               if (key.Key == ConsoleKey.A || key.Key == ConsoleKey.LeftArrow)
               {
                   player.MovePlayer(player.PlayerPos,(-1,0));
               }
               if (key.Key == ConsoleKey.D || key.Key == ConsoleKey.RightArrow)
               {
                   player.MovePlayer(player.PlayerPos,(1,0));
               }
               player.DrawPlayer();
           }*/
        }
        
    }
}