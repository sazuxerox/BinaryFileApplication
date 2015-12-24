using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryFileApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryWriter bw;
            BinaryReader br;

            int i = 25;
            double d = 2.14;
            bool b = true;
            string s = "I am Sazu";

            //create the file

            try
            {
                bw = new BinaryWriter(new FileStream("mydata", FileMode.Create));
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\nCannot create the file");
                return;
            }

            try
            {
                bw.Write(i);
                bw.Write(d);
                bw.Write(b);
                bw.Write(s);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\nCannot write to the file");
                return;
            }
            bw.Close();

            try
            {
                br = new BinaryReader(new FileStream("mydata", FileMode.Open));
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\nCannot open the file");
                return;
            }

            try
            {
                i = br.ReadInt32();
                Console.WriteLine("Integer data is => {0}", i);

                d = br.ReadDouble();
                Console.WriteLine("Double data is => {0:f2}", d);


                b = br.ReadBoolean();
                Console.WriteLine("Boolean data is => {0}", b);


                s = br.ReadString();
                Console.WriteLine("String data is => {0}", s);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\n cannot read from the  file");
                return;
            }
            br.Close();
            Console.ReadKey();
        }
    }
}
