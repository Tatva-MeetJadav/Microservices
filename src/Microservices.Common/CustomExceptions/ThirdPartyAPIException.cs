
namespace Microservices.Common.CustomExceptions
{
    public class ThirdPartyAPIException : Exception
    {
        /// <summary>
        /// If true, the 'message' will be passed to the base Exception (and thus sent to the client).
        /// If false, the general message ("Unexpected error") will be passed to the base Exception.
        /// </summary>
        public ThirdPartyAPIException(
            string message,
            bool exposeMessage = false)
            : base(exposeMessage ? message : "Unexpected error occured.")
        {
        }
    }
}