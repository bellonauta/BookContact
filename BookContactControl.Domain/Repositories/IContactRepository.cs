using BookContactControl.Domain.Models;
using System;
using System.Collections.Generic;

namespace BookContactControl.Domain.Repositories
{
    public interface IContactRepository : IDisposable
    {
        Contact Get(string email);
        void Create(Contact contact);
        void Update(Contact contact);
        void Delete(Contact contact);
        List<Contact> GetContacts(int skip, int take);
    }
}