using WiredBrainCoffee.StorageApp.Data;
using WiredBrainCoffee.StorageApp.Entities;
using WiredBrainCoffee.StorageApp.Repositories;

var employeeRepository = new SqlRepository<Employee>(new StorageAppDbContext());

AddEmployees(employeeRepository);
AddManagers(employeeRepository);

GetEmployeeById(employeeRepository);
WriteAllToConsole(employeeRepository);


var organisationRepository = new ListRepository<Organisation>();
AddOrganisations(organisationRepository);
WriteAllToConsole(organisationRepository);


Console.ReadLine();



static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}
static void GetEmployeeById(IRepository<Employee> employeeRepository)
{
    var employee = employeeRepository.GetById(2);
    Console.WriteLine($"Employee with Id 2: {employee.FirstName}");
}
static void AddEmployees(IRepository<Employee> employeeRepository)
{
    employeeRepository.Add(new Employee { FirstName = "Sam" });
    employeeRepository.Add(new Employee { FirstName = "John" });
    employeeRepository.Add(new Employee { FirstName = "Bilbo" });
    employeeRepository.Save();
}
static void AddOrganisations(IRepository<Organisation> organisationRepository)
{
    organisationRepository.Add(new Organisation { Name = "Viabl" });
    organisationRepository.Add(new Organisation { Name = "Facebook" });
    organisationRepository.Add(new Organisation { Name = "Google" });
    organisationRepository.Save();
}

static void AddManagers(IWriteRepository<Manager> managerRepository)
{
    managerRepository.Add(new Manager{ FirstName="Sara"});
    managerRepository.Add(new Manager { FirstName = "Gavin" });
    managerRepository.Save();
}