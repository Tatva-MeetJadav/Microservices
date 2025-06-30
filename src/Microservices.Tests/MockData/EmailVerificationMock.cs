using Bogus;
using Microservices.Models;
using Microservices.Models.DTO;

namespace Microservices.Tests.TestData
{
    public static class EmailVerificationFakers
    {
        public static Faker<EmailVerificationRequest> EmailRequestFaker { get; } =
            new Faker<EmailVerificationRequest>()
                .RuleFor(x => x.Email, f => f.Internet.Email());


        public static Faker<TimeInfoDTO> TimeInfoFaker { get; } =
            new Faker<TimeInfoDTO>()
                .RuleFor(x => x.Human, f => f.Date.Past().ToString("MMMM dd, yyyy"))
                .RuleFor(x => x.Timestamp, f => f.Date.Past().ToUniversalTime().Ticks)
                .RuleFor(x => x.Iso, f => f.Date.Past().ToUniversalTime().ToString("o"));

        public static Faker<EmailVerificationResponse> EmailResponseDtoFaker { get; } =
            new Faker<EmailVerificationResponse>()
                .RuleFor(x => x.Valid, f => f.Random.Bool())
                .RuleFor(x => x.TimedOut, f => f.Random.Bool())
                .RuleFor(x => x.Disposable, f => f.Random.Bool())
                .RuleFor(x => x.FirstName, f => f.Name.FirstName())
                .RuleFor(x => x.Deliverability, f => f.PickRandom<DeliverabilityEnum>())
                .RuleFor(x => x.SmtpScore, f => f.Random.Int(0, 100))
                .RuleFor(x => x.OverallScore, f => f.Random.Int(0, 100))
                .RuleFor(x => x.CatchAll, f => f.Random.Bool())
                .RuleFor(x => x.Generic, f => f.Random.Bool())
                .RuleFor(x => x.Common, f => f.Random.Bool())
                .RuleFor(x => x.DnsValid, f => f.Random.Bool())
                .RuleFor(x => x.Honeypot, f => f.Random.Bool())
                .RuleFor(x => x.FrequentComplainer, f => f.Random.Bool())
                .RuleFor(x => x.Suspect, f => f.Random.Bool())
                .RuleFor(x => x.RecentAbuse, f => f.Random.Bool())
                .RuleFor(x => x.FraudScore, f => f.Random.Int(0, 100))
                .RuleFor(x => x.Leaked, f => f.Random.Bool())
                .RuleFor(x => x.SuggestedDomain, f => f.Internet.DomainName())
                .RuleFor(x => x.DomainVelocity, f => f.PickRandom<DomainVelocityEnum>())
                .RuleFor(x => x.DomainTrust, f => f.PickRandom<DomainTrustEnum>())
                .RuleFor(x => x.UserActivity, f => f.PickRandom<UserActivityEnum>())
                .RuleFor(x => x.FirstSeen, f => TimeInfoFaker.Generate())
                .RuleFor(x => x.DomainAge, f => TimeInfoFaker.Generate())
                .RuleFor(x => x.Success, f => f.Random.Bool())
                .RuleFor(x => x.SpamTrapScore, f => f.PickRandom<SpamTrapScoreEnum>())
                .RuleFor(x => x.RiskyTld, f => f.Random.Bool())
                .RuleFor(x => x.SpfRecord, f => f.Random.Bool())
                .RuleFor(x => x.DmarcRecord, f => f.Random.Bool())
                .RuleFor(x => x.SanitizedEmail, f => f.Internet.Email())
                .RuleFor(x => x.MxRecords, f => new List<string> { f.Internet.DomainName(), f.Internet.DomainName() })
                .RuleFor(x => x.RequestId, f => f.Random.Guid().ToString())
                .RuleFor(x => x.ARecords, f => new List<string> { f.Internet.Ip(), f.Internet.Ip() });
    }
}