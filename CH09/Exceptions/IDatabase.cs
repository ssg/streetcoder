using System;

namespace Exceptions;
internal interface IDatabase
{
    Order GetOrder(Guid orderId);
    void ChangeOrderStatus(Order order, OrderStatus newState);

    /// <summary>
    /// Atomic change of order status and fail if state was 
    /// changed by some other caller.
    /// </summary>
    bool TryChangeOrderStatus(Order order,
      OrderStatus from,
      OrderStatus to);
    VotingResult Upvote(Guid contentId);
    bool ProcessOrder(Order order);
    object CreateAlbum(string title);
}