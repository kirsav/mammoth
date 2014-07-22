using UnityEngine;
using System.Collections;

/// <summary>
/// Наш игровой тайл - собственно то, что содержится в клетке
/// </summary>
public class Tile : MonoBehaviour
{
    /// <summary>
    /// Тип тайл. Конечно было бы правильнее использовать наследование для того чтобы создать разные типы, но мой опыт говорит, что мы в этом утонем.
    /// И поэтому у нас тут примитивный enum
    /// </summary>
    public TileType TileType;

}

public enum TileType
{
    Mammoth,
    Stone,
    BigStone
}
