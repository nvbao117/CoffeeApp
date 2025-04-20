using BLL.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
namespace BLL.Mappers
{
    public class ActivityMapper
    {
        public static ActivityDTO ToDTO(RecentActivity activity)
        {
            if (activity == null) return null;

            return new ActivityDTO
            {
                Action = activity.Action,
                Target = activity.Target,
                Description = activity.Description,
                UserName = activity.UserName,
                Timestamp = activity.Timestamp
            };
        }

        public static RecentActivity ToEntity(ActivityDTO dto)
        {
            if (dto == null) return null;

            return new RecentActivity
            {
                Action = dto.Action,
                Target = dto.Target,
                Description = dto.Description,
                UserName = dto.UserName,
                Timestamp = dto.Timestamp
            };
        }
        public static List<ActivityDTO> ToDTOList(IEnumerable<RecentActivity> entities)
              => entities.Select(ToDTO).ToList();
    }
}
