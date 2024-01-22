﻿using Application.CheckoutDetails.ProvinceDetails.Commands.Response;
using MediatR;

namespace Application.CheckoutDetails.ProvinceDetails.Commands.Request
{
    public class CreateProvinceCommandRequest : IRequest<CreateProvinceCommandResponse>
    {
        public int CountryId { get; set; }
        public string ProvinceName { get; set; }
    }
}