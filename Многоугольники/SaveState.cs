using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Многоугольники
{
    public class SaveLoad
    {
        public static void SaveState(List<Shape> shapes, Color hullcolor, int radius, Color lineClr, Color fillClr, string path)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            bf.Serialize(fs, radius);
            bf.Serialize(fs, lineClr);
            bf.Serialize(fs, fillClr);
            bf.Serialize(fs, hullcolor);
            bf.Serialize(fs, shapes);
            fs.Close();
        }

        public static void LoadState(ref List<Shape> shapes, ref Color hullcolor, ref int radius, ref Color lineClr, ref Color fillClr, string path)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            radius = (int) bf.Deserialize(fs);
            lineClr = (Color) bf.Deserialize(fs);
            fillClr = (Color) bf.Deserialize(fs);
            hullcolor = (Color) bf.Deserialize(fs);
            List<Shape> data = (List<Shape>) bf.Deserialize(fs);
            shapes = new List<Shape>();
            foreach (Shape shape in data)
            {
                shapes.Add(shape);
            }

            fs.Close();
        }
    }
}