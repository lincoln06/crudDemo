using crudDemo2.Interfaces;
using FluentValidation.Results;

namespace crudDemo2.View
{
    public class Viewer : IViewer
    {
        public bool ShowItem(IItem item)
        {
            if(item is null) return false;
            if(item is Smartphone)
            {
                Smartphone smartphone= (Smartphone)item;
                ShowSmartphone(smartphone);
            }
            if(item is Notebook)
            {
                Notebook notebook= (Notebook)item;
                ShowNotebook(notebook);
            }
            return true;
        }

        private void ShowNotebook(Notebook notebook)
        {
            throw new NotImplementedException();
        }

        private void ShowSmartphone(Smartphone smartphone)
        {
            throw new NotImplementedException();
        }

        public void ShowItemExistsError()
        {
            Console.WriteLine("Podany obiekt juz istnieje w bazie");
        }

        public void ShowNotFoundError()
        {
            Console.WriteLine("Nie znaleziono");
        }

        public bool ShowOutputMessage(List<ValidationFailure>? validationFailures)
        {
            if(validationFailures is null)
            {
                ShowAllDoneMessage();
                return true;
            }
            ShowErrors(validationFailures);
            return false;
        }

        private void ShowErrors(List<ValidationFailure> validationFailures)
        {
            Console.WriteLine("\n");
            Console.WriteLine(new String('-',20));
            Console.WriteLine("Wprowadzono nieprawidłowe dane");
            Console.WriteLine(new String('-', 20));
            foreach(ValidationFailure failure in validationFailures)
            {
                Console.WriteLine(failure.ToString());
            }
            Console.ReadKey();
        }

        private void ShowAllDoneMessage()
        {
            Console.WriteLine("Dodano pomyslnie");
        }

        public void ShowWrongValueError()
        {
            Console.WriteLine("Nieprawidłowa wartość");
        }
    }
}
