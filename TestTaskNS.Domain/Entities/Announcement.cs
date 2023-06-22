using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskNS.Domain.Entities;

public class Announcement : BaseEntity
{
    public string Title { get; set; }

    public string Description { get; set; }

    public string AuthorName { get; set; }

    public string AuthorEmail { get; set; }
}
