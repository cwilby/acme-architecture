using Acme.Core.DTO.Customer;
using Acme.Core.Repository.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.Core.Infrastructure;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using Acme.Core.Extensions;
using Acme.Core.Domain.Customer;
using Acme.Core.Exceptions;

namespace Acme.Core.Service.Customer
{
    public interface ICustomerService
    {
        IEnumerable<CustomerDTO> GetAll();
        CustomerDTO.WithRelations GetById(int id);
        CustomerDTO.WithRelations Create(CustomerDTO.WithRelations customer);
        void Update(CustomerDTO.WithRelations customer);
        CustomerDTO.WithRelations Delete(int id);
    }

    public class CustomerService : BaseService, ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly MapperConfiguration _mapperConfig;

        public CustomerService(IMapper mapper, ICustomerRepository customerRepository, IUnitOfWork unitOfWork, ISession session, MapperConfiguration mapperConfig) : base(session)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
            _mapperConfig = mapperConfig;
        }

        public CustomerDTO.WithRelations Create(CustomerDTO.WithRelations customer)
        {
            var dbCustomer = new Domain.Customer.Customer(customer);

            customer.Phones.ForEach(cp => dbCustomer.Phones.Add(new CustomerPhone(cp)));
            customer.Emails.ForEach(ce => dbCustomer.Emails.Add(new CustomerEmail(ce)));

            _customerRepository.Add(dbCustomer);

            _unitOfWork.Commit();

            return _mapper.Map<CustomerDTO.WithRelations>(dbCustomer);
        }
        public IEnumerable<CustomerDTO> GetAll()
        {
            return _customerRepository
                    .GetAll()
                    .ProjectTo<CustomerDTO>(_mapperConfig);
        }
        public CustomerDTO.WithRelations GetById(int id)
        {
            var customer = _customerRepository.GetById(id);

            if (customer == null) throw new ReadEntityException("Customer");

            return _mapper.Map<CustomerDTO.WithRelations>(customer);
        }
        public void Update(CustomerDTO.WithRelations customer)
        {
            var dbCustomer = _customerRepository.GetById(customer.Id);

            if (dbCustomer == null) throw new UpdateEntityException("Customer");

            dbCustomer.SetFields(customer);

            _customerRepository.Update(dbCustomer);

            _unitOfWork.Commit();
        }
        public CustomerDTO.WithRelations Delete(int id)
        {
            var dbCustomer = _customerRepository.GetById(id);

            if (dbCustomer == null) throw new DeleteEntityException("Customer");

            _customerRepository.Delete(dbCustomer);

            _unitOfWork.Commit();

            return _mapper.Map<CustomerDTO.WithRelations>(dbCustomer);
        }
    }
}
