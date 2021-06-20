using Microsoft.AspNetCore.Mvc;
using System;

namespace Exceptions {
  public enum OrderStatus {
    New,
    Processing,
    Complete,
    Failed,
  }

  public class Order {
    public Guid Id { get; set; }
    public OrderStatus Status { get; set; }
    public DateTimeOffset LastUpdate { get; set; }
  }

  class OrderController : Controller {
    private readonly IDatabase db;

    private static readonly TimeSpan orderTimeout = TimeSpan.FromSeconds(30);

    [HttpPost]
    public IActionResult Submit(Guid orderId) {
      Order order = db.GetOrder(orderId);

      if (!db.TryChangeOrderStatus(order, from: OrderStatus.New,
        to: OrderStatus.Processing)) {
        if (order.Status != OrderStatus.Processing) {
          return resultPage(order);
        }

        if (DateTimeOffset.Now - order.LastUpdate > orderTimeout) {
          db.ChangeOrderStatus(order, OrderStatus.Failed);
          return resultPage(order);
        }

        return orderStatusView(order);
      }

      if (!processOrder(order)) {
        db.ChangeOrderStatus(order, OrderStatus.Failed);
      }
      else {
        db.TryChangeOrderStatus(order, from: OrderStatus.Processing, 
          to: OrderStatus.Complete);
      }

      return resultPage(order);
    }

    private bool processOrder(Order order) {
      if (!db.ProcessOrder(order)) {
        return false;
      }
      order.Status = OrderStatus.Complete;
      return true;
    }

    private IActionResult orderStatusView(Order order) {
      return View("OrderStatus", order);
    }

    private IActionResult resultPage(Order order) {
      return RedirectToAction("Result", new { orderId = order.Id });
    }
  }
}
