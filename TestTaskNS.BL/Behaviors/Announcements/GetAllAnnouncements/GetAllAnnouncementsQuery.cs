using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskNS.Domain.Entities;

namespace TestTaskNS.BL.Behaviors.Announcements.GetAllAnnouncements;

public class GetAllAnnouncementsQuery : IRequest<List<Announcement>>
{
}
