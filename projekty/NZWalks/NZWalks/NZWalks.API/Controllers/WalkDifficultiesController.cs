using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalkDifficultiesController : Controller
    {
        private readonly IWalkDifficultyRepository walkDifficultyRepository;
        private readonly IMapper mapper;

        public WalkDifficultiesController(IWalkDifficultyRepository walkDifficultyRepository, IMapper mapper)
        {
            this.walkDifficultyRepository = walkDifficultyRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetAllWalksDifficultiesAsync()
        {
            var walksDifficultyDomain = await walkDifficultyRepository.GetAllAsync();

            var walksDifficultyDTO = mapper.Map<List<Models.DTO.WalkDifficulty>>(walksDifficultyDomain);
            return Ok(walksDifficultyDTO);

        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetWalkDifficultyById")]
        [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetWalkDifficultyById(Guid id)
        {
            var walkDifficulty = await walkDifficultyRepository.GetAsync(id);

            if (walkDifficulty == null)
            {
                return NotFound();
            }

            var walkDifficultyDTO = mapper.Map<Models.DTO.WalkDifficulty>(walkDifficulty);
            return Ok(walkDifficultyDTO);
        }

        [HttpPost]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> AddWalkDifficultyAsync([FromBody] Models.DTO.AddWalkDifficultyRequest addWalkDifficultyRequest)
        {

            //if (!(ValidateAddWalkDifficultyAsync(addWalkDifficultyRequest)))
            //{
            //    return BadRequest(ModelState);
            //}


            var walkDifficultyDomain = new Models.Domain.WalkDifficulty()
            {
                Code = addWalkDifficultyRequest.Code,
            };

            walkDifficultyDomain = await walkDifficultyRepository.AddAsync(walkDifficultyDomain);

            var walkDifficultyDTO = new Models.DTO.WalkDifficulty()
            {
                Code = walkDifficultyDomain.Code
            };

            return CreatedAtAction(nameof(GetWalkDifficultyById), new { id = walkDifficultyDTO.Id }, walkDifficultyDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> UpdateWalkDifficultyAsync([FromRoute] Guid id, [FromBody] Models.DTO.UpdateWalkDifficultyRequest updateWalkDifficultyRequest)
        {
            //if (!(ValidateUpdateWalkDifficultyAsync(updateWalkDifficultyRequest)))
            //{
            //    return BadRequest(ModelState);
            //}

            var walkDifficultyDomain = new Models.Domain.WalkDifficulty
            {
                Code = updateWalkDifficultyRequest.Code,
            };

            walkDifficultyDomain = await walkDifficultyRepository.UpdateAsync(id, walkDifficultyDomain);

            if (walkDifficultyDomain == null)
            {
                return NotFound();
            }

            var walkDifficultyDTO = new Models.DTO.WalkDifficulty
            {
                Code = walkDifficultyDomain.Code,
            };

            return Ok(walkDifficultyDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> DeleteWalkDifficultyById(Guid id)
        {
            var walkDifficultyDomain = await walkDifficultyRepository.DeleteAsync(id);

            if (walkDifficultyDomain == null)
            {
                return NotFound();
            }

            return Ok();
        }

        #region Private methods
        private bool ValidateAddWalkDifficultyAsync(Models.DTO.AddWalkDifficultyRequest addWalkDifficultyRequest)
        {
            if (string.IsNullOrWhiteSpace(addWalkDifficultyRequest.Code))
            {
                ModelState.AddModelError(nameof(addWalkDifficultyRequest.Code), $"{nameof(addWalkDifficultyRequest.Code)} is required.");
                return false;
            }

            return true;
        }

        private bool ValidateUpdateWalkDifficultyAsync(Models.DTO.UpdateWalkDifficultyRequest updateWalkDifficultyRequest)
        {
            if (string.IsNullOrWhiteSpace(updateWalkDifficultyRequest.Code))
            {
                ModelState.AddModelError(nameof(updateWalkDifficultyRequest.Code), $"{nameof(updateWalkDifficultyRequest.Code)} is required.");
                return false;
            }

            return true;
        }


        #endregion
    }
}
