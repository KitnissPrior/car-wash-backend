using System.Net;
using System.Web.Http;
using car_wash_backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace car_wash_backend.Services;

public class ServicesInOrderAccessor (CarWashContext db) : Controller
{
    public IQueryable<ServicesInOrder> GetAll()
    {
        return db.ServicesInOrders;
    }
    
    public ServicesInOrder? GetById(Guid id)
    {
        var service = GetAll().FirstOrDefault( s => s.ServiceId == id);
        return service;
    }
    
    public void Create(Guid serviceId, Guid orderId)
    {
        var serviceInOrderId = Guid.NewGuid();
        var serviceInOrder = new ServicesInOrder()
        {
            ServicesInOrderId = serviceInOrderId,
            ServiceId = serviceId,
            OrderId = orderId,
        };
        db.ServicesInOrders.Add(serviceInOrder);

        db.SaveChanges();
    }

    public void Delete(Guid id)
    {
        var serviceInOrder = ValidateServiceChange(id);
        db.ServicesInOrders.Remove(serviceInOrder);
        db.SaveChanges();
    }

    public ServicesInOrder ValidateServiceChange(Guid? id)
    {
        var serviceInOrder = db.ServicesInOrders.FirstOrDefault(s => s.ServiceId == id);
        if (serviceInOrder == null)
            throw new HttpResponseException(
                new HttpResponseMessage(HttpStatusCode.NotFound)
                    { Content = new StringContent("Услуга не найдена") });
        return serviceInOrder;
    }
}