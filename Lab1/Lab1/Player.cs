using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Player
{
    public (int x, int y) PlayerPos { get; set; }

    public void DrawPlayer()
    {
        Map.Instance.ChangeMap(PlayerPos.x, PlayerPos.y, 'X');
    }
    
    public void DrawPlayer((int x,int y) playerPos)//new рисует игрока в другой точке
    {
        Map.Instance.ChangeMap(playerPos.x, playerPos.y, 'X');
    }

    public void HideHero()
    {
        Map.Instance.ChangeMap(PlayerPos.x, PlayerPos.y, '.');
    }

    public void HideHero((int x, int y) playerPos)//new ставить пустую клетку на позиции игрока
    {
        Map.Instance.ChangeMap(playerPos.x, playerPos.y, '.');
    }

    public void MovePlayer((int x, int y) playerPos, (int x, int y) delta)
    {
        if (CanMove(playerPos, delta))
        {
            PlayerPos = (playerPos.x + delta.x, playerPos.y + delta.y);
            Map.Instance.MoveBox(playerPos, delta);
            Map.Instance.ChangeBoxOnMap();
        }
    }

    public bool CanMove((int x, int y) playerPos, (int x, int y) delta)
    {
        if (Map.Instance.BoxIsFind(playerPos.x + delta.x, playerPos.y + delta.y) &&
            (Map.Instance.BoxIsFind(playerPos.x + 2 * delta.x, playerPos.y + 2 * delta.y) ||
             Map.LevelMap[playerPos.y + 2 * delta.y][playerPos.x + 2 * delta.x] == '#'))
            return false;
        return Map.LevelMap[playerPos.y + delta.y][playerPos.x + delta.x] != '#';
    }

    public bool CanMove((int x, int y) playerPos, (int x, int y) delta, List<(int x, int y)> boxes)
    {
        if (Map.Instance.BoxIsFind(playerPos.x + delta.x, playerPos.y + delta.y, boxes) &&
            (Map.Instance.BoxIsFind(playerPos.x + 2 * delta.x, playerPos.y + 2 * delta.y, boxes) ||
             Map.LevelMap[playerPos.y + 2 * delta.y][playerPos.x + 2 * delta.x] == '#'))
            return false;
        return Map.LevelMap[playerPos.y + delta.y][playerPos.x + delta.x] != '#';
    }

}

