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
    public class AdminTest
    {
        List<Admin> role = new List<Admin>();

        public AdminTest()
        {
            role.Add(new Admin
            {
                AdminId = 1,
                AdminCode="ADMLBC1001",
                FullName = "Testing User",
                EmailId = "Testing@test.com",
                Phone = "9999009999",
                Avatar="NoUser.jpg",
                About="Test user created for testing",
                LoginId="testing",
                Password="testing",
                LoginAttempt=0,
                Role="Admin",
                Status="Active",
                StoreId=1,
                CreatedUI = "System",
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now
            });
            role.Add(new Admin
            {
                AdminId = 2,
                AdminCode = "ADMLBC1002",
                FullName = "Testing User2",
                EmailId = "Testin2g@test.com",
                Phone = "9999009992",
                Avatar = "NoUser2.jpg",
                About = "Test user2 created for testing",
                LoginId = "testing2",
                Password = "testing2",
                LoginAttempt = 0,
                Role = "Admin",
                Status = "Active",
                StoreId = 1,
                CreatedUI = "System",
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now
            });

            // Mock the Admin Repository using Moq
            Mock<IAdminService> mockAdminRepository = new Mock<IAdminService>();

            // Return all the role
            mockAdminRepository.Setup(mr => mr.GetAdmin()).Returns(role);

            // return a product by Id
            mockAdminRepository.Setup(mr => mr.Detail(
                It.IsAny<int>())).Returns((int i) => role.Where(
                x => x.AdminId == i).Single());

            // Allows us to test saving a product
            mockAdminRepository.Setup(mr => mr.InsertAdmin(It.IsAny<Admin>())).Returns(
                (Admin target) =>
                {
                    DateTime now = DateTime.Now;

                    if (target.AdminId.Equals(default(int)))
                    {
                        target.DateCreated = now;
                        target.DateUpdated = now;
                        target.AdminId = role.Count() + 1;
                        role.Add(target);
                    }
                    else
                    {
                        var original = role.Where(
                            q => q.AdminId == target.AdminId).Single();

                        if (original == null)
                        {
                            return "-1";
                        }

                        original.AdminCode = target.AdminCode;
                        original.FullName = target.FullName;
                        original.DateUpdated = now;
                        original.Status = "Active";
                        original.Role = "SuperAdmin";
                        original.DateCreated = now;
                        original.EmailId = target.EmailId;
                        original.Phone = target.Phone;
                        original.Avatar = target.Avatar;
                        original.About = target.About;
                        original.LoginAttempt = 0;
                        original.LoginId = target.LoginId;
                        original.Password = target.Password;
                        original.StoreId = target.StoreId;
                    }

                    return "0";
                });

            // Complete the setup of our Mock Admin Repository
            this.MockAdminRepository = mockAdminRepository.Object;
        }

        /// <summary>
        /// Our Mock Admin Repository for use in testing
        /// </summary>
        public readonly IAdminService MockAdminRepository;

        /// <summary>
        /// Can we return a product By Id?
        /// </summary>
        [Fact]
        public void CanReturnAdminById()
        {
            // Try finding a product by id
            Admin testAdmin = this.MockAdminRepository.Detail(2);

            Assert.NotNull(testAdmin); // Test if null
            Assert.Equal("Testing User2", testAdmin.FullName); // Verify it is the right product
        }

        /// <summary>
        /// Can we return all role?
        /// </summary>
        [Fact]
        public void CanReturnAllAdmin()
        {
            // Try finding all role
            IList<Admin> testAdmin = this.MockAdminRepository.GetAdmin().ToList();

            Assert.NotNull(testAdmin); // Test if null
            Assert.Equal(2, testAdmin.Count); // Verify the correct Number
        }

        /// <summary>
        /// Can we insert a new product?
        /// </summary>
        [Fact]
        public void CanInsertAdmin()
        {
            // Create a new product, not I do not supply an id
            Admin newAdmin = new Admin
            { FullName = "MyTesting", About = "Short description here" };

            int productCount = this.MockAdminRepository.GetAdmin().ToList().Count;
            Assert.Equal(2, productCount); // Verify the expected Number pre-insert

            // try saving our new product
            this.MockAdminRepository.InsertAdmin(newAdmin);

            // demand a recount
            productCount = this.MockAdminRepository.GetAdmin().ToList().Count;
            Assert.Equal(3, productCount); // Verify the expected Number post-insert

            // verify that our new product has been saved
            Admin testAdmin = this.MockAdminRepository.GetAdmin().ToList().Where(m => m.FullName == "MyTesting").FirstOrDefault();
            Assert.NotNull(testAdmin); // Test if null
            Assert.Equal(3, testAdmin.AdminId); // Verify it has the expected productid
        }

        /// <summary>
        /// Can we update a product?
        /// </summary>
        [Fact]
        public void CanUpdateAdmin()
        {
            // Find a product by id
            Admin testAdmin = this.MockAdminRepository.Detail(1);

            // Change one of its properties
            testAdmin.FullName = "C# 3.5 Unleashed";

            // Save our changes.
            this.MockAdminRepository.InsertAdmin(testAdmin);

            // Verify the change
            Assert.Equal("C# 3.5 Unleashed", this.MockAdminRepository.Detail(1).FullName);
        }
    }
}