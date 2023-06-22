using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TestTaskNS.Domain.DataTransferObjects;

namespace TestTaskNS.BL.Behaviors.Announcements.GetAnnouncement;

public class GetAnnouncementQuery : IRequest<AnnouncementDTO>
{
    public Guid Id { get; set; }

    public GetAnnouncementQuery(Guid id) => Id = id; 
}
