using System.ComponentModel;
using System.Drawing;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Program
    {
        private enum ShapeKind
        {
            Rectangle,
            Circle, 
            Line
        }

        public static void Main()
        {
            Window window = new Window("Shape Drawer", 800, 600);

            Drawing myDrawing = new Drawing();

            ShapeKind kindToAdd = ShapeKind.Circle;

            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                if(SplashKit.KeyTyped(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }
                if(SplashKit.KeyTyped(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }
                if(SplashKit.KeyTyped(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                }
                

                if(SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape newShape;
                    

                    switch(kindToAdd)
                    {
                        case ShapeKind.Circle:
                        newShape = new MyCircle(); 
                        break;
                        case ShapeKind.Rectangle:
                        newShape = new MyRectangle(); 
                        break;
                        case ShapeKind.Line:
                        newShape = new MyLine();                          
                        break;

                        default:
                        newShape = new MyRectangle();
                        break;
                    }

                        Point2D currentPosition = SplashKit.MousePosition();
                        newShape.X = (float)currentPosition.X;
                        newShape.Y = (float)currentPosition.Y;

                        myDrawing.AddShape(newShape);
                }
                if(SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    myDrawing.SelectedShapeAt(SplashKit.MousePosition());
                    //myDrawing.RemoveShape();
                }
                 
                if(SplashKit.KeyTyped(KeyCode.BackspaceKey)||SplashKit.KeyTyped(KeyCode.DeleteKey))
                {
                    foreach (Shape s in myDrawing.SelectedShapes)
                    {
                        myDrawing.RemoveShape(s);
                    }                    
                }

                if(SplashKit.KeyTyped(KeyCode.SpaceKey))
                {   
                   myDrawing.Background = SplashKit.RandomColor();
                }

                myDrawing.Draw();

                SplashKit.RefreshScreen();
            } while (!window.CloseRequested);
        }
    }
}
