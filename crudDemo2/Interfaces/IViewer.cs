using FluentValidation.Results;

namespace crudDemo2.Interfaces
{
    public interface IViewer
    {
        bool ShowItem(IItem item);
        void ShowItemExistsError();
        void ShowNotFoundError();
        bool ShowOutputMessage(List<ValidationFailure> validationFailures);
        void ShowWrongValueError();
    }
}