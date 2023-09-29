namespace Perosn_RecursiveGenerics
{
    public class Person {
        public string Name;
        public string Position;

        public class Builder : PersonJobBuilder<Builder> { }

        public static Builder New => new Builder();

        public override string? ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}";
        }
    }

    public abstract class PersonBuilder
    {
        protected Person Person;
        public PersonBuilder()
        {
            Person = new Person();
        }
        public Person Build() => Person;
    }

    public class PersonInfoBuilder<T> : PersonBuilder where T : PersonInfoBuilder<T>
    {
        public T Called(string name)
        {
            Person.Name = name;
            return (T)this;
        }
    }

    public class PersonJobBuilder<T>: PersonInfoBuilder<PersonJobBuilder<T>> where T : PersonJobBuilder<T>
    {
        public T WorksAsA(string position)
        {
            Person.Position = position;
            return (T)this;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            var me = Person.New.Called("rasoul").WorksAsA("developer").Build();
            Console.WriteLine(me);
        }
    }
}