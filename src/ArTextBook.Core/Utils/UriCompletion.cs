using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Alva.ArTextBook.Utils
{
    public class UriCompletionResult
    {
        public bool IsApi = false;
        public string Url = null;
        public string FullUrl = null;
        public bool Result = false;
    }
    public static class UriCompletion
    {
        private static Regex shortPattern = new Regex("^/[a-zA-Z0-9]*");
        private static Regex normalPattern = new Regex("^/[a-zA-Z0-9]+\\/[a-zA-Z0-9]*");
        private static Regex apiPattern = new Regex("^/[a-zA-Z0-9]+[aA][pP][iI]\\/");

        public static UriCompletionResult Completion(string url)
        {
            UriCompletionResult r = new UriCompletionResult();

            if (String.IsNullOrEmpty(url))
            {
                r.IsApi = false;
                r.Url = "/";
                r.FullUrl = "/Home/Index";
                r.Result = true;
                return r;
            }

            var k = normalPattern.Match(url);
            if (k.Success)
            {
                r.Result = true;
                r.Url = k.Value;
                if (r.Url.EndsWith("/"))
                {
                    r.FullUrl = r.Url + "Index";
                }
                else
                {
                    r.FullUrl = r.Url;
                }
                //r.IsApi = r.FullUrl.IndexOf("Api/", StringComparison.OrdinalIgnoreCase) > 0;
                r.IsApi = apiPattern.IsMatch(r.FullUrl);
            }
            else
            {
                k = shortPattern.Match(url);
                if (k.Success)
                {
                    r.Result = true;
                    r.Url = k.Value;
                    if (r.Url == "/")
                    {
                        r.FullUrl = r.Url + "Home/Index";
                    }
                    else
                    {
                        r.FullUrl = r.Url + "/Index";
                    }
                    //r.IsApi = r.FullUrl.IndexOf("Api/", StringComparison.OrdinalIgnoreCase) > 0;
                    r.IsApi = apiPattern.IsMatch(r.FullUrl);
                }
            }
            return r;
        }
    }
}
