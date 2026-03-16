namespace _03_ObjectClassConstructorInheritanceThisvsBase.Models
{
    internal class Teacher:Person
    {
        public string department;
        public string mainSubject;
        public double baseSalary;
        public int experienceYears;

        public Teacher(string firstName, string lastName, int age, string email, string id, string department, string mainSubject, double baseSalary, int experienceYears) : base(firstName, lastName, age, email, id)
        {
            this.department = department;
            this.mainSubject = mainSubject;
            this.baseSalary = baseSalary;
            this.experienceYears = experienceYears;
        }

        public void ShowTeacherInfo()
        {
            Console.WriteLine($"Tam ad: {GetFullName()}\nYas: {age}\nEmail: {email}\nId: {id}\nKafedra: {department}\nEsas fenn: {mainSubject}\nTecrube: {experienceYears}");
        }

        public double CalculateSalary()
        {
            return baseSalary + (experienceYears * 50);
        }
    }
}