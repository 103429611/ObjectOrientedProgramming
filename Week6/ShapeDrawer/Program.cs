using System.ComponentModel;
using System.Drawing;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Program
    {
        public static void Main()
        {
            Window window = new Window("Shape Drawer", 800, 600);
            //Shape myShape = new Shape(200);

            Drawing myDrawing = new Drawing();



            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();
                if(SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    //myShape.X = SplashKit.MouseX();
                    //myShape.Y = SplashKit.MouseY();
                    Point2D mPos = SplashKit.MousePosition();
                    myDrawing.AddShape(new MyRectangle(100, mPos.X, mPos.Y));
                }
                if(SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    //myDrawing.SelectedShapeAt(SplashKit.MousePosition());
                    //myDrawing.RemoveShape();
                }

                //if(SplashKit.KeyDown(KeyCode.SpaceKey) && myShape.IsAt(SplashKit.MousePosition()))
                {
                   // myShape.Color = SplashKit.RandomColor();
                    //SplashKit.RefreshScreen();
                    //SplashKit.ClearScreen();
                  // myShape.Draw();
                }
                myDrawing.Draw();
                //myShape.Draw();
                SplashKit.RefreshScreen();
            } while (!window.CloseRequested);
        }
    }
}
