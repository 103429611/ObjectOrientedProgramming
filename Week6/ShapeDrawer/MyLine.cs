using SplashKitSDK;


namespace ShapeDrawer{

    public class MyLine : Shape
    {
    private float _endX;
    private float _endY;
    public MyLine() 
        {
            _color = Color.Red;
            _x = 0.0f;
            _y = 0.0f;
            _width = 100 + 11;
            _height = 2;
        }
    public MyLine(Color color, float startX, float startY, int endX, int endY) : base(color) 
        {
            _x = startX;
            _y = startY;
            _endX = endX;
            _endY = endY;
        }
    public float EndX
        {
            get {return _endX;}
            set {_endX = value;}
        }
    public float EndY
        {
            get {return _endY;}
            set {_endY = value;}
        }
    public override void Draw()
        {
            if(_selected == true)
            {
                DrawOutLine();
            }
            SplashKit.FillRectangle(_color,_x,_y,_width,_height);
        }
    
    public override bool IsAt(Point2D pt)
        {
            return SplashKit.PointInRectangle(pt.X,pt.Y, _x,_y,_width,_height);

        }
    public override void DrawOutLine()
        {
            SplashKit.FillRectangle(Color.Black, _x-3, _y-3, _width+5+1, _height+5+1);
        }
    }

}