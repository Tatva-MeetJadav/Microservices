using Bogus;
using Microservices.Models;

namespace Microservices.Tests.MockData
{
    public class ProxyAndVpnDetectionMock
    {
        public static class ProxyAndVpnDetectionFaker
        {
            public static Faker<ProxyAndVpnDetectionRequest> GetRequestFaker()
            {
                return new Faker<ProxyAndVpnDetectionRequest>()
                    .RuleFor(x => x.IpAddress, f => f.Internet.IpAddress().ToString());
            }

            public static Faker<ProxyAndVpnDetectionResponse> GetResponseFaker()
            {
                return new Faker<ProxyAndVpnDetectionResponse>().
                    RuleFor(x => x.Message, f => f.Lorem.Sentence()).
                    RuleFor(x => x.Success, f => f.Random.Bool()).
                    RuleFor(x => x.Proxy, f => f.Random.Bool()).
                    RuleFor(x => x.ISP, f => f.Company.CompanyName()).
                    RuleFor(x => x.Organization, f => f.Company.CompanyName()).
                    RuleFor(x => x.ASN, f => f.Random.Int(10000, 99999)).
                    RuleFor(x => x.Host, f => $"{f.Internet.Ip().Replace('.', '-')}.client.{f.Internet.DomainName()}").
                    RuleFor(x => x.CountryCode, f => f.Address.CountryCode()).
                    RuleFor(x => x.City, f => f.Address.City()).
                    RuleFor(x => x.Region, f => f.Address.State()).
                    RuleFor(x => x.IsCrawler, f => f.Random.Bool()).
                    RuleFor(x => x.Latitude, f => ((float)f.Address.Latitude())).
                    RuleFor(x => x.Longitude, f => ((float)f.Address.Longitude())).
                    RuleFor(x => x.ZipCode, f => f.Address.ZipCode()).
                    RuleFor(x => x.Vpn, f => f.Random.Bool()).
                    RuleFor(x => x.Tor, f => f.Random.Bool()).
                    RuleFor(x => x.ActiveVpn, f => f.Random.Bool()).
                    RuleFor(x => x.ActiveTor, f => f.Random.Bool()).
                    RuleFor(x => x.RecentAbuse, f => f.Random.Bool()).
                    RuleFor(x => x.BotStatus, f => f.Random.Bool()).
                    RuleFor(x => x.Mobile, f => f.Random.Bool()).
                    RuleFor(x => x.FraudScore, f => f.Random.Int(0, 100)).
                    RuleFor(x => x.Timezone, f => f.PickRandom(new[] {
                    "America/New_York",
                    "Europe/London",
                    "Asia/Kolkata",
                    "America/Los_Angeles",
                    "Australia/Sydney"
                }));
            }
        }
    }
}
