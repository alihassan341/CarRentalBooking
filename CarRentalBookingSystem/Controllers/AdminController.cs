using Car_Rental_booking.Model;
using CarRentalBookingSystem.Data;
using Castle.Core.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class AdminController : Controller
{
    private readonly Contaxt _context;
    //private readonly UserManager<ApplicationUser> _userManager;
    //private readonly SignInManager<ApplicationUser> _signInManager;
    //private readonly IEmailSender _emailSender;

   
    public AdminController(Contaxt context)
        //,UserManager<ApplicationUser> userManager,
        //                          SignInManager<ApplicationUser> signInManager,
        //                          IEmailSender emailSender)
    {
        //_userManager = userManager;
        //_signInManager = signInManager;
        //_emailSender = emailSender;
        _context = context;
    }

    // GET: Admin
    public async Task<IActionResult> Index()
    {
        return View(await _context.Admins.ToListAsync());
    }

    // GET: Admin/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var admin = await _context.Admins
            .FirstOrDefaultAsync(m => m.Id == id);
        if (admin == null)
        {
            return NotFound();
        }

        return View(admin);
    }

    // GET: Admin/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Admin/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,PhoneNumber,PetName,Password")] Admin admin)
    {
        if (ModelState.IsValid)
        {
            _context.Add(admin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(admin);
    }

    // GET: Admin/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var admin = await _context.Admins.FindAsync(id);
        if (admin == null)
        {
            return NotFound();
        }
        return View(admin);
    }

    // POST: Admin/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,PhoneNumber,PetName,Password")] Admin admin)
    {
        if (id != admin.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(admin);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminExists(admin.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(admin);
    }

    // GET: Admin/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var admin = await _context.Admins
            .FirstOrDefaultAsync(m => m.Id == id);
        if (admin == null)
        {
            return NotFound();
        }

        return View(admin);
    }

    // POST: Admin/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var admin = await _context.Admins.FindAsync(id);
        if (admin == null)
        {
            return NotFound();
        }
        _context.Admins.Remove(admin);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
   

    //[HttpGet]
    //[AllowAnonymous]
    //public IActionResult ForgotPassword()
    //{
    //    return View();
    //}

    //[HttpPost]
    //[AllowAnonymous]
    //[ValidateAntiForgeryToken]
    //public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        var user = await _userManager.FindByEmailAsync(model.Email);
    //        if (user == null)
    //        {
    //            return RedirectToAction(nameof(ForgotPasswordConfirmation));
    //        }

    //        var code = await _userManager.GeneratePasswordResetTokenAsync(user);
    //        var callbackUrl = Url.ResetPasswordCallbackLink(user.Id, code, Request.Scheme);
    //        await _emailSender.SendEmailAsync(model.Email, "Reset Password",
    //            $"Please reset your password by clicking here: <a href='{callbackUrl}'>link</a>");
    //        return RedirectToAction(nameof(ForgotPasswordConfirmation));
    //    }

    //    return View(model);
    //}

    //[HttpGet]
    //[AllowAnonymous]
    //public IActionResult ForgotPasswordConfirmation()
    //{
    //    return View();
    //}

    //[HttpGet]
    //public IActionResult ChangePassword()
    //{
    //    return View();
    //}

    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        var user = await _userManager.GetUserAsync(User);
    //        if (user == null)
    //        {
    //            return NotFound();
    //        }

    //        var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
    //        if (!result.Succeeded)
    //        {
    //            foreach (var error in result.Errors)
    //            {
    //                ModelState.AddModelError(string.Empty, error.Description);
    //            }
    //            return View(model);
    //        }

    //        await _signInManager.RefreshSignInAsync(user);
    //        return RedirectToAction(nameof(Index));
    //    }

    //    return View(model);
    //}

    private bool AdminExists(int id)
    {
        return _context.Admins.Any(e => e.Id == id);
    }
}
