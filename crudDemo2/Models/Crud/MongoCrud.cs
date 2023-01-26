using MongoDB.Driver;

public class MongoCrud : CrudBase, ICrud
{
    private readonly static MongoClient _client = new();
    private readonly static IMongoDatabase _database = _client.GetDatabase(_databaseName);
    private readonly IMongoCollection<Smartphone> _smartphonesCollection = _database.GetCollection<Smartphone>(_notebooksTableName);
    private readonly IMongoCollection<Notebook> _notebooksCollection = _database.GetCollection<Notebook>(_notebooksTableName);

    public void AddToDB(IItem item)
    {
        if (item is Smartphone)
        {
            Smartphone smartphone = (Smartphone)item;
            AddSmartphoneToDB(smartphone);
        }
        if (item is Notebook)
        {
            Notebook notebook = (Notebook)item;
            AddNotebookToDB(notebook);
        }
    }

    private void AddNotebookToDB(Notebook notebook)
    {
        _notebooksCollection.InsertOne(notebook);
    }

    private void AddSmartphoneToDB(Smartphone smartphone)
    {
        _smartphonesCollection.InsertOne(smartphone);
    }

    public bool CheckIfItExists(IItem item)
    {
        if (item is Smartphone) return CheckIfSmartphoneExists(item);
        if (item is Notebook) return CheckIfNotebookExists(item);
        return false;
    }

    private bool CheckIfNotebookExists(IItem item)
    {
        Notebook notebook = (Notebook)item;
        var filter = Builders<Notebook>.Filter.And(
            Builders<Notebook>.Filter.Eq("Manufacturer", notebook.Manufacturer),
            Builders<Notebook>.Filter.Eq("Model", notebook.Model));
        try
        {
            var record = _notebooksCollection.Find(filter).First();
            return true;
        }
        catch
        {
            return false;
        }
    }

    private bool CheckIfSmartphoneExists(IItem item)
    {
        Smartphone smartphone = (Smartphone)item;
        var filter = Builders<Smartphone>.Filter.And(
            Builders<Smartphone>.Filter.Eq("Manufacturer", smartphone.Manufacturer),
            Builders<Smartphone>.Filter.Eq("Model", smartphone.Model));
        try
        {
            var record = _smartphonesCollection.Find(filter).First();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public IItem FindItemInDB(IItem item, SearchArguments searchArguments)
    {
        if (item is Smartphone) item = FindSmartphoneInDB(searchArguments);
        if (item is Notebook) item = FindNotebookInDB(searchArguments);
        return item;
    }

    private Notebook? FindNotebookInDB(SearchArguments searchArguments)
    {
        var filter = Builders<Notebook>.Filter.And(
            Builders<Notebook>.Filter.Eq("Manufacturer", searchArguments.Arg1),
            Builders<Notebook>.Filter.Eq("Model", searchArguments.Arg2));
        try
        {
            var record = _notebooksCollection.Find(filter).First();
            return record;
        }
        catch
        {
            return null;
        }
    }

    private Smartphone? FindSmartphoneInDB(SearchArguments searchArguments)
    {
        var filter = Builders<Smartphone>.Filter.And(
            Builders<Smartphone>.Filter.Eq("Manufacturer", searchArguments.Arg1),
            Builders<Smartphone>.Filter.Eq("Model", searchArguments.Arg2));
        try
        {
            var record = _smartphonesCollection.Find(filter).First();
            return record;
        }
        catch
        {
            return null;
        }
    }
}