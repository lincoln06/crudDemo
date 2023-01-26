using crudDemo2.Interfaces;
using crudDemo2.View;

public class App
{
    private readonly IMenu _menu;
    private readonly IResponseProvider _responseProvider;
    private readonly IViewer _viewer;
    private int _response;
    private ICrud _crud;
    private IItem _item;
    private bool _doesItExists;
    private SearchArguments _searchArguments;
    public App(IMenu menu, IResponseProvider responseProvider, IViewer viewer)
    {
        _menu = menu;
        _responseProvider = responseProvider;
        _viewer = viewer;
    }
    public void Start()
    {
        _menu.ShowMainMenu();
        _response = _responseProvider.GetIntFromUser(2);
        switch (_response)
        {
            case 1:
                _crud = new MongoCrud();
                break;
            case 2:
                _crud = new SqliteCrud();
                break;
        }
        _menu.ChooseTypeOfElement();
        _response = _responseProvider.GetIntFromUser(2);
        switch (_response)
        {
            case 1:
                _item = new Smartphone();
                break;
            case 2:
                _item = new Notebook();
                break;
        }
        _menu.AskWhatToDo();
        _response = _responseProvider.GetIntFromUser(2);
        switch (_response)
        {
            case 1:
                _item = _responseProvider.GetItemFromUser(_item);
                _doesItExists = _crud.CheckIfItExists(_item);
                if (_doesItExists)
                {
                    _viewer.ShowItemExistsError();
                }
                else
                {
                    if (_viewer.ShowOutputMessage(_item.Validate())) _crud.AddToDB(_item);
                }
                break;
            case 2:
                _searchArguments = _responseProvider.GetSearchArgumentsFromUser(_item);
                _item = _crud.FindItemInDB(_item, _searchArguments);
                if (!_viewer.ShowItem(_item)) _viewer.ShowNotFoundError();
                break;
        }
    }
}