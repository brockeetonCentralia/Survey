using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOS.Class;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ClassRepository : IClassRepository
    {
        private readonly ApplicationDBContext _context;
        public ClassRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Classes> CreateAsync(Classes classModel)
        {
            await _context.classes.AddAsync(classModel);
            await _context.SaveChangesAsync();
            return classModel;
        }

        public async Task<Classes?> DeleteAsync(int id)
        {
            var classModel = await _context.classes.FirstOrDefaultAsync(x => x.ClassID == id);

            if(classModel == null)
            {
                return null;
            }

            _context.classes.Remove(classModel);
            await _context.SaveChangesAsync();
            return classModel;
        }

        public async Task<List<Classes>> GetAllAsync()
        {
            return await _context.classes.ToListAsync();
        }

        public async Task<Classes?> GetByIdAsync(int id)
        {
            return await _context.classes.FindAsync(id);
        }

        public async Task<Classes?> UpdateAsync(int id, UpdateClassRequestDTO classRequestDTO)
        {
            var existingClass = await _context.classes.FirstOrDefaultAsync(x => x.ClassID == id);

            if(existingClass == null)
            {
                return null;
            }

            existingClass.ClassCode = classRequestDTO.ClassCode;
            existingClass.ClassName = classRequestDTO.ClassName;
            existingClass.InstructorName = classRequestDTO.InstructorName;

            await _context.SaveChangesAsync();
            return existingClass;
        }
    }
}