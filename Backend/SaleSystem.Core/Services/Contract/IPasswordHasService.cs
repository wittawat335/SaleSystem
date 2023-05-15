
namespace SaleSystem.Core.Services.Contract
{
    public interface IPasswordHasService
    {
        string Hash(string password);
        bool Verify(string passwordHash, string inputPassword);
    }
}
