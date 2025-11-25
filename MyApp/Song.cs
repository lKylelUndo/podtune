class Song : AudioContent
{
    private string Genre { get; set; }

    public Song(string title, string artist, double duration, string genre)
        : base(title, artist, duration)
    {
        Genre = genre;
    }

    public override void Play()
    {
        Console.WriteLine("Playing Song:");
        Console.WriteLine(GetInfo() + $", Genre: {Genre}\n");
    }

    public override string GetInfo()
    {
        return base.GetInfo() + $" | Genre: {Genre}";
    }
}
