﻿using Application.ProductDetails.Commands.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProductDetails.Commands.Request
{
    public class CreateProductColorImageRequest : IRequest<CreateProductCommandResponse>
    {
        public int ColorId { get; set; }
        public List<IFormFile> ImageFiles { get; set; }

    }
}