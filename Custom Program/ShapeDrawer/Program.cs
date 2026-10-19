using System.ComponentModel;
using System.Drawing;
using SplashKitSDK;
using System.IO;

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

                // Right clicking a shape will select the shape and outline it
                if(SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    myDrawing.SelectedShapeAt(SplashKit.MousePosition());
                    //myDrawing.RemoveShape();
                }

                // Pressing "A" Will put the name "Ashley" on screen using a number of shapes as defined by Ashley.cs
                if(SplashKit.KeyTyped(KeyCode.AKey))
                {
                    myDrawing.RemoveAllShapes();
                    Ashley.DrawAshley(myDrawing);
                }
                 
                // Pressing Backspace or Delete will remove the selected shapes
                if(SplashKit.KeyTyped(KeyCode.BackspaceKey)||SplashKit.KeyTyped(KeyCode.DeleteKey))
                {
                    foreach (Shape s in myDrawing.SelectedShapes)
                    {
                        myDrawing.RemoveShape(s);
                    }                    
                }

                // Pressing Spacebar will randomise the background color
                if(SplashKit.KeyTyped(KeyCode.SpaceKey))
                {   
                   myDrawing.Background = SplashKit.RandomColor();
                }

                // Pressing "S" Will save the current drawing to file "Drawing.txt"
                if(SplashKit.KeyTyped(KeyCode.SKey))
                {
                    try
                    {
                        myDrawing.Save("Drawing.txt"); 
                    } catch (Exception e)
                    {
                        Console.Error.WriteLine("Error Loading File", e.Message);
                    }
                }

                // Pressing "O" Will load in the saved drawings from "Drawing.txt"
                if(SplashKit.KeyTyped(KeyCode.OKey))
                {
                     try
                    {
                        myDrawing.Load("Drawing.txt"); 
                    } catch (Exception e)
                    {
                        Console.Error.WriteLine("Error Reading File", e.Message);
                    }
                }

                // Pressing Down arrow will scale down the shapes on screen between 1-5%
                if(SplashKit.KeyTyped(KeyCode.DownKey))
                {
                     try
                    {
                        int scale = Random.Shared.Next(95, 99);   
                        myDrawing.Save("ScaledDrawing.txt");
                        SplashKit.ClearScreen();
                        myDrawing = ScaleDown.LoadScaled("ScaledDrawing.txt",scale);
                    } catch (Exception e)
                    {
                        Console.Error.WriteLine("Error Reading File", e.Message);
                    }
                }

                // Pressing Up arrow will scale up the shapes on screen between 5 and 10%
                if(SplashKit.KeyTyped(KeyCode.UpKey))
                {
                     try
                    {
                        int scale = Random.Shared.Next(105, 110);   
                        myDrawing.Save("ScaledDrawing.txt");
                        SplashKit.ClearScreen();
                        myDrawing = ScaleDown.LoadScaled("ScaledDrawing.txt",scale);
                    } catch (Exception e)
                    {
                        Console.Error.WriteLine("Error Reading File", e.Message);
                    }
                }

                // Pressing "Q" Will draw a random number of shapes (between 2-15) with random size, location and color
                if(SplashKit.KeyTyped(KeyCode.QKey))
                {
                    myDrawing.RemoveAllShapes();
                    RandomShapes.DrawRandomShapes(myDrawing);

                }
              


                myDrawing.Draw();

                SplashKit.RefreshScreen();
            } while (!window.CloseRequested);
        }
    }
}
