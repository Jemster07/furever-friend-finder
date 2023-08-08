using Capstone.Models;

namespace Capstone.DAO
{
    public interface IAddressDao
    {
        Address GetAddress(int addressId);
        Address CreateAddress(Address newAddress);
        Address UpdateAddress(Address updatedAddress);
    }
}
