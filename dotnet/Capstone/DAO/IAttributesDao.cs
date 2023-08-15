using Capstone.Models;

namespace Capstone.DAO
{
    public interface IAttributesDao
    {
        Attributes GetAttribute(int attribute_Id);
        Attributes CreateAttribute(NewAttributes newAttributes);
        Attributes UpdateAttribute(Attributes updatedAttributes);
    }
}