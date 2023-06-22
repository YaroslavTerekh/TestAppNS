using MediatR;
using Microsoft.EntityFrameworkCore;
using TestTaskNS.BL.DbConnection;

namespace TestTaskNS.BL.Behaviors.Announcements.DeleteAnnouncement;

public class DeleteAnnouncementHandler : IRequestHandler<DeleteAnnouncementCommand>
{
    private readonly DataContext _context;

    public DeleteAnnouncementHandler(DataContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteAnnouncementCommand request, CancellationToken cancellationToken)
    {
        var announcement = await _context.Announcements.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);

        _context.Remove(announcement);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
