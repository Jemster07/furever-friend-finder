using Capstone.Models;

namespace Capstone.DAO
{
    public interface ITagDao
    {
        Tag GetTag(int tagId);
        Tag CreateTag(Tag newTag);
        Tag UpdateTag(Tag updatedTags);
    }
}