using Badgr.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace BadgrV1.Api.Model
{
    public class IssuerProvider: BadgrApiEntity
    {
        public IssuerProvider(Token token)
        {
            Token = token;
        }
        /// <summary>
        /// get all issuers for authenticated user
        /// </summary>
        /// <returns></returns>
        public List<Issuer> GetAll()
        {
            var issuers = HtmlUtilities.GetResults<List<Issuer>>(string.Format("{0}/v1/issuer/issuers", BadgrUrl), TokenHeader);

            if (issuers != null)
                issuers.ForEach(i => { i.Token = Token; });

            return issuers;
        }
        /// <summary>
        /// get single issuer for slug
        /// </summary>
        /// <param name="slug"></param>
        /// <returns></returns>
        public Issuer Get(string slug)
        {
            var issuer = HtmlUtilities.GetResults<Issuer>(string.Format("{0}/v1/issuer/issuers/{1}", BadgrUrl, slug), TokenHeader);

            if (issuer != null)
                issuer.Token = Token;

            return issuer;
        }

        /// <summary>
        /// Gets staff for an issuer
        /// </summary>
        /// <param name="slug"></param>
        /// <returns></returns>
        public List<IssuerStaff> GetStaff(string slug)
        {
            var issuerStaff = HtmlUtilities.GetResults<List<IssuerStaff>>(string.Format("{0}/v1/issuer/issuers/{1}/staff", BadgrUrl, slug), TokenHeader);

            return issuerStaff;
        }
    }
}
