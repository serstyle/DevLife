namespace DevLifeApi.Models
{
    public interface IVote
    {
        string Id { get; set; }
        string StoryId { get; set; }
        int UpDown { get; set; }
    }
}