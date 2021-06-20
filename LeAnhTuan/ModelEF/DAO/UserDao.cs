using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelEF.Model;
using PagedList;

namespace ModelEF.DAO
{
    public class UserDao
    {
        AnhTuanContext db = null;
        public UserDao()
        {
            db = new AnhTuanContext();
        }
        public long Insert(UserAccount entity)
        {
            db.UserAccount.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(UserAccount entity)
        {
            try
            {
                var User = db.UserAccount.Find(entity.ID);
                if(!string.IsNullOrEmpty(entity.Password))
                {
                    User.Password = entity.Password;
                }
                User.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }
        public IEnumerable<UserAccount> ListAllPaging(string searchString,int page, int pageSize)
        {
            IQueryable<UserAccount> model = db.UserAccount;
            if(!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Username.Contains(searchString) || x.Status.Contains(searchString));
            }
            return model.OrderBy(x=>x.ID).ToPagedList(page, pageSize);
        }
        public UserAccount GetByID(string userName)
        {
            return db.UserAccount.SingleOrDefault(x=>x.Username == userName);
        }
        public UserAccount ViewDetail(int id)
        {
            return db.UserAccount.Find(id);
        }
        public int Login(string Username , string Password)
        {
            var result = db.UserAccount.SingleOrDefault(x => x.Username == Username);
            if(result == null)
            {
                return 0;
            }
            else
            {
               if(result.Status == "Blocked")
                {
                    return -1;
                }
               else
                {
                    if (result.Password == Password)
                        return 1;
                    else
                        return -2;
                }
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.UserAccount.Find(id);
                db.UserAccount.Remove(user);
                db.SaveChanges();
                return true;
            }catch (Exception)
            {
                return false;
            }
          
        }
       
    }
}
