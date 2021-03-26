using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using AutoMapper;
using George_Dermentzis_Assignment_2.DAL;
using George_Dermentzis_Assignment_2.Models;

namespace George_Dermentzis_Assignment_2.Repositories
{
    public class TrainerRepository
    {
        private readonly Assignment_2Context _context;

        public TrainerRepository(Assignment_2Context context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Trainer>> GetAll() => await _context.Trainers.ToListAsync();

        public async Task<Trainer> GetById(int id) => await _context.Trainers.SingleOrDefaultAsync(c => c.TrainerID == id);

        public async void CreateOrUpdate(Trainer trainer)
        {
            if (trainer.TrainerID == 0)
                _context.Trainers.Add(trainer);
            else
            {
                var trainerDb = await _context.Trainers.FindAsync(trainer);
                Mapper.Map(trainer, trainerDb);
            }

            await _context.SaveChangesAsync();
        }

        public async void Delete(int id)
        {
            _context.Trainers.Remove(new Trainer(id));

            await _context.SaveChangesAsync();
        }
    }
}