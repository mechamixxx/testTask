using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace drivee_test
{
    public class DeliveryService
    {
        public List<Order> orders;
        public List<Courier> couriers;
        public DeliveryService(List<Order> orders, List<Courier> couriers)
        {
            this.orders = orders;
            this.couriers = couriers;
        }

        public void SortOrders()
        {
            //История заказов
            
            while (orders.Count > 0)
            {
                Dictionary<int, Order> assignedOrders = new Dictionary<int, Order>();
                for (int i = 0; i < couriers.Count; i++)
                {
                    double maxEffective = 0;
                    Order closestOrder = new Order(new Location(0, 0), new Location(0, 0), 0);
                    foreach (var order in orders)
                    {
                        double distance = Math.Sqrt(Math.Pow(couriers[i].Location.X - order.From.X, 2) + Math.Pow(couriers[i].Location.Y - order.From.Y, 2));
                        double effective = order.Price / (distance + Math.Sqrt(Math.Pow(order.To.X - order.From.X, 2) + Math.Pow(order.To.Y - order.From.Y, 2)));
                        if ((effective > maxEffective) && (couriers[i].Order != true))
                        {
                            maxEffective = effective;
                            closestOrder = order;
                        }
                    }
                    if (!assignedOrders.ContainsValue(closestOrder))
                    {
                        orders.Remove(closestOrder);
                        couriers[i].Order = true;
                        couriers[i].Location.X = closestOrder.To.X;
                        couriers[i].Location.Y = closestOrder.To.Y;
                        assignedOrders.Add(i, closestOrder);
                    }
                        
                }

                foreach (var kvp in assignedOrders)
                {
                    Console.WriteLine("Курьер: " + kvp.Key);
                    Order order = kvp.Value;
                    Console.WriteLine("Назначен заказ: от (" + order.From.X + ", " + order.From.Y + ") до (" + order.To.X + ", " + order.To.Y + ")");
                }
                for (int i = 0; i < couriers.Count; i++) 
                {
                    couriers[i].Order = false;
                }
            }

            

        }
    }
}