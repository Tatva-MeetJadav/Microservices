using Bogus;

namespace Microservices.Tests.MockData
{
    public class UrlMock
    {
        private static readonly Faker faker = new ();
        public static string GetBaseUrlFaker()
        {
            return faker.Internet.Url();
        }

        public static string GetApiKeyFaker()
        {
            return faker.Random.AlphaNumeric(16);
        }

        public static string GetDataFaker()
        {
           return faker.Random.Word();
        }
    }
}
