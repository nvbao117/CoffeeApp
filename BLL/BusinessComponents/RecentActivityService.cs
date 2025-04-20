using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.BusinessEntities;
using BLL.Mappers;
using DAL.Repositories;
namespace BLL.BusinessComponents
{
    public class RecentActivityService
    {
        private readonly ActivityRepository _activityRepo;

        public RecentActivityService()
        {
            _activityRepo = new ActivityRepository();
        }

        public void Log(string action, string target, string description, string userName)
        {
            var dto = new ActivityDTO
            {
                Action = action,
                Target = target,
                Description = description,
                UserName = userName,
                Timestamp = DateTime.Now
            };

            var entity = ActivityMapper.ToEntity(dto);
            _activityRepo.Add(entity);
        }

        public List<ActivityDTO> GetRecentActivities(int count = 20)
        {
            var recent = _activityRepo.GetRecent(count);
            return ActivityMapper.ToDTOList(recent);
        }
    }
}
