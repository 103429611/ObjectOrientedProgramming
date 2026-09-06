using System.Runtime.InteropServices.Marshalling;
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

    public Shape() : this(Color.Yellow)
        {    
        }

    public Shape(Color color)
        {
            _color = color;
            _x = 0.0f;
            _y = 0.0f;
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

        public abstract void Draw();

       public abstract void DrawOutLine();

        public bool Selected
        {
            get {return _selected;}
            set {_selected = value;}
        }
        public abstract bool IsAt(Point2D pt);

       

    }
}

