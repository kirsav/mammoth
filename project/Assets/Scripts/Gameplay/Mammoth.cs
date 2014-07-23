public class Mammoth : Tile
{
    public override TileType TileType { get { return TileType.Mammoth; } }

    public override bool IsLandscape
    {
        get { return true; }
    }

    public override bool IsMovable
    {
        get { return false; }
    }
}