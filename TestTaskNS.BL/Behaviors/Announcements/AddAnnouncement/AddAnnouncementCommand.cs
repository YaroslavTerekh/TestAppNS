using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskNS.Domain.Entities;

namespace TestTaskNS.BL.Behaviors.Announcements.AddAnnouncement;

public class AddAnnouncementCommand : IRequest<Announcement>
{
    public string Title { get; set; }

    public string Description { get; set; }

    public string AuthorName { get; set; }

    public string AuthorEmail { get; set; }
}
