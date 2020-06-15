using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVMAgendaEF.Models;
using WpfMVVMAgendaEF.ViewModels;

namespace WpfMVVMAgendaEF.Actions
{
    class PhoneActions
    {
        Agenda2015Entities context = new Agenda2015Entities();
        private PhoneVM phoneContext;
        public PhoneActions(PhoneVM phoneContext)
        {
            this.phoneContext = phoneContext;
        }

        public void AddMethod(object obj)
        {
            //parametrul obj este cel dat prin CommandParameter cu MultipleBinding la Button in xaml
            PhoneVM phoneVM = obj as PhoneVM;
            if (phoneVM.PersonId==0)
                phoneContext.Message = "Selecteaza o persoana din lista";
            else if (String.IsNullOrEmpty(phoneVM.PhoneNumber))
                phoneContext.Message = "Numarul de telefon trebuie precizat";
            else if (String.IsNullOrEmpty(phoneVM.Description))
                phoneContext.Message = "Descrierea trebuie precizata";
            else
            {
                context.AddPhoneForPerson2(phoneVM.PersonId, phoneVM.PhoneNumber, phoneVM.Description);
                context.SaveChanges();
                phoneContext.PhonesList = PhonesForPerson(phoneVM.PersonId);
                phoneContext.Message = "";
            }
        }

        public void UpdateMethod(object obj)
        {
            //parametrul obj este cel dat prin CommandParameter la Button in xaml
            PhoneVM phoneVM = obj as PhoneVM;
            if (phoneVM == null)
                phoneContext.Message = "Selecteaza un numar de telefon";
            else if (String.IsNullOrEmpty(phoneVM.PhoneNumber))
                phoneContext.Message = "Numarul de telefon trebuie precizat";
            else if (String.IsNullOrEmpty(phoneVM.Description))
                phoneContext.Message = "Descrierea trebuie precizata";
            else
            {
                telefoane tel = context.telefoanes.Find(phoneVM.PhoneId);
                tel.numarTelefon = phoneVM.PhoneNumber;
                tel.descriere = phoneVM.Description;
                context.SaveChanges();
                phoneContext.PhonesList = PhonesForPerson(phoneVM.PersonId);
                phoneContext.Message = "";
            }
        }

        public void DeleteMethod(object obj)
        {
            //parametrul obj este cel dat prin CommandParameter la Button in xaml
            PhoneVM phoneVM = obj as PhoneVM;
            if (phoneVM == null)
                phoneContext.Message = "Selecteaza un numar de telefon";
            else
            {
                context.DeletePhone(phoneVM.PhoneId);
                context.SaveChanges();
                phoneContext.PhonesList = PhonesForPerson(phoneVM.PersonId);
                phoneContext.Message = "";
            }
        }

        public ObservableCollection<PhoneVM> PhonesForPerson(int persId)
        {
            List<telefoane> phones = context.telefoanes.Where(item => item.idPersoana == persId).ToList();
            ObservableCollection<PhoneVM> result = new ObservableCollection<PhoneVM>();
            foreach (telefoane phone in phones)
            {
                result.Add(new PhoneVM()
                {
                    PhoneId = phone.idTelefon,
                    PhoneNumber = phone.numarTelefon,
                    Description = phone.descriere
                });
            }
            return result;
        }
    }
}
