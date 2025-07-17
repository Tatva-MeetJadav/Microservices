using Newtonsoft.Json;

namespace Microservices.Models.DTO
{
    /// <summary>
    /// 
    /// </summary>
    public class ProxyAndVpnDetectionResponseDTO
    {
        /// <summary>
        /// Gets or Sets Message
        /// </summary>
        /* <example>true</example> */
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or Sets Success
        /// </summary>
        /* <example>true</example> */
        [JsonProperty("success")]
        public bool Success { get; set; }

        /// <summary>
        /// Gets or Sets Proxy
        /// </summary>
        /* <example>false</example> */
        [JsonProperty("proxy")]
        public bool Proxy { get; set; }

        /// <summary>
        /// Gets or Sets ISP
        /// </summary>
        /* <example>Mediacom Cable</example> */
        [JsonProperty("ISP")]
        public string ISP { get; set; }

        /// <summary>
        /// Gets or Sets Organization
        /// </summary>
        /* <example>Mediacom Cable</example> */
        [JsonProperty("organization")]
        public string Organization { get; set; }

        /// <summary>
        /// Gets or Sets ASN
        /// </summary>
        /* <example>30036</example> */
        [JsonProperty("ASN")]
        public int ASN { get; set; }

        /// <summary>
        /// Gets or Sets Host
        /// </summary>
        /* <example>192-0-2-110.client.mchsi.com</example> */
        [JsonProperty("host")]
        public string Host { get; set; }

        /// <summary>
        /// Gets or Sets CountryCode
        /// </summary>
        /* <example>US</example> */
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        /// <summary>
        /// Gets or Sets City
        /// </summary>
        /* <example>Houston</example> */
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// Gets or Sets Region
        /// </summary>
        /* <example>Texas</example> */
        [JsonProperty("region")]
        public string Region { get; set; }

        /// <summary>
        /// Gets or Sets IsCrawler
        /// </summary>
        /* <example>false</example> */
        [JsonProperty("is_crawler")]
        public bool IsCrawler { get; set; }

        /// <summary>
        /// Gets or Sets Latitude
        /// </summary>
        /* <example>29.7079</example> */
        [JsonProperty("latitude")]
        public float Latitude { get; set; }

        /// <summary>
        /// Gets or Sets Longitude
        /// </summary>
        /* <example>-95.401</example> */
        [JsonProperty("longitude")]
        public float Longitude { get; set; }

        /// <summary>
        /// Gets or Sets ZipCode
        /// </summary>
        /* <example>77001</example> */
        [JsonProperty("zip_code")]
        public string ZipCode { get; set; }

        /// <summary>
        /// Gets or Sets Timezone
        /// </summary>
        /* <example>America Matamoros</example> */
        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        /// <summary>
        /// Gets or Sets Vpn
        /// </summary>
        /* <example>false</example> */
        [JsonProperty("vpn")]
        public bool Vpn { get; set; }

        /// <summary>
        /// Gets or Sets Tor
        /// </summary>
        /* <example>false</example> */
        [JsonProperty("tor")]
        public bool Tor { get; set; }

        /// <summary>
        /// Gets or Sets ActiveVpn
        /// </summary>
        /* <example>false</example> */
        [JsonProperty("active_vpn")]
        public bool ActiveVpn { get; set; }

        /// <summary>
        /// Gets or Sets ActiveTor
        /// </summary>
        /* <example>false</example> */
        [JsonProperty("active_tor")]
        public bool ActiveTor { get; set; }

        /// <summary>
        /// Gets or Sets RecentAbuse
        /// </summary>
        /* <example>true</example> */
        [JsonProperty("recent_abuse")]
        public bool RecentAbuse { get; set; }

        /// <summary>
        /// Gets or Sets BotStatus
        /// </summary>
        /* <example>false</example> */
        [JsonProperty("bot_status")]
        public bool BotStatus { get; set; }

        /// <summary>
        /// Gets or Sets Mobile
        /// </summary>
        /* <example>false</example> */
        [JsonProperty("mobile")]
        public bool Mobile { get; set; }

        /// <summary>
        /// Gets or Sets FraudScore
        /// </summary>
        /* <example>25</example> */
        [JsonProperty("fraud_score")]
        public int FraudScore { get; set; }

    }
}
