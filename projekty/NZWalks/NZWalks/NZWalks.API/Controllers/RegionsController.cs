using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("Regions")]
    public class RegionsController : Controller
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        public IMapper Mapper { get; }

        [HttpGet]
        public async Task<IActionResult> GetAllRegionsAsync()
        {
            var regions = await regionRepository.GetAllAsync();

            ////return DTO regions
            //var regionsDTO = new List<Models.DTO.Region>();
            //regions.ToList().ForEach(region =>
            //{
            //    var regionDto = new Models.DTO.Region()
            //    {
            //        Id = region.Id,
            //        Code = region.Code,
            //        Name = region.Name,
            //        Area = region.Area,
            //        Lat = region.Lat,
            //        Long = region.Long,
            //        Population = region.Population,
            //    };
            //    regionsDTO.Add(regionDto);
            //});

            var regionsDTO = mapper.Map<List<Models.DTO.Region>>(regions);

            return Ok(regionsDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetRegionAsync")]
        public async Task<IActionResult> GetRegionAsync(Guid id)
        {
            var region = await regionRepository.GetAsync(id);

            if (region == null)
            {
                return NotFound();
            }

            var regionDTO = mapper.Map<Models.DTO.Region>(region);
            return Ok(regionDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddRegionAsync(Models.DTO.AddRegionRequest addRegionRequest)
        {
            // Request(DTO) to Domain model
            var region = new Models.Domain.Region()
            {
                Area = addRegionRequest.Area,
                Code = addRegionRequest.Code,
                Lat = addRegionRequest.Lat,
                Population = addRegionRequest.Population,
                Long = addRegionRequest.Long,
                Name = addRegionRequest.Name
            };

            // Pass details to repository
            region = await regionRepository.AddAsync(region);

            // Convert back to DTO
            var regionDTO = new Models.DTO.Region()
            {
                Id = region.Id,
                Area = region.Area,
                Code = region.Code,
                Lat = region.Lat,
                Population = region.Population,
                Long = region.Long,
                Name = region.Name
            };

            return CreatedAtAction(nameof(GetRegionAsync), new { id = regionDTO.Id }, regionDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegionAsync(Guid id)
        {
            // Get region from database
            var region = await regionRepository.DeleteAsync(id);

            // If null NotFound
            if (region == null)
            {
                return NotFound();
            }

            // Convert response back to DTO
            var regionDTO = new Models.DTO.Region()
            {
                Id = region.Id,
                Area = region.Area,
                Code = region.Code,
                Lat = region.Lat,
                Population = region.Population,
                Long = region.Long,
                Name = region.Name
            };

            // return Ok response
            return Ok(regionDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateRegionAsync([FromRoute] Guid id, [FromBody] Models.DTO.UpdateRegionRequest updateRegionRequest)
        {
            // Convert DTO to Domain model
            var region = new Models.Domain.Region()
            {
                Area = updateRegionRequest.Area,
                Code = updateRegionRequest.Code,
                Lat = updateRegionRequest.Lat,
                Population = updateRegionRequest.Population,
                Long = updateRegionRequest.Long,
                Name = updateRegionRequest.Name
            };

            // Update Region using repository
            region = await regionRepository.UpdateAsync(id, region);

            // If null then NotFound
            if (region == null)
            {
                return NotFound();
            }

            // Convert Domain back to DTO
            var regionDTO = new Models.DTO.Region()
            {
                Area = region.Area,
                Code = region.Code,
                Lat = region.Lat,
                Population = region.Population,
                Long = region.Long,
                Name = region.Name
            };

            // Return Ok response
            return Ok(regionDTO);
        }
    }
}
