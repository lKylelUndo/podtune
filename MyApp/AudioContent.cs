public abstract partial class AudioContent
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
