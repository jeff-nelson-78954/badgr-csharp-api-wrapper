using Badgr.Utilities;
using BadgrV1.Api.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Badgr.Tests
{
    /// <summary>
    /// Currently the endpoint is broken POST - /v1/issuer/issuers/{slug}/staff (Add or remove a user from a role on an issuer. Limited to Owner users only)
    /// Null values on update will clear out data
    /// Issuer field and Badge class field will sometimes return a slug and sometimes a url with the id at the end.
    /// Not sure what user email update will update. No errors but nothing would update
    /// urls require http or https included
    /// skipped backpack calls
    /// </summary>
    class Program
    {
        public Program()
        {
            try
            {
                OverrideSSLWarnings();

                //get access token for the rest of the api calls
                var token = new Token();
                token.GetToken("username", "password");

            }
            catch (WebException ex)
            {
                Console.WriteLine(new StreamReader(ex.Response.GetResponseStream()).ReadToEnd());
            }
            

            Console.WriteLine("Done!");
            Console.ReadLine();
        }


        static void Main(string[] args)
        {
            var p = new Program();
        }

        private void IssuerExamples(Token token)
        {
            //get all issuers
            var issuerProvider = new IssuerProvider(token);
            var issuers = issuerProvider.GetAll();
            Console.WriteLine(issuers.Count);

            //get one issuer
            var issuer = issuerProvider.Get("");
            Console.WriteLine(issuer.Name);

            //get staff
            var issuerStaff = issuerProvider.GetStaff("");
            Console.WriteLine(issuerStaff.Count);

            //add issuer
            string testImage1 = string.Format("{0}/TestImages/issuer_badgeclass_5eae2371-c88e-4ea4-85b1-2be472a07a9a.png", Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())));
            var issuerToAdd = new IssuerAdd(token)
            {
                Description = "",
                Email = "",
                Url = "",
                Name = "",
                Image = ImageUtilities.GetBase64(testImage1),
            }.Add();

            //update issuer
            var issuerToUpdate = new IssuerUpdate(token)
            {
                Slug = "",
                Description = "",
                Email = "",
                Url = "",
                Name = ""
            }.Update();

            //delete issuer
            new IssuerUpdate(token)
            {
                Slug = ""
            }.Delete();
        }
        private void BadgeExamples(Token token)
        {
            //get all issuers
            var badgeProvider = new BadgeProvider(token);
            var badges = badgeProvider.GetAllCanIssue();
            Console.WriteLine(badges.Count);

            var badge = badgeProvider.GetForIssuer("", "");
            Console.WriteLine(badge.Name);

            var badgesForIssuer = badgeProvider.GetAllForIssuer("");
            Console.WriteLine(badgesForIssuer.Count);

            //add badge
            string testImage1 = string.Format("{0}/TestImages/issuer_badgeclass_5eae2371-c88e-4ea4-85b1-2be472a07a9a.png", Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())));
            var badgeToAdd = new BadgeAdd(token)
            {
                Name = "",
                Description = "",
                CriteriaText = "",
                CriteriaUrl = "",
                Image = ImageUtilities.GetBase64(testImage1),
                Tags = new List<string>
                {
                    ""
                },
                Alignments = new List<BadgeAlignment>
                {
                    new BadgeAlignment
                    {
                        TargetName = "",
                        TargetUrl = "",
                        TargetDescription = "",
                        TargetFramework = "",
                        TargetCode = ""
                    }
                },
                Expires = new BadgeExpires
                {
                    Amount = 10,
                    Duration = "days"
                }

            }.Add("");

            var badgeToUpdate = new BadgeUpdate(token)
            {
                Slug = "",
                Description = "",
                Name = "",
                CriteriaText = "",
                CriteriaUrl = "",
                Image = ImageUtilities.GetBase64(testImage1),
                //Tags = new List<string>
                //{
                //    "My Tag"
                //},
                //Alignments = new List<BadgeAlignment>
                //{
                //    new BadgeAlignment
                //    {
                //        TargetName = "",
                //        TargetUrl = "",
                //        TargetDescription = "",
                //        TargetFramework = "",
                //        TargetCode = ""
                //    }
                //},
                //Expires = new BadgeExpires
                //{
                //    Amount = 10,
                //    Duration = "days"

                //}
            }.Update("");

            //delete badge
            new BadgeUpdate(token)
            {
                Slug = ""
            }.Delete("");

        }
        private void AssertionExamples(Token token)
        {
            var assertionProvider = new AssertionProvider(token);

            var assertionsForIssuer = assertionProvider.GetForIssuer("");
            Console.WriteLine(assertionsForIssuer.Count);

            var assertionsForBadge = assertionProvider.GetForBadge("","");
            Console.WriteLine(assertionsForBadge.Count);

            var assertion = assertionProvider.Get("", "", "");
            Console.WriteLine(assertion.Slug);

            //issue assertion example
            var assertionToAdd = new AssertionAdd(token)
            {
                BadgeClass = "",
                Issuer = "",
                RecipientType = "email",
                RecipientIdentifier = "",
                Narrative = "",
                CreateNotification = true,
                EvidenceItems = new List<AssertionEvidence>
                {
                    new AssertionEvidence
                    {
                        Narrative = "",
                        EvidenceUrl = "",
                        Expiration = ""
                    }
                }
            }.Issue();
            Console.WriteLine(assertionToAdd.Slug);

            //update assertion example
            var assertionToUpdate = new AssertionUpdate(token)
            {
                Slug = "",
                BadgeClass = "",
                Issuer = "",
                RecipientType = "email",
                RecipientIdentifier = "",
                Narrative = "",
                CreateNotification = true,
                EvidenceItems = new List<AssertionEvidence>
                {
                    new AssertionEvidence
                    {
                        Narrative = "",
                        EvidenceUrl = "",
                        Expiration = ""
                    }
                }
            }.Update();

            //revoke assertion example
            new AssertionUpdate(token)
            {
                Slug = "",
                BadgeClass = "",
                Issuer = "",
                RevocationReason = ""
            }.Revoke();

            //issue batch assertion example
            new AssertionBatchAdd(token)
            {
                BadgeClass = "",
                Issuer = "",
                CreateNotification = true,
                Assertions = new List<AssertionBatchAddAssertion>
                    {
                        new AssertionBatchAddAssertion
                        {
                            RecipientIdentifier = "",
                            EvidenceItems = new List<AssertionBatchAddEvidence>
                            {
                                new AssertionBatchAddEvidence
                                {
                                    EvidenceUrl = ""
                                }
                            }
                        },
                        new AssertionBatchAddAssertion
                        {
                            RecipientIdentifier = "",
                            EvidenceItems = new List<AssertionBatchAddEvidence>
                            {
                                new AssertionBatchAddEvidence
                                {
                                    EvidenceUrl = ""
                                }
                            }
                        }
                    }

            }.BatchIssue();
        }
        private void UserExamples(Token token)
        {
            var userProvider = new UserProvider(token);
            //get user profile
            var user = userProvider.Get();

            ////get user emails
            var emails = userProvider.GetAllEmails();
            Console.WriteLine(emails.Count);

            ////get email by id
            var email = userProvider.GetEmail(0);
            Console.WriteLine(email.Email);

            //request password reset
            userProvider.RequestPasswordReset(new UserPasswordResetRequest { Email = "" });

            //reset password
            new UserPasswordReset
            {
                Password = "myTestReset!1234",
                Token = "1d2z-522-f4b6af17b860d33a52db"

            }.Recover();

            //update profile
            var userToUpdate = new UserUpdate(token)
            {
                FirstName = "",
                LastName = ""
            }.Update();

            //add email
            var emailToAdd = new UserEmailAdd(token)
            {
                Email = ""
            }.Add();
            Console.WriteLine(emailToAdd.Id);

            //update email - not sure what this updates
            var emailToUpdate = new UserEmailUpdate(token)
            {
                Id = 0

            }.Update();

            //delete email
            new UserEmailUpdate(token)
            {
                Id = 0

            }.Delete();
        }
        private void OverrideSSLWarnings()
        {
            ServicePointManager.ServerCertificateValidationCallback +=
            delegate (object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                                    System.Security.Cryptography.X509Certificates.X509Chain chain,
                                    System.Net.Security.SslPolicyErrors sslPolicyErrors)
            {
                return true; // **** Always accept
            };

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 |
                                                   SecurityProtocolType.Tls12 |
                                                   SecurityProtocolType.Tls11 |
                                                   SecurityProtocolType.Tls;
        }
    }
}
