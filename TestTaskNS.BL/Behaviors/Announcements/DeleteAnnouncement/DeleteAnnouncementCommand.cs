using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TestTaskNS.BL.Behaviors.Announcements.DeleteAnnouncement;

public class DeleteAnnouncementCommand : IRequest
{
    [JsonIgnore]
    public Guid Id { get; set; }

    public DeleteAnnouncementCommand(Guid id) => Id = id;
}
