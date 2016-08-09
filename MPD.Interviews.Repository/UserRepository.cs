using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using MPD.Interviews.Domain;
using MPD.Interviews.Interfaces.Logging;
using MPD.Interviews.Interfaces.Repositories;

namespace MPD.Interviews.Repository
{
    public class UserRepository : BaseRepository, IRepository<User>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="connectionProvider">The connection provider.</param>
        /// <param name="logger">The logger.</param>
        public UserRepository(IConnectionProvider connectionProvider, ILogger logger) : base(connectionProvider, logger)
        {
        }


        /// <summary>
        /// Save the entity
        /// </summary>
        /// <param name="entity">The entity to save</param>
        /// <returns></returns>
        public bool Save(User entity)
        {
            using (var conn = GetConnection())
            {
                const string SQL =
                    "INSERT INTO Users (Forename, Surname, Position) VALUES (@forename, @surname, @position);";
                var parameters = new
                {
                    forename = entity.Forename,
                    surname = entity.Surname,
                    position = entity.Position
                };

                try
                {
                    conn.Execute(SQL, parameters);
                    return true;
                }
                catch (Exception ex)
                {
                    Logger.Error($"Error adding new user {entity.Forename} {entity.Surname}. Error: {ex.Message}", ex);
                    return false;
                }
            }
        }


        /// <summary>
        /// Delete the specified User
        /// </summary>
        /// <param name="entity">The entity to delete</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException">Users cannot currently be deleted.</exception>
        public bool Delete(User entity)
        {
            throw new NotImplementedException("Users cannot currently be deleted.");
        }


        /// <summary>
        /// Get the User with the specified id
        /// </summary>
        /// <param name="id">The id of the object to retrieve</param>
        /// <returns>
        /// <see cref="User"></see>
        /// </returns>
        public User Get(object id)
        {
            using (var conn = GetConnection())
            {
                const string SQL = "SELECT Id, Forename, Surname, Position FROM Users WHERE id = @id";
                var parameters = new {id = id};

                try
                {
                    var users = conn.Query<User>(SQL, parameters);
                    return users.FirstOrDefault();
                }
                catch (Exception ex)
                {
                    Logger.Error($"Error retrieving user (id: '{id}'). Error: {ex.Message}", ex);
                    return null;
                }
            }
        }


        /// <summary>
        /// Get all the objects
        /// </summary>
        /// <returns>
        /// <see cref="IEnumerable{User}"/>
        /// </returns>
        public IEnumerable<User> GetAll()
        {
            using (var conn = GetConnection())
            {
                const string SQL = "SELECT Id, Forename, Surname, Position FROM Users;";

                try
                {
                    var users = conn.Query<User>(SQL);
                    return users;
                }
                catch (Exception ex)
                {
                    Logger.Error($"Error retrieving users. Error: {ex.Message}", ex);
                    return null;
                }
            }
        }


        /// <summary>
        /// Update the specified entity
        /// </summary>
        /// <param name="entity">The entity to update</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException">It is not currently possible to update users.</exception>
        public bool Update(User entity)
        {
            throw new NotImplementedException("It is not currently possible to update users.");
        }
    }
}
