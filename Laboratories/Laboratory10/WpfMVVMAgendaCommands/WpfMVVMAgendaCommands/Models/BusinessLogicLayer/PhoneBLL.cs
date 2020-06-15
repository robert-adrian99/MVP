using System;
using System.Collections.ObjectModel;
using WpfMVVMAgendaCommands.Exceptions;

namespace WpfMVVMAgendaCommands.Models
{
    class PhoneBLL
    {
        public ObservableCollection<Phone> PhonesList { get; set; }

        public PhoneBLL()
        {
            PhonesList = new ObservableCollection<Phone>();
        }

        internal void GetPhonesForPerson(Person persoana)
        {
            PhonesList.Clear();
            PhoneDAL telefoaneDAL = new PhoneDAL();
            var phones = telefoaneDAL.GetAllPhonesForPerson(persoana);
            foreach (var ph in phones)
            {
                PhonesList.Add(ph);
            }
        }

        //internal ObservableCollection<Phone> GetPhonesForPerson(Person persoana)
        //{
        //    PhoneDAL telefoaneDAL = new PhoneDAL();
        //    return telefoaneDAL.GetAllPhonesForPerson(persoana);
        //}

        internal void AddPhone(Phone telefon)
        {
            if (String.IsNullOrEmpty(telefon.PhoneNumber))
            {
                throw new AgendaException("Numarul de telefon nu poate sa lipseasca");

            }
            else if (telefon.PersonID == null)
            {
                throw new AgendaException("Trebuie precizat cui ii apartine numarul");
            }
            else
            {
                PhoneDAL telefoaneDAL = new PhoneDAL();
                telefoaneDAL.AddPhone(telefon);
                PhonesList.Add(telefon);
            }
        }

        internal void ModifyPhone(Phone phone)
        {
            if (phone == null)
            {
                throw new AgendaException("Trebuie selectat un numar de telefon");
            }
            if (String.IsNullOrEmpty(phone.PhoneNumber))
            {
                throw new AgendaException("Trebuie precizat numarul de telefon");
            }
            if (String.IsNullOrEmpty(phone.Description))
            {
                throw new AgendaException("Trebuie precizata o descriere");
            }
            PhoneDAL telefoaneDAL = new PhoneDAL();
            telefoaneDAL.ModifyPhone(phone);
        }

        internal void DeletePhone(Phone telefon)
        {
            if (telefon == null || telefon.PhoneID == null)
            {
                throw new AgendaException("Alege un numar de telefon!");
            }
            PhoneDAL telefoaneDAL = new PhoneDAL();
            telefoaneDAL.DeletePhone(telefon);
            PhonesList.Remove(telefon);
        }
    }
}
