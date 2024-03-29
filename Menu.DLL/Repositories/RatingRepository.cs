﻿using Menu.DLL.Data;
using Menu.DLL.Interface;
using Menu.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Menu.DLL.Repositories
{
    public class RatingRepository : IRepository<Rating>
    {
        private readonly AppDBContext _db;

        public RatingRepository(AppDBContext db)
        {
            _db = db;
        }

        public async Task<Rating> CreateAsync(Rating entity)
        {
            try
            {
                await _db.Rating.AddAsync(entity);
                await _db.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Rating> DeleteAsync(Rating entity)
        {
            try
            {
                var Rating = await _db.Rating.FindAsync(entity);
                if (Rating == null)
                    throw new Exception();

                _db.Rating.Remove(Rating);
                await _db.SaveChangesAsync();
                return Rating;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Rating> GetAsync(int id)
        {
            try
            {
                return await _db.Rating
                    .AsNoTracking()
                    .Include(x => x.Dishes)
                    .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<IEnumerable<Rating>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Rating> UpdateAsync(Rating entity)
        {
            throw new NotImplementedException();
        }
    }
}
