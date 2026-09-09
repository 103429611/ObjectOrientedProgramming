using SplashKitSDK;


namespace ShapeDrawer{

    public class MyLine : Shape
    {
        private float _endX;
        private float _endY;

        public MyLine()
        {
           _x = 0.0f;
           _y = 0.0f;
           _endX = 11.0f;
           _endY = 0.0f;
        }
        public MyLine(Color color, float startX, float startY, float endX, float endY) : base(color)
        {
            _x = startX;
            _y = startY;
            _endX = endX;
            _endY = endY;
        }
        public override float X
        {
            get { return _x; }
            set 
            { 
                _x = value;
                _endX = value + 11;
            }
        }

        public override float Y
        {
            get { return _y; }
            set 
            { 
                _y = value;
                _endY = value;
            }
        }
        public Line LineSegment
        {
            get { return SplashKit.LineFrom(_x, _y, _endX, _endY); }
        }

        public override void Draw()
        {
            SplashKit.DrawLine(_color, _x, _y, _endX, _endY);
        }

        public override bool IsAt(Point2D pt)
        {
            return SplashKit.PointOnLine(pt, LineSegment);
        }

        public override void DrawOutLine()
        {
            // Highlight endpoints
            SplashKit.FillCircle(Color.Black, _x, _y, 4);
            SplashKit.FillCircle(Color.Black, _endX, _endY, 4);
        }
    }
}