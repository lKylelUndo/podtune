
public abstract partial class AudioContent
{
    public virtual string GetInfo()
    {
        return $"{Title} by {Artist} - {Duration} min";
    }
}
