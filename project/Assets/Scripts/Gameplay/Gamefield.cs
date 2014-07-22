using UnityEngine;

/// <summary>
///     Основной класс с игровым полям - в нем будет вся игровая логика (точнее он будет отвечать за основную игровую
///     логика - некоторые части вполне могут быть в других классах)
/// </summary>
public class Gamefield : MonoBehaviour
{
    public CellCollection CellCollection = new CellCollection();
    public int Height = 2;
    public int Width = 2;

    private void Awake()
    {
        CellCollection.Init(Width, Height, transform);
    }
}