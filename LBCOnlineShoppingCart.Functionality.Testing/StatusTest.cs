using LBCOnlineShoppingCart.Application.Interfaces;
using LBCOnlineShoppingCart.Domain.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LBCOnlineShoppingCart.Functionality.Testing
{
    public class StatusTest
    {
        List<Status> status = new List<Status>();

        public StatusTest()
        {
            status.Add(new Status
            {
                Id = 1,
                Title = "Testing Data",
                Description = "Testing Data Description",
                IsActive = "Active",
                StatusFor = "Testing Status",
                CreatedUI = "System",
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now
            });
            status.Add(new Status
            {
                Id = 2,
                Title = "Testing Data 2",
                Description = "Testing Data Description 2",
                IsActive = "Active",
                StatusFor = "Testing Status 2",
                CreatedUI = "System",
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now
            });

            // Mock the Status Repository using Moq
            Mock<IStatusService> mockStatusRepository = new Mock<IStatusService>();

            // Return all the status
            mockStatusRepository.Setup(mr => mr.GetStatus()).Returns(status);

            // return a product by Id
            mockStatusRepository.Setup(mr => mr.Detail(
                It.IsAny<int>())).Returns((int i) => status.Where(
                x => x.Id == i).Single());

            // Allows us to test saving a product
            mockStatusRepository.Setup(mr => mr.InsertStatus(It.IsAny<Status>())).Returns(
                (Status target) =>
                {
                    DateTime now = DateTime.Now;

                    if (target.Id.Equals(default(int)))
                    {
                        target.DateCreated = now;
                        target.DateUpdated = now;
                        target.Id = status.Count() + 1;
                        status.Add(target);
                    }
                    else
                    {
                        var original = status.Where(
                            q => q.Id == target.Id).Single();

                        if (original == null)
                        {
                            return "-1";
                        }

                        original.Title = target.Title;
                        original.StatusFor = target.StatusFor;
                        original.Description = target.Description;
                        original.DateUpdated = now;
                        original.IsActive = "Active";
                    }

                    return "0";
                });

            // Complete the setup of our Mock Status Repository
            this.MockStatusRepository = mockStatusRepository.Object;
        }

        /// <summary>
        /// Our Mock Status Repository for use in testing
        /// </summary>
        public readonly IStatusService MockStatusRepository;

        /// <summary>
        /// Can we return a product By Id?
        /// </summary>
        [Fact]
        public void CanReturnStatusById()
        {
            // Try finding a product by id
            Status testStatus = this.MockStatusRepository.Detail(2);

            Assert.NotNull(testStatus); // Test if null
            Assert.Equal("Testing Data 2", testStatus.Title); // Verify it is the right product
        }

        /// <summary>
        /// Can we return all status?
        /// </summary>
        [Fact]
        public void CanReturnAllStatus()
        {
            // Try finding all status
            IList<Status> testStatus = this.MockStatusRepository.GetStatus().ToList();

            Assert.NotNull(testStatus); // Test if null
            Assert.Equal(2, testStatus.Count); // Verify the correct Number
        }

        /// <summary>
        /// Can we insert a new product?
        /// </summary>
        [Fact]
        public void CanInsertStatus()
        {
            // Create a new product, not I do not supply an id
            Status newStatus = new Status
            { Title = "MyTesting", Description = "Short description here", StatusFor = "Testing" };

            int productCount = this.MockStatusRepository.GetStatus().ToList().Count;
            Assert.Equal(2, productCount); // Verify the expected Number pre-insert

            // try saving our new product
            this.MockStatusRepository.InsertStatus(newStatus);

            // demand a recount
            productCount = this.MockStatusRepository.GetStatus().ToList().Count;
            Assert.Equal(3, productCount); // Verify the expected Number post-insert

            // verify that our new product has been saved
            Status testStatus = this.MockStatusRepository.GetStatus().ToList().Where(m => m.Title == "MyTesting").FirstOrDefault();
            Assert.NotNull(testStatus); // Test if null
            Assert.Equal(3, testStatus.Id); // Verify it has the expected productid
        }

        /// <summary>
        /// Can we update a product?
        /// </summary>
        [Fact]
        public void CanUpdateStatus()
        {
            // Find a product by id
            Status testStatus = this.MockStatusRepository.Detail(1);

            // Change one of its properties
            testStatus.Title = "C# 3.5 Unleashed";

            // Save our changes.
            this.MockStatusRepository.InsertStatus(testStatus);

            // Verify the change
            Assert.Equal("C# 3.5 Unleashed", this.MockStatusRepository.Detail(1).Title);
        }
    }
}