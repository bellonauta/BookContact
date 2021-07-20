using BookContactControl.Domain.Models;
using BookContactControl.Domain.Repositories;
using BookContactControl.Domain.Services;
using System;
using System.Collections.Generic;


namespace BookContactControl.Business.Services
{
    public class ContactService : IContactService
    {

        private IContactRepository _repository;

        public ContactService(IContactRepository repository)
        {
            _repository = repository;
        }

        public Contact AuthenticateConsumer(string id)
        // Autentica o cliente consumidor do serviço/API.
        // Essa autenticação pode estar nos serviços do domínio de autenticação do serviço/API. Foi
        // Mantida aqui para facilitar os testes.
        // "id", nessa implementação, deve ser o email do cliente consumidor.
        {
            var contact = Get(id); // Como está usando a mesma tabela para contatos e consumidores, utiliza o mesmo método Get().

            if (contact == null)
            {
                // Em produção, quando o consumer não existir, um erro deve ser retornado.

                // Em desenvolvimento/testes, cadastra o consumer para permitir a continuidade...
                Register(id, id, "(41)99345-1234");
                contact = Get(id); //Atualiza a instância
            }

            if (contact == null)
               throw new InvalidOperationException("Cliente não cadastrado.");

            return contact;
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
            return contact;
        }

        public List<Contact> GetContacts(int skip, int take)     
        {
            var contacts = _repository.GetContacts(skip, take);
            return contacts;
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