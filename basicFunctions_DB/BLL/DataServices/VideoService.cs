namespace basicFunctions_DB.BLL.DataServices
{
    using basicFunctions_DB.BLL.DTO;
    using basicFunctions_DB.BLL.Interfaces;
    using basicFunctions_DB.DAL;
    using basicFunctions_DB.DAL.MaterialType;
    using Microsoft.EntityFrameworkCore;

    internal class VideoService : IVideoService
    {
        private readonly ApplicationContext _context;

        public VideoService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(VideoDTO videoDTO)
        {
            await _context.Materials.AddAsync(new Video
            {
                Title = videoDTO.Title,
                Duration = videoDTO.Duration,
                Resolution = videoDTO.Resolution,
                Creator = videoDTO.Creator
            });

            await _context.SaveChangesAsync();
        }

        public async Task<List<VideoDTO>> GetAllAsync()
        {
            var videos = await _context.Videos.Include(x => x.Creator).ToListAsync();
            List<VideoDTO> videoDTOs = new List<VideoDTO>();
            foreach (var item in videos)
            {
                VideoDTO videoDTO = new VideoDTO
                {
                    Resolution = item.Resolution,
                    Duration = item.Duration,
                    Creator = item.Creator,
                    Id = item.Id,
                    Title = item.Title
                };

                videoDTOs.Add(videoDTO);
            }

            return videoDTOs;
        }

        public async Task<VideoDTO?> GetAsync(int id)
        {
            var video = await _context.Videos.Include(x => x.Creator).FirstOrDefaultAsync(x => x.Id == id);
            VideoDTO videoDTO = null;

            if (video != null)
            {
                videoDTO = new VideoDTO
                {
                    Resolution = video.Resolution,
                    Duration = video.Duration,
                    Creator = video.Creator,
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
            var video = await _context.Videos.FirstOrDefaultAsync(x => x.Id == videoDTO.Id);

            if (video != null)
            {
                video.Title = videoDTO.Title;
                video.Resolution = videoDTO.Resolution;
                video.Duration = videoDTO.Duration;
                video.Creator = videoDTO.Creator;

                await _context.SaveChangesAsync();
            }
        }
    }
}
