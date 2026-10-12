using MyGame;
using SplashKitSDK;
using System.IO;

namespace ShapeDrawer
{
    public class ScaleDown
    {
        
        public static Drawing LoadScaled(string filename, int scaleFactor)
        {
            StreamReader reader = new StreamReader(filename);
            Drawing scaledDrawing = new Drawing();

            try
            {
                scaledDrawing.Background = reader.ReadColor();
                int count = reader.ReadInteger();

                for(int i=0; i<count; i++)
                {
                    Shape s;
                    string kind = reader.ReadLine(); 
                    switch(kind)
                    {
                        case "Rectangle":
                            Color rcolor = reader.ReadColor();
                            float rx = reader.ReadInteger();
                            float ry = reader.ReadInteger();
                            int rwidth = reader.ReadInteger() - scaleFactor;
                            int rheight = reader.ReadInteger() - scaleFactor;
                            s = new MyRectangle(rcolor, rx, ry, rwidth, rheight);
                            break;
                        case "Circle":
                            Color ccolor = reader.ReadColor();
                            float cx = reader.ReadInteger();
                            float cy = reader.ReadInteger();
                            int cradius = reader.ReadInteger();
                            if (cradius <=10)
                            {
                                cradius -= scaleFactor;
                            }
                            else
                            {
                                
                            }
                            
                            s = new MyCircle(ccolor, cx, cy, cradius);
                            break;
                        case "Line":
                            Color lcolor = reader.ReadColor();
                            float lx = reader.ReadInteger();
                            float ly = reader.ReadInteger();
                            float lendX = reader.ReadInteger() - scaleFactor;
                            float lendY = reader.ReadInteger() - scaleFactor;
                            s = new MyLine(lcolor, lx,ly,lendX,lendY);
                            break;
                        default: throw new InvalidDataException("Unknown shape kind " + kind);
                    }
                    scaledDrawing.AddShape(s);

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
            return scaledDrawing;
        }
    }
}