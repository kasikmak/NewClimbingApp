﻿using AutoMapper;
using Azure;
using MediatR;
using NewClimbingApp.ApplicationServices.API.Domain.Models;
using NewClimbingApp.ApplicationServices.API.Domain.Requests.Ascents;
using NewClimbingApp.ApplicationServices.API.Domain.Responses.Ascents;
using NewClimbingApp.DataAccess.CQRS;
using NewClimbingApp.DataAccess.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.ApplicationServices.API.Handlers.Ascents
{
    public class GetAscentsByRatingHandler : IRequestHandler<GetAscentsByRatingRequest, GetAscentByRatingResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly ICommandExecutor commandExecutor;

        public GetAscentsByRatingHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.commandExecutor = commandExecutor;
        }
        public async Task<GetAscentByRatingResponse> Handle(GetAscentsByRatingRequest request, CancellationToken cancellationToken)
        {
            var query = new GetAscentsQuery { Rating = request.Rating };
            var ascents = await queryExecutor.Execute(query);
            return new GetAscentByRatingResponse
            {
                Data = mapper.Map<List<AscentDto>>(ascents)
            };
        }
    }
}
