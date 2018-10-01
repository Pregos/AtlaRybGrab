using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace ConsoleApplication1
{
    public class Rybka
    {
        public string Name { get; set; }
        public string MainImagePath { get; set; }
        public string MainImageTitle { get; set; }


        public string OpisPierwszy { get; set; }
        public List<string> Pochodzenie { get; set; }
        public List<string> Charakterystyka { get; set; }
        public List<string> Odzywianie { get; set; }
        public List<string> Akwarium { get; set; }
        public List<string> Rozmnazanie { get; set; }

        public List<string> Galeria { get; set; }

        public Rybka()
        {
            Galeria = new List<string>();
        }

        public void Wypisz()
        {
            Console.WriteLine("Nazwa:" + Name);
            Console.WriteLine("MainImagePath: " + MainImagePath);
            Console.WriteLine("MainImageTitle: " + MainImageTitle);
            Console.WriteLine("OpisPierwszy: " + OpisPierwszy);

            Console.WriteLine("Pochodzenie:");
            Pochodzenie.ForEach(Console.WriteLine);

            Console.WriteLine("Charakterystyka:");
            Charakterystyka.ForEach(Console.WriteLine);

            Console.WriteLine("Odżywianie:");
            Odzywianie.ForEach(Console.WriteLine);

            Console.WriteLine("Akwarium:");
            Akwarium.ForEach(Console.WriteLine);

            Console.WriteLine("Rozmnażanie:");
            Rozmnazanie.ForEach(Console.WriteLine);

            Console.WriteLine("Galeria:");
            Galeria.ForEach(Console.WriteLine);


            //Console.WriteLine("MainImagePath: " + MainImagePath);

        }
    }
}
