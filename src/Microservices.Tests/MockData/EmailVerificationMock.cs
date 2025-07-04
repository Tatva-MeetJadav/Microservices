using Bogus;
using Microservices.Models;

namespace Microservices.Tests.TestData
{
    public static class EmailVerificationRequestFaker
    {
        public static Faker<EmailVerificationRequest> GetFaker()
        {
            return new Faker<EmailVerificationRequest>()
                .RuleFor(x => x.Email, f => f.Internet.Email());
        }
    }
    public static class EmailVerificationResponseFaker
    {
        public static Faker<EmailVerificationResponse> GetFaker()
        {
            return new Faker<EmailVerificationResponse>()
                .RuleFor(x => x.Valid, f => f.Random.Bool())
                .RuleFor(x => x.TimedOut, f => f.Random.Bool())
                .RuleFor(x => x.Disposable, f => f.Random.Bool())
                .RuleFor(x => x.FirstName, f => f.Name.FirstName())
                .RuleFor(x => x.Deliverability, f => f.PickRandom<EmailVerificationResponse.DeliverabilityEnum>())
                .RuleFor(x => x.SmtpScore, f => f.Random.Int(-1, 3))
                .RuleFor(x => x.OverallScore, f => f.Random.Int(0, 4))
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
                .RuleFor(x => x.DomainVelocity, f => f.PickRandom<EmailVerificationResponse.DomainVelocityEnum>())
                .RuleFor(x => x.DomainTrust, f => f.PickRandom<EmailVerificationResponse.DomainTrustEnum>())
                .RuleFor(x => x.UserActivity, f => f.PickRandom<EmailVerificationResponse.UserActivityEnum>())
                .RuleFor(x => x.FirstSeen, f => EmailVerificationResponseFirstSeenFaker.GetFaker().Generate())
                .RuleFor(x => x.DomainAge, f => EmailVerificationResponseDomainAgeFaker.GetFaker().Generate())
                .RuleFor(x => x.Success, f => f.Random.Bool())
                .RuleFor(x => x.SpamTrapScore, f => f.PickRandom<EmailVerificationResponse.SpamTrapScoreEnum>())
                .RuleFor(x => x.RiskyTld, f => f.Random.Bool())
                .RuleFor(x => x.SpfRecord, f => f.Random.Bool())
                .RuleFor(x => x.DmarcRecord, f => f.Random.Bool())
                .RuleFor(x => x.SanitizedEmail, f => f.Internet.Email())
                .RuleFor(x => x.MxRecords, f => f.Make(f.Random.Int(1, 3), () => f.Internet.DomainName()))
                .RuleFor(x => x.RequestId, f => f.Random.Guid().ToString())
                .RuleFor(x => x.ARecords, f => f.Make(f.Random.Int(1, 2), () => f.Internet.Ip()));
        }
    }

    public static class EmailVerificationResponseFirstSeenFaker
    {
        public static Faker<EmailVerificationResponseFirstSeen> GetFaker()
        {
            return new Faker<EmailVerificationResponseFirstSeen>()
                .RuleFor(x => x.Human, f => f.Random.String())
                .RuleFor(x => x.Iso, f => f.Date.Past())
                .RuleFor(x => x.Timestamp, f => f.Random.Number());
        }
    }

    public static class EmailVerificationResponseDomainAgeFaker
    {
        public static Faker<EmailVerificationResponseDomainAge> GetFaker()
        {
            return new Faker<EmailVerificationResponseDomainAge>()
                .RuleFor(x => x.Human, f => f.Random.String())
                .RuleFor(x => x.Iso, f => f.Date.Past())
                .RuleFor(x => x.Timestamp, f => f.Random.Number());
        }
    }
}