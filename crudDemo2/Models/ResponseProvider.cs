using crudDemo2.Interfaces;

namespace crudDemo2.Models
{
    public class ResponseProvider : IResponseProvider
    {
        private readonly IViewer _viewer;
        public ResponseProvider(IViewer viewer)
        {
            _viewer= viewer;
        }
        public int GetIntFromUser(int maxValue)
        {
            int value = 0;
            bool isAbleToParse = false;
            while(isAbleToParse==false)
            {
                isAbleToParse = int.TryParse(Console.ReadLine(), out value);
                if (!isAbleToParse || value < 0 || value > maxValue) _viewer.ShowWrongValueError();
            }
            return value;
        }

        public IItem GetItemFromUser(IItem item)
        {
            if(item is Smartphone)
            {
                item = GetSmartphone();
            }
            if(item is Notebook)
            {
                item = GetNotebook();
            }
            return item;
        }

        private IItem GetNotebook()
        {
            throw new NotImplementedException();
        }

        private IItem GetSmartphone()
        {
            throw new NotImplementedException();
        }

        public SearchArguments GetSearchArgumentsFromUser(IItem item)
        {
            throw new NotImplementedException();
        }
    }
}
