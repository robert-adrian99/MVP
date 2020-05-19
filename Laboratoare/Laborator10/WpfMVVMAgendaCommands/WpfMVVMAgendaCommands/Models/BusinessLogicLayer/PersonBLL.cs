using System;
using System.Collections.ObjectModel;
using WpfMVVMAgendaCommands.Exceptions;

namespace WpfMVVMAgendaCommands.Models
{
    class PersonBLL
    {
        public ObservableCollection<Person> PersonsList { get; set; }

        PersonDAL persoanaDAL = new PersonDAL();

        internal ObservableCollection<Person> GetAllPersons()
        {
            return persoanaDAL.GetAllPersons();
        }

        internal ObservableCollection<Person> GetAllPersonsWithoutPhone()
        {
            return persoanaDAL.GetAllPersonsWithNoPhone();
        }

        internal void AddPerson(Person persoana)
        {
            if (String.IsNullOrEmpty(persoana.Name))
            {
                throw new AgendaException("Numele persoanei trebuie sa fie precizat");
            }
            persoanaDAL.AddPerson(persoana);
            PersonsList.Add(persoana);
        }

        internal void ModifyPerson(Person persoana)
        {
            if (persoana == null)
            {
                throw new AgendaException("Trebuie selectata o persoana");
            }
            if (String.IsNullOrEmpty(persoana.Name))
            {
                throw new AgendaException("Trebuie precizat numele persoanei");
            }
            persoanaDAL.ModifyPerson(persoana);
        }

        internal void DeletePerson(Person persoana)
        {
            if (persoana == null)
            {
                throw new AgendaException("Trebuie precizata o persoana!");
            }
            else
            {
                PhoneDAL phoneDAL = new PhoneDAL();
                if (phoneDAL.GetAllPhonesForPerson(persoana).Count > 0)
                {
                    throw new AgendaException("Trebuie sa stergeti mai intai numerele de telefon ale persoanei!");
                }
            }
            persoanaDAL.DeletePerson(persoana);
            PersonsList.Remove(persoana);
        }
    }
}
