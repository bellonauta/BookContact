using BookContactControl.Domain.Models;
using System;
using System.Collections.Generic;

namespace BookContactControl.Domain.Services
{
    public interface IContactService : IDisposable
    {
        Contact Get(string email);
        void Register(string email, string name, string phone);
        void ChangeInformation(string email, string name, string phone);
        List<Contact> GetByRange(int skip, int take);
    }
}