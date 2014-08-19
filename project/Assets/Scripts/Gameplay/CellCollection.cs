using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

/// <summary>
/// Коллекция клеток
/// Так же создает клетки (можно потом будет вынести в отдельный класс - но пока для простоты оставим здесь
/// </summary>
[Serializable]
public class CellCollection : IEnumerable
{
    #region Prefabs

    [SerializeField]
    private GameObject _cellPrefab;

    [SerializeField] private GameObject _landscapePrefab;

    [SerializeField]
    private GameObject _iceBlockBigPrefab;

    [SerializeField]
    private GameObject _mammothPrefab;

    [SerializeField]
    private GameObject _iceBlockSmallPrefab;

    #endregion

    [SerializeField]
    private List<Cell> cells = new List<Cell>();

    [SerializeField]
    private float _landscapeProbability = 0.05f;

    private bool error = false;
    


    void Check()
    {
        if (_landscapePrefab == null || _landscapePrefab.GetComponent<Landscape>() == null)
        {
            Debug.LogError("Incorrect prefab Landscape: "+_landscapePrefab);
            error = true;
            return;
        }

        if (_iceBlockBigPrefab == null || _iceBlockBigPrefab.GetComponent<IceBlockBig>() == null)
        {
            Debug.LogError("Incorrect prefab IceBlockBig: " + _iceBlockBigPrefab);
            error = true;
            return;
        }

        if (_mammothPrefab == null || _mammothPrefab.GetComponent<Mammoth>() == null)
        {
            Debug.LogError("Incorrect prefab mammoth: " + _mammothPrefab);
            error = true;
            return;
        }

        if (_iceBlockSmallPrefab == null || _iceBlockSmallPrefab.GetComponent<IceBlockSmall>() == null)
        {
            Debug.LogError("Incorrect prefab iceblock small: " + _iceBlockSmallPrefab);
            error = true;
            return;
        }
    }


    public IEnumerator GetEnumerator()
    {
        return cells.GetEnumerator();
    }

    public void Init(int width, int height, Transform parent = null)
    {
        Check();
        if (error)
        {
            return;
        }

        //kill all tiles
        foreach (var cell in cells)
        {
            Object.Destroy(cell.gameObject);
            cells.Clear();
        }


        var mammothPos = Random.Range(0, height - 1);
       

        //create new ones
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                var newCell = ((GameObject)Object.Instantiate(_cellPrefab)).GetComponent<Cell>();
                newCell.Init(i,j);
                newCell.transform.parent = parent;
                cells.Add(newCell);
                //landscape
                var landscape = CreateLandscape(newCell);

                if (j == mammothPos && landscape)
                {
                    Object.Destroy(landscape.gameObject);
                }

                if ((i == width/2 || i == width/2+1))
                {
                    if (landscape)
                    {
                        Object.Destroy(landscape.gameObject);
                    }
                    CreateBigIceBlock(newCell);
                }
            }
        }

        CreateMammoth(cells.First(x => x.X == 0 && x.Y == mammothPos));

        var freeCells = cells.Where(x => x.Tile == null).ToList();
        //Debug.Log("Free cell size: "+freeCells.Count);
        GenerateIceBlocks(freeCells, 10);

    }

    private void GenerateIceBlocks(List<Cell> freeCells, int amount)
    {
        var clampedAmount = Mathf.Min(amount, freeCells.Count);
        for (int i = 0; i < clampedAmount; i++)
        {
            var randomCell = freeCells[Random.Range(0, freeCells.Count)];
            freeCells.Remove(randomCell);
            CreateIceBlock(randomCell);
        }
    }

    private void CreateIceBlock(Cell randomCell)
    {
        var iceBlockSmall = ((GameObject)Object.Instantiate(_iceBlockSmallPrefab)).GetComponent<IceBlockSmall>();
        var colors = Enum.GetNames(typeof(ColorType));
        var randomColor = (ColorType)Enum.Parse(typeof(ColorType), colors[Random.Range(0, colors.Length)]);
        iceBlockSmall.Init(randomColor);
        SetTile(randomCell, iceBlockSmall);
    }

    private void CreateMammoth(Cell newCell)
    {
        var mammoth = ((GameObject)Object.Instantiate(_mammothPrefab)).GetComponent<Mammoth>();
        SetTile(newCell, mammoth);
    }

    private void CreateBigIceBlock(Cell newCell)
    {
        var bigIceBlock = ((GameObject) Object.Instantiate(_iceBlockBigPrefab)).GetComponent<IceBlockBig>();
        var colors = Enum.GetNames(typeof(ColorType));
        var randomColor = (ColorType)Enum.Parse(typeof(ColorType), colors[Random.Range(0, colors.Length)]);

        bigIceBlock.Init(randomColor);
        SetTile(newCell, bigIceBlock);
    }

    private Tile CreateLandscape(Cell newCell)
    {
        var random = Random.Range(0f, 1f);
        if (random < _landscapeProbability)
        {
            var landscape = ((GameObject) Object.Instantiate(_landscapePrefab)).GetComponent<Landscape>();
            SetTile(newCell, landscape);
            return landscape;
        }
        return null;
    }

    public static void SetTile(Cell cell, Tile tile)
    {
        tile.ClearCell();

        var position = tile.transform.localPosition;
        var scale = tile.transform.localScale;
        var rotation = tile.transform.localRotation;
        tile.transform.parent = cell.transform;
        tile.transform.localRotation = rotation;
        tile.transform.localPosition = position;
        tile.transform.localScale = scale;
        tile.Cell = cell;
        cell.Tile = tile;
    }


}