﻿using FluentAssertions.Execution;
using GaEpd.AppLibrary.Pagination;
using MyApp.AppServices.Customers;
using MyApp.AppServices.Customers.Dto;
using MyApp.AppServices.UserServices;
using MyApp.Domain.Entities.Contacts;
using MyApp.Domain.Entities.Customers;
using MyApp.TestData;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using Microsoft.Extensions.Caching.Memory;

namespace AppServicesTests.Customers;

public class Search
{
    private static CustomerSearchDto DefaultCustomerSearchDto => new();

    [Test]
    public async Task WhenItemsExist_ReturnsPagedList()
    {
        // Arrange
        var itemList = new ReadOnlyCollection<Customer>(CustomerData.GetCustomers.ToList());
        var count = CustomerData.GetCustomers.Count();
        var paging = new PaginatedRequest(1, 100);

        var customerRepoMock = Substitute.For<ICustomerRepository>();
        customerRepoMock.GetPagedListAsync(Arg.Any<Expression<Func<Customer, bool>>>(),
            Arg.Any<PaginatedRequest>(), Arg.Any<CancellationToken>()).Returns(itemList);
        customerRepoMock.CountAsync(Arg.Any<Expression<Func<Customer, bool>>>(), Arg.Any<CancellationToken>())
            .Returns(count);

        var appService = new CustomerService(AppServicesTestsSetup.Mapper!, Substitute.For<IUserService>(),
            customerRepoMock, Substitute.For<ICustomerManager>(),
            Substitute.For<IContactRepository>(), new MemoryCache(new MemoryCacheOptions()));

        // Act
        var result = await appService.SearchAsync(DefaultCustomerSearchDto, paging, CancellationToken.None);

        // Assert
        using (new AssertionScope())
        {
            result.Items.Should().BeEquivalentTo(itemList);
            result.CurrentCount.Should().Be(count);
        }
    }

    [Test]
    public async Task WhenNoItemsExist_ReturnsEmptyPagedList()
    {
        // Arrange
        var itemList = new ReadOnlyCollection<Customer>(new List<Customer>());
        const int count = 0;
        var paging = new PaginatedRequest(1, 100);

        var customerRepoMock = Substitute.For<ICustomerRepository>();
        customerRepoMock.GetPagedListAsync(Arg.Any<Expression<Func<Customer, bool>>>(),
            Arg.Any<PaginatedRequest>(), Arg.Any<CancellationToken>()).Returns(itemList);
        customerRepoMock.CountAsync(Arg.Any<Expression<Func<Customer, bool>>>(), Arg.Any<CancellationToken>())
            .Returns(count);

        var appService = new CustomerService(AppServicesTestsSetup.Mapper!, Substitute.For<IUserService>(),
            customerRepoMock, Substitute.For<ICustomerManager>(),
            Substitute.For<IContactRepository>(), new MemoryCache(new MemoryCacheOptions()));

        // Act
        var result = await appService.SearchAsync(DefaultCustomerSearchDto, paging, CancellationToken.None);

        // Assert
        using (new AssertionScope())
        {
            result.Items.Should().BeEquivalentTo(itemList);
            result.CurrentCount.Should().Be(count);
        }
    }
}
