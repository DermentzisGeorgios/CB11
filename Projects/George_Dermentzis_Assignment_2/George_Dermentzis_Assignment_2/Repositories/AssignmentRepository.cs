using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using AutoMapper;
using George_Dermentzis_Assignment_2.DAL;
using George_Dermentzis_Assignment_2.Models;

namespace George_Dermentzis_Assignment_2.Repositories
{
    public class AssignmentRepository
    {
        private readonly Assignment_2Context _context;

        public AssignmentRepository(Assignment_2Context context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Assignment>> GetAll() => await _context.Assignments.ToListAsync();

        public async Task<Assignment> GetById(int id) => await _context.Assignments.SingleOrDefaultAsync(c => c.AssignmentID == id);

        public async void CreateOrUpdate(Assignment assignment)
        {
            if (assignment.AssignmentID == 0)
                _context.Assignments.Add(assignment);
            else
            {
                var assignmentDb = await _context.Assignments.FindAsync(assignment);
                Mapper.Map(assignment, assignmentDb);
            }

            await _context.SaveChangesAsync();
        }

        public async void Delete(int id)
        {
            _context.Assignments.Remove(new Assignment(id));

            await _context.SaveChangesAsync();
        }
    }
}