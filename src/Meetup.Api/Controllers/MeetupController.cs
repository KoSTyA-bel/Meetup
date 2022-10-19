using Meetup.BusinessLayer.Interfaces;
using Models = Meetup.BusinessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace Meetup.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MeetupController : ControllerBase
{
    private readonly IMeetupService _service;
    private readonly IMapper _mapper;

    public MeetupController(IMeetupService service, IMapper mapper)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Models.Meetup>> GetById(string id)
    {
        var guideedId = _mapper.Map<Guid>(id);

        try
        {
            var meetup = await _service.GetById(guideedId, CancellationToken.None);

            if (meetup is null)
            {
                return NoContent();
            }

            return Ok(meetup);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet()]
    public async Task<ActionResult<IEnumerable<Models.Meetup>>> Get(int page, int pageSize)
    {
        throw new NotImplementedException();
    }
}
