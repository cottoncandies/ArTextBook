using Alva.ArTextBook.Types;
using System.Collections.Generic;
using Scietec.Combine.Inject;
using Scietec.Combine.Data;
using Alva.ArTextBook.TextBook.Workers;
using Alva.ArTextBook.TextBook.Tdm;

namespace Alva.ArTextBook.Kernel.Services
{
    [Repository]
    public class TextBookService : ServiceBase
    {
        [Autowired]
        TextBookWorker textBookWorker = null;

        public TextbookTdm FindById(long id)
        {
            return DbSessionManager.Execute<TextbookTdm>((IDbSession sess) => {
                return textBookWorker.FindById(sess, id);
            });
        }

        public List<TextbookTdm> GetAll()
        {
            return DbSessionManager.Execute<List<TextbookTdm>>((IDbSession sess) => {
                return textBookWorker.GetAll(sess);
            });
        }

        //public UserTdm FindByUsername(string uname)
        //{
        //    return DbSessionManager.Execute<UserTdm>((IDbSession sess)=>{
        //        return userWorker.FindByUserName(sess,uname);
        //    });
        //}

        public void Save(TextbookTdm textbook)
        {
            DbSessionManager.Execute<int>((IDbSession sess) =>
            {
                textBookWorker.Save(sess, textbook);
                return 0;
            });
        }

        //public void Update(UserTdm user)
        //{
        //    DbSessionManager.Execute<int>((IDbSession sess) => {
        //        userWorker.Update(sess, user);
        //        return 0;
        //    });
        //}
    }
}
