using basicFunctions_DB.BLL.DTO;
using basicFunctions_DB.BLL.Interfaces;
using basicFunctions_DB.DAL;
using basicFunctions_DB.DAL.MaterialType;
using Microsoft.EntityFrameworkCore;

namespace basicFunctions_DB.BLL.DataServices
{
    internal class VideoService : IVideoService
    {
        private readonly ApplicationContext _context;

        public VideoService(ApplicationContext context)
        {
            this._context = context;
        }

        public async Task CreateAsync(VideoDTO videoDTO)
        {
            await this._context.Materials.AddAsync(new Video
            {
                Title = videoDTO.Title,
                Duration = videoDTO.Duration,
                Resolution = videoDTO.Resolution,
                CreatorUserName = videoDTO.CreatorUserName
            });

            await this._context.SaveChangesAsync();
        }

        public async Task<List<VideoDTO>> GetAllAsync()
        {
            var videos = await this._context.Videos.ToListAsync();
            List<VideoDTO> videoDTOs = new List<VideoDTO>();
            foreach (var item in videos)
            {
                VideoDTO videoDTO = new VideoDTO
                {
                    Resolution = item.Resolution,
                    Duration = item.Duration,
                    CreatorUserName = item.CreatorUserName,
                    Id = item.Id,
                    Title = item.Title
                };

                videoDTOs.Add(videoDTO);
            }

            return videoDTOs;
        }

        public async Task<VideoDTO?> GetAsync(int id)
        {
            var video = await this._context.Videos.FirstOrDefaultAsync(x => x.Id == id);
            VideoDTO videoDTO = null;

            if (video != null)
            {
                videoDTO = new VideoDTO
                {
                    Resolution = video.Resolution,
                    Duration = video.Duration,
                    CreatorUserName = video.CreatorUserName,
                    Id = video.Id,
                    Title = video.Title
                };

                return videoDTO;
            }
            else
            {
                return videoDTO;
            }
        }

        public async Task UpdateAsync(VideoDTO videoDTO)
        {
            var video = await this._context.Videos.FirstOrDefaultAsync(x => x.Id == videoDTO.Id);

            if (video != null)
            {
                video.Title = videoDTO.Title;
                video.Resolution = videoDTO.Resolution;
                video.Duration = videoDTO.Duration;
                video.CreatorUserName = videoDTO.CreatorUserName;

                await this._context.SaveChangesAsync();
            }
        }
    }
}
