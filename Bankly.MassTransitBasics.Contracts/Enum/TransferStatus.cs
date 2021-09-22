using System.Globalization;

namespace Bankly.MassTransitBasics.Contracts.Enum
{
    public enum  TransferStatus
    {
        CREATED,
        REGISTERED,
        TAXED,
        REFUSED,
        SUCCESFUL
    }

    public static class EnumExtensions
    {
        public static TransferStatus ToStatus(this string @string) => System.Enum.Parse<TransferStatus>(@string);

        public static string ToString(this TransferStatus status) => string.Format(new CultureInfo("en-us"), status.ToString());
       /*  public const string CREATED = "Created";
        public const string REGISTERED = "Registered";
        public const string NOTIFIED = "Notified";
        public const string CLOSED = "Closed";
        public const string FINISHED = "Finished"; */
    }
}