namespace MVC_CRUD.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateOnly ContractDate { get; set; }
        public bool Active { get; set; }
    }
}