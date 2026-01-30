using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace EduTrack.EntityFrameworkCore;

public static class EduTrackDbContextConfigurer
{
    public static void Configure(DbContextOptionsBuilder<EduTrackDbContext> builder, string connectionString)
    {
        builder.UseSqlServer(connectionString);
    }

    public static void Configure(DbContextOptionsBuilder<EduTrackDbContext> builder, DbConnection connection)
    {
        builder.UseSqlServer(connection);
    }
}
