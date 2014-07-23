using UnityEngine;

public class IceBlockSmall : Tile
{
    [SerializeField]
    private TileType tileType;

    [SerializeField]
    private ColorType colorType;

    public override TileType TileType
    {
        get { return TileType.IceBlockSmall; }
    }

    public override bool IsLandscape
    {
        get { return false; }
    }

    public override bool IsMovable
    {
        get { return true; }
    }
}