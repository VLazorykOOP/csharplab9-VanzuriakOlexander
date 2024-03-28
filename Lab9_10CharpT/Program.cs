using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

class Song
{
    public string Title { get; set; }
    public string Artist { get; set; }

    public Song(string title, string artist)
    {
        Title = title;
        Artist = artist;
    }

    public override string ToString()
    {
        return $"{Title} - {Artist}";
    }
}

class MusicDisk
{
    public string Title { get; set; }
    public List<Song> Songs { get; private set; }

    public MusicDisk(string title)
    {
        Title = title;
        Songs = new List<Song>();
    }

    public void AddSong(Song song)
    {
        Songs.Add(song);
    }

    public void RemoveSong(Song song)
    {
        Songs.Remove(song);
    }

    public override string ToString()
    {
        string result = $"Music Disk: {Title}\n";
        result += "Songs:\n";
        foreach (var song in Songs)
        {
            result += $"- {song}\n";
        }
        return result;
    }
}

class MusicDiskCatalog
{
    private Hashtable catalog;

    public MusicDiskCatalog()
    {
        catalog = new Hashtable();
    }

    public void AddDisk(string key, MusicDisk disk)
    {
        catalog.Add(key, disk);
    }

    public void RemoveDisk(string key)
    {
        catalog.Remove(key);
    }

    public MusicDisk GetDisk(string key)
    {
        return (MusicDisk)catalog[key];
    }

    public void ViewCatalog()
    {
        foreach (DictionaryEntry entry in catalog)
        {
            Console.WriteLine($"Key: {entry.Key}, Disk: {entry.Value}");
        }
    }

    public void ViewDisk(string key)
    {
        MusicDisk disk = GetDisk(key);
        Console.WriteLine(disk);
    }

    public List<Song> SearchArtist(string artist)
    {
        List<Song> result = new List<Song>();

        foreach (DictionaryEntry entry in catalog)
        {
            MusicDisk disk = (MusicDisk)entry.Value;
            foreach (var song in disk.Songs)
            {
                if (song.Artist.Equals(artist, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(song);
                }
            }
        }

        return result;
    }
}

class Program
{
    static void PrintVowelsInReverseOrder(string filePath)
    {
        HashSet<char> vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u', 'y', 'A', 'E', 'I', 'O', 'U', 'Y' };

        Stack<char> vowelStack = new Stack<char>();

        string text = File.ReadAllText(filePath);

        foreach (char c in text)
        {
            if (vowels.Contains(c))
            {
                vowelStack.Push(c);
            }
        }

        Console.WriteLine("Vowels in reverse order:");
        while (vowelStack.Count > 0)
        {
            Console.Write(vowelStack.Pop());
        }
    }
    static void PrintNumbersInOrder(string filePath, int a, int b)
    {
        Queue<int> numbersInRange = new Queue<int>();
        Queue<int> numbersLessThanA = new Queue<int>();
        Queue<int> numbersGreaterThanB = new Queue<int>();

        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            string[] tokens = line.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string token in tokens)
            {
                if (int.TryParse(token, out int number))
                {
                    if (number >= a && number <= b)
                    {
                        numbersInRange.Enqueue(number);
                    }
                    else if (number < a)
                    {
                        numbersLessThanA.Enqueue(number);
                    }
                    else if (number > b)
                    {
                        numbersGreaterThanB.Enqueue(number);
                    }
                }
            }
        }

        Console.WriteLine("Numbers in the specified order:");

        Console.WriteLine($"Numbers in the range [{a},{b}]:");
        while (numbersInRange.Count > 0)
        {
            Console.WriteLine(numbersInRange.Dequeue());
        }

        Console.WriteLine($"Numbers less than {a}:");
        while (numbersLessThanA.Count > 0)
        {
            Console.WriteLine(numbersLessThanA.Dequeue());
        }

        Console.WriteLine($"Numbers greater than {b}:");
        while (numbersGreaterThanB.Count > 0)
        {
            Console.WriteLine(numbersGreaterThanB.Dequeue());
        }
    }

    static void PrintNumbersInOrderNew(IEnumerable collection, int a, int b)
    {
        Console.WriteLine($"Numbers in the range [{a},{b}]:");
        foreach (int num in collection)
        {
            if (num >= a && num <= b)
                Console.WriteLine(num);
        }

        Console.WriteLine($"Numbers less than {a}:");
        foreach (int num in collection)
        {
            if (num < a)
                Console.WriteLine(num);
        }

        Console.WriteLine($"Numbers greater than {b}:");
        foreach (int num in collection)
        {
            if (num > b)
                Console.WriteLine(num);
        }
    }

    static void PrintVowelsInReverseOrderNew(IEnumerable collection)
    {
        HashSet<char> vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u', 'y', 'A', 'E', 'I', 'O', 'U', 'Y' };

        Stack<char> vowelsStack = new Stack<char>();

        foreach (char ch in collection)
        {
            if (vowels.Contains(ch))
            {
                vowelsStack.Push(ch);
            }
        }

        Console.WriteLine("Vowels in reverse order:");
        while (vowelsStack.Count > 0)
        {
            Console.Write(vowelsStack.Pop());
        }
    }

    static void Main()
    {
        Console.WriteLine("Enter the task");
        string? str = Console.ReadLine();
        int n = 0;
        if (str != null) n = int.Parse(str);
        if (n == 1)
        {
            string inputFilePath = "task1.txt";

            PrintVowelsInReverseOrder(inputFilePath);
        }
        else if (n == 2)
        {
            string readFile = "task2.txt";

            int a = 10;
            int b = 20;

            PrintNumbersInOrder(readFile, a, b);
        }
        else if (n == 3)
        {
            Queue numbersQueue = new Queue();
            numbersQueue.Enqueue(10);
            numbersQueue.Enqueue(5);
            numbersQueue.Enqueue(7);
            numbersQueue.Enqueue(13);
            numbersQueue.Enqueue(2);
            numbersQueue.Enqueue(8);

            int a = 5;
            int b = 10;

            PrintNumbersInOrderNew(numbersQueue, a, b);
            Queue<char> charactersQueue = new Queue<char>();
            string text = "apple monkey hello world";

            foreach (char ch in text)
            {
                charactersQueue.Enqueue(ch);
            }

            PrintVowelsInReverseOrderNew(charactersQueue);
        }
        else if (n == 4)
        {
            MusicDiskCatalog catalog = new MusicDiskCatalog();

            MusicDisk disk1 = new MusicDisk("Disk 1");
            disk1.AddSong(new Song("Song 1", "Artist 1"));
            disk1.AddSong(new Song("Song 2", "Artist 2"));
            catalog.AddDisk("Key 1", disk1);

            MusicDisk disk2 = new MusicDisk("Disk 2");
            disk2.AddSong(new Song("Song 3", "Artist 1"));
            disk2.AddSong(new Song("Song 4", "Artist 3"));
            catalog.AddDisk("Key 2", disk2);

            Console.WriteLine("Catalog:");
            catalog.ViewCatalog();

            Console.WriteLine("\nViewing Disk:");
            catalog.ViewDisk("Key 1");

            Console.WriteLine("\nSongs by Artist 1:");
            List<Song> songsByArtist = catalog.SearchArtist("Artist 1");
            foreach (var song in songsByArtist)
            {
                Console.WriteLine(song);
            }
        }
    }
}
