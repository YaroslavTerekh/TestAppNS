using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskNS.BL.DbConnection;
using TestTaskNS.Domain.Entities;

namespace TestTaskNS.BL.Behaviors.Announcements.ModifyAnnouncement;

public class ModifyAnnouncementHandler : IRequestHandler<ModifyAnnouncementCommand, Announcement>
{
    private readonly DataContext _context;

    public ModifyAnnouncementHandler(DataContext context)
    {
        _context = context;
    }

    public async Task<Announcement> Handle(ModifyAnnouncementCommand request, CancellationToken cancellationToken)
    {
        var announcement = await _context.Announcements.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);

        announcement.Title = request.Title;
        announcement.Description = request.Description;
        announcement.AuthorEmail = request.AuthorEmail;

        await _context.SaveChangesAsync(cancellationToken);

        return announcement;
    }
}
