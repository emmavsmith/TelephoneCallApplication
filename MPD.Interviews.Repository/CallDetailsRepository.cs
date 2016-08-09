using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using MPD.Interviews.Domain;
using MPD.Interviews.Interfaces.Logging;
using MPD.Interviews.Interfaces.Repositories;

namespace MPD.Interviews.Repository
{
    public class CallDetailsRepository : BaseRepository, IRepository<CallDetails>, ICallDetailsSearchRepository
    {
        public CallDetailsRepository(IConnectionProvider connectionProvider, ILogger logger) : base(connectionProvider, logger) { }

        public bool Save(CallDetails entity)
        {
            using (var conn = GetConnection())
            {
                const string SQL = "INSERT INTO CallDetails (UserId, PhoneNumber, CustomLabel, Duration, Date) VALUES (@userId, @phoneNumber, @customLabel, @duration, @date);";
                try
                {
                    var parameters = new
                    {
                        userId = entity.UserId,
                        phoneNumber = entity.PhoneNumber,
                        customLabel = entity.CustomLabel,
                        duration = entity.Duration,
                        date = entity.Date
                    };
                    conn.Execute(SQL, parameters);
                    return true;
                }
                catch (Exception ex)
                {
                    Logger.Error($"Error inserting new CallDetails entity. Error: {ex.Message}", ex);
                    return false;
                }
            }
        }

        public bool Delete(CallDetails entity)
        {
            using (var conn = GetConnection())
            {
                try
                {
                    const string SQL = "DELETE FROM CallDetails WHERE id = @id;";
                    var parameters = new {id = entity.Id};
                    conn.Execute(SQL, parameters);
                    return true;
                }
                catch (Exception ex)
                {
                    Logger.Error($"Error deleting entity '{entity.Id}'. Error: {ex.Message}", ex);
                    return false;
                }
            }
        }

        public CallDetails Get(object id)
        {
            using (var conn = GetConnection())
            {
                const string SQL = "SELECT Id, UserId, PhoneNumber, CustomLabel, Duration, Date FROM CallDetails WHERE Id = @id;";
                var result = conn.Query<CallDetails>(SQL, new {id = id});
                return result.FirstOrDefault();
            }
        }

        public IEnumerable<CallDetails> GetAll()
        {
            using (var conn = GetConnection())
            {
                const string SQL = "SELECT Id, UserId, PhoneNumber, CustomLabel, Duration, Date FROM CallDetails;";
                var result = conn.Query<CallDetails>(SQL);
                return result.ToList();
            }
        }

        public bool Update(CallDetails entity)
        {
            using (var conn = GetConnection())
            {
                const string SQL =
                    "Update CallDetails SET UserId=@userId, PhoneNumber=@phoneNumber, CustomLabel=@customLabel, Duration=@duration, Date=@date WHERE id = @id";
                try
                {
                    var parameters = new
                    {
                        userId = entity.UserId,
                        phoneNumber = entity.PhoneNumber,
                        customLabel = entity.CustomLabel,
                        duration = entity.Duration,
                        date = entity.Date,
                        id = entity.Id
                    };

                    conn.Execute(SQL, parameters);
                    return true;
                }
                catch (Exception ex)
                {
                    Logger.Error($"Error updating CallDetails with id: '{entity.Id}'. Error: {ex.Message}", ex);
                    return false;
                }
            }
        }

        public IEnumerable<CallDetails> CallDetailsSearch(CallSearchTerms searchTerms)
        {
            throw new NotImplementedException("See task 4");
        }

        private string ApplySearchTerms(string sql, CallSearchTerms searchTerms)
        {
            throw new NotImplementedException("See task 4");
        }

        private bool HasAnySearchTerm(CallSearchTerms searchTerms)
        {
            return !string.IsNullOrEmpty(searchTerms.CustomLabel)
                   || searchTerms.EndDate.HasValue
                   || searchTerms.StartDate.HasValue
                   || !string.IsNullOrEmpty(searchTerms.PhoneNumber)
                   || searchTerms.UserId.HasValue;
        }
    }
}