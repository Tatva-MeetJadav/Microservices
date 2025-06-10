using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Microservices.BusinessLogic.Dto
{
    public class EmailVerificationDto
    {
        [JsonProperty("valid")]
        public bool Valid { get; set; }

        [JsonProperty("timed_out")]
        public bool TimedOut { get; set; }

        [JsonProperty("disposable")]
        public bool Disposable { get; set; }

        [JsonProperty("first_name")]
        public string? FirstName { get; set; }

        [JsonProperty("deliverability")]
        public string? Deliverability { get; set; }

        [JsonProperty("smtp_score")]
        public int SmtpScore { get; set; }

        [JsonProperty("overall_score")]
        public int OverallScore { get; set; }

        [JsonProperty("catch_all")]
        public bool CatchAll { get; set; }

        [JsonProperty("generic")]
        public bool Generic { get; set; }

        [JsonProperty("common")]
        public bool Common { get; set; }

        [JsonProperty("dns_valid")]
        public bool DnsValid { get; set; }

        [JsonProperty("honeypot")]
        public bool Honeypot { get; set; }

        [JsonProperty("frequent_complainer")]
        public bool FrequentComplainer { get; set; }

        [JsonProperty("suspect")]
        public bool Suspect { get; set; }

        [JsonProperty("recent_abuse")]
        public bool RecentAbuse { get; set; }

        [JsonProperty("fraud_score")]
        public int FraudScore { get; set; }

        [JsonProperty("leaked")]
        public bool Leaked { get; set; }

        [JsonProperty("suggested_domain")]
        public string? SuggestedDomain { get; set; }

        [JsonProperty("domain_velocity")]
        public string? DomainVelocity { get; set; }

        [JsonProperty("domain_trust")]
        public string? DomainTrust { get; set; }

        [JsonProperty("user_activity")]
        public string? UserActivity { get; set; }

        [JsonProperty("associated_names")]
        public AssociatedNamesDto? AssociatedNames { get; set; }

        [JsonProperty("associated_phone_numbers")]
        public AssociatedPhoneNumbersDto? AssociatedPhoneNumbers { get; set; }

        [JsonProperty("first_seen")]
        public TimeInfoDto? FirstSeen { get; set; }

        [JsonProperty("domain_age")]
        public TimeInfoDto? DomainAge { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("spam_trap_score")]
        public string? SpamTrapScore { get; set; }

        [JsonProperty("risky_tld")]
        public bool RiskyTld { get; set; }

        [JsonProperty("spf_record")]
        public bool SpfRecord { get; set; }

        [JsonProperty("dmarc_record")]
        public bool DmarcRecord { get; set; }

        [JsonProperty("sanitized_email")]
        public string? SanitizedEmail { get; set; }

        [JsonProperty("mx_records")]
        public List<string>? MxRecords { get; set; }

        [JsonProperty("request_id")]
        public string? RequestId { get; set; }

        [JsonProperty("a_records")]
        public List<string>? ARecords { get; set; }
    }

    public class AssociatedNamesDto
    {
        [JsonProperty("status")]
        public string? Status { get; set; }

        [JsonProperty("names")]
        public List<string>? Names { get; set; }
    }

    public class AssociatedPhoneNumbersDto
    {
        [JsonProperty("status")]
        public string? Status { get; set; }

        [JsonProperty("phone_numbers")]
        public List<string>? PhoneNumbers { get; set; }
    }

    public class TimeInfoDto
    {
        [JsonProperty("human")]
        public string Human { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("iso")]
        public string? Iso { get; set; }
    }
}
