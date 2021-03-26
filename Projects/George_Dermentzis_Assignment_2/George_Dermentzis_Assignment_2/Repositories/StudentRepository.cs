using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using AutoMapper;
using George_Dermentzis_Assignment_2.DAL;
using George_Dermentzis_Assignment_2.Models;

namespace George_Dermentzis_Assignment_2.Repositories
{
    public class StudentRepository
    {
        private readonly Assignment_2Context _context;

        public StudentRepository(Assignment_2Context context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Student>> GetAll() => await _context.Students.ToListAsync();

        public async Task<Student> GetById(int id) => await _context.Students.SingleOrDefaultAsync(c => c.StudentID == id);

        public async void CreateOrUpdate(Student student)
        {
            if (student.StudentID == 0)
                _context.Students.Add(student);
            else
            {
                var studentDb = await _context.Students.FindAsync(student);
                Mapper.Map(student, studentDb);
            }

            await _context.SaveChangesAsync();
        }

        public async void Delete(int id)
        {
            _context.Students.Remove(new Student(id));

            await _context.SaveChangesAsync();
        }
    }
}