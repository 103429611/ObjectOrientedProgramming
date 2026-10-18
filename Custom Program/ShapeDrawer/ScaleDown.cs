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
                    float scaleMultiplier = scaleFactor / 100.0f;
                    switch(kind)
                    {
                        case "Rectangle":
                            Color rcolor = reader.ReadColor();
                            float rx = reader.ReadSingle() * scaleMultiplier;
                            float ry = reader.ReadSingle() * scaleMultiplier;
                            float rwidth = reader.ReadSingle() * scaleMultiplier;
                            float rheight = reader.ReadSingle() * scaleMultiplier;
                            s = new MyRectangle(rcolor, rx, ry, rwidth, rheight);
                            break;
                        case "Circle":
                            Color ccolor = reader.ReadColor();
                            float cx = reader.ReadSingle();
                            float cy = reader.ReadSingle();
                            float cradius = reader.ReadSingle();
                            if (cradius >=  10)
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
                            float lx = reader.ReadSingle() - scaleFactor;
                            float ly = reader.ReadSingle() - scaleFactor;
                            float lendX = reader.ReadSingle() - scaleFactor;
                            float lendY = reader.ReadSingle() - scaleFactor;
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