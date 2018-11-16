using Alva.ArTextBook.Types;
using System.Collections.Generic;
using Scietec.Combine.Inject;
using Scietec.Combine.Data;
using Alva.ArTextBook.TextBook.Workers;
using Alva.ArTextBook.TextBook.Tdm;

namespace Alva.ArTextBook.Kernel.Services
{
    [Repository]
    public class EditionService : ServiceBase
    {
        [Autowired]
        EditionWorker editionWorker = null;

        public EditionTdm FindById(long id)
        {
            return DbSessionManager.Execute<EditionTdm>((IDbSession sess) => {
                return editionWorker.FindById(sess, id);
            });
        }

        public List<EditionTdm> GetAll()
        {
            return DbSessionManager.Execute<List<EditionTdm>>((IDbSession sess) => {
                return editionWorker.GetAll(sess);
            });
        }

        //public UserTdm FindByUsername(string uname)
        //{
        //    return DbSessionManager.Execute<UserTdm>((IDbSession sess)=>{
        //        return userWorker.FindByUserName(sess,uname);
        //    });
        //}

        //public void Save(UserTdm user)
        //{
        //    DbSessionManager.Execute<int>((IDbSession sess) => {
        //        userWorker.Save(sess, user);
        //        return 0;
        //    });
        //}

        //public void Save(UserTdm user, List<long> roleIds)
        //{
        //    DbSessionManager.ExecuteWithTrans<int>((IDbSession sess) => {
        //        userWorker.Save(sess, user);
        //        foreach (var i in roleIds)
        //        {
        //            roleWorker.AddToRole(sess, user.Id, i);
        //        }
        //        return 0;
        //    });
        //}

        //public void Update(UserTdm user)
        //{
        //    DbSessionManager.Execute<int>((IDbSession sess) => {
        //        userWorker.Update(sess, user);
        //        return 0;
        //    });
        //}
    }
}
