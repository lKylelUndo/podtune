class Podcast : AudioContent
{
    private int EpisodeNumber { get; set; }

    public Podcast(string title, string artist, double duration, int episode)
        : base(title, artist, duration)
    {
        EpisodeNumber = episode;
    }

    public override void Play()
    {
        Console.WriteLine("Playing Podcast:");
        Console.WriteLine(GetInfo() + $", Episode: {EpisodeNumber}\n");
    }

    public override string GetInfo()
    {
        return base.GetInfo() + $" | Episode {EpisodeNumber}";
    }
}
