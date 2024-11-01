using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApp.Application.Mediator.Commands.CarPricingCommands
{
    public class RemoveCarPricingCommand:IRequest
    {
        public RemoveCarPricingCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
