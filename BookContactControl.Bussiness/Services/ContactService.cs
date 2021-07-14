using BookContactControl.Domain.Models;
using BookContactControl.Domain.Repositories;
using BookContactControl.Domain.Services;
using System;
using System.Collections.Generic;


namespace BookContactControl.Bussiness.Services
{
    public class ContactService : IContactService
    {

        private IContactRepository _repository;

        public ContactService(IContactRepository repository)
        {
            _repository = repository;
        }

        public void ChangeInformation(string email, string name, string phone)
        {
            var contact = Get(email);

            if (contact == null)
                throw new InvalidOperationException("Contato não cadastrado.");

            contact.ChangeName(name);
            contact.ChangePhone(phone);
            contact.Validate();

            _repository.Update(contact);        
        }

        
        public Contact Get(string email)
        {
            var contact = _repository.Get(email);
            if (contact == null)
               throw new InvalidOperationException("Contato não cadastrado.");

            return contact;
        }

        public List<Contact> GetByRange(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public void Register(string email, string name, string phone)
        {
            var found = Get(email);
            if (found != null)
                throw new InvalidOperationException("Contato já cadastrado.");

            var contact = new Contact(email, name, phone);
            contact.Validate();

            _repository.Create(contact);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

    }
}
}
