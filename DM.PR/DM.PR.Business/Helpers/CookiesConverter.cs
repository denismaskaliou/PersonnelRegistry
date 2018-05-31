﻿using DM.PR.Business.Entities;
using DM.PR.Common.Entities.Account;
using Newtonsoft.Json;
using System;                         
using System.Security.Principal;   
using System.Web;
using System.Web.Security;

namespace DM.PR.Business.Helpers
{
    public static class CookiesConverter
    {
        public static HttpCookie ConvertToCookie(User user)
        {
            var userData = JsonConvert.SerializeObject(user);
            var ticket = new FormsAuthenticationTicket(1, user.Login, DateTime.Now, DateTime.Now.AddMinutes(15), false, userData);
            var encryptTicket = FormsAuthentication.Encrypt(ticket);
            return new HttpCookie(FormsAuthentication.FormsCookieName, encryptTicket);
        }

        public static IPrincipal ConvertToIPrincipal(HttpCookie cookie)
        {
            var decryptedCookie = FormsAuthentication.Decrypt(cookie.Value);
            var User = JsonConvert.DeserializeObject<User>(decryptedCookie.UserData);
            return new UserPrincipal(User);
        }
    }
}
