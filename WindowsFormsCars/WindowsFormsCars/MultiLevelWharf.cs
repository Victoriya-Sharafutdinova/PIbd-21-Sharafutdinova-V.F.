﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsCars
{
    class MultiLevelWharf
    {
        List<Wharf<ITransport>> parkingStages;
        private const int countPlaces = 20;
        private int pictureWidth;
        private int pictureHeight;

        public MultiLevelWharf(int countStages, int pictureWidth, int pictureHeight)
        {
            parkingStages = new List<Wharf<ITransport>>();
            this.pictureHeight = pictureHeight;
            this.pictureWidth = pictureWidth;
            for (int i = 0; i < countStages; ++i)
            {
                parkingStages.Add(new Wharf<ITransport>(countPlaces, pictureWidth, pictureHeight));
            }
        }
        public Wharf<ITransport> this[int ind]
        {
            get
            {
                if (ind > -1 && ind < parkingStages.Count)
                {
                    return parkingStages[ind];
                }
                return null;
            }
        }

        public void SaveData(string filename)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                WriteToFile("CountLeveles:" + parkingStages.Count + Environment.NewLine, fs);
                foreach (var level in parkingStages)
                {
                    WriteToFile("Level" + Environment.NewLine, fs);
                    foreach (ITransport ship in level)
                    {

                        if (ship.GetType().Name == "SimpleShip")
                        {
                            WriteToFile(level.GetKey + ":SimpleShip:", fs);
                        }
                        if (ship.GetType().Name == "Ship")
                        {
                            WriteToFile(level.GetKey + ":Ship:", fs);
                        }
                        WriteToFile(ship + Environment.NewLine, fs);
                    }
                }
            }
        }



        private void WriteToFile(string text, FileStream stream)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(text);
            stream.Write(info, 0, info.Length);
        }

        public void LoadData(string filename)
        {
            if (!File.Exists(filename))
            {
                throw new FileNotFoundException();
            }
            string bufferTextFromFile = "";
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                using (BufferedStream bs = new BufferedStream(fs))
                {
                    byte[] b = new byte[fs.Length];
                    UTF8Encoding temp = new UTF8Encoding(true);
                    while (bs.Read(b, 0, b.Length) > 0)
                    {
                        bufferTextFromFile += temp.GetString(b);
                    }
                }
            }
            bufferTextFromFile = bufferTextFromFile.Replace("\r", "");
            var strs = bufferTextFromFile.Split('\n');
            if (strs[0].Contains("CountLeveles"))
            {
                int count = Convert.ToInt32(strs[0].Split(':')[1]);
                if (parkingStages != null)
                {
                    parkingStages.Clear();
                }
                parkingStages = new List<Wharf<ITransport>>(count);
            }
            else
            {
                throw new Exception("Неверный формат файла");
            }
            int counter = -1;
            int counterShip = 0;
            ITransport ship = null;
            for (int i = 1; i < strs.Length; ++i)
            {
                if (strs[i] == "Level")
                {
                    counter++;
                    counterShip = 0;
                    parkingStages.Add(new Wharf<ITransport>(countPlaces, pictureWidth, pictureHeight));
                    continue;
                }

                if (string.IsNullOrEmpty(strs[i]))
                {
                    continue;
                }

                if (strs[i].Split(':')[1] == "SimpleShip")
                {
                    ship = new SimpleShip(strs[i].Split(':')[2]);
                }

                else if (strs[i].Split(':')[1] == "Ship")
                {
                    ship = new Ship(strs[i].Split(':')[2]);
                }

                parkingStages[counter][counterShip++] = ship;
            }
        }
        public void Sort()
        {
            parkingStages.Sort();

            
        }
    }
}
