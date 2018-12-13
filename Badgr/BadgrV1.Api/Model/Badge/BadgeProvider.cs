using Badgr.Utilities;
using System.Collections.Generic;
using System.Linq;


namespace BadgrV1.Api.Model
{
    public class BadgeProvider : BadgrApiEntity
    {
        public BadgeProvider(Token token)
        {
            Token = token;
        }
        /// <summary>
        /// get all badges this authenticate  user can issue
        /// </summary>
        /// <returns></returns>
        public List<Badge> GetAllCanIssue()
        {
            var badges = HtmlUtilities.GetResults<List<Badge>>(string.Format("{0}/v1/issuer/all-badges", BadgrUrl), TokenHeader);

            if (badges != null)
                badges.ForEach(i => { i.Token = Token; });

            return badges;
        }
                

        /// <summary>
        /// gets a badge for an issuer
        /// </summary>
        /// <param name="issuerSlug"></param>
        /// <param name="badgeSlug"></param>
        /// <returns></returns>
        public Badge GetForIssuer(string issuerSlug, string badgeSlug)
        {
            var badge = HtmlUtilities.GetResults<Badge>(string.Format("{0}/v1/issuer/issuers/{1}/badges/{2}", BadgrUrl,issuerSlug,badgeSlug), TokenHeader);

            if (badge != null)
                badge.Token = Token;

            return badge;
        }

        /// <summary>
        /// gets all badges for an issuer
        /// </summary>
        /// <param name="issuerSlug"></param>
        /// <param name="badgeSlug"></param>
        /// <returns></returns>
        public List<Badge> GetAllForIssuer(string issuerSlug)
        {
            var badges = HtmlUtilities.GetResults<List<Badge>>(string.Format("{0}/v1/issuer/issuers/{1}/badges", BadgrUrl, issuerSlug), TokenHeader);

            if (badges != null)
                badges.ForEach(i => { i.Token = Token; });

            return badges;
        }
    }
}
