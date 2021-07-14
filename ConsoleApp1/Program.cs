using BookContactControl.Domain.Models;
using BookContactControl.Domain.Repositories;
using BookContactControl.Infraestructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var contact = new Contact("wilson@gmail.com", "Wilson Angeli", "(46)99927-3580");

            var found = false;

            using (IContactRepository contactRep = new ContactRepository())
            {
                found = contactRep.Get(contact.Email) != null;
            }

   
            if (!found)
            {
                using (IContactRepository contactRep = new ContactRepository())
                {
                    contactRep.Create(contact);
                }
            }

            using (IContactRepository contactRep = new ContactRepository())
            {
                var cnt = contactRep.Get("wilson@gmail.com");
                Console.WriteLine(cnt.Name);
            }

            using (IContactRepository contactRep = new ContactRepository())
            {
                contactRep.Delete(contact);
            }

            Console.ReadKey();
            
        }
    }
}
