using MVC_MobileBankApp.ApplicationContext;
using MVC_MobileBankApp.Models;
using MVC_MobileBankApp.Repositories;

namespace MVC_MobileBankApp.Repositories.Implementations
{
    public class CEORepository : ICEORepository
    {
         private readonly ApplicationDbContext _context;
        public CEORepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public CEO CreateCEO(CEO ceo)
        {
           _context.CEOs.Add(ceo);
           _context.SaveChanges();
           return ceo;
        }

        public CEO DeleteCEO(CEO ceo)
        {
             _context.CEOs.Update(ceo);
            _context.SaveChanges();
            return ceo;
            
        }

        public IList<CEO> GetAllCEO()
        {
           return _context.CEOs.ToList();
        }

        public CEO GetCEOById(string ceoId)
        {
             var manager =_context.CEOs.SingleOrDefault(a => a.CEOId == ceoId);
            return manager;
        }

        public CEO Login(string email, string passWord)
        {
            return _context.CEOs.SingleOrDefault(a => a.Email == email && a.PassWord == passWord);
        }

        public CEO UpdateCEO(CEO ceo)
        {
           
            _context.CEOs.Update(ceo);
            _context.SaveChanges();
            return ceo;
        }
    }
}