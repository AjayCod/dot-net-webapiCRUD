using Microsoft.EntityFrameworkCore;

namespace dot_net_webapi.Data
{
    public class EmployeeRepository
    {
        private readonly AppDBContext _context;
        public EmployeeRepository(AppDBContext AppDBContext)
        {
            _context = AppDBContext;
        }
        public async Task AddEmployee(Employee employee)
        {
            await _context.Set<Employee>().AddAsync(employee);
            await _context.SaveChangesAsync();
         
        }
        public async Task<List<Employee>> GetAllEmployee()
        {
           return  await _context.Employees.ToListAsync();

        }
        public async Task UpdateEmployee(Employee employee)
        {

        }
       
        public async Task DeleteEmployee(int id)
        {
            var existEmployee = await _context.Employees.FindAsync(id);
            if (existEmployee == null)
            {
                throw new Exception("No Employee Found");
            }

            _context.Employees.Remove(existEmployee);
            await _context.SaveChangesAsync();
        }

        public async Task<Employee> GetEmployeeeById(int id)
        {
            return await _context.Employees.FindAsync(id);
        }
        public async Task UpdateEmployee(int id,Employee model)
        {
            var employees =await _context.Employees.FindAsync(id);
            if (employees == null)
            {
                throw new Exception("Not fount");
            }
            employees.Name = model.Name;
            employees.Age = model.Age;
            employees.Salary = model.Salary;
            employees.Email = model.Email;
           await _context.SaveChangesAsync();
        }
    } 
}
