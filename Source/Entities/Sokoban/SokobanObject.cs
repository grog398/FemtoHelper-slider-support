using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Celeste.Mod.FemtoHelper.Entities.Sokoban;

public struct SokobanObjectType
{
    public string SourcePath;
    public Rectangle SourceRect;
    public bool IsSolid;
    public bool IsPushable;
    public bool IsPullable;
    public int Depth;
}

public class SokobanObject
{
    static SokobanObject()
    {
        types.Add("Player", new SokobanObjectType
        {
            SourcePath = "objects/FemtoHelper/sokoban/atlas",
            SourceRect = new Rectangle(0, 0, 8, 8),
            IsSolid = false,
            IsPushable = false,
            IsPullable = false,
            Depth = 0,
        });
        types.Add("Rock", new SokobanObjectType
        {
            SourcePath = "objects/FemtoHelper/sokoban/atlas",
            SourceRect = new Rectangle(8, 0, 8, 8),
            IsSolid = true,
            IsPushable = true,
            IsPullable = false,
            Depth = 100,
        });
        types.Add("Gem", new SokobanObjectType
        {
            SourcePath = "objects/FemtoHelper/sokoban/atlas",
            SourceRect = new Rectangle(16, 0, 8, 8),
            IsSolid = true,
            IsPushable = false,
            IsPullable = true,
            Depth = 150,
        });
        types.Add("Slot", new SokobanObjectType
        {
            SourcePath = "objects/FemtoHelper/sokoban/atlas",
            SourceRect = new Rectangle(24, 0, 8, 8),
            IsSolid = false,
            IsPushable = false,
            IsPullable = false,
            Depth = 600,
        });
        types.Add("Swap", new SokobanObjectType
        {
            SourcePath = "objects/FemtoHelper/sokoban/atlas",
            SourceRect = new Rectangle(32, 0, 8, 8),
            IsSolid = false,
            IsPushable = false,
            IsPullable = false,
            Depth = 400,
        });
        types.Add("Wall", new SokobanObjectType
        {
            SourcePath = "objects/FemtoHelper/sokoban/atlas",
            SourceRect = new Rectangle(48, 0, 8, 8),
            IsSolid = true,
            IsPushable = false,
            IsPullable = false,
            Depth = 200,
        });
        types.Add("Tile", new SokobanObjectType
        {
            SourcePath = "objects/FemtoHelper/sokoban/atlas",
            SourceRect = new Rectangle(40, 0, 8, 8),
            IsSolid = false,
            IsPushable = false,
            IsPullable = false,
            Depth = 300,
        });
        types.Add("Bomb", new SokobanObjectType
        {
            SourcePath = "objects/FemtoHelper/sokoban/atlas",
            SourceRect = new Rectangle(0, 8, 8, 14),
            IsSolid = true,
            IsPushable = true,
            IsPullable = false,
            Depth = 50,
        });
    }
    private static List<string> registeredTypes =
    [
        "Player",
        "Rock",
        "Gem",
        "Slot",
        "Swap",
        "Wall",
        "Tile",
        "Bomb",
    ];
    private static Dictionary<string, SokobanObjectType> types = [];
    public float stepPercent;
    public Vector2 pos;
    public Vector2 visualPos;
    public string type;
    public string prevType;

    public void Render()
    {
        SokobanObjectType type = types[this.type];
        GFX.Game[type.SourcePath].GetSubtexture(type.SourceRect).DrawCentered(visualPos);
    }
}
