using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

/// <summary>
/// Коллекция клеток
/// Так же создает клетки (можно потом будет вынести в отдельный класс - но пока для простоты оставим здесь
/// </summary>
[Serializable]
public class CellCollection : IEnumerable
{
    [SerializeField]
    private GameObject _cellPrefab;

    [SerializeField]
    private List<Cell> cells = new List<Cell>();

    public IEnumerator GetEnumerator()
    {
        return cells.GetEnumerator();
    }

    public void Init(int width, int height, Transform parent = null)
    {
        //kill all tiles
        foreach (var cell in cells)
        {
            Object.Destroy(cell.gameObject);
        }

        //create new ones
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                var newCell = ((GameObject)Object.Instantiate(_cellPrefab)).GetComponent<Cell>();
                newCell.Init(i,j);
                newCell.transform.parent = parent;
            }
        }
    }
}