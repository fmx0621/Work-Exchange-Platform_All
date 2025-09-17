using System;
using System.Linq;
using System.Threading.Tasks;
using Job.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Job.Areas.Back.Controllers
{
    [Area("Back")]
    public class ProfilesController : Controller
    {
        private readonly JobDbContext _context;
        public ProfilesController(JobDbContext context) => _context = context;

        // GET: d/Profiles
        public async Task<IActionResult> List()
        {
            var list = await _context.TMemberProfiles
                .OrderByDescending(x => x.UpdatedAt ?? x.CreatedAt)
                .ToListAsync();
            return View(list);
        }

        // GET: d/Profiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null) return NotFound();
            var row = await _context.TMemberProfiles.FirstOrDefaultAsync(m => m.ProfileId == id);
            if (row is null) return NotFound();
            return View(row);
        }

        // GET: d/Profiles/Create
        public IActionResult Create() => View();

        // POST: d/Profiles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(
            "ProfileId,MemberId,Name,Sex,BirthDate,ProfilePicture," +
            "Education,Languages,WorkExperience,Licenses," +
            "AvailableFrom,AvailableTo,PreferredCategories,ExpectedBenefits,Motivation,ContactIG"
        )] TMemberProfile p)
        {
            if (!ModelState.IsValid) return View(p);

            p.CreatedAt = DateTime.UtcNow;
            p.UpdatedAt = DateTime.UtcNow;

            _context.Add(p);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: d/Profiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return NotFound();
            var row = await _context.TMemberProfiles.FindAsync(id);
            if (row is null) return NotFound();
            return View(row);
        }

        // POST: d/Profiles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind(
            "ProfileId,MemberId,Name,Sex,BirthDate,ProfilePicture," +
            "Education,Languages,WorkExperience,Licenses," +
            "AvailableFrom,AvailableTo,PreferredCategories,ExpectedBenefits,Motivation,ContactIG"
        )] TMemberProfile form)
        {
            if (id != form.ProfileId) return NotFound();
            if (!ModelState.IsValid) return View(form);

            var db = await _context.TMemberProfiles.FindAsync(id);
            if (db is null) return NotFound();

            // 可編輯欄位
            db.MemberId = form.MemberId;
            db.Name = form.Name;
            db.Sex = form.Sex;
            db.BirthDate = form.BirthDate;               // Date 或 DateTime? 皆可
            db.ProfilePicture = form.ProfilePicture;

            db.Education = form.Education;
            db.Languages = form.Languages;
            db.WorkExperience = form.WorkExperience;
            db.Licenses = form.Licenses;

            db.AvailableFrom = form.AvailableFrom;
            db.AvailableTo = form.AvailableTo;
            db.PreferredCategories = form.PreferredCategories;
            db.ExpectedBenefits = form.ExpectedBenefits;
            db.Motivation = form.Motivation;
            db.ContactIg = form.ContactIg;

            db.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: d/Profiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return NotFound();
            var row = await _context.TMemberProfiles.FirstOrDefaultAsync(m => m.ProfileId == id);
            if (row is null) return NotFound();
            return View(row);
        }

        // POST: d/Profiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var row = await _context.TMemberProfiles.FindAsync(id);
            if (row != null) _context.TMemberProfiles.Remove(row);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TMemberProfileExists(int id) =>
            _context.TMemberProfiles.Any(e => e.ProfileId == id);
    }
}
