using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Interface.Presentation.Controllers
{
    public class LoginGitHubController : Controller
    {
        const string clientId = "d6fe6834f30081cf609d";
        private const string clientSecret = "d829abc7d3a9435cdae06599d698106f9066420d";

        readonly GitHubClient client = new GitHubClient(
            new ProductHeaderValue("BugTracker-GitHub-Oauth"), 
            new Uri("https://github.com/"));

        public async Task<ActionResult> GithubAuthentication(string code, string state)
        {
            if (!String.IsNullOrEmpty(code))
            {
                var expectedState = Session["CSRF:State"] as string;
                //TODO: Tratar erro de segurança
                if (state != expectedState) throw new InvalidOperationException("SECURITY FAIL!");
                Session["CSRF:State"] = null;

                var token = await client.Oauth.CreateAccessToken(
                    new OauthTokenRequest(clientId, clientSecret, code)
                    {
                        RedirectUri = new Uri("http://10.99.3.129:58173/logingithub/githubauthentication")
                    });
                Session["OAuthToken"] = token.AccessToken;
            }

            return RedirectToAction("SignInGitHub");
        }

        public async Task<ActionResult> SignInGitHub()
        {
            var accessToken = Session["OAuthToken"] as string;

            if (accessToken != null)
            {
                client.Credentials = new Credentials(accessToken);
            }

            try
            {
                var email = await client.User.Email.GetAll();

                string primaryEmail = email.FirstOrDefault(e => e.Primary == true).Email;

                var gitHubUser = await client.User.Current();

                //TODO: registrar usuario

                //LoggedUser usuarioEncontrado =
                //    this.userService.BuscarPorGitAuth(primaryEmail, gitHubUser.Name);

                //if (usuarioEncontrado != null)
                //{
                //    UserSessionService.CreateSession(usuarioEncontrado);
                //}
                //else
                //{
                //    userService.SaveUser(primaryEmail, gitHubUser.Name);
                //    LoggedUser user = new LoggedUser() { Name = gitHubUser.Name, Username = primaryEmail };
                //    UserSessionService.CreateSession(user);
                //}

                return RedirectToAction("Index","User");

            }

            catch (AuthorizationException)
            {
                return Redirect(GetOauthLoginUrl());
            }
        }

        private string GetOauthLoginUrl()
        {
            string csrf = Membership.GeneratePassword(24, 1);
            Session["CSRF:State"] = csrf;

            var request = new OauthLoginRequest(clientId)
            {
                Scopes = { "user", "email" },
                State = csrf
            };
            var oauthLoginUrl = client.Oauth.GetGitHubLoginUrl(request);
            return oauthLoginUrl.ToString();
        }
    }
}