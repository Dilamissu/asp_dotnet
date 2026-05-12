using DotnetPractice.Models;
namespace DotnetPractice.Repository.Interface;
public interface IUserRepository
{
    public bool AddUser(User user);
    public bool RemoveUser(User user);
}