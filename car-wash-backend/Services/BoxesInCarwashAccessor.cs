using car_wash_backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace car_wash_backend.Services;

public class BoxesInCarwashAccessor (CarWashContext db) : Controller
{
    public IQueryable<BoxesInCarwash> GetAll()
    {
        return db.BoxesInCarwashes;
    }

    public Box GetAvailableBox(Guid carwashId)
    {
        //потом использовать это:
        //return GetAll().FirstOrDefault(b => b.CarwashId == carwashId && b.Status == "available").Box;
        
        return GetAll().FirstOrDefault(b => b.CarwashId == carwashId).Box;
    }
}