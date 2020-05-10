namespace PersonsInfo
{
    public class PersonBuilder
    {
        private Person person;

        //public PersonBuilder()
        //{
        //    this.person = new Person();
        //}

        public PersonBuilder WithFirstName(string firstName)
        {
            this.person.FirstName = firstName;
            return this;
        }

        public PersonBuilder WithLastName(string lastName)
        {
            this.person.LastName = lastName;
            return this;
        }

        public PersonBuilder WithAge(int age)
        {
            this.person.Age = age;
            return this;
        }

        public Person Build()
        {
            return this.person;
        }
    }
}
