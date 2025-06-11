using System.ComponentModel.DataAnnotations;

namespace Microservices.DataAccess.Models
{
    public class Log
    {
        public long Id { get; set; }

        [MaxLength(1024)]
        public string? Message { get; set; }

        [MaxLength(2048)]
        public string? MessageTemplate { get; set; }

        public string? Level { get; set; }

        public DateTime RaiseDate { get; set; }

        public string? Exception { get; set; }

        public string? Properties { get; set; }

        public string? LogEvent { get; set; }
    }
}
