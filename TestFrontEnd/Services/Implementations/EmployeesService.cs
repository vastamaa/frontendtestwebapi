using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestFrontEnd.Models;

namespace TestFrontEnd.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly AppDbContext _context;

        public EmployeesService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            var employees = await _context.Employees.Select(x => new Employee()
            {
                EmployeeNumber = x.EmployeeNumber,
                LastName = x.LastName,
                FirstName = x.FirstName,
                Extension = x.Extension,
                Email = x.Email,
                OfficeCode = x.OfficeCode,
                ReportsTo = x.ReportsTo,
                JobTitle = x.JobTitle
            }).ToListAsync();

            return employees;
        }

        public async Task<Employee> GetOneEmployeeAsync(int employeeNumber)
        {
            var employee = await _context.Employees.Where(x => x.EmployeeNumber == employeeNumber).Select(x => new Employee()
            {
                EmployeeNumber = x.EmployeeNumber,
                LastName = x.LastName,
                FirstName = x.FirstName,
                Extension = x.Extension,
                Email = x.Email,
                OfficeCode = x.OfficeCode,
                ReportsTo = x.ReportsTo,
                JobTitle = x.JobTitle
            }).FirstOrDefaultAsync();

            return employee;
        }

        public async Task UpdateOneEmployeeAsync(Employee employeeModel)
        {
            var employee = await _context.Employees.FindAsync(employeeModel.EmployeeNumber);

            if (employee is not null)
            {
                employee.EmployeeNumber = employeeModel.EmployeeNumber;
                employee.LastName = employeeModel.LastName;
                employee.FirstName = employeeModel.FirstName;
                employee.Extension = employeeModel.Extension;
                employee.Email = employeeModel.Email;
                employee.OfficeCode = employeeModel.OfficeCode;
                employee.ReportsTo = employeeModel.ReportsTo;
                employee.JobTitle = employeeModel.JobTitle;

                await _context.SaveChangesAsync();
            }
        }

        public async Task PatchOneEmployeeAsync(JsonPatchDocument employeeModel, int employeeNumber)
        {
            var employee = await _context.Employees.FindAsync(employeeNumber);

            if (employee is not null)
            {
                employeeModel.ApplyTo(employee);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> PostOneEmployeeAsync(Employee employeeModel)
        {
            var employee = new Employee()
            {
                EmployeeNumber = employeeModel.EmployeeNumber,
                LastName = employeeModel.LastName,
                FirstName = employeeModel.FirstName,
                Extension = employeeModel.Extension,
                Email = employeeModel.Email,
                OfficeCode = employeeModel.OfficeCode,
                ReportsTo = employeeModel.ReportsTo,
                JobTitle = employeeModel.JobTitle
            };

            await _context.AddAsync(employee);
            await _context.SaveChangesAsync();

            return employee.EmployeeNumber;
        }

        public async Task DeleteOneEmployeeAsync(int employeeNumber)
        {
            _context.Employees.Remove(new Employee() { EmployeeNumber = employeeNumber });
            await _context.SaveChangesAsync();
        }
    }
}
