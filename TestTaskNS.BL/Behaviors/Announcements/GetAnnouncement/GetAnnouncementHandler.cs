using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskNS.BL.DbConnection;
using TestTaskNS.Domain.DataTransferObjects;
using TestTaskNS.Domain.Entities;

namespace TestTaskNS.BL.Behaviors.Announcements.GetAnnouncement;

public class GetAnnouncementHandler : IRequestHandler<GetAnnouncementQuery, AnnouncementDTO>
{
    private readonly DataContext _context;

    public GetAnnouncementHandler(DataContext context)
    {
        _context = context;
    }

    public async Task<AnnouncementDTO> Handle(GetAnnouncementQuery request, CancellationToken cancellationToken)
    {
        var announcement = await _context.Announcements
            .Where(a => a.Id == request.Id)
            .Select(a => new AnnouncementDTO
            {
                Id = a.Id,
                Description = a.Description,
                AuthorEmail = a.AuthorEmail,
                AuthorName = a.AuthorName,
                Title = a.Title,
                CreatedDate = a.CreatedDate
            })
            .FirstOrDefaultAsync(cancellationToken);

        if(announcement is null)
        {
            throw new Exception("Announcement not found!");
        }

        var allAnnouncements = await _context.Announcements.ToListAsync(cancellationToken);

        Dictionary<Announcement, int> similarityScores = new Dictionary<Announcement, int>();

        foreach (var announcementFromList in allAnnouncements.Where(a => a.Id != announcement.Id))
        {
            int commonWordCount = 
                GetCommonWordCount(announcement.Title, 
                announcementFromList.Title, 
                announcement.Description, 
                announcementFromList.Description);

            similarityScores.Add(announcementFromList, commonWordCount);
        }

        announcement.SimilarAnnouncements = similarityScores.OrderByDescending(kv => kv.Value)
                                                                      .Take(3)
                                                                      .Select(kv => kv.Key)
                                                                      .ToList();

        return announcement;
    }

    private int GetCommonWordCount(string title1, string title2, string descr1, string descr2)
    {
        var words1 = title1.Split(new[] { ' ', '.', ',', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        var words2 = title2.Split(new[] { ' ', '.', ',', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        var words3 = descr1.Split(new[] { ' ', '.', ',', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        var words4 = descr2.Split(new[] { ' ', '.', ',', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

        int titleCount = words1.Intersect(words2).Count();
        int descrCount = words3.Intersect(words4).Count();

        if(titleCount < 1 || descrCount < 1)
        {
            return 0;
        }

        return titleCount + descrCount;
    }
}
