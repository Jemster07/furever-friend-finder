using Capstone.Models;

namespace Capstone.DAO
{
    public interface IAddressDao
    {
        Address GetAddress(int addressId);
        Address CreateAddress(CreateAddress newAddress);
        Address UpdateAddress(Address updatedAddress);
    }
}
