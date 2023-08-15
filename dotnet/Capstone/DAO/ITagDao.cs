using Capstone.Models;

namespace Capstone.DAO
{
    public interface ITagDao
    {
        Tag GetTag(int tagId);
        Tag CreateTag(NewTag newTag);
        Tag UpdateTag(Tag updatedTags);
    }
}