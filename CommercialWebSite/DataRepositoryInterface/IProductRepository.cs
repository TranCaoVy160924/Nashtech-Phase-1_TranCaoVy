﻿using ShareModelsDTO.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepositoryInterface
{
    public interface IProductRepository
    {
        Task<List<ProductModel>> GetAllProductAsync();

        Task<List<ProductModel>> GetProductByCategoryAsync(int categoryId);

        Task<ProductModel> GetProductByIdAsync(int id);
    }
}
