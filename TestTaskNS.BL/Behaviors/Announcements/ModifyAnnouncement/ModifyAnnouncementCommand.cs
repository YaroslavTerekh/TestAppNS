﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TestTaskNS.Domain.Entities;

namespace TestTaskNS.BL.Behaviors.Announcements.ModifyAnnouncement;

public class ModifyAnnouncementCommand : IRequest<Announcement>
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string AuthorEmail { get; set; }
}
