using CreatingObjects.Interfaces;

namespace CreatingObjects.Builders.Interfaces
{
    public interface IPrimaryContactHolder
    {
        IContactHolder WithPrimaryContact(IContactInfo contact);
    }
}