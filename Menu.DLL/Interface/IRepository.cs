namespace Menu.DLL.Interface
{
    public interface IRepository<Entity> where Entity : class
    {
        public Task<Entity> CreateAsync (Entity entity);
        public Task<Entity> UpdateAsync (Entity entity);
        public Task<Entity> DeleteAsync (Entity entity);
        public Task<Entity> GetAsync(int Id);
        public Task<IEnumerable<Entity>> GetAsync();
    }
}
