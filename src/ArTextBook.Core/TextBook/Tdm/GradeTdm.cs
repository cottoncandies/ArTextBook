using Alva.ArTextBook.Types;

namespace Alva.ArTextBook.TextBook.Tdm
{
    public class GradeTdm: EntityBase
    {
        public long Id { get; set; }
        public string Caption { get; set; }
        public int Section { get; set; }
        public string Insti { get; set; }

        public GradeTdm() { }

        public GradeTdm(long id)
        {
            this.Id = id;
        }
    }
}
