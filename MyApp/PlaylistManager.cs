using System;
using System.Collections.Generic;
using System.IO;

// Delegate
public delegate void MediaAddedHandler(AudioContent item);

class PlaylistManager
{
    public event MediaAddedHandler OnMediaAdded;

    // Using Generics & Collections
    private List<AudioContent> playlist = new List<AudioContent>();

    public void AddMedia(AudioContent item)
    {
        Console.Clear();
        playlist.Add(item);
        OnMediaAdded?.Invoke(item); // Event Trigger
    }

    public void PlayAll()
    {
        Console.Clear();
        playlist.ForEach(item => item.Play()); // Lambda Expression
    }

    public void SaveToFile()
    {
        using StreamWriter writer = new StreamWriter("playlist.txt");

        foreach (var item in playlist)
        {
            writer.WriteLine(item.GetInfo());
        }
    }

    public void LoadFromFile(string path)
    {
        if (!File.Exists(path))
            throw new FileNotFoundException("Playlist file not found.");

        Console.WriteLine("\nLoading playlist from file...");

        foreach (var line in File.ReadLines(path))
        {
            Console.WriteLine(line);
        }
    }
}
