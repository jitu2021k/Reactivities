using System;
using Application.Activities.Commands;
using Application.Activities.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using static Application.Activities.Queries.GetActivityList;

namespace API.Controllers;

public class ActivitiesController : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetActivities()
    {
        return await Mediator.Send(new Query());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivity(string id)
    {
        return await Mediator.Send(new GetActivityDetails.Query{ Id = id});
        // if( activuty == null )  return NotFound();
        // return Ok(activuty);
    }

    [HttpPost]
    public async Task<ActionResult<string>> CreateActivity(Activity activity)
    {
        return await Mediator.Send(new CreateActivity.Command{Activity = activity});
    } 

    [HttpPut]
    public async Task<ActionResult> EditActivity(Activity activity)
    {
        await Mediator.Send(new EditActivity.Command{Activity = activity});  
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteActivity(string id)
    {
        await Mediator.Send(new DeleteActivity.Command{Id = id});
        return Ok();
    }
}
    