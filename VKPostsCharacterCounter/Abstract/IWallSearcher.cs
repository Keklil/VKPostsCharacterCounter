namespace VKPostsCharacterCounter.Abstract
{
    public interface IWallSearcher
    {
        Task<List<string>> Search();
    }
}
