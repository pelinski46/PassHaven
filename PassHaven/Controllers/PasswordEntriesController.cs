using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PassHaven.Data;
using PassHaven.Models;

namespace PassHaven.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PasswordEntriesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PasswordEntriesController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<List<PasswordEntry>> GetPasswordAsync()
    {
        return await _context.PasswordEntries.ToListAsync();
    }

    [HttpPost("add")]
    public async Task<ActionResult> AddPasswordAsync(PasswordEntry passwordEntry)
    {
        _context.PasswordEntries.Add(passwordEntry);
        await _context.SaveChangesAsync();

        return Ok(passwordEntry);
    }

    [HttpPost("edit")]
    public async Task<IActionResult> EditPasswordAsync(PasswordEntry passwordEntry)
    {
        _context.Entry(passwordEntry).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return Ok(passwordEntry);
    }

    [HttpPost("delete")]
    public async Task<IActionResult> DeletepasswordAsync(int passwordEntryId)
    {
        var passwordEntry = await _context.PasswordEntries.FindAsync(passwordEntryId);
        if (passwordEntry == null)
        {
            return NotFound();
        }

        _context.PasswordEntries.Remove(passwordEntry);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}

