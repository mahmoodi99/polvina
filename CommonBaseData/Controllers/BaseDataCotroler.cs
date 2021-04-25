using CommonBaseData.Entity.Repository;
using CommonBaseData.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CommonBaseData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseDataController : ControllerBase
    {


        private IBaseDataRepository _baseValueRepository;
        public BaseDataController(IBaseDataRepository baseValueRepository)
        {
            _baseValueRepository = baseValueRepository;
        }




        // GET: api/<BasedataController>
        [HttpGet]
        public IEnumerable<TblCommonBaseData> ws_loadBaseValue()
        {
            return _baseValueRepository.loadBaseValue();
        }


        // GET api//BasedataController/ws_loadBaseValue /{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> ws_loadBaseValue([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var baseValue = await _baseValueRepository.ws_loadBaseValueById(id);

            if (baseValue == null)
            {
                return NotFound();
            }

            return Ok(baseValue);
        }


        // GET api/<BasedataController>/name
        [HttpGet("{name}")]
        public async Task<IActionResult> ws_loadBaseValue([FromBody] string value)
        {
            return Ok(await _baseValueRepository.ws_loadBaseValueByTitle(value));
        }


        // POST api/<BasedataController>
        [HttpPost]
        public async Task<IActionResult> ws_CreateBaseValue([FromBody] TblCommonBaseData tblCommonBaseData)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _baseValueRepository.ws_CreateBaseValue(tblCommonBaseData);

            return CreatedAtAction("GetTblCommonBaseData", new { id = tblCommonBaseData.CommonBaseTypeId }, tblCommonBaseData);
        }


        // PUT api/<BasedataController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> ws_UpdateBaseValue([FromBody] TblCommonBaseData tblCommonBaseData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _baseValueRepository.ws_UpdateBaseValue(tblCommonBaseData);

            return NoContent();
        }



        // DELETE api/<BasedataController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> ws_DeleteBaseValue([FromRoute] int id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var baseValue = await _baseValueRepository.ws_loadBaseValueById(id);
            if (baseValue == null)
            {
                return NotFound();
            }

            if (baseValue != null)
            {

            }
            //var x = _baseValueRepository.IsExistsTblsNeed(id);

            //if (x != null)
            //{
            //    return BadRequest(" این کد را به دلیل وابستگی اطلاعات نمیتوان حذف کرد");
            //}

            await _baseValueRepository.ws_DeleteBaseValue(id);

            return Ok(baseValue);
        }
    }
}
