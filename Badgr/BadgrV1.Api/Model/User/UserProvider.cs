using Badgr.Utilities;
using System.Collections.Generic;

namespace BadgrV1.Api.Model
{
    public class UserProvider : BadgrApiEntity
    {
        public UserProvider(Token token)
        {
            Token = token;
        }

        /// <summary>
        /// gets all email addresses for logged in user
        /// </summary>
        /// <returns></returns>
        public List<UserEmail> GetAllEmails()
        {
            var userEmails = HtmlUtilities.GetResults<List<UserEmail>>(string.Format("{0}/v1/user/emails", BadgrUrl), TokenHeader);

            if (userEmails != null)
                userEmails.ForEach(i => { i.Token = Token; });

            return userEmails;
        }

        /// <summary>
        /// get all email address for logged in user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserEmail GetEmail(int id)
        {
            var userEmail = HtmlUtilities.GetResults<UserEmail>(string.Format("{0}/v1/user/emails/{1}", BadgrUrl, id), TokenHeader);

            if (userEmail != null)
                userEmail.Token = Token;

            return userEmail;
        }

        /// <summary>
        /// Gets logged in users profile information
        /// </summary>
        /// <returns></returns>
        public User Get()
        {
            var user = HtmlUtilities.GetResults<User>(string.Format("{0}/v1/user/profile", BadgrUrl), TokenHeader);

            if (user != null)
                user.Token = Token;

            return user;
        }

        public void RequestPasswordReset(UserPasswordResetRequest request)
        {
            HtmlUtilities.GetResults<UserPasswordResetRequest, object>(string.Format("{0}/v1/user/forgot-password", BadgrUrl), request, null);
                       
        }
    }
}
