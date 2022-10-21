using Meetup.BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;
using Meetup.BusinessLayer.Models;
using Meetup.Api.Infrastructure.Attributes;

namespace Meetup.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MeetupController : ControllerBase
{
    private const int StandartPageNumber = 1;
    private const int StandartPageSize = 1;
    private readonly IMeetupService _service;
    private readonly IMapper _mapper;

    public MeetupController(IMeetupService service, IMapper mapper)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    [SwaggerResponse(200, "Successfully get meetup", typeof(Models.Meetup))]
    [SwaggerResponse(204, "Can`t find meetup with passed id")]
    [SwaggerResponse(400, "Id can`t be empty")]
    public async Task<ActionResult<Models.Meetup>> GetById([FromRoute] string id)
    {
        var guidedId = _mapper.Map<Guid>(id);

        try
        {
            var meetup = await _service.GetById(guidedId, CancellationToken.None);

            if (meetup is null)
            {
                return NoContent();
            }

            var mapped = _mapper.Map<Models.Meetup>(meetup);

            return Ok(mapped);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("Get-range")]
    [AllowAnonymous]
    [SwaggerResponse(200, "Successfully get range of meetups", typeof(IEnumerable<Models.Meetup>))]
    public async Task<ActionResult<IEnumerable<Models.Meetup>>> Get(int page, int pageSize)
    {
        if (page < 1 && pageSize < 1)
        {
            var meetups = await _service.GetAll(CancellationToken.None);
            var mapped = _mapper.Map<IEnumerable<Models.Meetup>>(meetups);
            return Ok(mapped);
        }
        else
        {
            page = page > 1 ? page : StandartPageNumber;
            pageSize = pageSize > 1 ? pageSize : StandartPageSize;

            var meetups = await _service.GetRange(page, pageSize, CancellationToken.None);
            var mapped = _mapper.Map<IEnumerable<Models.Meetup>>(meetups);
            return Ok(mapped);
        }
    }

    [HttpPost("Create-meetup")]
    [AuthorizeJWT]
    [SwaggerResponse(200, "Successfully creating meetup", typeof(Guid))]
    [SwaggerResponse(401, "Unauthorized")]
    public async Task<ActionResult> Create([FromBody] Models.Meetup meetup)
    {
        var mapped = _mapper.Map<Meeting>(meetup);
        await _service.Create(mapped, CancellationToken.None);

        return Ok(mapped.Id);
    }

    [HttpPut("Update-meetup")]
    [AuthorizeJWT]
    [SwaggerResponse(200, "Successfully updating meetup")]
    [SwaggerResponse(400, "Meeting does not exist")]
    [SwaggerResponse(401, "Unauthorized")]
    public async Task<ActionResult> Update([FromBody] Models.Meetup meetup)
    {
        var mapped = _mapper.Map<Meeting>(meetup);

        try
        {
            await _service.Update(mapped, CancellationToken.None);
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest();
        }
        

        return Ok();
    }

    [HttpDelete("{id}")]
    [AuthorizeJWT]
    [SwaggerResponse(200, "Successfully deleting meetup")]
    [SwaggerResponse(401, "Unauthorized")]
    public async Task<ActionResult> Delete([FromRoute] string id)
    {
        var mappedId = _mapper.Map<Guid>(id);
        await _service.Delete(mappedId, CancellationToken.None);

        return Ok();
    }
}
