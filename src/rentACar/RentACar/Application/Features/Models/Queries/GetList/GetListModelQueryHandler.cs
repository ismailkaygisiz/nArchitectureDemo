﻿using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Pagination;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Models.Queries.GetList
{
    public class GetListModelQueryHandler : IRequestHandler<GetListModelQuery, GetListResponse<GetListModelListItemDto>>
    {
        private readonly IModelRepository _modelRepository;
        private readonly IMapper _mapper;

        public GetListModelQueryHandler(IModelRepository modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListModelListItemDto>> Handle(GetListModelQuery request, CancellationToken cancellationToken)
        {
            Paginate<Model> models = await _modelRepository.GetListAsync(
                include: m => m.Include(m => m.Brand).Include(m => m.Fuel).Include(m => m.Transmission),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize
            );

            GetListResponse<GetListModelListItemDto> response = _mapper.Map<GetListResponse<GetListModelListItemDto>>(models);
            return response;
        }
    }
}
