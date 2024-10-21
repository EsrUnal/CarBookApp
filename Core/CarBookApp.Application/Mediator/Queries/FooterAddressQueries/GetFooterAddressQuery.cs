﻿using CarBookApp.Application.Mediator.Results.FooterAddressResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApp.Application.Mediator.Queries.FooterAddressQueries
{
    public class GetFooterAddressQuery: IRequest<List<GetFooterAddressQueryResult>>
    {        
    }
}
