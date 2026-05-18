using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Linq_Employee_list
{
    internal class Program
    {
        record Employee(string Name, string Department, decimal Salary);

        private static readonly List<Employee> Employees = 
        [
            new Employee(Name:"Alice",Department:"Marketing", Salary:72000),
            new Employee(Name:"Bob",Department:"Engineering", Salary:95000),
            new Employee(Name:"Charlie",Department:"Engineering", Salary:11000),
            new Employee(Name:"Karen",Department:"HR", Salary:68000),
            new Employee(Name:"Eve",Department:"Engineering", Salary:88000),
            new Employee(Name:"Frank",Department:"Marketing", Salary:79000),
        ];
        
        // 1. Get all Engineering employees, ordered by salary descending
        // 2. Get the average salary across all employees
        // 3. Get the highest paid employee in each department
        // 4. Get names of employees earning above 80k, uppercase
        
        static void Main(string[] args)
        {
            var salary = Employees.Where(e => e.Department == "Engineering").OrderByDescending(e => e.Salary).ToList();
            
            foreach (var employee in salary)
                Console.WriteLine($"{employee.Name} {employee.Department}: €{employee.Salary}");
            
            var averageSalary = Employees.Average(e => e.Salary);
            
            Console.WriteLine($"Average salary: {averageSalary:N2}");

            var highestSalary = Employees.GroupBy(e => e.Department)
                .Select(g => g.OrderByDescending(e => e.Salary).First());
            
            foreach (var highest in highestSalary)
                Console.WriteLine($"{highest.Department}: Highest Salary - €{highest.Salary}");
            
            var highRoller = Employees.Where(e => e.Salary > 80000).Select(e => e.Name.ToUpper());
            
            foreach (var name in highRoller)
                Console.WriteLine($"Highest paid Employees: {name}");
        }
    }
}