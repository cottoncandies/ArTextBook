using Alva.ArTextBook.Types;

namespace Alva.ArTextBook.TextBook.Tdm
{
    public class SubjectTdm: EntityBase
    {
        public long Id { get; set; }
        public string Caption { get; set; }

        public SubjectTdm() { }

        public SubjectTdm(long id)
        {
            this.Id = id;
        }
    }
}
