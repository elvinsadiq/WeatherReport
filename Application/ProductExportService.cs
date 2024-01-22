using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using OfficeOpenXml;

namespace YourProjectNamespace.Services
{
    public class ProductExportService
    {
        public async Task<byte[]> ExportProductsToExcelAsync(List<Product> products)
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Products");

                
                var headerRow = new List<string[]>
                {
                    new [] { "ID", "Title", "SubTitle", "Introduction", "SalePrice", "CostPrice", "DiscountPercent", "Sku", "IsNew", "CategoryId", "CategoryName", "Description", "CreatedAt" }
                };

                // Başlık satırını yaz
                worksheet.Cells["A1"].LoadFromArrays(headerRow);

                // Veri satırları
                var dataRows = products.Select(product => new object[]
                {
                    product.Id,
                    product.Title,
                    product.SubTitle,
                    product.Introduction,
                    product.SalePrice,
                    product.CostPrice,
                    product.DiscountPercent,
                    product.Sku,
                    product.IsNew,
                    product.CategoryId,
                    product.Category?.CategoryName,
                    product.Description?.Introduction,
                    product.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss")
                }).ToList();

                // Veri satırlarını yaz
                worksheet.Cells["A2"].LoadFromArrays(dataRows);

                // Excel dosyasını stream'e dönüştür
                var stream = new MemoryStream(package.GetAsByteArray());

                return stream.ToArray();
            }
        }
    }
}
