using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ConsoleApp165
{
    public class Сonverter
    {
        public string Name;
        public int HotelId;
        public string FoundedDate;
        public int TouristСapacity;
        public int Rating;

        public Сonverter(string name, int hotelId, string foundedDate, int touristСapacity, int rating)
        {
            this.Name = name;
            this.HotelId = hotelId;
            this.FoundedDate = foundedDate;
            this.TouristСapacity = touristСapacity;
            this.Rating = rating;
        }
        public Сonverter() { }
        static void Main(string[] args)
        {
            List<Сonverter> readers = new List<Сonverter>();
            using (StreamReader rd = new StreamReader(@"D:\JSONSS\Pars.csv"))
            {
                while (!rd.EndOfStream)
                {
                    string str = rd.ReadLine();
                    string[] value = str.Split(new char[] { ';' });
                    int reading = 0;
                    int.TryParse(value[4], out reading);
                    readers.Add(new Сonverter(value[0], int.Parse(value[1]), value[2], int.Parse(value[3]), reading));
                }
            }
            readers.Sort((x, y) => x.Rating.CompareTo(y.Rating));

            int a = int.Parse(Console.ReadLine());
            switch (a)
            {
                case (1):
                    XmlSerializer formatter = new XmlSerializer(typeof(List<Сonverter>));
                    using (FileStream fs = new FileStream("input.xml", FileMode.OpenOrCreate))
                    {
                        formatter.Serialize(fs, readers);
                        Console.WriteLine("Object serialized Xml");
                    }
                    break;
                case (2):
                    using (FileStream fs = new FileStream("input.xml", FileMode.OpenOrCreate))
                    {
                        File.AppendAllText("input.json", JsonConvert.SerializeObject(readers));
                        Console.WriteLine("Object serialized Json");
                    }                                                      
                    break;
                default:
                    Console.WriteLine("input or 1 or 2");
                    break;                   
            }
            ShowRead(readers);
        }
        public static void ShowRead(List<Сonverter> readers)
        {
            foreach (Сonverter x in readers)
            {
                Console.WriteLine(string.Format("Name : {0} \t HotelId : {1} \t FoundedDate {2}  \t TouristСapacity {3} \t Rating{4}", x.Name, x.HotelId, x.FoundedDate, x.TouristСapacity, x.Rating));
            }

        }
    }

}






//public static void ShowRead(List<Program> readers)          
//{
//    foreach (Program x in readers)
//    {
//        Console.WriteLine(x.Name +";" + x.HotelId + ";" + x.FoundedDate + ";" +  x.TouristСapacity + ";" + x.Rating);
//    }

//}