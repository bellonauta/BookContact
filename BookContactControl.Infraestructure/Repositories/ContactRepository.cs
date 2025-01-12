﻿using BookContactControl.Domain.Models;
using BookContactControl.Domain.Repositories;
using BookContactControl.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookContactControl.Infraestructure.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private AppDataContext _context; // = new AppDataContext();

        public ContactRepository(AppDataContext context)
        {
            _context = context;
        }

        public Contact Get(string email)
        {
            return _context.Contacts.Where(x => x.Email == email.ToLower().Trim().Replace(" ", "")).FirstOrDefault();
        }

        public List<Contact> GetContacts(string order, int skip, int take) {
            if (order == "" || order == "pk")
                return _context.Contacts.OrderBy(x => x.Email).Skip(skip).Take(take).ToList();
            else if (order == "asc")
                return _context.Contacts.OrderBy(x => x.Name).Skip(skip).Take(take).ToList();
            else
                return _context.Contacts.OrderByDescending(x => x.Name).Skip(skip).Take(take).ToList();
        }

        public void Create(Contact contact)
        {
            _context.Contacts.Add(contact); //Persistir na memória/sessão
            _context.SaveChanges(); //Persistir no banco
        }
        
        public void Update(Contact contact)
        {
            _context.Entry<Contact>(contact).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges(); //Persistir no banco
        }

        public void Delete(Contact contact)
        {
            _context.Contacts.Remove(contact);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
