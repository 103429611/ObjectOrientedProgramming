using System.Xml;
using SplashKitSDK;
namespace ShapeDrawer
{   
    public abstract class Shape
    {
        protected Color _color;
        protected float _x;
        protected float _y;
        protected int _width;
        protected int _height;

        protected bool _selected;

    public Shape()
        {
            
        }
    public Shape(int param)
    {
        _color = Color.Azure;
        _x = 0.0f;
        _y = 0.0f;
        //_width = param;
        //_height = param;
        _selected = false;
    }
    public Shape(Color color)
        {
            _color = color;
            _x = 0.0f;
            _y = 0.0f;
            _selected = false; 
        }
    public Shape(int param, double iX, double iY)
    {
        _color = Color.Azure;
        _x = (float)iX;
        _y = (float)iY;
        _width = param;
        _height = param;
        _selected = false;
    }
    public Color Color
    {
        get{return _color;}
        set{_color = value;}
    }
    
    public float X
        {
            get {return _x;}
            set {_x = value;}
        }
            public float Y
        {
            get {return _y;}
            set {_y = value;}
        }

        //public int Width
        //{
        //    get {return _width;}
        //    set {_width = value;}
        //}
        // public int Height
        //{
        //    get {return _height;}
        //    set {_height = value;}
        //}
        public abstract void Draw();
        //{
           //SplashKit.FillRectangle(_color, _x, _y, _width, _height); 
        //}

        public bool Selected
        {
            get {return _selected;}
            set {_selected = value;}
        }
        public abstract bool IsAt(Point2D pt);
        //{
        //   return (pt.X >= _x) && (pt.X <= _x + _width) && (pt.Y >= _y) && (pt.Y <= _y + _height);
        //}
       
       public abstract void DrawOutLine();
        //{
        //    SplashKit.FillRectangle(Color.Black, _x-13, _y-13, _width+13, _height+13);
        //}

    }
}

