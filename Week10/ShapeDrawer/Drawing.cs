
using MyGame;
using SplashKitSDK;
using System.IO;

namespace ShapeDrawer
{
    public class Drawing
    {
        private readonly List<Shape> _shapes;
        private Color _background;

        public Drawing() : this(Color.White)
        {

        }

        public Drawing(Color background)
        {
            _background = background;
            _shapes = new List<Shape>();
        }

        public List<Shape> SelectedShapes
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
                s.DisplayXY();
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
        public void Save(string filename)
        {
            StreamWriter writer = new StreamWriter(filename);
            try
            {
            writer.WriteColor(_background);
            writer.WriteLine(_shapes.Count);
            foreach(Shape s in _shapes)
            {
                s.SaveTo(writer);
            }
            } catch(Exception e)
            {
                Console.WriteLine("There is an error in the drawing.cs files at the line 82-90", e.Message);
            }
            finally
            {
            writer.Close();
            }
        }
        public void Load(string filename)
        {
            StreamReader reader = new StreamReader(filename);

            try
            {
                Background = reader.ReadColor();
                int count = reader.ReadInteger();

                _shapes.Clear();
                for(int i=0; i<count; i++)
                {
                    Shape s;
                    string kind = reader.ReadLine(); 
                    switch(kind)
                    {
                        case "Rectangle":
                            s = new MyRectangle();
                            break;
                        case "Circle":
                            s = new MyCircle();
                            break;
                        case "Line":
                            s = new MyLine();
                            break;
                        default: throw new InvalidDataException("Unknown shape kind " + kind);
                    }
                    s.LoadFrom(reader);
                    AddShape(s);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("There is an error in the loading function, maybe file does not exist.", e.Message);
            }
            finally
            {
                reader.Close();
            }
        }

    }
}