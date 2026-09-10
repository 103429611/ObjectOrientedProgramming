using SplashKitSDK;


namespace ShapeDrawer{

    public class MyCircle : Shape
    {
        private int _radius;

    public MyCircle() : this(Color.Blue, 50 + 11)
    {

    }

    public MyCircle(Color color, int radius)  : base(color) 
        {
            _color = color;
            _radius = radius;
        }

    public int Radius
        {
            get {return _radius;}
            set {_radius = value;}
        }

        
    public override void Draw()
        {   
            if(Selected)
            {
                DrawOutLine();
            }
            SplashKit.FillCircle(_color, _x, _y, _radius);
        }
    
    public override bool IsAt(Point2D pt)
        {
            return SplashKit.PointInCircle(pt.X, pt.Y, _x, _y, _radius);
        }
    public override void DrawOutLine()
        {
            SplashKit.FillCircle(Color.Black, _x, _y, _radius+2);
        }
    }
}

