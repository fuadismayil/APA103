namespace _03_ObjectClassConstructorInheritanceThisvsBase.Models
{
    internal class Administrator:Person
    {
        public string position;
        public string department;
        public int accessLevel;

        public Administrator(string firstName, string lastName, int age, string email, string id, string position, string department, int accessLevel):base(firstName, lastName, age, email, id)
        {
            this.position = position;
            this.department = department;
            this.accessLevel = accessLevel;
        }

        public void ShowAdminInfo()
        {
            Console.WriteLine($"Tam ad: {GetFullName()}\nYas: {age}\nEmail: {email}\nID: {id}\nVezife: {position}\nKafedra: {department}\nGiris seviyyesi: {accessLevel}");
        }

        public void GrantAccess(Student student)
        {
            Console.WriteLine($"Bu telebeye giris icazesi verildi: {student.GetFullName()}");
        }
    }
}