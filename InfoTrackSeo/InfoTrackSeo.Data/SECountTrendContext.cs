using InfoTrackSeo.Common.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTrackSeo.Data
{
    public sealed class SECountTrendContext : DbContext
    {
        public SECountTrendContext(DbContextOptions<SECountTrendContext> options) : base(options) { }

        public DbSet<DbSearchEngineCountTrend> SearchEngineCountTrends { get; set; }
    }
}
