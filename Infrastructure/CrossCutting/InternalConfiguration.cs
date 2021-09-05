using Microsoft.Extensions.Configuration;
using System.IO;

namespace Infrastructure.CrossCutting.Core
{
    public static class InternalConfiguration
    {
        private static IConfiguration _iConfiguration = null;
        private static readonly object locker = new object();

        public static IConfiguration AppSettings
        {
            get {
                // Double Thread-Safe.
                if (_iConfiguration == null)
                {
                    lock (locker)
                    {
                        if (_iConfiguration == null)
                            _iConfiguration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
                    }
                }

                return _iConfiguration;
            }
        }
    }
}
