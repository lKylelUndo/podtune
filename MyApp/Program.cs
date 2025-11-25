
abstract class AudioContent
{

    protected string Title { get; set; }
    protected string Artist { get; set; }
    protected double Duration { get; set; }


    public AudioContent(string title, string artist, double duration)
    {
        Title = title;
        Artist = artist;
        Duration = duration;
    }


    public abstract void Play();
}

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
        Console.WriteLine($"Title: {Title}, Artist: {Artist}, Genre: {Genre}, Duration: {Duration} min\n");
    }
}



class Podcast : AudioContent
{

    private int EpisodeNumber { get; set; }


    public Podcast(string title, string artist, double duration, int episodeNumber)
        : base(title, artist, duration)
    {
        EpisodeNumber = episodeNumber;
    }


    public override void Play()
    {
        Console.WriteLine("Playing Podcast:");
        Console.WriteLine($"Title: {Title}, Artist: {Artist}, Episode: {EpisodeNumber}, Duration: {Duration} min\n");
    }
}



class MediaPlayer
{
    static void Main(string[] args)
    {

        AudioContent[] playlist = new AudioContent[]
        {
            new Song("Halo", "Beyoncé", 3.5, "Pop"),
            new Podcast("Learning C#", "DevTalk", 20.0, 5)
        };

        foreach (AudioContent item in playlist)
        {
            item.Play();
        }

        Console.WriteLine("All media played.");
    }
}
