using System;
using System.ComponentModel.DataAnnotations;
using BookContactControl.Common.Validators;


namespace BookContactControl.Domain.Models
{
    public class Contact
    {
        protected Contact() { }

        public Contact(string email, string name, string phone)
        {
            this.Email = email.ToLower().Trim().Replace(" ","");
            this.Name = name.Trim().Replace("  ", " ");
            this.Phone = phone.Trim().Replace(" ", "");
        }

        [Key]
        public String Email { get; private set; }
        
        public String Name { get; private set; }
        public String Phone { get; private set; }

        public void ChangeName(string newName) 
        {
            this.Name = newName.Trim().Replace("  ", " ");
        }

        public void ChangePhone(string newPhone) 
        {
            this.Phone = newPhone.Trim().Replace(" ", "");
        }

        public void Validate() 
        {
            EmailAssertionConcern.AssertIsValid(this.Email, "e-mail inválido.");
            AssertionConcern.AssertArgumentLength(this.Name, 3, 60, "Nome inválido.");
            PhoneAssertionConcern.AssertIsValid(this.Phone, "Telefone com número inválido.");
        }     
    }
}