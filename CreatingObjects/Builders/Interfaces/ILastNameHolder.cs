namespace CreatingObjects.Builders.Interfaces
{
    public interface ILastNameHolder
    {
        IPrimaryContactHolder WithLastName(string surename);
    }
}