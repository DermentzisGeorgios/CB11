using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using AutoMapper;
using George_Dermentzis_Assignment_2.DAL;
using George_Dermentzis_Assignment_2.Models;

namespace George_Dermentzis_Assignment_2.Repositories
{
    public class CourseRepository
    {
        private readonly Assignment_2Context _context;

        public CourseRepository(Assignment_2Context context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Course>> GetAll() => await _context.Courses.ToListAsync();

        public async Task<Course> GetById(int id) => await _context.Courses.SingleOrDefaultAsync(c => c.CourseID == id);

        public async void CreateOrUpdate(Course course)
        {
            if (course.CourseID == 0)
                _context.Courses.Add(course);
            else
            {
                var courseDb = await _context.Courses.FindAsync(course);
                Mapper.Map(course, courseDb);
            }

            await _context.SaveChangesAsync();
        }

        public async void Delete(int id)
        {
            _context.Courses.Remove(new Course(id));

            await _context.SaveChangesAsync();
        }
    }
}