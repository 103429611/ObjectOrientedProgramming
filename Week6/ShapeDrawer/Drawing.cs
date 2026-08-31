
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Drawing
    {
        private readonly List<Shape> _shapes;
        private Color _background;

        public Drawing()
        {
            _background = Color.White;
            _shapes = new List<Shape>();
        }

        public Drawing(Color background)
        {
            _background = background;
            _shapes = new List<Shape>();
        }

        public List<Shape> selectedShapes
        {
            get
            {
                List<Shape> results = new List<Shape>();
                foreach(Shape s in _shapes)
                {
                    if(s.Selected == true)
                    {
                        results.Add(s);
                    }
                }
                return results;
            }
        }
        public int ShapeCount()
        {
            return _shapes.Count;
        }
        public Color Background
        {
            get {return _background;}
            set {_background = value;}
        }

        public void Draw()
        {
            SplashKit.ClearScreen(_background);
            foreach(Shape s in _shapes)
            {
                s.Draw();
            }
        }

        public void AddShape(Shape s)
        {
            _shapes.Add(s);
        }

        public void RemoveShape(Shape s)
        {
            _shapes.Remove(s);
        }


        public void SelectedShapeAt(Point2D pt)
        {
            foreach(Shape s in _shapes)
            {
                if(s. IsAt(pt) == true)
                {
                    s.Selected = true;
                }
            }
        }

    }
}