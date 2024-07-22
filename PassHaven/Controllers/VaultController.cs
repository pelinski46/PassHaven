using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PassHaven.Data;
using PassHaven.Models;

namespace PassHaven.Controllers;
[Route("api/[controller]")]
[ApiController]
public class VaultController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public VaultController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<List<Vault>> GetVaultsAsync()
    {
        return await _context.Vaults.ToListAsync();
    }

    [HttpPost("add")]
    public async Task<ActionResult> AddVaultAsync(Vault vault)
    {
        _context.Vaults.Add(vault);
        await _context.SaveChangesAsync();

        return Ok(vault);
    }

    [HttpPost("edit")]
    public async Task<IActionResult> EditVaultAsync(Vault vault)
    {
        _context.Entry(vault).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return Ok(vault);
    }

    [HttpPost("delete")]
    public async Task<IActionResult> DeleteVaultAsync(int vaultId)
    {
        var vault = await _context.Vaults.FindAsync(vaultId);
        if (vault == null)
        {
            return NotFound();
        }

        _context.Vaults.Remove(vault);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}

