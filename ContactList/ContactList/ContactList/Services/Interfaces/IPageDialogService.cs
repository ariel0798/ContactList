using System.Threading.Tasks;

namespace ContactList.Services.Interfaces
{
    public interface IPageDialogService
    {
        Task<string> DisplayActionSheet(string call, string edit);
    }
}
