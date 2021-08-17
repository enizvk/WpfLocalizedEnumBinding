using LocalizedEnumBindingExample.Enums;
using LocalizedEnumBindingExample.MVVM;

namespace LocalizedEnumBindingExample
{
    public class MainViewModel : BindableBase
    {
        private PatientStatus _patientStatus;
        private PatientDepartment _selectedPatientDepartment;
        private Language _selectedLanguage;

        public MainViewModel()
        {
        }

        public PatientDepartment PatientDepartment
        {
            get => _selectedPatientDepartment;
            set
            {
                _selectedPatientDepartment = value;
                RaisePropertyChanged();
            }
        }

        public PatientStatus PatientStatus
        {
            get => _patientStatus;
            set
            {
                _patientStatus = value;
                RaisePropertyChanged();
            }
        }

        public Language SelectedLanguage
        {
            get => _selectedLanguage;
            set
            {
                if (_selectedLanguage == value)
                    return;


                _selectedLanguage = value;
                RaisePropertyChanged();
            }
        }
    }
}
