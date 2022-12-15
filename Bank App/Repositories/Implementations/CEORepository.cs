using Bank_App.Models;
using MVC_MobileBankApp.ApplicationContext;
using MVC_MobileBankApp.Repositories;

namespace Bank_App.Repositories.Implementations
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

        public void DeleteCEOUsingCEOId(CEO ceoId)
        {
            _context.CEOs.Remove(ceoId);
            _context.SaveChanges();
            
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