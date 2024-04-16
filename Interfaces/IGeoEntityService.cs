namespace MyApp.Interfaces
{
    public interface IGeoEntityService
    {
        /// <summary>
        /// Method to get the state details
        /// </summary>
        /// <returns></returns>
        Task MergeStateDetails();
        /// <summary>
        /// Method to get the county details
        /// </summary>
        /// <returns></returns>
        Task MergeCountyDetails();
    }
}
