using Microsoft.EntityFrameworkCore;
using Urnaus.Server.Data;
using Urnaus.Server.Interface;
using Urnaus.Shared;
using Task = System.Threading.Tasks.Task;

namespace Urnaus.Server.Repository;

public class ContactRepository : IContactRepository
{
    private readonly AppDbContext _context;

    public ContactRepository(AppDbContext context) => _context = context;

    public async Task<List<Contact>> GetAll()
    {
        var contacts = await _context.Contact.ToListAsync();

        return contacts;
    }

    public async Task AddContact(Contact contact)
    {
        _context.Contact.Add(contact);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var contact = await _context.Contact.FindAsync(id);
        if (contact != null)
        {
            _context.Contact.Remove(contact);
            await _context.SaveChangesAsync();
        }
    }
}