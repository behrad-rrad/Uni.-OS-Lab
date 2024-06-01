using System;
using System.Net;
using System.Threading;

class Program
{
    public static void Main(string[] args)
    {
        string dir = "C:\\Users\\behra\\Downloads\\Download here";
        string[] downloadLinks = new string[]
                {
                    "https://irsv.upmusics.com/AliBZ/Zang%20Bzn%20Ambulaance%20(320).mp3",
                    "https://upera.uptv.ir/?f=2974938-0-480.mp4?ref=7xk"

                };


        foreach (string url in downloadLinks)
        {
            string fileName = GetFileNameFromUrl(url);
            DownloadFile(url, dir + "\\" + fileName);
        }
        Console.ReadLine();
    }

    public static string[] GetUrls(int counter)
    {
        string[] urls = new string[counter];
        for (int i = 0; i < counter; i++)
        {
            Console.WriteLine($"URL {i + 1}: ");
            urls[i] = Console.ReadLine();
            Console.Clear();
        }
        Console.Clear();
        return urls;
    }

    public static void DownloadFile(string url, string fileName)
    {
        Thread thread = new Thread(() => DownloadProcess(url, fileName));
        thread.Start();
    }

    public static void DownloadProcess(string url, string fileName)
    {
        try
        {
            using (var client = new WebClient())
            {
                client.DownloadFile(new Uri(url), fileName);
                client.DownloadProgressChanged += (sender, e) =>
                {
                    Console.WriteLine(e.ProgressPercentage);
                };
            }
            Console.WriteLine($"Download of '{fileName}' completed!");

        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred for '{url}'! Error message: {e.Message}");
        }
    }


    public static string GetFileNameFromUrl(string url)
    {
        Uri uri = new Uri(url);
        string fileName = System.IO.Path.GetFileName(uri.LocalPath);
        return fileName;
    }
}