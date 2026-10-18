using MyGame;
using SplashKitSDK;
using System.IO;

namespace ShapeDrawer
{
    public class RandomShapes
    {
        private enum ShapeKind
        {
            Rectangle,
            Circle, 
            Line
        }
        public static void DrawRandomShapes(Drawing drawing)
        {
            int _shapeNumber = Random.Shared.Next(2, 15);
            ShapeKind kindToAdd = ShapeKind.Rectangle;
            Shape newShape;

            int i = 0;
            while(i < _shapeNumber)
            {

                float _randomX = Random.Shared.Next(0,800);
                float _randomY = Random.Shared.Next(0,600);
                Color _randomColor = SplashKit.RandomColor();
                float _randomRadius = Random.Shared.Next(10,30);
                float _randomStartX = Random.Shared.Next(0,800);
                float _randomStartY = Random.Shared.Next(0,600);
                float _randomWidth = Random.Shared.Next(10,100);
                float _randomHeight = Random.Shared.Next(10,100);




                int _randomShape = Random.Shared.Next(0,3);
                if(_randomShape == 0)
                {
                    kindToAdd = ShapeKind.Rectangle;
                }
                if(_randomShape == 1)
                {
                    kindToAdd = ShapeKind.Circle;
                }
                if(_randomShape == 2)
                {
                    kindToAdd = ShapeKind.Line;
                }

                switch(kindToAdd)
                    {
                        case ShapeKind.Circle:
                        newShape = new MyCircle(_randomColor, _randomX, _randomY, _randomRadius); 
                        break;
                        case ShapeKind.Rectangle:
                        newShape = new MyRectangle(_randomColor, _randomX, _randomY, _randomWidth, _randomHeight); 
                        break;
                        case ShapeKind.Line:
                        newShape = new MyLine(_randomColor, _randomX, _randomY, _randomStartX, _randomStartY);                          
                        break;

                        default:
                        newShape = new MyRectangle();
                        break;
                    }


                drawing.AddShape(newShape);
                i += 1;
                    
            }
        }
    }
}
