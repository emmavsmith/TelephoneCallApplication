using System.Data.SQLite;

namespace MPD.Interviews.Interfaces.Repositories
{
    public interface IConnectionProvider
    {
        SQLiteConnection GetOpenConnection();
    }
}