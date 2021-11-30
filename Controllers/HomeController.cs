using Microsoft.AspNetCore.Mvc;
using AccountManager.Models.Contexts;
using AccountManager.Models;
using System.Linq;
namespace AccountManager.Controllers
{
    public class HomeController : Controller
    {
        private AccountContext _context;
        public HomeController(AccountContext context)
        {
            _context = context;
        }

        public IActionResult Index(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                return View(_context.OnlineAccounts.Where(account => account.Name.Contains(searchString))
                                                   .AsEnumerable()
                                                   .OrderByDescending(account => account.Id));
            }

            return  View(_context.OnlineAccounts.AsEnumerable().OrderByDescending(account => account.Id));
        }

        public IActionResult NewAccount()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult NewAccount(OnlineAccount account)
        {
            if (ModelState.IsValid)
            {
                _context.OnlineAccounts.Add(account);
                _context.SaveChanges();
            }
            else
            {
                return View();
            }

            return RedirectToAction("Index");
        }

        public IActionResult EditAccount(int id)
        {
            var account = _context.OnlineAccounts.First(acct => acct.Id == id);

            return View(account);
        }

        [HttpPost]
        public IActionResult EditAccount(OnlineAccount account)
        {
            if (ModelState.IsValid)
            {
                _context.OnlineAccounts.Update(account);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult DeleteAccount(int id)
        {
            if (_context.OnlineAccounts.Any(account => account.Id == id))
            {
                OnlineAccount accountToRemove = _context.OnlineAccounts.First(account => account.Id == id);

                _context.OnlineAccounts.Remove(accountToRemove);

                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}