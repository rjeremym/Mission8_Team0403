using Microsoft.EntityFrameworkCore;

namespace Mission8_Assignment.Models
{
    public class EFQuadrantRepository : IQuadrantRepository
    {
        private QuadrantContext _context;

        public EFQuadrantRepository(QuadrantContext temp)
        {
            _context = temp;
        }

        // We use .Include() so the Category Name comes along with the CategoryId
        public IQueryable<Quadrant> Quadrants => _context.Quadrants.Include(x => x.Category);
        public IQueryable<Category> Categories => _context.Categories;

        public void AddTask(Quadrant task)
        {
            _context.Quadrants.Add(task);
            _context.SaveChanges();
        }

        public void UpdateTask(Quadrant task)
        {
            _context.Quadrants.Update(task);
            _context.SaveChanges();
        }

        public void DeleteTask(Quadrant task)
        {
            _context.Quadrants.Remove(task);
            _context.SaveChanges();
        }
    }
}