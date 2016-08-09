using System.Data.Common;
using MPD.Interviews.Interfaces.Logging;
using MPD.Interviews.Interfaces.Repositories;

namespace MPD.Interviews.Repository
{
    public abstract class BaseRepository
    {
        protected readonly IConnectionProvider ConnectionProvider;
        protected readonly ILogger Logger;

        protected BaseRepository(IConnectionProvider connectionProvider, ILogger logger)
        {
            ConnectionProvider = connectionProvider;
            Logger = logger;
        }

        protected DbConnection GetConnection()
        {
            return ConnectionProvider.GetOpenConnection();
        }
    }
}