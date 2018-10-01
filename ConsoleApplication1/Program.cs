using System;
using System.Collections.Generic;
using ConsoleApplication1;
using HtmlAgilityPack;


public class Program
{
    public static void Main()
    {
        HtmlNode node;
        List<string> alfabet = new List<string>();
        List<string> rybkiNaLitere = new List<string>();


        string url;


        var html = @"https://rybyakwariowe.eu/spis-alfabetyczny/?na-litere=A";
        HtmlWeb web = new HtmlWeb();
        var htmlDoc = web.Load(html);

        Rybka rybka = new Rybka();




        //spis rybek - ALFABET, pobranie href do konkretnej literki
        /*
        node = htmlDoc.DocumentNode.SelectSingleNode("//*[@class=\"spis-a-z-navigation pagination\"]");
        HtmlNodeCollection childNodes = node.ChildNodes;
        foreach (var node1 in childNodes)
        {
            if (node1.NodeType == HtmlNodeType.Element)
            {
                Console.WriteLine(node1.OuterHtml);
                Console.WriteLine(node1.GetAttributeValue("href", string.Empty));
                alfabet.Add(node1.GetAttributeValue("href", string.Empty));
                //Console.WriteLine(node1.InnerText);
            }
        }
        */


        //spis rybek na konkretną literkę
        /*
        url = "https://rybyakwariowe.eu/spis-alfabetyczny/?na-litere=A";
        htmlDoc = web.Load(s);

        var nodes = htmlDoc.DocumentNode.SelectNodes("//*[@class=\"na-litere\"]");

        rybkiNaLitere.Clear();

        foreach (var node1 in nodes)
        {

            if (node1.NodeType == HtmlNodeType.Element)
            {
                Console.WriteLine("https://rybyakwariowe.eu" + node1.ChildNodes[0].GetAttributeValue("href", string.Empty));
                rybkiNaLitere.Add("https://rybyakwariowe.eu" + node1.ChildNodes[0].GetAttributeValue("href", string.Empty));
            }
        }
        */

        //szczegóły rybki
        url = " https://rybyakwariowe.eu/ryba-akwariowa/ameka-wspaniala-ameca-splendens/";
        htmlDoc = web.Load(url);

        //Nazwa rybki
        node = htmlDoc.DocumentNode.SelectSingleNode("//*[@class=\"entry-title single-title\"]");
        rybka.Name = node.InnerText;


        //główny obrazek
        var imageNode = htmlDoc.DocumentNode.SelectSingleNode("//*[@class=\"feature-img\"]");
        rybka.MainImagePath = imageNode.ChildNodes[0].ChildNodes[0].Attributes["src"].Value;
        rybka.MainImageTitle = imageNode.ChildNodes[0].Attributes["title"].Value;

        //szczegóły o rybce
        node = htmlDoc.DocumentNode.SelectSingleNode("//*[@class=\"entry-content clearfix\"]");

        rybka.OpisPierwszy = node.ChildNodes[1].InnerText;

        List<string> text = new List<string>();
        for (int i = 2; i < node.ChildNodes.Count; i++)
        {
            //Console.WriteLine(i);

            switch (node.ChildNodes[i].GetAttributeValue("class", string.Empty))
            {
                case "vanished":
                case "report-spelling":
                case "sense-ryba-bottom":
                case "embed-container":
                case "vish":
                    break;

                case "ryby-first":
                    //Console.WriteLine("Pochodzenie:");
                    text.Clear();
                    break;
                case "ryby-second":
                    //Console.WriteLine("Charakterystyka:");
                    rybka.Pochodzenie = text;
                    text.Clear();
                    break;
                case "ryby-third":
                    //Console.WriteLine("Odżywianie:");
                    rybka.Charakterystyka = text;
                    text.Clear();
                    break;
                case "ryby-four":
                    //Console.WriteLine("Akwarium:");
                    rybka.Odzywianie = text;
                    text.Clear();
                    break;
                case "ryby-five":
                    //Console.WriteLine("Rozmnażanie:");
                    rybka.Akwarium = text;
                    text.Clear();
                    break;

                case "galleryoview":
                    //Console.WriteLine("Galeria:");
                    rybka.Rozmnazanie = text;
                    rybka.Galeria.Clear();
                    foreach (HtmlNode link in node.ChildNodes[i].ChildNodes)
                    {
                        if (link.ChildNodes.Count > 0)
                        {
                            //Console.WriteLine(link.ChildNodes[0].ChildNodes[1].GetAttributeValue("href", string.Empty));
                            rybka.Galeria.Add(link.ChildNodes[0].ChildNodes[1].GetAttributeValue("href", string.Empty));
                        }
                    }
                    break;

                default:
                    if (node.ChildNodes[i].GetAttributeValue("id", string.Empty) == "summary")
                    {
                        Console.WriteLine("Default: !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");

                        foreach(var wym in node.ChildNodes[i].ChildNodes)
                        {
                            foreach (var w in wym.ChildNodes)
                            {
                                Console.WriteLine(w.InnerText);
                            }
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        if ((node.ChildNodes[i].InnerText != "") && (node.ChildNodes[i].InnerText != "Video") && (node.ChildNodes[i].InnerText != "Galeria"))
                        {
                            //Console.WriteLine("Default: " + node.ChildNodes[i].InnerText);
                            text.Add(node.ChildNodes[i].InnerText);
                        }
                    }
                    break;
            }
        }
        //var plainText = ConvertToPlainText(string html);

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        rybka.Wypisz();
        Console.ReadKey();

    }
}
