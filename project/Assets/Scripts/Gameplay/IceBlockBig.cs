using UnityEngine;

public class IceBlockBig: Tile
{
    [SerializeField]
    private TileType tileType;

    [SerializeField] private ColorType colorType;

    [SerializeField]
    private bool isMovable;

    public IceBlockBig(bool isMovable)
    {
        this.isMovable = isMovable;
    }

    public override TileType TileType
    {
        get { return TileType.IceBlockBig; }
    }

    public override bool IsLandscape
    {
        get { return false; }
    }

    public override bool IsMovable
    {
        get { return isMovable; }
    }

    public void SetMovable(bool newState)
    {
        isMovable = newState;
        //DO ANIMATION OR EFFECTS
    }
}