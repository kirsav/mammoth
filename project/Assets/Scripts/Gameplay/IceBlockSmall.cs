using System;
using UnityEngine;

public class IceBlockSmall : Tile
{
    [SerializeField]
    private ColorType colorType;
 
    [SerializeField]
    private GameObject RedPrefab;

    [SerializeField]
    private GameObject OrangePrefab;

     [SerializeField]
    private GameObject YellowPrefab;

      [SerializeField]
    private GameObject GreenPrefab;    
    
    [SerializeField]
    private GameObject LightBluePrefab;

      [SerializeField]
    private GameObject BluePrefab;

     [SerializeField]
    private GameObject VioletPrefab;

    public override TileType TileType
    {
        get { return TileType.IceBlockSmall; }
    }

    public ColorType ColorType
    {
        get { return colorType; }
    }

    public override bool IsLandscape
    {
        get { return false; }
    }

    public override bool IsMovable
    {
        get { return true; }
    }

    public virtual void Init(ColorType color)
    {
        colorType = color;
        GameObject colorPrefab;
        switch (ColorType)
        {
            case ColorType.Red:
                colorPrefab = RedPrefab;
                break;
            case ColorType.Orange:
                colorPrefab = OrangePrefab;
                break;
            case ColorType.Yellow:
                colorPrefab = YellowPrefab;
                break;
            case ColorType.Green:
                colorPrefab = GreenPrefab;
                break;
            case ColorType.LightBlue:
                colorPrefab = LightBluePrefab;
                break;
            case ColorType.Blue:
                colorPrefab = BluePrefab;
                break;
            case ColorType.Violet:
                colorPrefab = VioletPrefab;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        var colorInstance = Instantiate(colorPrefab) as GameObject;
        colorInstance.transform.parent = this.transform;
        colorInstance.transform.localPosition = Vector3.zero;
        colorInstance.transform.localScale = Vector3.one;
        colorInstance.transform.localRotation = Quaternion.identity;

    }
}