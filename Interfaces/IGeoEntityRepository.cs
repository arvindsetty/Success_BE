namespace MyApp.Interfaces
{
    public interface IGeoEntityRepository
    {
        /// <summary>
        /// Get the state details
        /// </summary>
        /// <returns></returns>
        Task MergeStateDetails(string states);
        /// <summary>
        /// Get the county details
        /// </summary>
        /// <returns></returns>
        Task MergeCountyDetails(string counties);
    }
}
