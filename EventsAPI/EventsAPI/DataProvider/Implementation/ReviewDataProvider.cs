using EventsAPI.DataProvider.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
using EventsAPI.Models;
using System.Data.SqlClient;
using Dapper;
using System;
using Microsoft.Extensions.Options;

namespace EventsAPI.DataProvider.Implementation
{
    public class ReviewDataProvider : IReviewDataProvider
    {
        private readonly ConnectionStrings _connectionStrings;
        public ReviewDataProvider(IOptions<ConnectionStrings> options)
        {
            _connectionStrings = options.Value;

        }

        private SqlConnection GetConnection()
        {
            string connectionString = _connectionStrings.DefaultConnection;
            return new SqlConnection(connectionString);            
        }

        public async Task AddReview(ReviewModel review)
        {
            try
            {

                using (var sqlConnection = GetConnection())
                {
                    await sqlConnection.OpenAsync();
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@name", review.Name);
                    await sqlConnection.ExecuteAsync("AddReview", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteReview(int id)
        {
            try
            {
                using (var sqlConnection = GetConnection())
                {
                    await sqlConnection.OpenAsync();
                    var dynamicParamperts = new DynamicParameters();
                    dynamicParamperts.Add("@id", id);
                    await sqlConnection.ExecuteAsync("DeleteReview", dynamicParamperts, commandType: System.Data.CommandType.StoredProcedure);
                }
            } 
            catch(Exception ex)
            {
                throw ex;
            }
}

        public async Task<ReviewModel> GetReview(int id)
        {
            try
            {
                using (var sqlConnection = GetConnection())
                {
                    await sqlConnection.OpenAsync();
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@id", id);
                    return await sqlConnection.QuerySingleOrDefaultAsync<ReviewModel>("GetReview", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        public async Task<IEnumerable<ReviewModel>> GetReviews()
        {
            try
            {
                using (var sqlConnection = GetConnection())
                {
                    await sqlConnection.OpenAsync();
                    return await sqlConnection.QueryAsync<ReviewModel>("GetReviews", null, commandType: System.Data.CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        public async Task UpdateReview(ReviewModel review)
        {
            try
            {
                using (var sqlConnection = GetConnection())
                {
                    await sqlConnection.OpenAsync();
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@id", review.Id);
                    dynamicParameters.Add("@name", review.Name);
                    await sqlConnection.ExecuteAsync("UpdateReview", dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
