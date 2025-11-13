using Raylib_cs;

namespace MyRaylibGame;

class Program
{
    private const int screenWidth = 1280;
    private const int screenHeight = 720;

    private static View currentView = null!;
    private static List<View> views = new();

    public static void Main()
    {
        Raylib.InitWindow(screenWidth, screenHeight, "QA Factory");
        Raylib.SetTargetFPS(60);

        AssetManager.Instance.Initialize();

        View mainMenu = new MainMenu("MainMenu");
        views.Add(mainMenu);
        currentView = mainMenu;

        View inGame = new InGame("InGame");
        views.Add(inGame);

        mainMenu.Initialize();

        while (!Raylib.WindowShouldClose())
        {
            currentView.Update();

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);

            currentView.Draw();

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
    
    public static void SetView(string name)
    {
        foreach (View v in views)
        {
            if (v.name == name)
            {
                Console.WriteLine($"[ LOAD VIEW ] View changed from '{currentView.name}' to '{name}'");
                currentView = v;
                return;
            }
        }

        Console.WriteLine($"[ LOAD VIEW ] View '{name}' not found");
    }
}