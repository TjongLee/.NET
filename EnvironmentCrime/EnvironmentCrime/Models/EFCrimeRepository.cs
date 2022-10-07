using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnvironmentCrime.Models
{
    public class EFCrimeRepository : ICrimeRepository
    {
        private ApplicationDbContext context;

        public EFCrimeRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Errand> Errands => context.errands; // get -||-
        public IQueryable<Department> Departments => context.departments;
        public IQueryable<ErrandStatus> ErrandStatuses => context.errandStatuses;
        public IQueryable<Employee> Employees => context.employees;
        public IQueryable<Sequence> Sequences => context.sequences;

        public Task<Errand> GetErrandDetail(int id)
        {
            return Task.Run(() =>
            {
                var ErrandDetail = Errands.Where(ed => ed.ErrandId == id).First();
                return ErrandDetail;
            });
        }

        //Create and Update
        public void SaveErrand(Errand errand)
        {
            if(errand.ErrandId == 0) // this means its a new errand
            {
                Sequence seq = context.sequences.FirstOrDefault();
                errand.RefNumber = "2022-45-" + seq.CurrentValue.ToString(); // sets reference number using the sequence
                errand.StatusId = "S_A"; // hardcoded status
                context.errands.Add(errand); 
                seq.CurrentValue += 1; // incraments the sequence
            }
            else // if it already exists
            {
                Errand dbEntry = context.errands.FirstOrDefault(s => s.ErrandId == errand.ErrandId); // get the errand with the wanted id
                if(dbEntry != null) //if the id given was valid
                {
                    dbEntry.StatusId = errand.StatusId; // update the status 
                    dbEntry.EmployeeId = errand.EmployeeId; // designate the employee
                }
            }
            context.SaveChanges(); // saves the changes that has been tracked so far
        }

        //Delete
        public Errand DeleteErrand(int id)
        {
            Errand dbEntry = context.errands.FirstOrDefault(s => s.ErrandId == id); // get the errand with the wanted id
            if(dbEntry != null) // if its valid
            {
                context.errands.Remove(dbEntry); 
                context.SaveChanges();
            }
            return dbEntry; // retunrs the removed entry incase you want to display it or use it
        }

    }
}
