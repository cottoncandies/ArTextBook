using Alva.ArTextBook.Types;
using Scietec.Combine.Data;
using Scietec.Combine.Inject;
using Alva.ArTextBook.Kernel.Where;
using Alva.ArTextBook.TextBook.Tdm;
using System.Collections.Generic;

namespace Alva.ArTextBook.TextBook.Workers
{
    [Repository]
    public class TextBookWorker : WorkerBase
    {
        #region SQL
        private const string SelectTextBook = @"
        select 
	        t.ng_id as Id,
	        t.sz_caption as Caption,
            t.ng_grade_id as GradeId,
            g.sz_caption as Grade,
            t.ng_subject_id as SubjectId,
            s.sz_caption as Subject,
            t.ng_publish_id as PublishId,
            p.sz_caption as Publish,
            t.ng_edition_id as EditionId,
            e.sz_caption as Edition,
            t.ng_editor_id as EditorId,
            ut.sz_uname as Editor,
            t.sz_oid as OId,
            t.sz_cover as Cover,
            t.sz_src_store as SrcStore,
            t.sz_src_md5 as SrcMd5,
            t.ng_src_size as SrcSize,
            t.sz_dst_store as DstStore,
            t.sz_dst_md5 as DstMd5,
            t.ng_dst_size as DstSize,
            t.sz_img_path as ImgPath,
            t.sz_res_path as ResPath,
            t.nt_state as State,
            t.ng_ctor_id as CreatorId,
	        uc.sz_uname as CreatorName,	
	        t.ng_uper_id as UpdaterId,
	        uu.sz_uname as UpdaterName,
	        t.ts_create as TimeCreate,
	        t.ts_update as TimeUpdate,
	        t.nt_r_state as RowState,
	        t.nt_r_ver as RowVersion
        from atb_textbook_t t 
            left join sys_user_t uc on t.ng_ctor_id=uc.ng_id
	        left join sys_user_t uu on t.ng_uper_id=uu.ng_id
	        left join atb_grade_t g on t.ng_grade_id=g.ng_id
	        left join atb_subject_t s on t.ng_subject_id=s.ng_id
	        left join atb_publish_t p on t.ng_publish_id=p.ng_id
	        left join atb_edition_t e on t.ng_edition_id=e.ng_id
            left join sys_user_t ut on t.ng_editor_id=ut.ng_id
    ";
        #endregion

        public Pagable<TextbookTdm> Find(IDbSession sess, UserWhere where)
        {
            return null;
        }

        public TextbookTdm FindById(IDbSession sess, long id)
        {
            SqlSelect ss = new SqlSelect(sess);
            ss.Sql = SelectTextBook;
            ss.Where = "u.ng_id=@userId";
            ss.AddParam("@userId", id);
            return ss.ExecuteSingle<TextbookTdm>();
        }

        public List<TextbookTdm> GetAll(IDbSession sess)
        {
            SqlSelect ss = new SqlSelect(sess);
            ss.Sql = SelectTextBook;
            ss.Where = "nt_r_state=@nt_r_state";
            ss.AddParam("nt_r_state", 1);
            return ss.ExecuteList<TextbookTdm>();
        }

        public void Save(IDbSession sess, TextbookTdm textbook)
        {
            if (textbook.Id == 0)
            {
                textbook.Id = sess.GetNextSequence("atb_textbook__id__seq");
            }

            SqlInsert ss = new SqlInsert(sess);
            ss.Sql = "atb_textbook_t";
            ss.Set("sz_oid", textbook.OId)
              .Set("sz_caption", textbook.Caption)
              .Set("ng_edition_id", textbook.EditionId)
              .Set("ng_subject_id", textbook.SubjectId)
              .Set("ng_publish_id", textbook.PublishId)
              .Set("ng_grade_id", textbook.GradeId)
              .Set("sz_src_store", textbook.SrcStore)
              .Set("sz_src_md5", textbook.SrcMd5)
              .Set("ng_src_size", textbook.SrcSize)
              .Set("sz_dst_store", textbook.DstStore)
              .Set("sz_dst_md5", textbook.DstMd5)
              .Set("ng_dst_size", textbook.DstSize)
              .Set("nt_state", textbook.State)
              .Set("ng_editor_id", textbook.EditorId)
              .Set("ng_ctor_id", textbook.CreatorId)
              .Set("ng_uper_id", textbook.UpdaterId);
            ss.ExecuteNonQuery();
        }

        public void Update(IDbSession sess, TextbookTdm textbook)
        {
            var ss = new SqlUpdate(sess);
            ss.Sql = "atb_textbook_t";
            ss.Where = "ng_id=@ng_id";
            ss.Set("ng_editor_id", textbook.EditorId)
               .Set("nt_state", textbook.State)
               .Set("sz_dst_store", textbook.DstStore)
               .Set("sz_dst_md5", textbook.DstMd5)
               .Set("ng_dst_size", textbook.DstSize)
               .Set("ng_uper_id", textbook.UpdaterId)
               .AddParam("ng_id", textbook.Id);
            ss.ExecuteNonQuery();
        }

        public void Delete(IDbSession sess, TextbookTdm textbook)
        {
            var ss = new SqlUpdate(sess);
            ss.Sql = "atb_textbook_t";
            ss.Where = "ng_id=@ng_id";
            ss.Set("nt_r_state", 0)
              .AddParam("ng_id", textbook.Id);
            ss.ExecuteNonQuery();
        }
    }
}
