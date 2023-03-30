using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string st = "C:/Student/16";
        private void button1_Click(object sender, EventArgs e)
        {
            List<double> x = new List<double>() {5.5, 4.2, 16.4, 7.1}, y = new List<double>() { 0.8, 4.3, 7.7, 61.2 };
            /*for (int i = 0; i < listBox1.Items.Count; i++)
            {
                x.Add(Convert.ToDouble(listBox1.Items[i]));
            }
            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                y.Add(Convert.ToDouble(listBox2.Items[i]));
            }*/
            if (x.Count != y.Count)
                MessageBox.Show("Количество иксов не соответствует количеству игриков!");
            else
            {
                for (int i = 0; i < x.Count; i++)
                {
                    double d = Function(x[i], y[i]);
                        rand(d);
                }
            }
        }
        private double Function(double x, double y){
            return Math.Pow(x*x*x*x*x-2, 1/3)/y;
        }
        private void rand( double d)
        {
            //Создание объекта для генерации чисел
            Random rnd = new Random();
 
            //Получить очередное (в данном случае - первое) случайное число
            int value = rnd.Next(4, 4);
            switch (value)
            {
                case 1:
                    BinFile1(d);
                    break;
                case 2:
                    BinFile2(d);
                    break;
                case 3:
                    BinFile3(d);
                    break;
                case 4:
                    BinFile4(d);
                    break;
            }
        }
        private void BinFile1(double d)
        {
            string s = st + "/G0001.rez";
            using (BinaryWriter b = new BinaryWriter(File.Open(s, FileMode.OpenOrCreate))) {
                b.Write(Convert.ToString(d));
            }
            using (BinaryReader b = new BinaryReader(File.Open(s, FileMode.Open)))
                        {
                            int pos = 50000;
                            int required = 2000;

                            // Seek the required index.
                            b.BaseStream.Seek(pos, SeekOrigin.Begin);

                            // Read the next 2000 bytes.
                            byte[] by = b.ReadBytes(required);
                        }
            

        }
        private void BinFile2(double d)
        {
            string s = st + "/G0002.rez";
            using (BinaryWriter b = new BinaryWriter(File.Open(s, FileMode.OpenOrCreate)))
            {
                b.Write(Convert.ToString(d));
            }
            using (BinaryReader b = new BinaryReader(File.Open(s, FileMode.Open)))
            {
                int pos = 50000;
                int required = 2000;

                // Seek the required index.
                b.BaseStream.Seek(pos, SeekOrigin.Begin);

                // Read the next 2000 bytes.
                byte[] by = b.ReadBytes(required);
            }

        }
        private void BinFile3(double d)
        {
            string s = st + "/G0003.rez";
            using (BinaryWriter b = new BinaryWriter(File.Open(s, FileMode.OpenOrCreate)))
            {
                b.Write(Convert.ToString(d));
            }
            using (BinaryReader b = new BinaryReader(File.Open(s, FileMode.Open)))
            {
                int pos = 50000;
                int required = 2000;

                // Seek the required index.
                b.BaseStream.Seek(pos, SeekOrigin.Begin);

                // Read the next 2000 bytes.
                byte[] by = b.ReadBytes(required);
            }

        }
        private void BinFile4(double d)
        {
            string s = st + "/G0004.rez";
            using (BinaryWriter b = new BinaryWriter(File.Open(s, FileMode.OpenOrCreate)))
            {
                b.Write(Convert.ToString(d));
            }
            using (BinaryReader b = new BinaryReader(File.Open(s, FileMode.Open)))
            {
                int pos = 0;
                int required = 2000;
                string strin = "";

                //b.(Convert.ToString(d));

                // Seek the required index.
                b.BaseStream.Seek(pos, SeekOrigin.Begin);

                // Read the next 2000 bytes.
                byte[] by = b.ReadBytes(required);
                MessageBox.Show(string.Join("", by));
                while (b.PeekChar() > -1)
                    strin = string.Join("", b.ReadDouble());
                MessageBox.Show(strin);
            }

        }
    }
}
