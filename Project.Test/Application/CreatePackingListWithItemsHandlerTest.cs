using System;
using System.Threading.Tasks;
using NSubstitute;
using Project.Application.Commands.Handlers;
using Project.Application.Commands;
using Project.Application.DTO.External;
using Project.Application.Services;
using Project.Domain.Consts;
using Project.Domain.Entities;
using Project.Domain.Factories;
using Project.Domain.Repositories;
using Project.Domain.ValueObjects;
using Project.Shared.Abstraction.Commands;
using Shouldly;
using Xunit;
using Project.Application.Exceptions;

namespace Project.Test.Application
{
	public class CreatePackingListWithItemsHandlerTest
	{
		Task Act(CreatePackingListWithItems command)
			=> _commandHandler.HandleAsync(command);

		[Fact]
		public async Task HandleAsync_Throws_PackingListAlreadyExistsException_When_List_With_same_Name_Already_Exists()
		{
			var command = new CreatePackingListWithItems(Guid.NewGuid(), "MyList", 10, Gender.Female, default);
			_readService.ExistsByNameAsync(command.Name).Returns(true);

			var exception = await Record.ExceptionAsync(() => Act(command));

			exception.ShouldNotBeNull();
			exception.ShouldBeOfType<PackingListAlreadyExistsException>();
		}

		[Fact]
		public async Task HandleAsync_Throws_MissingLocalizationWeatherException_When_Weather_Is_Not_Returned_From_Service()
		{
			var command = new CreatePackingListWithItems(Guid.NewGuid(), "MyList", 10, Gender.Female,
				new LocalizationWriteModel("Warsaw", "Poland"));

			_readService.ExistsByNameAsync(command.Name).Returns(false);
			_weatherService.GetWeatherAsync(Arg.Any<Localization>()).Returns(default(WeatherDTO));

			var exception = await Record.ExceptionAsync(() => Act(command));

			exception.ShouldNotBeNull();
			exception.ShouldBeOfType<WeatherNullException>();
		}

		[Fact]
		public async Task HandleAsync_Calls_Repository_On_Success()
		{
			var command = new CreatePackingListWithItems(Guid.NewGuid(), "MyList", 10, Gender.Female,
				new LocalizationWriteModel("Warsaw", "Poland"));

			_readService.ExistsByNameAsync(command.Name).Returns(false);
			_weatherService.GetWeatherAsync(Arg.Any<Localization>()).Returns(new WeatherDTO(12));
			_factory.CreateWithDefaultItems(command.Id, command.Name, command.Days, command.Gender,
				Arg.Any<Temperature>(), Arg.Any<Localization>()).Returns(default(PackingList));

			var exception = await Record.ExceptionAsync(() => Act(command));

			exception.ShouldBeNull();
			await _repository.Received(1).AddAsync(Arg.Any<PackingList>());
		}

		#region ARRANGE

		private readonly ICommandHandler<CreatePackingListWithItems> _commandHandler;
		private readonly IPackingListRepository _repository;
		private readonly IWeatherService _weatherService;
		private readonly IPackingListReadService _readService;
		private readonly IPackingListFactory _factory;

		public CreatePackingListWithItemsHandlerTest()
		{
			_repository = Substitute.For<IPackingListRepository>();
			_weatherService = Substitute.For<IWeatherService>();
			_readService = Substitute.For<IPackingListReadService>();
			_factory = Substitute.For<IPackingListFactory>();

			_commandHandler = new CreatePackingListWithItemsHandler(_repository, _factory, _readService, _weatherService);
		}

		#endregion
	}
}