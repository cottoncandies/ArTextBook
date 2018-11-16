using Alva.ArTextBook.Kernel.Types;
using Alva.ArTextBook.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alva.ArTextBook.Kernel.Tdm
{
    public class OAuthTdm
    {
        public long Id { get; set; }
        public OAuthKind Kind { get; set; } = OAuthKind.WeChat;
        public string OpenId { get; set; }
        public long UserId { get; set; }
        public string NickName { get; set; }
        public GenderKind Gender { get; set; } = GenderKind.Unknown;
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Language { get; set; }
        public string AvatarUri { get; set; }
        public string UnionId { get; set; }
        public DateTime TimeCreate { get; set; }
        public DateTime TimeUpdate { get; set; }
        public RowState RowState { get; set; } = RowState.Normal;
        public int RowVersion { get; set; } = 1;
    }
}
