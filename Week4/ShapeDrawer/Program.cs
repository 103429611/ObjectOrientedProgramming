using System.ComponentModel;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Program
    {
        public static void Main()
        {
            Window window = new Window("Shape Drawer", 800, 600);
            Shape myShape = new Shape(111); //103429611



            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();
                if(SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    myShape.X = SplashKit.MouseX();
                    myShape.Y = SplashKit.MouseY();
                    myShape.Color = Color.Red;
                }
                if(SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    Console.WriteLine(myShape.IsAt(SplashKit.MousePosition()));
                }

                if(SplashKit.KeyDown(KeyCode.SpaceKey) && myShape.IsAt(SplashKit.MousePosition()))
                {
                    myShape.Color = SplashKit.RandomColor();
                    SplashKit.RefreshScreen();
                    SplashKit.ClearScreen();
                    myShape.Draw();
                }
                myShape.Draw();
                SplashKit.RefreshScreen();
            } while (!window.CloseRequested);
        }
    }
}