using Capstone.Models;

namespace Capstone.DAO
{
    public interface IAttributesDao
    {
        Attributes GetAttribute(int attribute_Id);
        Attributes CreateAttribute(Attributes newAttributes);
        Attributes UpdateAttribute(Attributes updatedAttributes);

    }
}