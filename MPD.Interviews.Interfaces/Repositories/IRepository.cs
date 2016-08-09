using System.Collections.Generic;

namespace MPD.Interviews.Interfaces.Repositories
{
    /// <summary>
    /// Default repository interface
    /// </summary>
    /// <typeparam name="T">The type of object for this repository</typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Save the entity
        /// </summary>
        /// <param name="entity">The entity to save</param>
        bool Save(T entity);

        /// <summary>
        /// Delete the specified entity
        /// </summary>
        /// <param name="entity">The entity to delete</param>
        bool Delete(T entity);

        /// <summary>
        /// Get the object with the specified id
        /// </summary>
        /// <param name="id">The id of the object to retrieve</param>
        /// <returns>T</returns>
        T Get(object id);

        /// <summary>
        /// Get all the objects
        /// </summary>
        /// <returns><see cref="IEnumerable{T}"/></returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Update the specified entity
        /// </summary>
        /// <param name="entity">The entity to update</param>
        bool Update(T entity);
    }
}