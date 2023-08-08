using Capstone.Models;

namespace Capstone.DAO
{
    public interface IAddressDao
    {
        Address GetAddress(int userId);
        Address CreateAddress(int userId, Address newAddress);
        Address UpdateAddress(int userId, Address updatedAddress);
    }
}
