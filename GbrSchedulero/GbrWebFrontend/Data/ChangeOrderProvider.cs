using CHA.Data;
using GbrSchedulero;
using System.Linq;

public class ChangeOrderProvider : IChangeOrderUpdater
{
    private FlightScheduleDbContext context;
    public ChangeOrderProvider(FlightScheduleDbContext context)
    {
        this.context = context;
    }

    public void ApplyChangeOrderUpdate(AssignmentChangeOrder changeOrder)
    {
        if ((changeOrder.CurrentAssignment != null) || (changeOrder.PreviousAssignment != null))
            context.Add(changeOrder);
    }

    public AssignmentChangeOrder GetExistingChangeOrder(FlightCrewAssignment assignment)
    {
        IQueryable<AssignmentChangeOrder> orders = context.ChangeOrders
            .Where(c => (c.CurrentAssignment.Flight == assignment.Flight));

        return orders.Count() > 0 ? orders.FirstOrDefault() : null;
    }
}