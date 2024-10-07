using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab1;

public class Map
{
    private static Map instance;

    // Приватный конструктор
    private Map()
    {
    }

    public static Map Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Map();
            }
            return instance;
        }
    }

    public static string[] LevelMap =  {
        //"########",
        //"#X.....#",
        //"#@.....#",
        //"#....@.#",
        //"#......#",
        //"#*...*.#",
        //"#......#",
        //"########"
    };

    public List<(int x, int y)> AllBox { get; set; }
    public List<(int x, int y)> AllPoint { get; set; }

    public void DrawMap(string[] map)
    {
        foreach (var str in map)
        {
            Console.WriteLine(str);
        }
    }

    //Чистая карта(только пустые клетки и стенки) ++
    public void DrawClearMap()
    {
        for (int y = 1; y < LevelMap.Length; y++)//y
        {
            for (int x = 1; x < LevelMap[y].Length; x++)//x
            {
                if (LevelMap[y][x] == 'X' || LevelMap[y][x] == '@' || LevelMap[y][x]== '*')//Инверсия коодинат
                { 
                    ChangeMap(x, y, '.');
                }
            }
        }
    }

    public void ChangeMap(int x, int y, char c) // функция для изменения карты
    {
        char[] row = LevelMap[y].ToCharArray();
        row[x] = c;
        LevelMap[y] = new string(row);
    }

    public (int x, int y) GetPlayerPos() //находит игрока на карте и его позицию игрока 
    {
            for (int i = 0; i < LevelMap.Length; i++)
            {
                for (int j = 0; j < LevelMap[i].Length; j++)
                {
                    if (LevelMap[i][j] == 'X')
                    {
                        return (j, i);
                    }
                }
            }
        return (-1, -1);
    }

    public List<(int x, int y)> GetBoxPosition() //находит все ящики на карте и возвращает лист с их координатами 
    {
        List<(int x, int y)> res = new List<(int x, int y)>();
        for (int i = 0; i < LevelMap.Length; i++)
        {
            for (int j = 0; j < LevelMap[i].Length; j++)
            {
                if (LevelMap[i][j] == '@')
                {
                    res.Add((i, j));
                }
            }
        }

        return res;
    }

    public List<(int x, int y)> GetPointPosition() //находит все точки на карте и возвращает лист с их координатами 
    {
        List<(int x, int y)> res = new List<(int x, int y)>();
        for (int i = 0; i < LevelMap.Length; i++)
        {
            for (int j = 0; j < LevelMap[i].Length; j++)
            {
                if (LevelMap[i][j] == '*')
                {
                    res.Add((i, j));
                }
            }
        }

        return res;
    }

    public bool BoxIsFind(int x, int y) //проверяет есть ли ящик по данным координатам
    {
        int index = AllBox.FindIndex(box => box.x == y && box.y == x);
        if (index != -1)
            return true;
        return false;
    }

    public bool BoxIsFind(int x, int y, List<(int x, int y)> boxes) //проверяет есть ли ящик по данным координатам
    {
        int index = boxes.FindIndex(box => box.x == y && box.y == x);
        if (index != -1)
            return true;
        return false;
    }

    public void ChangeBoxOnMap()
    {
        foreach (var vec in AllBox)
        {
            ChangeMap((int)vec.y, (int)vec.x, '@');
        }
    }
    //Отрисовка коробки Относительно State ++
    public void DrawBox((int x, int y) boxPos)
    {
        ChangeMap(boxPos.y, boxPos.x, '@');//инверсия координат
    }

    public void MoveBox((int x, int y) playerPos, (int x, int y) delta)
    {
        int index = AllBox.FindIndex(box =>
            box.x == playerPos.y + delta.y && box.y == playerPos.x + delta.x);
        if (index != -1)
        {
            AllBox[index] = (playerPos.y + 2 * delta.y, playerPos.x + 2 * delta.x);
        }
    }

    public List<(int x, int y)> MoveBox((int x, int y) playerPos, (int x, int y) delta, List<(int x, int y)> boxes)
    {
        List<(int x, int y)> tmpBoxes = new List<(int x, int y)> (boxes);
        int index = tmpBoxes.FindIndex(box =>
            box.x == playerPos.y + delta.y && box.y == playerPos.x + delta.x);
        if (index != -1)
        {
            tmpBoxes[index] = (playerPos.y + 2 * delta.y, playerPos.x + 2 * delta.x);
        }

        return tmpBoxes;
    }

    public void MoveBoxRevers((int x, int y) playerPos, (int x, int y) delta)
    {
        int index = AllBox.FindIndex(box =>
            box.x == playerPos.y - delta.y && box.y == playerPos.x - delta.x);
        if (index != -1)
        {
            ChangeMap(AllBox[index].y, AllBox[index].x, '.');
            AllBox[index] = (playerPos.y, playerPos.x);
        }
    }

    public List<(int x, int y)> MoveBoxRevers((int x, int y) playerPos, (int x, int y) delta,
        List<(int x, int y)> boxes)
    {
        List<(int x, int y)> tmpBoxes = new List<(int x,int y)>(boxes);
        int index = tmpBoxes.FindIndex(box =>
            box.x == playerPos.y - delta.y && box.y == playerPos.x - delta.x);
        if (index != -1)
        {
            tmpBoxes[index] = (playerPos.y, playerPos.x);
        }

        return tmpBoxes;
    }

    public bool IsWin()
    {
        int count = 0;
        foreach (var point in AllPoint)
        {
            if (BoxIsFind(point.y, point.x))
                count++;
        }
        return count == AllBox.Count;
    }

    //функция по отрисовке коробки на новой пустой позиции
    public void DrawBox((int x,int y) boxPosition,(int x,int y) boxPositionPrev)
    {
        ChangeMap(boxPositionPrev.y,boxPositionPrev.x,'.');//Удаление прошлого места коробки
        ChangeMap(boxPosition.y,boxPosition.x,'@');//инвертированны координаты
    }
    //функция по отрисовке point на пустой позиции
    public void DrawPoint((int x, int y) pointPosition)
    {
        ChangeMap(pointPosition.y, pointPosition.x, '*');
    }


}