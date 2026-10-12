using System.Runtime.InteropServices.Marshalling;
using System.Xml;

using SplashKitSDK;
using System.IO;
using MyGame;
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
    
    public virtual float X
        {
            get {return _x;}
            set {_x = value;}
        }
    public virtual float Y
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
        
        public void DisplayXY()
        {
            string X = _x.ToString();
            string Y = _y.ToString();
            SplashKit.DrawText("x= " + X + ", y= " + Y,Color.Black, _x,_y);
        }

        public abstract bool IsAt(Point2D pt);

        public virtual void SaveTo(StreamWriter writer)
        {
            writer.WriteColor(_color);
            writer.WriteLine(_x);
            writer.WriteLine(_y);
        }
       public virtual void LoadFrom(StreamReader reader)
        {
            _color = reader.ReadColor();
            _x = reader.ReadInteger();
            _y = reader.ReadInteger();

        }

    }
}

