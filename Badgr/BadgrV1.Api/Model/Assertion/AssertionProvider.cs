using Badgr.Utilities;
using System.Collections.Generic;

namespace BadgrV1.Api.Model
{
    public class AssertionProvider : BadgrApiEntity
    {
        public AssertionProvider(Token token)
        {
            Token = token;
        }

        public Assertion Get(string issuerSlug, string badgeSlug, string assertionSlug)
        {
            var assertion = HtmlUtilities.GetResults<Assertion>(string.Format("{0}/v1/issuer/issuers/{1}/badges/{2}/assertions/{3}", BadgrUrl, issuerSlug, badgeSlug, assertionSlug), TokenHeader);

            if (assertion != null)
                assertion.Token = Token;

            return assertion;
        }

        /// <summary>
        /// gets a list of assertions for an issuer by slug
        /// </summary>
        /// <param name="slug"></param>
        /// <returns></returns>
        public List<Assertion> GetForIssuer(string slug)
        {
            var assertions = HtmlUtilities.GetResults<List<Assertion>>(string.Format("{0}/v1/issuer/issuers/{1}/assertions", BadgrUrl, slug), TokenHeader);

            if (assertions != null)
                assertions.ForEach(i => { i.Token = Token; });

            return assertions;
        }

        /// <summary>
        /// gets a list of asserts for a badge
        /// </summary>
        /// <param name="issuerSlug"></param>
        /// <param name="badgeSlug"></param>
        /// <returns></returns>
        public List<Assertion> GetForBadge(string issuerSlug, string badgeSlug)
        {
            var assertions = HtmlUtilities.GetResults<List<Assertion>>(string.Format("{0}/v1/issuer/issuers/{1}/badges/{2}/assertions", BadgrUrl, issuerSlug, badgeSlug), TokenHeader);

            if (assertions != null)
                assertions.ForEach(i => { i.Token = Token; });

            return assertions;
        }

        /// <summary>
        /// get all assertions for the logged in user
        /// </summary>
        /// <returns></returns>
        public List<Assertion> GetAllIssued()
        {
            var assertions = HtmlUtilities.GetResults<List<Assertion>>(string.Format("{0}/v1/earner/badges", BadgrUrl), TokenHeader);

            if (assertions != null)
                assertions.ForEach(i => { i.Token = Token; });

            return assertions;
        }

    }
}
