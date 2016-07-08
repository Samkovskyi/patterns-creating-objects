using CreatingObjects.Interfaces;

namespace CreatingObjects.Builders.Interfaces
{
    public interface IContactHolder
    {
        IContactHolder WithSecondatyContact(IContactInfo contact);
        IPersonBuilder AddNoMoreContacts();
    }
}