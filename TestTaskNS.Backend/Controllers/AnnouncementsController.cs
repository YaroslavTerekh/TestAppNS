using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestTaskNS.BL.Behaviors.Announcements.AddAnnouncement;
using TestTaskNS.BL.Behaviors.Announcements.DeleteAnnouncement;
using TestTaskNS.BL.Behaviors.Announcements.GetAllAnnouncements;
using TestTaskNS.BL.Behaviors.Announcements.GetAnnouncement;
using TestTaskNS.BL.Behaviors.Announcements.ModifyAnnouncement;
using TestTaskNS.BL.DbConnection;

namespace TestTaskNS.Backend.Controllers
{
    [Route("api/announcements")]
    [ApiController]
    public class AnnouncementsController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public AnnouncementsController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAllAnnouncementsAsync(CancellationToken cancellationToken = default)
        {
            return Ok(await _mediatr.Send(new GetAllAnnouncementsQuery(), cancellationToken));
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetAnnouncementAsync(
            [FromRoute] Guid id,
            CancellationToken cancellationToken = default
        )
        {           
            return Ok(await _mediatr.Send(new GetAnnouncementQuery(id), cancellationToken));
        }

        [HttpPost("add")]
        public async Task<IActionResult> CreateNewAnnouncementAsync(
            [FromBody] AddAnnouncementCommand command,
            CancellationToken cancellationToken = default
        )
        {
            await _mediatr.Send(command, cancellationToken);

            return Ok();
        }

        [HttpPut("modify")]
        public async Task<IActionResult> ModifyAnnouncementAsync(
            [FromBody] ModifyAnnouncementCommand command, 
            CancellationToken cancellationToken = default
        )
        {
            await _mediatr.Send(command, cancellationToken);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnnouncementAsync(
            [FromRoute] Guid id,
            CancellationToken cancellationToken = default
        ) 
        {
            await _mediatr.Send(new DeleteAnnouncementCommand(id), cancellationToken);

            return Ok();
        }
    }
}
