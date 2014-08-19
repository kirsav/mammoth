using UnityEngine;
using System.Collections;

/// <summary>
/// Наш игровой тайл - собственно то, что содержится в клетке
/// </summary>
public abstract class Tile : MonoBehaviour
{
    /// <summary>
    /// Тип тайла. С помощью наследования мы создадим разное поведение тайлов, но мой опыт говорит, что для игровой логике удобнее использовать enum
    /// </summary>
    public abstract TileType TileType { get; }

    /// <summary>
    /// Пейзаж это или нет - для более быстрого поиска
    /// </summary>
    public abstract bool IsLandscape { get; }

    public abstract bool IsMovable { get; }

    public Cell Cell;

    void OnDestroy()
    {
        if (Cell != null)
        {
            Cell.Tile = null;
        }
    }
}