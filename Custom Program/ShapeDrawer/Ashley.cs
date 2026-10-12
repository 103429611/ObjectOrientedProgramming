using MyGame;
using SplashKitSDK;
using System.IO;

namespace ShapeDrawer
{
    public class Ashley
    {
        public static void DrawAshley(Drawing drawing)
        {
        
            // Example layout using lines and rectangles to form letters
            // Letter A
            MyRectangle a1 = new MyRectangle(Color.LightCoral, 50, 200, 80, 80);
            MyRectangle a2 = new MyRectangle(drawing.Background, 70, 220, 40, 20);
            MyRectangle a3 = new MyRectangle(drawing.Background, 70, 260, 40, 20);

            
            // Letter S
            MyRectangle s1 = new MyRectangle(Color.LightCoral, 160, 200, 80, 80);
            MyRectangle s2 = new MyRectangle(drawing.Background, 180, 220, 60, 10);
            MyRectangle s3 = new MyRectangle(drawing.Background, 160, 250, 60, 10);
            
            // Letter H
            MyRectangle h1 = new MyRectangle(Color.LightCoral, 270, 200, 80, 80);
            MyRectangle h2 = new MyRectangle(drawing.Background, 290, 200, 40, 30);
            MyRectangle h3 = new MyRectangle(drawing.Background, 290, 250, 40, 30);

            // Letter L
            MyRectangle l1 = new MyRectangle(Color.LightCoral, 380, 200, 80, 80);
            MyRectangle l2 = new MyRectangle(drawing.Background, 400, 200, 60, 60);


            // Letter E
            MyRectangle e1 = new MyRectangle(Color.LightCoral, 490, 200, 80, 80);
            MyRectangle e2 = new MyRectangle(drawing.Background, 510, 220, 60, 10);
            MyRectangle e3 = new MyRectangle(drawing.Background, 510, 250, 60, 10);


            // Letter Y
            MyRectangle y1 = new MyRectangle(Color.LightCoral, 600, 200, 80, 80);
            MyRectangle y2 = new MyRectangle(drawing.Background, 620, 200, 40, 30);
            MyRectangle y3 = new MyRectangle(drawing.Background, 600, 250, 30, 30);
            MyRectangle y4 = new MyRectangle(drawing.Background, 650, 250, 30, 30);


            drawing.AddShape(a1);
            drawing.AddShape(a2);
            drawing.AddShape(a3);

            drawing.AddShape(s1);
            drawing.AddShape(s2);
            drawing.AddShape(s3);

            drawing.AddShape(h1);
            drawing.AddShape(h2);
            drawing.AddShape(h3);

            drawing.AddShape(l1);
            drawing.AddShape(l2);

            drawing.AddShape(e1);
            drawing.AddShape(e2);
            drawing.AddShape(e3);

            drawing.AddShape(y1);
            drawing.AddShape(y2);
            drawing.AddShape(y3);
            drawing.AddShape(y4);

        }
    }
}