using Urnaus.Shared;
using Task = System.Threading.Tasks.Task;

namespace Urnaus.Server.Interface;

public interface IContactRepository
{
    Task<List<Contact>> GetAll();
    Task AddContact(Contact contact);
    Task Delete(int id);
}