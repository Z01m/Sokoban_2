using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1;
public class iddfs
{
    public Queue<State> Queue { get; set; } = new Queue<State>();
    public List<State> Visited { get; set; } = new List<State>();
    public List<State> MovesWin { get; set; } = new List<State>();//массив шагов для победы для шага вперёд
    public List<State> MovesWinReverse { get; set; } = new List<State>();//массив шагов для победы для шага назад

    Stack<State> stack = new Stack<State>();

    Player player = new Player();

    int countNode = 0;
    int countIteration = 0;

    public class State
    {
        public (int x, int y) PlayerPosition;
        public List<(int x, int y)> BoxPositions;
        public List<(int x, int y)> PointPosition;
        public State prevMove = null;
        public int depthNode = 0;
        public State((int x, int y) playerPos, List<(int x, int y)> boxPos, List<(int x, int y)> pointPos, State state /*int depthNode*/)
        {
            this.PlayerPosition = (playerPos.x, playerPos.y);
            this.BoxPositions = new List<(int x, int y)>(boxPos);
            this.PointPosition = new List<(int x, int y)>(pointPos);
            this.prevMove = state;//предыдущий шаг
            //this.depthNode = depthNode;//глубина узла
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            State s = (State)obj;
            if (PlayerPosition != s.PlayerPosition) return false;
            foreach (var b in BoxPositions)
            {
                if (!s.BoxPositions.Contains(b)) return false;
            }
            return true;
        }
    }
    public bool IsGoalState(State state) //проверяет на победу
    {
        int count = 0;
        foreach (var box in state.BoxPositions)
        {
            foreach (var point in state.PointPosition)
            {
                if (box.x == point.x && box.y == point.y)
                {
                    count++;
                    break;
                }
            }
        }
        return count == state.BoxPositions.Count;
    }

    public void fillMovesWin(State current)
    {
        MovesWin.Add(current);//добавление позиции
        if (current.prevMove != null)//если существует ссылка на предыдущий шаг
            fillMovesWin(current.prevMove);//вызываем рекурсию с ссылкой на пред.шаг
        else
        {
            MovesWinReverse = MovesWin;
            MovesWin.Reverse();//если пред.шага нет, тогда разворачиваем массив шагов, тем самым на первой позиции будет стартовая точка
        }
    }

    public void WriteMovesWin()
    {
        for (int i = 0; i < MovesWin.Count; i++)
        {
            Console.WriteLine($"({MovesWin[i].PlayerPosition.x} {MovesWin[i].PlayerPosition.y})");
        }
    }

    public int GetCountNode()
    {
        return countNode;
    }

    public int GetCountIteration()
    {
        return countIteration;
    }

    //Сохраняет ближайшие шаги
    public IEnumerable<State> GetPossibleMoves(State current)
    {
        Player player = new Player();
        List<State> moves = new List<State>();
        var directions = new (int x, int y)[]
        {
            (0, 1),  //down
            (0, -1), //up
            (1, 0),  //right
            (-1, 0), //left    
        };
        foreach (var dir in directions)
        {
            var newPos = (current.PlayerPosition.x + dir.x, current.PlayerPosition.y + dir.y);
            if (player.CanMove(current.PlayerPosition, dir, current.BoxPositions))
            {
                var tmpBoxes = Map.Instance.MoveBox(current.PlayerPosition, dir, current.BoxPositions);
                moves.Add(new State(newPos, tmpBoxes, current.PointPosition, current/*,current.depthNode*/));//в конце current -> это предыдущий шаг, глубина текущего нода

            }
        }
        return moves;
    }

    public void DrawNextStep(int indexMovesWin)
    {
        if (indexMovesWin < MovesWin.Count)
        {
            Map.Instance.DrawClearMap();//функция по очистке карты -> всё что не точка и не стена делать точкой
            player.DrawPlayer(MovesWin[indexMovesWin].PlayerPosition);//отрисовка игрока
            for (int i = 0; i < MovesWin[indexMovesWin].PointPosition.Count; i++)
                Map.Instance.DrawPoint(MovesWin[indexMovesWin].PointPosition[i]);//отрисовка точек
            for (int i = 0; i < MovesWin[indexMovesWin].BoxPositions.Count; i++)
                Map.Instance.DrawBox(MovesWin[indexMovesWin].BoxPositions[i]);//отрисовка коробок
        }
        else Console.WriteLine("Следующего шага нет!");
    }

    public void DrawPrevStep(int indexMovesWin)
    {
        Map.Instance.DrawClearMap();//функция по очистке карты -> всё что не точка и не стена делать точкой
        player.DrawPlayer(MovesWinReverse[indexMovesWin].PlayerPosition);//отрисовка игрока
        for (int i = 0; i < MovesWinReverse[indexMovesWin].PointPosition.Count; i++)
            Map.Instance.DrawPoint(MovesWinReverse[indexMovesWin].PointPosition[i]);//отрисовка точек
        for (int i = 0; i < MovesWinReverse[indexMovesWin].BoxPositions.Count; i++)
            Map.Instance.DrawBox(MovesWinReverse[indexMovesWin].BoxPositions[i]);//отрисовка коробок

        if (indexMovesWin == 0) Console.WriteLine("Стартовая позциия");
    }

    public bool NumberNextStep(int indexMovesWin)
    {
        if (indexMovesWin == MovesWin.Count - 1)
            return false;
        else return true;
    }

    public int GetCountSteps()
    {
        return MovesWin.Count;
    }

    public void _IDDFS_()
    {
        Player player = new Player();
        int depthLimit = 0; // Начальный предел глубины

        while (true)
        {
            countIteration++;
            Visited.Clear();
            var result = DLS(new State(Map.Instance.GetPlayerPos(), Map.Instance.GetBoxPosition(), Map.Instance.GetPointPosition(), null),0, depthLimit);
            if (result != null)
            {
                fillMovesWin(result);
                WriteMovesWin();
                Console.WriteLine("Win!");
                return;
            }
            depthLimit++;
        }
    }

    private State DLS(State current, int depth, int limit)
    {
        if (depth < limit)
        {
            if (IsGoalState(current))
            {
                return current;
            }

            Visited.Add(current); // Помечаем состояние как посещённое
            foreach (var move in GetPossibleMoves(current))
            {
                countNode++;
                if (!Visited.Contains(move)) // Проверяем на посещённость
                {
                    var result = DLS(move,depth+1,limit); // Рекурсивный вызов DLS на следующем уровне
                    if (result != null)
                    {
                        return result; // Если решение найдено, возвращаем его
                    }
                }
            }
        }
        Visited.Remove(current); // Убираем состояние из посещённых, чтобы позволить исследовать другие пути на уровнях выше
        return null; // Если решение не найдено на данном уровне, возвращаем null
    }

}

