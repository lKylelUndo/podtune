using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

    // Display all songs with a number (1, 2, 3, ...)
    public void ShowSongs()
    {
        Console.Clear();

        var songs = playlist
            .Select((item, index) => new { item, index })
            .Where(x => x.item is Song)
            .ToList();

        if (songs.Count == 0)
        {
            Console.WriteLine("No songs in the playlist.");
            return;
        }

        Console.WriteLine("=== SONGS IN PLAYLIST ===");
        foreach (var entry in songs)
        {
            int number = entry.index + 1;
            Console.WriteLine($"{number}. {entry.item.GetInfo()}");
        }
    }

    // Display all podcasts with a number (1, 2, 3, ...)
    public void ShowPodcasts()
    {
        Console.Clear();

        var podcasts = playlist
            .Select((item, index) => new { item, index })
            .Where(x => x.item is Podcast)
            .ToList();

        if (podcasts.Count == 0)
        {
            Console.WriteLine("No podcasts in the playlist.");
            return;
        }

        Console.WriteLine("=== PODCASTS IN PLAYLIST ===");
        foreach (var entry in podcasts)
        {
            int number = entry.index + 1;
            Console.WriteLine($"{number}. {entry.item.GetInfo()}");
        }
    }

    // Delete a song based on the displayed number
    public bool DeleteSongByNumber(int number)
    {
        // Convert the 1-based displayed number back to index
        int targetIndex = number - 1;

        if (targetIndex < 0 || targetIndex >= playlist.Count)
            return false;

        if (playlist[targetIndex] is Song)
        {
            playlist.RemoveAt(targetIndex);
            return true;
        }

        return false;
    }

    // Delete a podcast based on the displayed number
    public bool DeletePodcastByNumber(int number)
    {
        int targetIndex = number - 1;

        if (targetIndex < 0 || targetIndex >= playlist.Count)
            return false;

        if (playlist[targetIndex] is Podcast)
        {
            playlist.RemoveAt(targetIndex);
            return true;
        }

        return false;
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

    public void LoadFromFile(string path = "playlist.txt")
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
