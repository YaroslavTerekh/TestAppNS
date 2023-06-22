using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskNS.BL.DbConnection;
using TestTaskNS.Domain.Entities;

namespace TestTaskNS.BL.Behaviors.Announcements.AddAnnouncement;

public class AddAnnouncementHandler : IRequestHandler<AddAnnouncementCommand, Announcement>
{
    private readonly DataContext _context;

    public AddAnnouncementHandler(DataContext context)
    {
        _context = context;
    }

    public async Task<Announcement> Handle(AddAnnouncementCommand request, CancellationToken cancellationToken)
    {
        var newAnnouncement = new Announcement
        {
            Title = request.Title,
            Description = request.Description,
            AuthorName = request.AuthorName,
            AuthorEmail = request.AuthorEmail
        };

        await _context.Announcements.AddAsync(newAnnouncement, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return newAnnouncement;
    }
}
