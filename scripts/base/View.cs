using System.Numerics;
using Raylib_cs;

public class View
{
    protected List<UIObject> objects = new();

    protected Vector2 screenDimensions = Vector2.Zero;
    public string name;
    
    public View(string name)
    {
        this.name = name;
    }

    public virtual void Initialize()
    {
        screenDimensions = new Vector2(Raylib.GetScreenWidth(), Raylib.GetScreenHeight());
    }

    public virtual void Update()
    {
        foreach (UIObject o in objects)
        {
            o.Update();
        }
    }

    public virtual void Draw()
    {
        foreach (UIObject o in objects)
        {
            o.Draw();
        }
    }
}