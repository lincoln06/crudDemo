using crudDemo2.Interfaces;

namespace crudDemo2.View
{
    public class Menu : IMenu
    {
        public void AskWhatToDo()
        {
            Console.WriteLine("Wybierz akcję");
            Console.WriteLine("1\tDodaj");
            Console.WriteLine("2\tWyświetl");
        }

        public void ChooseTypeOfElement()
        {
            Console.WriteLine("Wybierz typ elementu");
            Console.WriteLine("1\tSmartfon");
            Console.WriteLine("2\tNotebook");
        }

        public void ShowMainMenu()
        {
            Console.WriteLine("Wybierz CRUD");
            Console.WriteLine("1\tMongoDB");
            Console.WriteLine("2\tSQLite");
        }
    }
}
