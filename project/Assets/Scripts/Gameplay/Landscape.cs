public class Landscape : Tile
{
    public override TileType TileType { get {return TileType.Landscape;} }

    public override bool IsLandscape
    {
        get { return true; }
    }

    public override bool IsMovable
    {
        get { return false; }
    }
}