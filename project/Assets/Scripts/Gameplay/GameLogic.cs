using System.Net;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    private Tile chosen;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var pos = Input.mousePosition;
            var ray = Camera.main.ScreenPointToRay(pos);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var cell = hit.collider.GetComponent<Cell>();
                var tile = hit.collider.GetComponent<Tile>();
                if (chosen)
                {
                    if (cell && !cell.Tile)
                    {
                        CellCollection.SetTile(cell, chosen);
                        Chose(null);
                    }
                    else
                    {
                        if (tile && tile.IsMovable)
                        {
                            Chose(null);
                            Chose(tile);
                        }
                    }
                }
                else
                {
                    if (tile && tile.IsMovable)
                    {
                        Chose(tile);
                    }
                }
            }
        }
    }

    private void Chose(Tile tile)
    {
        if (tile)
        {
            chosen = tile;
            chosen.Highlight = true;
        }
        else
        {
            if (chosen)
            {
                chosen.Highlight = false;
            }
            chosen = null;
        }
    }
}
