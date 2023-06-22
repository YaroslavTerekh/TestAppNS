using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskNS.Domain.Entities;

namespace TestTaskNS.Domain.DataTransferObjects;

public class AnnouncementDTO : Announcement
{
    public List<Announcement> SimilarAnnouncements { get; set; }
}
