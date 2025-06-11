using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Microservices.BusinessLogic.Dto
{
    public class EmailVerificationDTO
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
        public DeliverabilityEnum Deliverability { get; set; }

        [JsonProperty("smtp_score")]
        public SmtpScoreEnum SmtpScore { get; set; }

        [JsonProperty("overall_score")]
        public OverallScoreEnum OverallScore { get; set; }

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
        public DomainVelocityEnum? DomainVelocity { get; set; }

        [JsonProperty("domain_trust")]
        public DomainTrustEnum? DomainTrust { get; set; }

        [JsonProperty("user_activity")]
        public UserActivityEnum? UserActivity { get; set; }

        [JsonProperty("associated_names")]
        public AssociatedNamesDTO? AssociatedNames { get; set; }

        [JsonProperty("associated_phone_numbers")]
        public AssociatedPhoneNumbersDTO? AssociatedPhoneNumbers { get; set; }

        [JsonProperty("first_seen")]
        public TimeInfoDTO? FirstSeen { get; set; }

        [JsonProperty("domain_age")]
        public TimeInfoDTO? DomainAge { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("spam_trap_score")]
        public SpamTrapScoreEnum? SpamTrapScore { get; set; }

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

    public class AssociatedNamesDTO
    {
        [JsonProperty("status")]
        public string? Status { get; set; }
        [JsonProperty("names")]
        public List<string>? Names { get; set; }
    }

    public class AssociatedPhoneNumbersDTO
    {
        [JsonProperty("status")]
        public string? Status { get; set; }
        [JsonProperty("phone_numbers")]
        public List<string>? PhoneNumbers { get; set; }
    }

    public class TimeInfoDTO
    {
        [JsonProperty("human")]
        public string Human { get; set; }
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
        [JsonProperty("iso")]
        public string? Iso { get; set; }
    }

    // Enum types matching the response model

    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum DeliverabilityEnum
    {
        [EnumMember(Value = "high")]
        High = 1,
        [EnumMember(Value = "medium")]
        Medium = 2,
        [EnumMember(Value = "low")]
        Low = 3
    }

    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum SmtpScoreEnum
    {
        [EnumMember(Value = "-1")]
        _1 = -1,
        [EnumMember(Value = "0")]
        _0 = 0,
        [EnumMember(Value = "1")]
        _12 = 1,
        [EnumMember(Value = "2")]
        _2 = 2,
        [EnumMember(Value = "3")]
        _3 = 3
    }

    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum OverallScoreEnum
    {
        [EnumMember(Value = "0")]
        _0 = 0,
        [EnumMember(Value = "1")]
        _1 = 1,
        [EnumMember(Value = "2")]
        _2 = 2,
        [EnumMember(Value = "3")]
        _3 = 3,
        [EnumMember(Value = "4")]
        _4 = 4
    }

    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum DomainVelocityEnum
    {
        [EnumMember(Value = "high")]
        High = 1,
        [EnumMember(Value = "medium")]
        Medium = 2,
        [EnumMember(Value = "low")]
        Low = 3,
        [EnumMember(Value = "none")]
        None = 4,
        [EnumMember(Value = "Enterprise Mini or higher required.")]
        Upgrade = 5
    }

    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum DomainTrustEnum
    {
        [EnumMember(Value = "trusted")]
        Trusted = 1,
        [EnumMember(Value = "positive")]
        Positive = 2,
        [EnumMember(Value = "neutral")]
        Neutral = 3,
        [EnumMember(Value = "suspicious")]
        Suspicious = 4,
        [EnumMember(Value = "malicious")]
        Malicious = 5,
        [EnumMember(Value = "notRated")]
        NotRated = 6,
        [EnumMember(Value = "Upgraded plan required.")]
        Upgrade = 7
    }

    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum UserActivityEnum
    {
        [EnumMember(Value = "high")]
        High = 1,
        [EnumMember(Value = "medium")]
        Medium = 2,
        [EnumMember(Value = "low")]
        Low = 3,
        [EnumMember(Value = "none")]
        None = 4,
        [EnumMember(Value = "Enterprise L4+ required.")]
        Upgrade = 5
    }

    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum SpamTrapScoreEnum
    {
        [EnumMember(Value = "high")]
        High = 1,
        [EnumMember(Value = "medium")]
        Medium = 2,
        [EnumMember(Value = "low")]
        Low = 3,
        [EnumMember(Value = "none")]
        None = 4
    }
}