using _27_FrontToBackSqlConnection.Areas.AdminPanel.View_Models.Product;
using _27_FrontToBackSqlConnection.Areas.AdminPanel.Views.Product;
using _27_FrontToBackSqlConnection.Data;
using _27_FrontToBackSqlConnection.Models;
using _27_FrontToBackSqlConnection.Utilities.Enums;
using _27_FrontToBackSqlConnection.Utilities.Extension;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace _27_FrontToBackSqlConnection.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;



        public ProductController(AppDbContext context, IWebHostEnvironment? env)
        {
            _context = context;
            _env = env;
        }


        [Authorize(Roles = "Admin, Moderator, Member")]
        public async Task<IActionResult> Index()
        {
            List<ProductGetVM> products = await _context.Products
                .Where(p => !p.IsDeleted)
                .Include(p => p.ProductImages)
                .Include(p => p.Category)
                .Select(product => new ProductGetVM
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    CategoryName = product.Category.Name,
                    SKU = product.SKU,
                    Image = product.ProductImages.FirstOrDefault().Image
                })
                .ToListAsync();
            return View(products);
        }


        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IActionResult> Create()
        {
            ProductCreateVM productCreateVM = new()
            {
                Categories = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync()
,                Tags = await _context.Tags.Where(t => !t.IsDeleted).ToListAsync()
            };
            return View(productCreateVM);
        }



        [HttpPost]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IActionResult> Create(ProductCreateVM productCreateVM)
        {
            productCreateVM.Categories = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync();
            productCreateVM.Tags = await _context.Tags.Where(t => !t.IsDeleted).ToListAsync();
            if (!ModelState.IsValid) return View(productCreateVM);
            Product newProduct = new()
            {
                Name = productCreateVM.Name,
                Description = productCreateVM.Description ?? string.Empty,
                Price = productCreateVM.Price,
                SKU = productCreateVM.SKU,
                CategoryId = productCreateVM.CategoryId.Value,
                ProductImages = new List<ProductImage>()
            };
            if (productCreateVM.MainPhoto is not null)
            {
                string mainFileName = await productCreateVM.MainPhoto.CreateFile(_env.WebRootPath, "assets", "images", "website-images");
                newProduct.ProductImages.Add(new ProductImage { Image = mainFileName, IsPrimary = true });
            }
            if (productCreateVM.HoverPhoto != null)
            {
                string hoverFileName = await productCreateVM.HoverPhoto.CreateFile(_env.WebRootPath, "assets", "images", "website-images");
                newProduct.ProductImages.Add(new ProductImage { Image = hoverFileName, IsPrimary = false });
            }
            if (productCreateVM.AdditionalPhoto != null && productCreateVM.AdditionalPhoto.Any())
            {
                foreach (var file in productCreateVM.AdditionalPhoto)
                {
                    string additionalFileName = await file.CreateFile(_env.WebRootPath, "assets", "images", "website-images");
                    newProduct.ProductImages.Add(new ProductImage { Image = additionalFileName, IsPrimary = null });
                }
            }
            if (productCreateVM.TagIds != null)
            {
                newProduct.ProductTags = new List<ProductTag>();
                foreach (var tagId in productCreateVM.TagIds)
                {
                    newProduct.ProductTags.Add(new ProductTag { TagId = tagId });
                }
            }
            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null || id < 1) return BadRequest();
            Product? product = await _context.Products
                .Include(p => p.ProductTags)
                .Include(p => p.ProductImages)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) return NotFound();
            if (product.ProductImages is not null && product.ProductImages.Count > 0)
            {
                foreach (var productImage in product.ProductImages)
                {
                    if (!string.IsNullOrEmpty(productImage.Image))
                    {
                        productImage.Image.DeleteFile(_env.WebRootPath, "assets", "images", "website-images");
                    }
                }
                _context.ProductImages.RemoveRange(product.ProductImages);
            }
            if (product.ProductTags is not null && product.ProductTags.Count > 0) _context.ProductTags.RemoveRange(product.ProductTags);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null || id < 1) return BadRequest();
            Product? product = await _context.Products
                .Include(p => p.ProductImages)
                .Include(p => p.ProductTags)
                .ThenInclude(pt => pt.Tag)
                .FirstOrDefaultAsync(p => p.Id == id);
            return View(product);
        }

        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id < 1) return BadRequest();
            Product? existProduct = await _context.Products
                .Include(p => p.ProductImages)
                .Include(p => p.ProductTags)
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
            if (existProduct == null) return NotFound();
            ProductUpdateVM productUpdateVM = new()
            {
                Name = existProduct.Name,
                Price = existProduct.Price,
                Description = existProduct.Description,
                SKU = existProduct.SKU,
                CategoryId = existProduct.CategoryId,
                TagIds = existProduct.ProductTags.Select(pt => pt.TagId).ToList(),
                Categories = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync(),
                Tags = await _context.Tags.Where(t => !t.IsDeleted).ToListAsync(),
                ProductImages = existProduct.ProductImages
            };
            return View(productUpdateVM);
        }



        [HttpPost]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IActionResult> Update(int? id, ProductUpdateVM productUpdateVM)
        {
            productUpdateVM.Categories=await _context.Categories.Where(c=>!c.IsDeleted).ToListAsync();
            productUpdateVM.Tags=await _context.Tags.Where(t =>!t.IsDeleted).ToListAsync();
            if (id == null || id < 1) return BadRequest();
            Product? existProduct = await _context.Products
                .Include(p => p.ProductImages)
                .Include(p => p.ProductTags)
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
            if (existProduct == null) return NotFound();
            productUpdateVM.ProductImages = existProduct.ProductImages;
            if (!ModelState.IsValid) return View(productUpdateVM);
            var deleteImages = existProduct.ProductImages
                .Where(pi => (productUpdateVM.ImageIds == null || !productUpdateVM.ImageIds
                .Exists(imgId => imgId == pi.Id))&& pi.IsPrimary == null)
                .ToList();
            deleteImages.ForEach(di => di.Image.DeleteFile(_env.WebRootPath, "assets", "images", "website-images"));
            _context.ProductImages.RemoveRange(deleteImages);
            if (productUpdateVM.ImageIds == null)
            {
                productUpdateVM.ImageIds = new List<int>();
            }
            if (productUpdateVM.MainPhoto != null)
            {
                string fileName = await productUpdateVM.MainPhoto.CreateFile(_env.WebRootPath, "assets", "images", "website-images");
                ProductImage mainImage = existProduct.ProductImages.FirstOrDefault(p => p.IsPrimary == true);
                if (mainImage != null)
                {
                    mainImage.Image.DeleteFile(_env.WebRootPath, "assets", "images", "website-images");
                    existProduct.ProductImages.Remove(mainImage);
                }
                existProduct.ProductImages.Add(new ProductImage { Image = fileName, IsPrimary = true });
            }
            if (productUpdateVM.HoverPhoto != null)
            {
                string hoverFileName = await productUpdateVM.HoverPhoto.CreateFile(_env.WebRootPath, "assets", "images", "website-images");
                ProductImage hoverImage = existProduct.ProductImages.FirstOrDefault(p => p.IsPrimary == false);
                if (hoverImage != null)
                {
                    hoverImage.Image.DeleteFile(_env.WebRootPath, "assets", "images", "website-images");
                    existProduct.ProductImages.Remove(hoverImage);
                }
                existProduct.ProductImages.Add(new ProductImage { Image = hoverFileName, IsPrimary = false });
            }
            if (productUpdateVM.AdditionalPhoto != null && productUpdateVM.AdditionalPhoto.Any())
            {
                foreach (var file in productUpdateVM.AdditionalPhoto)
                {
                    string additionalFileName = await file.CreateFile(_env.WebRootPath, "assets", "images", "website-images");
                    existProduct.ProductImages.Add(new ProductImage { Image = additionalFileName, IsPrimary = null });
                }
            }
            existProduct.ProductTags.Clear();
            if (productUpdateVM.TagIds != null)
            {
                foreach (var tagId in productUpdateVM.TagIds)
                {
                    existProduct.ProductTags.Add(new ProductTag { TagId = tagId });
                }
            }
            existProduct.Name = productUpdateVM.Name;
            existProduct.Price = productUpdateVM.Price;
            existProduct.Description = productUpdateVM.Description ?? string.Empty;
            existProduct.SKU = productUpdateVM.SKU;
            existProduct.CategoryId = productUpdateVM.CategoryId.Value;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}