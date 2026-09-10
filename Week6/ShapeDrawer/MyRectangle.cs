using SplashKitSDK;


namespace ShapeDrawer{

    public class MyRectangle : Shape
    {
    
    public MyRectangle() : this(Color.Green, 0.0f, 0.0f, 100+11, 100+11)
        {
        
        }
    
    public MyRectangle(Color color, float x, float y, int width, int height) : base(color) 
        {
            _x = x;
            _y = y;
            _width = width;
            _height = height;
        }
    public int Width
        {
            get {return _width;}
            set {_width = value;}
        }
    public int Height
        {
            get {return _height;}
            set {_height = value;}
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