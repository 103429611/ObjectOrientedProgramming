using SplashKitSDK;


namespace ShapeDrawer{

    public class MyLine : Shape
    {
        private float _endX;
        private float _endY;

        public MyLine() : this(Color.Red, 0.0f, 0.0f, 11.0f, 0.0f)
        {

        }
        public MyLine(Color color, float startX, float startY, float endX, float endY) : base(color)
        {
            _x = startX;
            _y = startY;
            _endX = endX;
            _endY = endY;
        }
        public Line LineSegment
        {
            get { return SplashKit.LineFrom(_x, _y, _endX, _endY); }
        }

        public override void Draw()
        {
            if(Selected == true)
            {
                DrawOutLine();
            }
            SplashKit.DrawLine(_color, _x, _y, _endX, _endY);
        }

        public override bool IsAt(Point2D pt)
        {
            return SplashKit.PointOnLine(pt, LineSegment);
        }

        public override void DrawOutLine()
        {
            SplashKit.FillCircle(Color.Black, _x, _y, 10);
            SplashKit.FillCircle(Color.Black, _endX, _endY, 10);
        }
    }
}