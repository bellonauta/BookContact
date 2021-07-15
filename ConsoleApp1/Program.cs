using System;
using BookContactControl.Domain.Services;
using BookContactControl.Startup;
using Microsoft.Practices.Unity;


namespace BookContactControl.Executable
    
{
    class Program
    {
        static void Main(string[] args)
        {

            // Testes de consumo...

            // Resolve as dependências para um container de trabalho...
            var container = new UnityContainer();
            DependencyResolver.Resolve(container);

            // Pega a implementação dos serviços do domínio...
            var service = container.Resolve<IContactService>();

            try
            {
                // Tenta cadastrar um contato...
                service.Register("wilson2@gmail.com", "Wilson2 Angeli", "(46)99927-3580");
                Console.WriteLine("Contato cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                service.Dispose();
            }


            Console.ReadKey();
            
        }
    }
}
