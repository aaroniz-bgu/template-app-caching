﻿using MyApp.AppServices.Offices;
using MyApp.AppServices.UserServices;
using MyApp.Domain.Entities.Offices;
using MyApp.TestData.Constants;

namespace AppServicesTests.Offices;

public class GetList
{
    [Test]
    public async Task WhenItemsExist_ReturnsViewDtoList()
    {
        var office = new Office(Guid.Empty, TextData.ValidName);
        var itemList = new List<Office> { office };

        var repoMock = Substitute.For<IOfficeRepository>();
        repoMock.GetListAsync(Arg.Any<CancellationToken>()).Returns(itemList);
        var managerMock = Substitute.For<IOfficeManager>();
        var userServiceMock = Substitute.For<IUserService>();
        var appService = new OfficeService(repoMock, managerMock,
            AppServicesTestsSetup.Mapper!, userServiceMock);

        var result = await appService.GetListAsync();

        result.Should().BeEquivalentTo(itemList);
    }

    [Test]
    public async Task WhenNoItemsExist_ReturnsEmptyList()
    {
        var repoMock = Substitute.For<IOfficeRepository>();
        repoMock.GetListAsync(Arg.Any<CancellationToken>()).Returns(new List<Office>());
        var managerMock = Substitute.For<IOfficeManager>();
        var userServiceMock = Substitute.For<IUserService>();
        var appService = new OfficeService(repoMock, managerMock,
            AppServicesTestsSetup.Mapper!, userServiceMock);

        var result = await appService.GetListAsync();

        result.Should().BeEmpty();
    }
}
