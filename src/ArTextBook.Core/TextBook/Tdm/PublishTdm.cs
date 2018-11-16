using Alva.ArTextBook.Types;

namespace Alva.ArTextBook.TextBook.Tdm
{
    public class PublishTdm: EntityBase
    {
        public long Id { get; set; }
        public string Caption { get; set; }

        public PublishTdm() { }

        public PublishTdm(long id)
        {
            this.Id = id;
        }
    }
}
