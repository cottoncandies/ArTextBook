using Alva.ArTextBook.Kernel.Tdm;
using Alva.ArTextBook.Kernel.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Alva.ArTextBook.Kernel.Vdm;

namespace Alva.ArTextBook.Web
{
    public class SessionalUser
    {
        [JsonProperty("id")]
        public long Id { get; set; } = 0;
        [JsonProperty("username")]
        public string UserName { get; set; }
        [JsonProperty("nickname")]
        public string NickName { get; set; }

        [JsonIgnore]
        public string DisplayName
        {
            get
            {
                return String.IsNullOrEmpty(NickName) ? UserName : NickName;
            }
        }

        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("mobile")]
        public string Mobile { get; set; }
        [JsonProperty("gender")]
        public GenderKind Gender { get; set; }
        [JsonProperty("slogan")]
        public string Slogan { get; set; }
        [JsonProperty("avatar")]
        public string Avatar { get; set; }
        public long AppId { get; set; }
        public string AppName { get; set; }
        public string AppCaption { get; set; }
        public string WeChatId { get; set; }
        public string WeChatSecret { get; set; }
        public string OpenId { get; set; }
        public string SessionKey { get; set; }
        public HashSet<string> AuthMap { get; set; }
        //此应用中，不保留用户菜单，减少Session数据量
        //public List<ModuleVdm> UserMenus { get; set; }

        public SessionalUser() { }

        public SessionalUser(UserTdm u)
        {
            this.Id = u.Id;
            this.UserName = u.UserName;
            this.NickName = u.NickName;
            this.Email = u.Email;
            this.Mobile = u.Mobile;
            this.Gender = u.Gender;
            this.Slogan = u.Slogan;
            this.Avatar = u.Avatar;
        }
    }
}
