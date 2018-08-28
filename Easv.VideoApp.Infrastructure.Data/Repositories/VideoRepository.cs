using Easv.VideoApp.Core.DomainService;
using Easv.VideoApp.Core.Entity;
using System;
using System.Collections.Generic;

namespace Easv.VideoApp.Infrastructure.Data.Repositories
{
    class VideoRepository : IVideoRepository
    {
        static int id = 1;
        static List<Video> videos = new List<Video>();

        public Video Create(Video video)
        {
            throw new NotImplementedException();
        }

        public List<Video> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Video ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public Video Update(Video videoUpdate)
        {
            throw new NotImplementedException();
        }

        public Video delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
