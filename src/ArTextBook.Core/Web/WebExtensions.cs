using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Scietec.Combine.Session;
using Alva.ArTextBook.Utils;
using Microsoft.AspNetCore.Http;
using ISession = Scietec.Combine.Session.ISession;
using Scietec.Combine.AspNetCore;

namespace Alva.ArTextBook.Web
{
    public static class WebExtensions
    {
        #region ISession
        #region User
        private const string _userIdKey = "__USER_ID__";

        private static string GetUserCacheKey(ISession sess)
        {
            return "WSU_" + sess.Id;
        }

        public static SessionalUser GetUser(this ISession sess)
        {
            string cacheKey = GetUserCacheKey(sess);
            SessionalUser r = CacheUtils.Get<SessionalUser>(cacheKey);
            if (null != r)
            {
                return r;
            }
            string s = sess.GetString(_userIdKey);
            if (String.IsNullOrEmpty(s))
            {
                return null;
            }

            var setting = new JsonSerializerSettings();
            setting.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
            setting.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
            r = JsonConvert.DeserializeObject<SessionalUser>(s, setting);
            if (null == r || r.Id <= 0)
            {
                return null;
            }

            CacheUtils.Set(cacheKey, r);
            return r;
        }

        public static void SetUser(this ISession sess, SessionalUser user)
        {
            string cacheKey = GetUserCacheKey(sess);
            CacheUtils.Set(cacheKey, user);
            var setting = new JsonSerializerSettings();
            setting.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
            setting.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
            setting.NullValueHandling = NullValueHandling.Ignore;
            string s = JsonConvert.SerializeObject(user, setting);
            sess.SetString(_userIdKey, s);
        }
        #endregion

        #region Token
        private const string _tokenKey = "__TOKEN__";
        public static string GetToken(this ISession sess)
        {
            return sess.GetString(_tokenKey);
        }

        public static void SetToken(this ISession sess, string token)
        {
            sess.SetString(_tokenKey, token);
        }
        #endregion

        #region CleanUserInfo
        public static void Exit(this ISession sess)
        {
            string cacheKey = GetUserCacheKey(sess);
            CacheUtils.Remove(cacheKey);
            sess.Clear();
            sess.Abandon();
        }
        #endregion
        #endregion

        #region HttpContext
        private const string _curUriKey = "__CUR_URI__";

        public static string GetCurrentUri(this HttpContext context)
        {
            return (string)(context.Items.ContainsKey(_curUriKey)
                ? context.Items[_curUriKey]
                : null);
        }

        public static void SetCurrentUri(this HttpContext context, string uri)
        {
            context.Items[_curUriKey] = uri;
        }
        #endregion

        #region HttpRequest

        public static SessionalUser GetUser(this HttpRequest request)
        {
            return request.GetCSession().GetUser();            
        }

        public static void SetUser(this HttpRequest request, SessionalUser user)
        {
            request.GetCSession().SetUser(user);
        }

        public static bool AuthCheck(this HttpRequest request,string uri)
        {
            SessionalUser su = request.GetCSession().GetUser();
            return (null == su || su.Id <= 0)
                ? WebApp.AnonymAuthMap.Contains(uri)
                : su.AuthMap.Contains(uri);
        }
        #endregion

    }
}
