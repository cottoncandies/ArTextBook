using System;
using System.Collections.Generic;
using System.Text;

namespace Alva.ArTextBook.Kernel.Tdm
{
    public class UserQuestionAnswer
    {
        public long Id { get; set; }
        public UserTdm User { get; set; }
        public String Question { get; set; }
        public String Answer { get; set; }
        public int Order { get; set; }
        public DateTime TimeCreate { get; set; }
        public DateTime TimeUpdate { get; set; }
        public int RowVersion { get; set; }

        public UserQuestionAnswer() { }

        public UserQuestionAnswer(long id)
        {
            this.Id = id;
        }
    }
}
