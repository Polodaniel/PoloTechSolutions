using SourceAFIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoEletronicoWeb.Server.Models
{
    public class UserDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public FingerprintTemplate Template { get; set; }

        public UserDetails Find(FingerprintTemplate probe, IEnumerable<UserDetails> candidates)
        {
            var matcher = new FingerprintMatcher(probe);

            UserDetails match = null;

            double high = 0;

            foreach (var candidate in candidates)
            {
                double score = matcher.Match(candidate.Template);
                if (score > high)
                {
                    high = score;
                    match = candidate;
                }
            }

            double threshold = 40;

            return high >= threshold ? match : null;
        }
    }
}
