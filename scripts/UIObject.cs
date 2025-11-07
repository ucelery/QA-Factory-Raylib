using System.Numerics;
using Raylib_cs;

public class UIObject
{
    public delegate void UIEvents();
    public UIEvents OnClick = null!;
    private Texture2D texture;
    private Vector2 position;
    private float scale = 1;
    private Rectangle rectangle;
    private bool isClickable = false;
    private Vector2 offset;
    private Vector2 textSize;

    public struct FontProps
    {
        public string text;
        public int size;
        public Color color;
        public Font font;
    }

    private FontProps fontProps;

    public UIObject(Vector2 position, Texture2D texture, float scale)
    {
        this.texture = texture;
        this.position = position;
        this.scale = scale;

        offset = new Vector2(texture.Width / 2 * scale, texture.Height / 2 * scale);
        rectangle = new Rectangle(position - offset, new Vector2(texture.Width * scale, texture.Height * scale));
    }

    public UIObject(Vector2 position, FontProps fontProps)
    {
        this.position = position;
        this.fontProps = fontProps;

        textSize = Raylib.MeasureTextEx(fontProps.font, fontProps.text, fontProps.size, 1);
        rectangle = new Rectangle(position - textSize / 2, textSize);
    }
    
    public void Update()
    {
        HandleClick();
    }

    public void Draw()
    {
        Rectangle source = new Rectangle(0, 0, texture.Width, texture.Height);
        Rectangle dest = new Rectangle(position - offset, texture.Width * scale, texture.Height * scale);

        Raylib.DrawTexturePro(
            texture,
            source,
            dest,
            new Vector2(0, 0),
            0f,
            Color.White
        );

        Raylib.DrawTextPro(fontProps.font, fontProps.text, position - textSize / 2, Vector2.Zero, 0, fontProps.size * scale, 1, fontProps.color);
        DrawGizmos();
    }
    
    public void SetClickable(bool flag)
    {
        isClickable = flag;
    }

    public void HandleClick()
    {
        Vector2 mousePos = Raylib.GetMousePosition();
        bool isInside = Raylib.CheckCollisionPointRec(mousePos, rectangle);
        if (Raylib.IsMouseButtonPressed(0) && isInside && isClickable)
        {
            OnClick?.Invoke();
        }
    }

    public void DrawGizmos()
    {
        // Raylib.DrawRectangleLines((int)position.X - (int)offset.X, (int)position.Y - (int)offset.Y, (int)(texture.Width * scale), (int)(texture.Height * scale), Color.Green);
        Raylib.DrawRectangleLines((int)rectangle.Position.X, (int)rectangle.Position.Y, (int)(rectangle.Width), (int)(rectangle.Height), Color.Green);
    }

    public void SetText(FontProps props)
    {
        fontProps = props;
    }
} 
