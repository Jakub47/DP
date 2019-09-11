using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private string _firstName = "Tim";
        private string _lastName;
        private PersonModel _selectedPerson;
        private BindableCollection<PersonModel> _people = new BindableCollection<PersonModel>();

        public ShellViewModel()
        {
            People.Add(new PersonModel { FirstName = "Jakub", LastName = "Berg" });
            People.Add(new PersonModel { FirstName = "Maciek", LastName = "Johnes" });
            People.Add(new PersonModel { FirstName = "Joanna", LastName = "Kowalska" });
            ActivateItem(new TaskListViewModel());
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; NotifyOfPropertyChange(() => FirstName); NotifyOfPropertyChange(() => FullName); }
        }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; NotifyOfPropertyChange(() => LastName); NotifyOfPropertyChange(() => FullName); }
        } 
        public string FullName
        {
            get { return $"{ FirstName } { LastName }"; }
        }

        public BindableCollection<PersonModel> People
        {
            get { return _people; }
            set { _people = value; }
        }
        public PersonModel SelectedPerson
        {
            get { return _selectedPerson; }
            set { _selectedPerson = value; NotifyOfPropertyChange(() => SelectedPerson); }
        }

        public bool CanClearText(string firstName, string lastName) /*=> !String.IsNullOrWhiteSpace(firstName) || !String.IsNullOrWhiteSpace(lastName);*/
        {
            //return !String.IsNullOrWhiteSpace(firstName) && !String.IsNullOrWhiteSpace(lastName);
            if (string.IsNullOrWhiteSpace(firstName) && string.IsNullOrWhiteSpace(lastName))
                return false;
            else
                return true;
        }

        public void ClearText(string firstName,string lastName)
        {
            FirstName = string.Empty;
            LastName = string.Empty;
        }

        public void LoadPageTwo()
        {
            ActivateItem(new AddTaskViewModel());
        }
    }
}
