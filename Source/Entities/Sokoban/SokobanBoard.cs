using Celeste.Mod.Roslyn.ModLifecycleAttributes;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Celeste.Mod.FemtoHelper.Entities.Sokoban;

[CustomEntity("FemtoHelper/SokobanBoard")]
public class SokobanBoard : Entity
{
    internal static VirtualRenderTarget buffer;
    public List<SokobanObject> Objects = [];
    private Coroutine sequence;
    public readonly string Room;
    public int boardWidth, boardHeight;
    public SokobanBoard(EntityData data, Vector2 offset) : base(data.Position + offset)
    {
        Add(sequence = new(Sequence()));
        Add(new BeforeRenderHook(BeforeRender));
        Room = data.String("room");
    }

    public override void Awake(Scene scene)
    {
        base.Awake(scene);
        Init(Room);
    }

    public void Init(string room)
    {
        LevelData data = (Scene as Level).Session.MapData.Get(room);
        if(data == null)
        {
            Warn($"SokobanBoard: Could not find room '{Room}'!");
            Add(new Text(Draw.DefaultFont, $"invalid room '{Room}'", Vector2.Zero, Color.Aquamarine));
            return;
        }

        boardWidth = data.TileBounds.Width;
        boardHeight = data.TileBounds.Height;

        foreach(EntityData d in data.Entities.Where(d => d.Name == "FemtoHelper/SokobanObject"))
        {
            Objects.Add(new SokobanObject()
            {
                stepPercent = 0f,
                pos = d.Position,
                visualPos = d.Position,
                type = d.Attr("type"),
                prevType = d.Attr("type"),
            });
        }
    }

    public override void Update()
    {
        base.Update();
    }

    public void BeforeRender()
    {
        foreach (SokobanObject obj in Objects)
        {
            obj.Render();
        }
    }

    public override void Render()
    {
        base.Render();

    }

    public IEnumerator Sequence()
    {
        yield return null;
    }

    [OnLoadContent]
    public static void OnLoadContent(bool firstLoad)
    {
        buffer ??= VirtualContent.CreateRenderTarget("femtohelper-sokoban", 320, 180);
    }

    [OnUnload]
    public static void Unload()
    {
        buffer.Dispose();
    }
}
