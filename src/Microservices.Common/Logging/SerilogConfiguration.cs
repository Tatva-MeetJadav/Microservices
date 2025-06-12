using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Sinks.PostgreSQL;

namespace Microservices.Common.Logging
{
    public static class SerilogConfiguration
    {
        public static void ConfigureSerilog(IConfiguration configuration)
        {
            Dictionary<string,ColumnWriterBase> columnWriters = new Dictionary<string, ColumnWriterBase>
            {
                { "Message", new RenderedMessageColumnWriter() },
                { "MessageTemplate", new MessageTemplateColumnWriter() },
                { "Level", new LevelColumnWriter() },
                { "RaiseDate", new TimestampColumnWriter() },
                { "Exception", new ExceptionColumnWriter() },
                { "Properties", new LogEventSerializedColumnWriter() },
                { "PropsTest", new SinglePropertyColumnWriter("PropsTest") },
                { "MachineName", new SinglePropertyColumnWriter("MachineName") } 
            };

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .WriteTo.PostgreSQL(
                    connectionString: configuration.GetConnectionString("DefaultConnection"),
                    tableName: "logs",
                    columnOptions: columnWriters,
                    needAutoCreateTable: false
                )
                .Enrich.FromLogContext()
                .Enrich.WithMachineName()
                .CreateLogger();
        }
    }
}