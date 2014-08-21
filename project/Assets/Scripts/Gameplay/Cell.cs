using UnityEngine;
/// <summary>
/// Наша клетка. Может содержать, а может не содержать тайл.
/// Это одновременно как и игровая логика, так и спрайт (обычно так все в юнити и делают)
/// </summary>
public class Cell : MonoBehaviour
{
    public int X;
    public int Y;
    public Tile Tile;

    public void Init(int x, int y)
    {
        X = x;
        Y = y;
        transform.position = new Vector3(x*transform.localScale.x, 0, y*transform.localScale.z);
    }
}
