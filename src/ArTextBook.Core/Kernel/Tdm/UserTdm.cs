using Alva.ArTextBook.Kernel.Types;
using Alva.ArTextBook.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alva.ArTextBook.Kernel.Tdm
{
    
    public class UserTdm: EntityBase
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string NickName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public String Mobile { get; set; }
        public UserKind Kind { get; set; } = UserKind.User;
        public GenderKind Gender { get; set; } = GenderKind.Unknown;
        public string Slogan { get; set; }
        public string Avatar { get; set; }            
        public bool Locked { get; set; } = false;
        public DateTime? TimeLocked { get; set; }
        public int FailCount { get; set; } = 0;
        public int LoginCount { get; set; } = 0;
        public DateTime? LastLogin { get; set; }
        public int State { get; set; } = 0;

        public UserTdm() { }

        public UserTdm(long id)
        {
            this.Id = id;
        }
    }
}
