using Microsoft.AspNetCore.Mvc;
using Project.Application.Commands;
using Project.Application.DTO;
using Project.Application.Queries;
using Project.Shared.Abstraction.Commands;
using Project.Shared.Abstraction.Queries;
using Project.Api.Controllers;

namespace PackIT.Api.Controllers
{
	public class PackingListsController : BaseController
	{
		private readonly ICommandDispatcher _commandDispatcher;
		private readonly IQueryDispatcher _queryDispatcher;

		public PackingListsController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
		{
			_commandDispatcher = commandDispatcher;
			_queryDispatcher = queryDispatcher;
		}

		[HttpGet("{id:guid}")]
		public async Task<ActionResult<PackingListDTO>> Get([FromRoute] GetPackingList query)
		{
			var result = await _queryDispatcher.QueryAsync(query);
			return OkOrNotFound(result);
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<PackingListDTO>>> Get([FromQuery] SearchPackingList query)
		{
			var result = await _queryDispatcher.QueryAsync(query);
			return OkOrNotFound(result);
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody] CreatePackingListWithItems command)
		{
			await _commandDispatcher.DispatchAsync(command);
			return CreatedAtAction(nameof(Get), new { id = command.Id }, null);
		}

		[HttpPut("{packingListId}/items")]
		public async Task<IActionResult> Put([FromBody] AddPackingItem command)
		{
			await _commandDispatcher.DispatchAsync(command);
			return Ok();
		}

		[HttpPut("{packingListId:guid}/items/{name}/pack")]
		public async Task<IActionResult> Put([FromBody] PackItem command)
		{
			await _commandDispatcher.DispatchAsync(command);
			return Ok();
		}

		[HttpDelete("{packingListId:guid}/items/{name}")]
		public async Task<IActionResult> Delete([FromBody] RemovePackItem command)
		{
			await _commandDispatcher.DispatchAsync(command);
			return Ok();
		}

		[HttpDelete("{id:guid}")]
		public async Task<IActionResult> Delete([FromBody] RemovePackingList command)
		{
			await _commandDispatcher.DispatchAsync(command);
			return Ok();
		}
	}
}