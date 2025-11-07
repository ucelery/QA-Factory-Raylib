using System.Numerics;
using Raylib_cs;

public class InGame : View
{
    public InGame(string name) : base(name)
    {
    }

    public override void Initialize()
    {
        base.Initialize();
    }

    public override void Update()
    {
        Raylib.DrawTextureV(AssetManager.Instance.Textures["FactoryBg"][0], Vector2.Zero, Color.White);
    }
}