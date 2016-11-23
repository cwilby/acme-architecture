using Acme.Api.Controllers.Customer;
using Acme.Core.DTO.Customer;
using Acme.Core.Exceptions;
using Acme.Core.Service.Customer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace Acme.Api.Test.Controllers.Customer
{
    [TestClass]
    public class CustomersControllerTests
    {
        private Mock<ICustomerService> mockCustomerService = null;
        private CustomersController customerController = null;

        [TestInitialize]
        public void Initialize()
        {
            mockCustomerService = new Mock<ICustomerService>();
            customerController = new CustomersController(mockCustomerService.Object);
        }

        [TestMethod]
        public void GetCustomersShouldReturnCustomers()
        {
            // ARRANGE
            mockCustomerService.Setup(cs => cs.GetAll()).Returns(new CustomerDTO[]
            {
                new CustomerDTO { },
                new CustomerDTO { }
            });

            // ACT
            var customers = customerController.GetCustomers();

            // ASSERT
            Assert.IsNotNull(customers);
            Assert.AreEqual(2, customers.Count());
        }

        [TestMethod]
        public void GetCustomerShouldReturnCustomerWhenFound()
        {
            // ARRANGE
            mockCustomerService.Setup(cs => cs.GetById(1)).Returns(new CustomerDTO.WithRelations
            {
                Id = 1
            });

            // ACT
            var result = customerController.GetCustomer(1) as OkNegotiatedContentResult<CustomerDTO.WithRelations>;

            // ASSERT
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<CustomerDTO.WithRelations>));
            Assert.IsNotNull(result.Content);
            Assert.IsTrue(result.Content.Id == 1);
        }

        [TestMethod]
        public void GetCustomerShouldReturnNotFoundResult()
        {
            // ARRANGE
            mockCustomerService.Setup(cs => cs.GetById(1)).Throws<ReadEntityException>();

            // ACT
            var result = customerController.GetCustomer(1) as NotFoundResult;

            // ASSERT
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void CreateCustomerShouldCreateCustomer()
        {
            // ARRANGE
            mockCustomerService.Setup(cs => cs.Create(It.IsAny<CustomerDTO.WithRelations>())).Returns(new CustomerDTO.WithRelations
            {
                Id = 1,
                FirstName = "John",
                LastName = "Smith"
            });

            // ACT
            var result = customerController.PostCustomer(new CustomerDTO.WithRelations
            {
                FirstName = "John",
                LastName = "Smith"
            }) as CreatedAtRouteNegotiatedContentResult<CustomerDTO.WithRelations>;
            

            // ASSERT
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(CreatedAtRouteNegotiatedContentResult<CustomerDTO.WithRelations>));
            Assert.AreEqual(1, result.Content.Id);
            Assert.AreEqual("John", result.Content.FirstName);
            Assert.AreEqual("Smith", result.Content.LastName);
        }

        [TestMethod]
        public void UpdateCustomerShouldReturnNoContent()
        {
            // ARRANGE

            // ACT
            var result = customerController.PutCustomer(1, new CustomerDTO.WithRelations { Id = 1 }) as StatusCodeResult;

            // ASSERT 
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }

        [TestMethod]
        public void UpdateCustomerShouldReturnBadRequestWhenIdsDontMatch()
        {
            // ARRANGE

            // ACT
            var result = customerController.PutCustomer(1, new CustomerDTO.WithRelations { Id = 2 }) as BadRequestResult;

            // ASSERT
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod]
        public void DeleteCustomerShouldReturnCopyOfCustomerUponDeletion()
        {
            // ARRANGE
            mockCustomerService.Setup(cs => cs.Delete(1)).Returns(new CustomerDTO.WithRelations
            {
                Id = 1
            });

            // ACT
            var result = customerController.DeleteCustomer(1) as OkNegotiatedContentResult<CustomerDTO.WithRelations>;

            // ASSERT
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<CustomerDTO.WithRelations>));
            Assert.AreEqual(1, result.Content.Id);
        }

        [TestMethod]
        public void DeleteCustomerShouldReturnNotFoundWhenTryingToDeleteEmptyCustomer()
        {
            // ARRANGE
            mockCustomerService.Setup(cs => cs.Delete(2)).Throws<DeleteEntityException>();

            // ACT
            var result = customerController.DeleteCustomer(2) as NotFoundResult;

            // ASSERT
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}
