using RestWithAspNetUdemy.Model;

namespace RestWithAspNetUdemy.Services.Implementations
{
    public class PersonServicesImplements : IPersonServices
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
           
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 9; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
        }
        public Person FindByID(long id)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                Name = "Victor",
                LastName = "Rodrigues",
                Address = "São Paulo",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                Name = "Neymar" + i,
                LastName = "Junior" + i,
                Address = "Bahia" + i,
                Gender = "Male" + i
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
