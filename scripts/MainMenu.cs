using System.Numerics;
using MyRaylibGame;
using Raylib_cs;

public class MainMenu : View
{
    public MainMenu(string name) : base(name)
    {
    }

    public override void Initialize()
    {
        base.Initialize();
        // Cover
        Vector2 coverPos = new Vector2(screenDimensions.X / 2, (screenDimensions.Y / 2) - 120);
        Texture2D titleTexture = AssetManager.Instance.Textures["QAFactoryCover"][0];
        UIObject title = new UIObject(coverPos, titleTexture, 1.2f);
        objects.Add(title);

        // Play Button
        Vector2 playPos = new Vector2(coverPos.X, coverPos.Y + (titleTexture.Height / 2) + 50);
        UIObject.FontProps fontProps = new();
        fontProps.font = Raylib.LoadFont("resources/fonts/Indie_Flower/IndieFlower-Regular.ttf");
        fontProps.text = "PLay";
        fontProps.color = Color.White;
        fontProps.size = 46;

        UIObject playButton = new UIObject(playPos, fontProps);
        playButton.SetClickable(true);
        playButton.OnClick += OnClick_Play;
        objects.Add(playButton);
    }

    private void OnClick_Play()
    {
        Program.SetView("InGame");
    }
}