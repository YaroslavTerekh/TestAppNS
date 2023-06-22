using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskNS.BL.DbConnection;
using TestTaskNS.Domain.Entities;

namespace TestTaskNS.BL.Behaviors.Announcements.GetAllAnnouncements;

public class GetAllAnnouncementsHandler : IRequestHandler<GetAllAnnouncementsQuery, List<Announcement>>
{
    private readonly DataContext _context;

    public GetAllAnnouncementsHandler(DataContext context)
    {
        _context = context;
    }

    public async Task<List<Announcement>> Handle(GetAllAnnouncementsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Announcements.ToListAsync(cancellationToken);
    }
}
