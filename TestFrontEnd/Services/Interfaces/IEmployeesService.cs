using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestFrontEnd.Models;

namespace TestFrontEnd.Services
{
    public interface IEmployeesService
    {
        Task<List<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetOneEmployeeAsync(int employeeNumber);
        Task UpdateOneEmployeeAsync(Employee employeeModel);
        Task PatchOneEmployeeAsync(JsonPatchDocument employeeModel, int employeeNumber);
        Task<int> PostOneEmployeeAsync(Employee employeeModel);
        Task DeleteOneEmployeeAsync(int employeeNumber);
    }
}