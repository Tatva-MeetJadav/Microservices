using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Microservices.Models.DTO
{
    /// <summary>
    /// Represents the response from an email verification API containing various analysis results about the email address.
    /// </summary>
    public class EmailVerificationResponseDTO
    {
        /// <summary>
        /// Indicates if the email is valid.
        /// </summary>
        [JsonProperty("valid")]
        public bool Valid { get; set; }

        /// <summary>
        /// Indicates if the verification process timed out.
        /// </summary>
        [JsonProperty("timed_out")]
        public bool TimedOut { get; set; }

        /// <summary>
        /// Indicates if the email address is disposable.
        /// </summary>
        [JsonProperty("disposable")]
        public bool Disposable { get; set; }

        /// <summary>
        /// The first name associated with the email address, if available.
        /// </summary>
        [JsonProperty("first_name")]
        public string? FirstName { get; set; }

        /// <summary>
        /// The deliverability status of the email address.
        /// </summary>
        [JsonProperty("deliverability")]
        public DeliverabilityEnum Deliverability { get; set; }

        /// <summary>
        /// The SMTP score of the email address.
        /// </summary>
        [JsonProperty("smtp_score")]
        public int SmtpScore { get; set; }

        /// <summary>
        /// The overall score for the email address.
        /// </summary>
        [JsonProperty("overall_score")]
        public int OverallScore { get; set; }

        /// <summary>
        /// Indicates if the email address is a catch-all address.
        /// </summary>
        [JsonProperty("catch_all")]
        public bool CatchAll { get; set; }

        /// <summary>
        /// Indicates if the email address is generic (e.g., info@, support@).
        /// </summary>
        [JsonProperty("generic")]
        public bool Generic { get; set; }

        /// <summary>
        /// Indicates if the email address is a common address.
        /// </summary>
        [JsonProperty("common")]
        public bool Common { get; set; }

        /// <summary>
        /// Indicates if the DNS of the domain is valid.
        /// </summary>
        [JsonProperty("dns_valid")]
        public bool DnsValid { get; set; }

        /// <summary>
        /// Indicates if the email address is a honeypot (trap for spam).
        /// </summary>
        [JsonProperty("honeypot")]
        public bool Honeypot { get; set; }

        /// <summary>
        /// Indicates if the owner is a frequent complainer.
        /// </summary>
        [JsonProperty("frequent_complainer")]
        public bool FrequentComplainer { get; set; }

        /// <summary>
        /// Indicates if the email is considered suspect.
        /// </summary>
        [JsonProperty("suspect")]
        public bool Suspect { get; set; }

        /// <summary>
        /// Indicates if there has been recent abuse reported for this email.
        /// </summary>
        [JsonProperty("recent_abuse")]
        public bool RecentAbuse { get; set; }

        /// <summary>
        /// The fraud score for the email address.
        /// </summary>
        [JsonProperty("fraud_score")]
        public int FraudScore { get; set; }

        /// <summary>
        /// Indicates if the email has been leaked in a breach.
        /// </summary>
        [JsonProperty("leaked")]
        public bool Leaked { get; set; }

        /// <summary>
        /// Suggested domain if a typo or issue is detected.
        /// </summary>
        [JsonProperty("suggested_domain")]
        public string? SuggestedDomain { get; set; }

        /// <summary>
        /// The velocity (activity level) of the domain.
        /// </summary>
        [JsonProperty("domain_velocity")]
        public DomainVelocityEnum? DomainVelocity { get; set; }

        /// <summary>
        /// The trust level of the domain.
        /// </summary>
        [JsonProperty("domain_trust")]
        public DomainTrustEnum? DomainTrust { get; set; }

        /// <summary>
        /// The user activity level associated with the email address.
        /// </summary>
        [JsonProperty("user_activity")]
        public UserActivityEnum? UserActivity { get; set; }

        /// <summary>
        /// Associated names found with the email address.
        /// </summary>
        [JsonProperty("associated_names")]
        public AssociatedNamesDTO? AssociatedNames { get; set; }

        /// <summary>
        /// Associated phone numbers found with the email address.
        /// </summary>
        [JsonProperty("associated_phone_numbers")]
        public AssociatedPhoneNumbersDTO? AssociatedPhoneNumbers { get; set; }

        /// <summary>
        /// Information about when the email address was first seen.
        /// </summary>
        [JsonProperty("first_seen")]
        public TimeInfoDTO? FirstSeen { get; set; }

        /// <summary>
        /// Information about the age of the domain.
        /// </summary>
        [JsonProperty("domain_age")]
        public TimeInfoDTO? DomainAge { get; set; }

        /// <summary>
        /// Indicates if the request was successful.
        /// </summary>
        [JsonProperty("success")]
        public bool Success { get; set; }

        /// <summary>
        /// The spam trap score for the email address.
        /// </summary>
        [JsonProperty("spam_trap_score")]
        public SpamTrapScoreEnum? SpamTrapScore { get; set; }

        /// <summary>
        /// Indicates if the top-level domain (TLD) is considered risky.
        /// </summary>
        [JsonProperty("risky_tld")]
        public bool RiskyTld { get; set; }

        /// <summary>
        /// Indicates if the domain has an SPF record.
        /// </summary>
        [JsonProperty("spf_record")]
        public bool SpfRecord { get; set; }

        /// <summary>
        /// Indicates if the domain has a DMARC record.
        /// </summary>
        [JsonProperty("dmarc_record")]
        public bool DmarcRecord { get; set; }

        /// <summary>
        /// The sanitized version of the email address.
        /// </summary>
        [JsonProperty("sanitized_email")]
        public string? SanitizedEmail { get; set; }

        /// <summary>
        /// The MX records found for the domain.
        /// </summary>
        [JsonProperty("mx_records")]
        public List<string>? MxRecords { get; set; }

        /// <summary>
        /// The unique request ID for tracking.
        /// </summary>
        [JsonProperty("request_id")]
        public string? RequestId { get; set; }

        /// <summary>
        /// The A records found for the domain.
        /// </summary>
        [JsonProperty("a_records")]
        public List<string>? ARecords { get; set; }
    }

    /// <summary>
    /// Represents names associated with an email address.
    /// </summary>
    public class AssociatedNamesDTO
    {
        /// <summary>
        /// The status of the associated names search.
        /// </summary>
        [JsonProperty("status")]
        public string? Status { get; set; }

        /// <summary>
        /// The list of associated names.
        /// </summary>
        [JsonProperty("names")]
        public List<string>? Names { get; set; }
    }

    /// <summary>
    /// Represents phone numbers associated with an email address.
    /// </summary>
    public class AssociatedPhoneNumbersDTO
    {
        /// <summary>
        /// The status of the associated phone numbers search.
        /// </summary>
        [JsonProperty("status")]
        public string? Status { get; set; }

        /// <summary>
        /// The list of associated phone numbers.
        /// </summary>
        [JsonProperty("phone_numbers")]
        public List<string>? PhoneNumbers { get; set; }
    }

    /// <summary>
    /// Represents information about a point in time.
    /// </summary>
    public class TimeInfoDTO
    {
        /// <summary>
        /// The human-readable date/time.
        /// </summary>
        [JsonProperty("human")]
        public string? Human { get; set; }

        /// <summary>
        /// The timestamp (Unix epoch).
        /// </summary>
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        /// <summary>
        /// The ISO date/time string.
        /// </summary>
        [JsonProperty("iso")]
        public string? Iso { get; set; }
    }

    /// <summary>
    /// Indicates the deliverability status of an email address.
    /// </summary>
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum DeliverabilityEnum
    {
        /// <summary>
        /// The email address is highly deliverable.
        /// </summary>
        [EnumMember(Value = "high")]
        High = 1,

        /// <summary>
        /// The email address has medium deliverability.
        /// </summary>
        [EnumMember(Value = "medium")]
        Medium = 2,

        /// <summary>
        /// The email address has low deliverability.
        /// </summary>
        [EnumMember(Value = "low")]
        Low = 3
    }

    /// <summary>
    /// Represents the velocity (activity level) of a domain.
    /// </summary>
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum DomainVelocityEnum
    {
        /// <summary>
        /// The domain has high velocity.
        /// </summary>
        [EnumMember(Value = "high")]
        High = 1,

        /// <summary>
        /// The domain has medium velocity.
        /// </summary>
        [EnumMember(Value = "medium")]
        Medium = 2,

        /// <summary>
        /// The domain has low velocity.
        /// </summary>
        [EnumMember(Value = "low")]
        Low = 3,

        /// <summary>
        /// The domain has no activity.
        /// </summary>
        [EnumMember(Value = "none")]
        None = 4,

        /// <summary>
        /// Indicates a higher plan is required to view this information.
        /// </summary>
        [EnumMember(Value = "Enterprise Mini or higher required.")]
        Upgrade = 5
    }

    /// <summary>
    /// Represents the trust level of a domain.
    /// </summary>
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum DomainTrustEnum
    {
        /// <summary>
        /// The domain is trusted.
        /// </summary>
        [EnumMember(Value = "trusted")]
        Trusted = 1,

        /// <summary>
        /// The domain has a positive trust rating.
        /// </summary>
        [EnumMember(Value = "positive")]
        Positive = 2,

        /// <summary>
        /// The domain has a neutral trust rating.
        /// </summary>
        [EnumMember(Value = "neutral")]
        Neutral = 3,

        /// <summary>
        /// The domain is suspicious.
        /// </summary>
        [EnumMember(Value = "suspicious")]
        Suspicious = 4,

        /// <summary>
        /// The domain is malicious.
        /// </summary>
        [EnumMember(Value = "malicious")]
        Malicious = 5,

        /// <summary>
        /// The domain has not been rated.
        /// </summary>
        [EnumMember(Value = "notRated")]
        NotRated = 6,

        /// <summary>
        /// Indicates a higher plan is required to view this information.
        /// </summary>
        [EnumMember(Value = "Upgraded plan required.")]
        Upgrade = 7
    }

    /// <summary>
    /// Represents the user activity level associated with an email address.
    /// </summary>
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum UserActivityEnum
    {
        /// <summary>
        /// High user activity.
        /// </summary>
        [EnumMember(Value = "high")]
        High = 1,

        /// <summary>
        /// Medium user activity.
        /// </summary>
        [EnumMember(Value = "medium")]
        Medium = 2,

        /// <summary>
        /// Low user activity.
        /// </summary>
        [EnumMember(Value = "low")]
        Low = 3,

        /// <summary>
        /// No user activity.
        /// </summary>
        [EnumMember(Value = "none")]
        None = 4,

        /// <summary>
        /// Indicates a higher plan is required to view this information.
        /// </summary>
        [EnumMember(Value = "Enterprise L4+ required.")]
        Upgrade = 5
    }

    /// <summary>
    /// Represents the spam trap score for an email address.
    /// </summary>
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum SpamTrapScoreEnum
    {
        /// <summary>
        /// High risk of being a spam trap.
        /// </summary>
        [EnumMember(Value = "high")]
        High = 1,

        /// <summary>
        /// Medium risk of being a spam trap.
        /// </summary>
        [EnumMember(Value = "medium")]
        Medium = 2,

        /// <summary>
        /// Low risk of being a spam trap.
        /// </summary>
        [EnumMember(Value = "low")]
        Low = 3,

        /// <summary>
        /// No risk of being a spam trap.
        /// </summary>
        [EnumMember(Value = "none")]
        None = 4
    }
}