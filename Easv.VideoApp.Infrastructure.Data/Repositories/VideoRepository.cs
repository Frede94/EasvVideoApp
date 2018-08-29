using Easv.VideoApp.Core.DomainService;
using Easv.VideoApp.Core.Entity;
using System;
using System.Collections.Generic;

namespace Easv.VideoApp.Infrastructure.Data.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        static int id = 1;
        private List<Video> _videos = new List<Video>();

        public Video Create(Video video)
        {
            video.Id = id++;
            _videos.Add(video);
            return video;
        }

        public Video ReadById(int id)
        {
            foreach (var video in _videos)
            {
                if (video.Id == id)
                {
                    return video;
                }
            }
            return null;            
        }
        public List<Video> ReadAll()
        {
            return _videos;
        }

        public Video Update(Video videoUpdate)
        {
            var videoFraDB = this.ReadById(videoUpdate.Id);
            if (videoFraDB != null)
            {
                videoFraDB.Name = videoUpdate.Name;
                videoFraDB.Genre = videoUpdate.Genre;
                return videoFraDB;
            }
            return null;
        }

        public Video delete(int id)
        {
            var videoFundet = this.ReadById(id);

            if (videoFundet != null)
            {
                _videos.Remove(videoFundet);
                return videoFundet;
            }
            return null;
        }
    }
}
