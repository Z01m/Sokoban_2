namespace Sokoban_2;

public class bis
{
    public List<State> MovesWin { get; set; } = new List<State>();
    
    public Queue<State> BFSQueue { get; set; } = new Queue<State>();
    public List<State> BFSVisited { get; set; } = new List<State>();
    
    public Queue<State> BISQueue { get; set; } = new Queue<State>();
    public List<State> BISVisited { get; set; } = new List<State>();

    public List<State> MovesBFS { get; set; } = new List<State>();
    public List<State> MovesBIS { get; set; } = new List<State>();
    public class State
    {
        public State prevMove = null;
        public (int x, int y) PlayerPosition;
        public List<(int x, int y)> BoxPositions;
        public List<(int x, int y)> PointPosition;

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
            if (this.PlayerPosition != s.PlayerPosition) return false;
            foreach (var b in BoxPositions)
            {
                if (!s.BoxPositions.Contains(b)) return false;
            }
            return true;
        }
    }
    
    
    public bool IsGoalState(Queue<State>BFS,List<State> BFSVisited, Queue<State>BIS, List<State> BISVisited) //проверяет на победу
    {
        foreach (var state in BFS)
        {
            if (BIS.Contains(state) || BISVisited.Contains(state))
                return true;
        }
        foreach (var state in BIS)
        {
            if (BFSVisited.Contains(state) )
                return true;
        }

        return false;
    }

    public void  _BIS_()
    { 
        BFSQueue.Enqueue(new State(Map.Instance.GetPlayerPos(),Map.Instance.GetBoxPosition(),Map.Instance.GetPointPosition(),null));
        foreach (var var in GenerateWiningState(Map.Instance.GetPointPosition()))
        {
            //Console.Write(var.PlayerPosition);
            BISQueue.Enqueue(var);
        }
        
        while (BFSQueue.Count > 0 && BISQueue.Count > 0)
        {
            if (IsGoalState(BFSQueue,BFSVisited, BISQueue,BISVisited))
            {
                Console.WriteLine("win");
                setMovesBFS(BFSQueue.Dequeue());
                setMovesBIS(BISQueue.Dequeue());
                ReadAllMoves();
                return;
            }
            //bfs block
            var current = BFSQueue.Dequeue();
            BFSVisited.Add(current);
            foreach (var move in GetPossibleMoves(current))
            {
                if (!BFSVisited.Contains(move) && !BFSQueue.Contains(move))
                {
                    BFSQueue.Enqueue(move);
                }
            }
            //bi s block
            var cur = BISQueue.Dequeue();
            BISVisited.Add(cur);
            foreach (var move in GetPossibleRevMoves(cur))
            {
                if (!BISVisited.Contains(move) && !BISQueue.Contains(move))
                {
                    BISQueue.Enqueue(move);
                }
            }
        }
        
    }

    public List<State> GenerateWiningState(List<(int x, int y)> pointPos)
    {
        List<State> winningState = new List<State>();
        var moves = new List<(int dx, int dy)> //инвертирован 
        {
            (0, 1),  // Вверх
            (0, -1), // Вниз
            (1, 0),  // Вправо
            (-1, 0)  // Влево
        };
        foreach (var move in moves)
        {
            foreach (var point in pointPos)
            {
                (int x,int y) newPlayerPos = (point.x + move.dx, point.y + move.dy);
                if (Map.LevelMap[newPlayerPos.x][newPlayerPos.y] != '#' &&
                    !pointPos.Contains(newPlayerPos))
                {
                    winningState.Add(new State((newPlayerPos.y,newPlayerPos.x),pointPos,pointPos,null));
                }
            }
        }
        return winningState;
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

    public List<State> GetPossibleRevMoves(State current)
    {
        Player player = new Player();
        List<State> moves = new List<State>();
        var directions = new (int x, int y)[]
        {
            (0, 1),  //up
            (0, -1), //down
            (1, 0),  //left
            (-1, 0), //right    
        };
        foreach (var dir in directions)
        {
            (int x, int y) newPos = (current.PlayerPosition.x + dir.x, current.PlayerPosition.y + dir.y);
            if (Map.LevelMap[newPos.y][newPos.x]=='.')
            {
                State moveState = new State(newPos, current.BoxPositions, current.PointPosition, current);
                moves.Add(moveState); //убрать?
                var tmpBoxes = Map.Instance.MoveBoxRevers(current.PlayerPosition, dir, current.BoxPositions);

                State boxState = new State(newPos, tmpBoxes, current.PointPosition, current);
                    
                if (!moveState.Equals(boxState))
                    moves.Add(boxState);//если игрок  двигает коробку
            }
        }

        return moves;
    }
    
    public void ReadAllMoves()
    {
        Console.WriteLine("BFS:");
        for(int i=0;i<MovesBFS.Count;i++)
        {
            Console.WriteLine($"({i} x={MovesBFS[i].PlayerPosition.x} y={MovesBFS[i].PlayerPosition.y})");
        }
        Console.WriteLine("BIS:");
        for (int i = 0; i < MovesBIS.Count; i++)
        {
            Console.WriteLine($"({MovesBIS[i].PlayerPosition.x} {MovesBIS[i].PlayerPosition.y})");
        }
    }
    
    public void setMovesBFS(State bfs)//обязательно переименовать
    {
        MovesBFS.Add(bfs);
        if (bfs.prevMove != null)
            setMovesBFS(bfs.prevMove);
       
    }

    public void setMovesBIS(State bis)
    {
        MovesBIS.Add(bis);
        if (bis.prevMove != null)
            setMovesBFS(bis.prevMove);
    }
}