namespace BusinessLib.Bl
{
    public class clsGenericRepository<T> : ICRUD<T>, ITransactionOperations<T> where T : class
    {
        private readonly AppDbContext _appDbContext;
        private readonly DbSet<T> _dbSet;

        public clsGenericRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _dbSet = _appDbContext.Set<T>(); // Generic DbSet for any entity T
        }

        public IQueryable<T> GetAll()
        {
            try
            {
                return _dbSet.AsNoTracking().AsQueryable();
            }
            catch (Exception)
            {
                return new List<T>().AsQueryable();
            }
        }

        public T GetById(int elementId)
        {
            try
            {
                return _dbSet.Find(elementId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int? Save(T element)
        {
            try
            {
                // Assuming every entity has an 'Id' property
                var id = (int)typeof(T).GetProperty("Id").GetValue(element);

                if (id == 0)
                {
                    _dbSet.Add(element);
                }
                else
                {
                    _appDbContext.Entry(element).State = EntityState.Modified;
                }

                _appDbContext.SaveChanges();
                return id;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Delete(int elementId)
        {
            try
            {
                var entity = GetById(elementId);
                if (entity != null)
                {
                    _dbSet.Remove(entity);
                    return _appDbContext.SaveChanges() > 0;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int? SaveTransaction(T element, DbContext dbContext)
        {
            try
            {
                // Ensure the element has an Id property
                var idProperty = typeof(T).GetProperty("Id");
                if (idProperty == null)
                {
                    throw new InvalidOperationException("The entity does not have an 'Id' property.");
                }

                // Get the current Id value
                var idValue = idProperty.GetValue(element);
                var id = idValue != null ? (int?)idValue : null;

                if (id == null || id == 0)
                {
                    // Add new entity
                    dbContext.Set<T>().Add(element);
                }
                else
                {
                    // Update existing entity
                    dbContext.Entry(element).State = EntityState.Modified;
                }

                // Save changes and return the ID
                dbContext.SaveChanges();

                // Return the ID if auto-generated
                return (int)idProperty.GetValue(element);
            }
            catch (Exception ex)
            {
                // Log exception if needed
                Console.WriteLine(ex.Message);
                return null;
            }
        }

    }
}
