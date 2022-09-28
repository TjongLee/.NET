using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnvironmentCrime.Models
{
    public interface ICrimeRepository
    {
        IQueryable<Department> Departments { get; }
        IQueryable<ErrandStatus> ErrandStatuses { get; }
        IQueryable<Employee> Employees { get; }

        //Create and Update
        public void SaveErrand(Errand errand);

        //Read
        IQueryable<Errand> Errands { get; }
        Task<Errand> GetErrandDetail(int id);

        //Delete
        public Errand DeleteErrand(int errandId);
    }
}
