using BugApplication.Data;
using BugApplication.Models;


namespace BugApplication.Services
{
    public class BugService
    {
        private readonly AppDbContext _db;

        public BugService(AppDbContext db)
        {
            _db = db;
        }

        public List<Bug> ObtenerTodos() => _db.Bugs.ToList();

        public void Crear(Bug nuevoBug)
        {
            nuevoBug.FechaRegistro = DateTime.Now;
            _db.Bugs.Add(nuevoBug);
            _db.SaveChanges();
        }

        public bool Eliminar(int id)
        {
            var bug = _db.Bugs.Find(id);
            if (bug != null)
            {
                _db.Bugs.Remove(bug);
                _db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}