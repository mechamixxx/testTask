
using drivee_test;
using System.Security.Cryptography.X509Certificates;

class Program 
{
   static void Main(string[] args)
    {
        //Добавляем заказы
        List<Order> orders = new List<Order>
        {
            new Order(new Location(0, 0),new Location(100, 100), 50),
            new Order(new Location(25, 25),new Location(75,75), 70 ),
            new Order(new Location(80, 80),new Location(10, 10), 60),
            new Order(new Location(10, 100), new Location(20,110), 140)
        };
        //Добавляем курьеров
        List<Courier> couriers = new List<Courier>
        {
            new Courier(new Location(50, 50)),
            new Courier(new Location(0, 0))
        };

        DeliveryService deliveryService = new DeliveryService(orders, couriers);
        deliveryService.SortOrders();
    }
}
