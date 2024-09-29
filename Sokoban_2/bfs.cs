using Sokoban_2;


public class bfs
{
    public List<State> MovesWin { get; set; } = new List<State>();
    public Queue<State> Queue { get; set; } = new Queue<State>();
    public List<State> Visited { get; set; } = new List<State>();
    
    public class State
    {
        public State prevMove = null;
        public (int x,int y) PlayerPosition;
        public List<(int x,int y)> BoxPositions;
        public List<(int x,int y)> PointPosition;

        public State((int x, int y) playerPos, List<(int x, int y)> boxPos, List<(int x, int y)> pointPos, State state)
        {
            this.PlayerPosition = (playerPos.x, playerPos.y);
            this.BoxPositions = new List<(int x, int y)>(boxPos);
            this.PointPosition = new List<(int x, int y)>(pointPos);
            this.prevMove = state;
        }

        public override bool Equals(object? obj)
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
        return count==state.BoxPositions.Count;
    }
    public void _BFS_()
    {
        Queue.Enqueue(new State(Map.Instance.GetPlayerPos(),Map.Instance.GetBoxPosition(),Map.Instance.GetPointPosition(),null));
        int count = 0;
        while (Queue.Count > 0)
        {
            var current = Queue.Dequeue();
            if (IsGoalState(current))
            {
                Console.WriteLine("Win!");
                Console.WriteLine($"count:{count}");
                fillMovesWin(current);
                WritePath();
                return;
            }
            Visited.Add(current);
            foreach (var move in GetPossibleMoves(current))
            {
                if (!Visited.Contains(move) && !Queue.Contains(move))
                {
                    count++;
                    Queue.Enqueue(move);
                }
            }
        }
    }
    
    public void fillMovesWin(State current)
    {
        MovesWin.Add(current);
        if (current.prevMove != null)
            fillMovesWin(current.prevMove);
    }

    public void WritePath()
    {
        MovesWin.Reverse();
        foreach (var moves in MovesWin)
            Console.Write($"({moves.PlayerPosition.x},{moves.PlayerPosition.y})");
    }
    
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
            if (player.CanMove(current.PlayerPosition, dir,current.BoxPositions))
            {
                var tmpBoxes = Map.Instance.MoveBox(current.PlayerPosition, dir, current.BoxPositions);
                
                moves.Add(new State(newPos, tmpBoxes , current.PointPosition,current));
            }
        }
        return moves;
    }
}