using Alva.ArTextBook.Types;

namespace Alva.ArTextBook.TextBook.Tdm
{
    public class EditionTdm: EntityBase
    {
        public long Id { get; set; }
        public string Caption { get; set; }

        public EditionTdm() { }

        public EditionTdm(long id)
        {
            this.Id = id;
        }
    }
}
