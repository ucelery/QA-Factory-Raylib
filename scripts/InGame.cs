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
        
    }

    public override void Draw()
    {
        Texture2D texture = AssetManager.Instance.Textures["FactoryBg"][0];
        Rectangle textureRec = new(0, 0, texture.Width, texture.Height);
        Rectangle screenRec = new(0, 0, Raylib.GetScreenWidth(), Raylib.GetScreenHeight());

        Raylib.DrawTexturePro(AssetManager.Instance.Textures["FactoryBg"][0], textureRec, screenRec, Vector2.Zero, 0f, Color.White);
    }
}