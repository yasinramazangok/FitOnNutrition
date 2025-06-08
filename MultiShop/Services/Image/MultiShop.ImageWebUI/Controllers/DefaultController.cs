using Microsoft.AspNetCore.Mvc;
using MultiShop.ImageWebUI.DataAccessLayer.Entities;
using MultiShop.ImageWebUI.Services;

namespace MultiShop.ImageWebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly ICloudStorageService _cloudStorageService;

        public DefaultController(ICloudStorageService cloudStorageService)
        {
            _cloudStorageService = cloudStorageService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ImageDrive imageDrive)
        {
            if (imageDrive.Photo != null)
            {
                imageDrive.SavedFileName = GenerateFileNameToSave(imageDrive.Photo.FileName);
                imageDrive.SavedUrl = await _cloudStorageService.UploadFileAsync(imageDrive.Photo, imageDrive.SavedFileName);
            }
            return RedirectToAction("Index", "Default");
        }

        private string? GenerateFileNameToSave(string incomingFileName)
        {
            var fileName = Path.GetFileNameWithoutExtension(incomingFileName);
            var extension = Path.GetExtension(incomingFileName);
            return $"{fileName}-{DateTime.Now.ToUniversalTime().ToString("yyyyMMddHHmmss")}{extension}";
        }

        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.RefereeDrives == null)
        //    {
        //        return NotFound();
        //    }

        //    var referee = await _context.RefereeDrives.FindAsync(id);
        //    if (referee == null)
        //    {
        //        return NotFound();
        //    }
        //    await GenerateSignedUrl(referee);
        //    return View(referee);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Age,Photo,SavedUrl,SavedFileName")] RefereeDrive referee)
        //{
        //    if (id != referee.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            await ReplacePhoto(referee);
        //            _context.Update(referee);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!RefereeExists(referee.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction("RefereeDrive", "Admin");
        //    }
        //    return View(referee);
        //}

        //private async Task ReplacePhoto(RefereeDrive referee)
        //{
        //    if (referee.Photo != null)
        //    {
        //        //replace the file by deleting referee.SavedFileName file and then uploading new referee.Photo
        //        if (!string.IsNullOrEmpty(referee.SavedFileName))
        //        {
        //            await _cloudStorageService.DeleteFileAsync(referee.SavedFileName);
        //        }
        //        referee.SavedFileName = GenerateFileNameToSave(referee.Photo.FileName);
        //        referee.SavedUrl = await _cloudStorageService.UploadFileAsync(referee.Photo, referee.SavedFileName);
        //    }
        //}

        //public async Task<IActionResult> Delete(int id)
        //{
        //    if (_context.RefereeDrives == null)
        //    {
        //        return Problem("Entity set is null.");
        //    }
        //    var referee = await _context.RefereeDrives.FindAsync(id);
        //    if (referee != null)
        //    {
        //        if (!string.IsNullOrWhiteSpace(referee.SavedFileName))
        //        {
        //            await _cloudStorageService.DeleteFileAsync(referee.SavedFileName);
        //            referee.SavedFileName = String.Empty;
        //            referee.SavedUrl = String.Empty;
        //        }
        //        _context.RefereeDrives.Remove(referee);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction("RefereeDrive", "Admin");
        //}

        //private bool RefereeExists(int id)
        //{
        //    return _context.RefereeDrives.Any(e => e.Id == id);
        //}
    }
}
