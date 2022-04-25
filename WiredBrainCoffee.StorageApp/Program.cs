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

void AddEmployees(IRepository<Employee> employeeRepository)
{
    var employees = new[]
    {
    new Employee { FirstName = "Sam" },
    new Employee { FirstName = "John" },
    new Employee { FirstName = "Bilbo" }
    };
    employeeRepository.AddBatch(employees);
    employeeRepository.Save();
}

void AddOrganisations(IRepository<Organisation> organisationRepository)
{
    var organisations = new[]
    {
        new Organisation { Name = "Viabl" },
        new Organisation { Name = "Facebook" },
        new Organisation { Name = "Google" }
    };
    organisationRepository.AddBatch(organisations);
}

void AddManagers(IWriteRepository<Manager> managerRepository)
{
    var managers = new[]
    {
    new Manager { FirstName = "Sara" },
    new Manager { FirstName = "Gavin" },
    };
    managerRepository.AddBatch(managers);
    managerRepository.Save();
}
