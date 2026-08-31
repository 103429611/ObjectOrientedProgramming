using SplashKitSDK;


namespace ShapeDrawer{

    public class MyRectangle : Shape
    {

    public MyRectangle()
        {
            _color = Color.Chocolate;
            _x = 0.0f;
            _y = 0.0f;
            _width = 100 + 20;
            _height = 100 + 20;
        }
    public MyRectangle(int param, double X, double Y)
        {
            _x = (float)X;
            _y = (float)Y;
            _width = param;
            _height = param;
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
            SplashKit.FillRectangle(_color,_x,_y,_width,_height);
        }
    
    public override bool IsAt(Point2D pt)
        {
            return SplashKit.PointInRectangle(pt.X,pt.Y, _x,_y,_width,_height);

        }
    public override void DrawOutLine()
        {
            SplashKit.FillRectangle(Color.Black);
        }
    }

}