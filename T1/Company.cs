namespace MLOOP2_L3.T1
{
    public class Company
    {
        public enum AreaOfBusiness
        {
            None,
            IT,
            Marketing,
            Military,
            Cinema,
            Science,
            Electricity
        }

        public int ID { get; init; }
        public string? Name { get; init; }
        public string? Description { get; init; }
        public int NumOfEmployees { get; init; }
        public string? Address { get; init; }
        public DateTime DateOfFoundation { get; init; }
        public AreaOfBusiness Area { get; init; }
        public FullName CEO { get; init; }

        public Company(int id, string? name, string? description, int numOfEmployees, string? address, DateTime dateOfFoundation,
            string? ceoName, string? ceoSurname, string? ceoPatronymic, AreaOfBusiness area)
        {
            ID = id;
            Name = name;
            Description = description;
            NumOfEmployees = numOfEmployees;
            Address = address;
            DateOfFoundation = dateOfFoundation;
            CEO = new FullName( ceoName, ceoSurname, ceoPatronymic );
            Area = area;
        }

        public Company() : this(0, null, null, 1, null, new DateTime(1984, 5, 5), null, null, null, AreaOfBusiness.None) { }

        public Company(int id, string? name, string? description) : 
            this(id, name, description, 1, null, new DateTime(1984, 5, 5), null, null, null, AreaOfBusiness.None) { }

        public Company(int id, string? name, string? description, string? ceoName, string? ceoSurname, string? ceoPatronymic, AreaOfBusiness area) :
            this(id, name, description, 1, null, new DateTime(1984, 5, 5), ceoName, ceoSurname, ceoPatronymic, area) { }

        public override string ToString()
        {
            return $"id: {ID}; ім'я компанії: {Name}; опис: {Description}; сфера: {Area}; к-ість працівників: {NumOfEmployees}; " +
                $"юридична адреса: {Address}; дата заснування: {DateOfFoundation}; гендиректор: {CEO.name} {CEO.surname} {CEO.patronymic};";
        }
    }
}
