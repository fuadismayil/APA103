namespace _03_ObjectClassConstructorInheritanceThisvsBase.Models
{
    internal class Person
    {
        public string firstName;
        public string lastName;
        public int age;
        public string email;
        public string id;

        public Person(string firstName, string lastName, int age, string email, string id)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.email = email;
            this.id = id;
        }
        public string GetFullName()
        {
            return $"{firstName} {lastName}";
        }

        public void ShowBasicInfo()
        {
            Console.WriteLine($"Tam ad: {GetFullName()}");
            Console.WriteLine($"Yas: {age}");
            Console.WriteLine($"Email: {email}");
            Console.WriteLine($"ID: {id}");
        }
    }
}