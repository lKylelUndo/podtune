class MediaPlayer
{
    static void Main(string[] args)
    {
        PlaylistManager manager = new PlaylistManager();

        // Register event
        manager.OnMediaAdded += (item) =>
        {
            Console.WriteLine($"[EVENT] Added: {item.GetInfo()}");
        };

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n=== MEDIA PLAYER MENU ===");
            Console.WriteLine("1. Add Song");
            Console.WriteLine("2. Add Podcast");
            Console.WriteLine("3. Play All");
            Console.WriteLine("4. Save to File");
            Console.WriteLine("5. Load from File");
            Console.WriteLine("6. Exit");
            Console.Write("Choose option: ");

            try
            {
                int choice = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (choice)
                {
                    case 1:
                        AddSong(manager);
                        break;

                    case 2:
                        AddPodcast(manager);
                        break;

                    case 3:
                        manager.PlayAll();
                        break;

                    case 4:
                        manager.SaveToFile();
                        Console.WriteLine("Saved to playlist.txt");
                        break;

                    case 5:
                        manager.LoadFromFile("playlist.txt");
                        break;

                    case 6:
                        Console.Clear();
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        Console.WriteLine("Exiting Media Player...");
    }

    static void AddSong(PlaylistManager manager)
    {
        Console.Write("Song Title: ");
        string title = Console.ReadLine();

        Console.Write("Artist: ");
        string artist = Console.ReadLine();

        Console.Write("Duration (min): ");
        double duration = double.Parse(Console.ReadLine());

        Console.Write("Genre: ");
        string genre = Console.ReadLine();

        manager.AddMedia(new Song(title, artist, duration, genre));
    }

    static void AddPodcast(PlaylistManager manager)
    {
        Console.Write("Podcast Title: ");
        string title = Console.ReadLine();

        Console.Write("Host: ");
        string artist = Console.ReadLine();

        Console.Write("Duration (min): ");
        double duration = double.Parse(Console.ReadLine());

        Console.Write("Episode #: ");
        int episode = int.Parse(Console.ReadLine());

        manager.AddMedia(new Podcast(title, artist, duration, episode));
    }
}
