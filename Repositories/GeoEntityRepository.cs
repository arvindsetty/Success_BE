using Dapper;
using Microsoft.Extensions.Configuration;
using MyApp.Interfaces;
using System.Data;
using System.Data.SqlClient;
using static Dapper.SqlMapper;

namespace MyApp.Repositories
{
    public class GeoEntityRepository : IGeoEntityRepository
    {
        private readonly IConfiguration _configuration;

        public GeoEntityRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task MergeCountyDetails(string counties)
        {
            using (IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                await connection.ExecuteAsync("MergeCountyData", new { CountyDataJson = counties}  ,commandType: CommandType.StoredProcedure);
            }
        }

        public async Task MergeStateDetails(string states)
        {
            using (IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                await connection.ExecuteAsync("MergeStateData", new { StateDataJson = states }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
