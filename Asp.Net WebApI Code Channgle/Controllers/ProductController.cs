using Asp.Net_WebApI_Code_Channgle.DTO;
using Asp.Net_WebApI_Code_Channgle.Entitys;
using Asp.Net_WebApI_Code_Channgle.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asp.Net_WebApI_Code_Channgle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IMapper _mapper;
        private readonly IConfiguration configuration;

        public ProductController(IProductService userService, IMapper mapper, IConfiguration configuration)
        {
            this.productService = productService;
            _mapper = mapper;
            this.configuration = configuration;

        }

        [HttpGet, Route("GetAllProducts")]
        [Authorize(Roles ="Admin")]
        public IActionResult GetAll()
        {
            try
            {
                List<Product> products = productService.GetAllProducts(); 
                List<ProductDTO> productDTO = _mapper.Map<List<ProductDTO>>(products);
                return StatusCode(200, productDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost, Route("AddProduct")]
        [Authorize(Roles ="Suppiler")]
        public IActionResult AddProduct([FromBody] ProductDTO productDTO)
        {
            try
            {

                Product product = _mapper.Map<Product>(productDTO);
                productService.AddProduct(product);

                return StatusCode(200, product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet, Route("GetProductById/{productId}")]
        [Authorize]
        public IActionResult GetProductById(int productId)
        {
            try
            {
                Product product = productService.GetProductById(productId);

                ProductDTO productDTO = _mapper.Map<ProductDTO>(product);
                return StatusCode(200, productDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut, Route("EditProduct")]
        [Authorize(Roles ="Supplier")]
       
        public IActionResult Edit(ProductDTO productDTO)
        {
            try
            {
                Product product = _mapper.Map<Product>(productDTO); 
                productService.UpdateProduct(product);
                return StatusCode(200, product);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        
        [HttpDelete, Route("DeleteProduct/{productId}")]
        [Authorize(Roles ="Admin")]
        public IActionResult Delete(int productId)
        {
            try
            {
                productService.DeleteProduct(productId);
                return StatusCode(200, new JsonResult($"Product with Id {productId} is Deleted"));
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
