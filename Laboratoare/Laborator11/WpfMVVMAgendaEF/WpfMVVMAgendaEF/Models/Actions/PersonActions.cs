using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVMAgendaEF.Models;
using WpfMVVMAgendaEF.Utilities;
using WpfMVVMAgendaEF.ViewModels;

namespace WpfMVVMAgendaEF.Actions
{
    class PersonActions: BaseVM
    {
        Agenda2015Entities context = new Agenda2015Entities();

        private PersonVM persContext;
        public PersonActions(PersonVM persContext)
        {
            this.persContext = persContext;
        }

        public void AddMethod(object obj)
        {
            //parametrul obj este cel dat prin CommandParameter cu MultipleBinding la Button in xaml
            PersonVM personVM = obj as PersonVM;
            if (personVM != null)
            {
                if (String.IsNullOrEmpty(personVM.Name))
                {
                    persContext.Message = "Numele persoanei trebuie precizat";
                }
                else
                {
                    context.AddPerson2(personVM.Name, personVM.Address);
                    //context.persoanes.Add(new persoane() { nume = personVM.Name , adresa = personVM.Address});
                    context.SaveChanges();
                    persContext.PersonsList = AllPersons();
                    persContext.Message = "";
                }
            }
        }

        public void UpdateMethod(object obj)
        {
            PersonVM personVM = obj as PersonVM;
            if (personVM == null)
            {
                persContext.Message = "Selecteaza o persoana";
            }
            else if (String.IsNullOrEmpty(personVM.Name))
            {
                persContext.Message = "Numele persoanei trebuie precizat";
            }
            else
            {
                context.ModifyPerson(personVM.PersonId, personVM.Name, personVM.Address);
                context.SaveChanges();
                persContext.Message = "";
            }
        }

        public void DeleteMethod(object obj)
        {
            PersonVM personVM = obj as PersonVM;
            if (personVM == null)
            {
                persContext.Message = "Selecteaza o persoana";
            }
            else
            {
                persoane pers = context.persoanes.Where(i => i.idPersoana == personVM.PersonId).FirstOrDefault();
                if (pers.telefoanes.Count > 0)
                {
                    persContext.Message = "Persoana are telefoane asociate";
                }
                else
                {
                    context.DeletePerson(personVM.PersonId);
                    context.SaveChanges();
                    persContext.PersonsList = AllPersons();
                    persContext.Message = "";
                }
            }
        }

        public ObservableCollection<PersonVM> AllPersons()
        {
            List<persoane> persons = context.persoanes.ToList();
            ObservableCollection<PersonVM> result = new ObservableCollection<PersonVM>();
            foreach (persoane person in persons)
            {
                result.Add(new PersonVM()
                {
                    PersonId = person.idPersoana,
                    Name = person.nume,
                    Address = person.adresa
                });
            }
            return result;
        }

        public List<persoane> PersonsWoPhone()
        {
            var persons = context.GetAllPersonsWithNoPhone();
            List<persoane> result = new List<persoane>();
            foreach (var person in persons)
            {
                result.Add(new persoane()
                {
                    idPersoana = person.idPersoana,
                    nume = person.nume,
                    adresa = person.adresa
                });
            }
            return result;
        }
    }
}
