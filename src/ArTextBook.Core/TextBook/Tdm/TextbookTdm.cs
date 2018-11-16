using Alva.ArTextBook.Types;

namespace Alva.ArTextBook.TextBook.Tdm
{
    public class TextbookTdm : EntityBase
    {
        public long Id { get; set; }
        public long GradeId { get; set; }
        public long EditionId { get; set; }
        public long SubjectId { get; set; }
        public long PublishId { get; set; }
        public long EditorId { get; set; }
        public string OId { get; set; }
        public string Grade { get; set; }
        public string Edition { get; set; }
        public string Subject { get; set; }
        public string Publish { get; set; }
        public string Editor { get; set; }
        public string Caption { get; set; }
        public string Cover { get; set; } = "00000.jpg";
        public string SrcStore { get; set; }
        public string SrcMd5 { get; set; }
        public long SrcSize { get; set; } = 0;
        public string DstStore { get; set; } 
        public string DstMd5 { get; set; }
        public long DstSize { get; set; } = 0;
        public string ImgPath { get; set; }
        public string ResPath { get; set; }
        public int State { get; set; } = 0;
       
        public TextbookTdm() { }

        public TextbookTdm(long id)
        {
            this.Id = id;
        }
    }
}
