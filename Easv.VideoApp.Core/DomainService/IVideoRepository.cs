using Easv.VideoApp.Core.Entity;
using System.Collections.Generic;

namespace Easv.VideoApp.Core.DomainService
{
    public interface IVideoRepository
    {
        Video Create(Video video);

        Video ReadById(int id);
        List<Video> ReadAll();

        Video Update(Video videoUpdate);

        Video delete(int id);
    }
}
