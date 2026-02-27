namespace Mission8_Assignment.Models
{
    public interface IQuadrantRepository
    {
        IQueryable<Quadrant> Quadrants { get; }
        IQueryable<Category> Categories { get; }
        
        void AddTask(Quadrant task);
        void UpdateTask(Quadrant task);
        void DeleteTask(Quadrant task);
    }
}