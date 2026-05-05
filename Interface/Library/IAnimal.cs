namespace Interface.Library;

public interface IAnimal
{
    string Name { get; }
    void Speak();
    string Describe();
}