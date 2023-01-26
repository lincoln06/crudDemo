internal interface ICrud
{
    void AddToDB(IItem item);
    bool CheckIfItExists(IItem item);
    IItem FindItemInDB(IItem item, SearchArguments searchArguments);
}