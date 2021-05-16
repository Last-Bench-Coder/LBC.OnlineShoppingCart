using LBCOnlineShoppingCart.Application.Interfaces;
using LBCOnlineShoppingCart.Domain.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace LBCOnlineShoppingCart.Functionality.Testing
{
    public class RoleTest
    {
        List<Role> role = new List<Role>();

        public RoleTest()
        {
            role.Add(new Role
            {
                Id = 1,
                Title = "Testing Data",
                Description = "Testing Data Description",
                IsActive = "Active",
                CreatedUI = "System",
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now
            });
            role.Add(new Role
            {
                Id = 2,
                Title = "Testing Data 2",
                Description = "Testing Data Description 2",
                IsActive = "Active",
                CreatedUI = "System",
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now
            });

            // Mock the Role Repository using Moq
            Mock<IRoleService> mockRoleRepository = new Mock<IRoleService>();

            // Return all the role
            mockRoleRepository.Setup(mr => mr.GetRole()).Returns(role);

            // return a product by Id
            mockRoleRepository.Setup(mr => mr.Detail(
                It.IsAny<int>())).Returns((int i) => role.Where(
                x => x.Id == i).Single());

            // Allows us to test saving a product
            mockRoleRepository.Setup(mr => mr.InsertRole(It.IsAny<Role>())).Returns(
                (Role target) =>
                {
                    DateTime now = DateTime.Now;

                    if (target.Id.Equals(default(int)))
                    {
                        target.DateCreated = now;
                        target.DateUpdated = now;
                        target.Id = role.Count() + 1;
                        role.Add(target);
                    }
                    else
                    {
                        var original = role.Where(
                            q => q.Id == target.Id).Single();

                        if (original == null)
                        {
                            return "-1";
                        }

                        original.Title = target.Title;
                        original.Description = target.Description;
                        original.DateUpdated = now;
                        original.IsActive = "Active";
                    }

                    return "0";
                });

            // Complete the setup of our Mock Role Repository
            this.MockRoleRepository = mockRoleRepository.Object;
        }

        /// <summary>
        /// Our Mock Role Repository for use in testing
        /// </summary>
        public readonly IRoleService MockRoleRepository;

        /// <summary>
        /// Can we return a product By Id?
        /// </summary>
        [Fact]
        public void CanReturnRoleById()
        {
            // Try finding a product by id
            Role testRole = this.MockRoleRepository.Detail(2);

            Assert.NotNull(testRole); // Test if null
            Assert.Equal("Testing Data 2", testRole.Title); // Verify it is the right product
        }

        /// <summary>
        /// Can we return all role?
        /// </summary>
        [Fact]
        public void CanReturnAllRole()
        {
            // Try finding all role
            IList<Role> testRole = this.MockRoleRepository.GetRole().ToList();

            Assert.NotNull(testRole); // Test if null
            Assert.Equal(2, testRole.Count); // Verify the correct Number
        }

        /// <summary>
        /// Can we insert a new product?
        /// </summary>
        [Fact]
        public void CanInsertRole()
        {
            // Create a new product, not I do not supply an id
            Role newRole = new Role
            { Title = "MyTesting", Description = "Short description here" };

            int productCount = this.MockRoleRepository.GetRole().ToList().Count;
            Assert.Equal(2, productCount); // Verify the expected Number pre-insert

            // try saving our new product
            this.MockRoleRepository.InsertRole(newRole);

            // demand a recount
            productCount = this.MockRoleRepository.GetRole().ToList().Count;
            Assert.Equal(3, productCount); // Verify the expected Number post-insert

            // verify that our new product has been saved
            Role testRole = this.MockRoleRepository.GetRole().ToList().Where(m => m.Title == "MyTesting").FirstOrDefault();
            Assert.NotNull(testRole); // Test if null
            Assert.Equal(3, testRole.Id); // Verify it has the expected productid
        }

        /// <summary>
        /// Can we update a product?
        /// </summary>
        [Fact]
        public void CanUpdateRole()
        {
            // Find a product by id
            Role testRole = this.MockRoleRepository.Detail(1);

            // Change one of its properties
            testRole.Title = "C# 3.5 Unleashed";

            // Save our changes.
            this.MockRoleRepository.InsertRole(testRole);

            // Verify the change
            Assert.Equal("C# 3.5 Unleashed", this.MockRoleRepository.Detail(1).Title);
        }
    }
}