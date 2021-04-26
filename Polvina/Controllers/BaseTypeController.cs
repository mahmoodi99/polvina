using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CommonBaseType.Model;

namespace CommonBaseType.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseTypeController : ControllerBase
    {

        private IBaseTypeRepository _baseTyperepository;
        public BaseTypeController(IBaseTypeRepository baseTypeRepository)
        {
            _baseTyperepository = baseTypeRepository;          
        }


        // GET: api/<BaseTypeController>
        [HttpGet (Name =" ws_loadBaseType")]
        public IEnumerable<TblCommonBaseType> ws_loadBaseType()
        {
            return _baseTyperepository.ws_loadBaseType();
        }




        // GET api/<BaseTypeController>/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> ws_loadBaseType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var baseType = await _baseTyperepository.ws_loadBaseTypeById(id);

            if (baseType == null)
            {
                return NotFound();
            }

            return Ok(baseType);
        }





        //// GET api/<BaseTypeController>/name
        //[HttpGet("{searchType}/{value}")]
        //public async Task<IActionResult> Custom_ws_loadBaseType([FromBody] SearchViewModel value)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return  BadRequest(ModelState);
        //    }

        //    return Ok();
        //}




        // GET api/<BaseTypeController>/name
        [HttpGet("Basetype/{value}")]
        public async Task<IActionResult> Custom_ws_loadBaseType(string value)
        {


            return Ok(await _baseTyperepository.ws_loadBaseTypeByTitle(value));
        }



        // POST api/<BaseTypeController>
        [HttpPost]
        public async Task<IActionResult> ws_CreateBaseType( [FromBody] TblCommonBaseType tblCommonBaseType)
        {

            var type = _baseTyperepository.ws_loadBaseTypeByTitle(tblCommonBaseType.BaseTypeTitle);
            var code = _baseTyperepository.ws_loadBaseTypeByTitle(tblCommonBaseType.BaseTypeCode);
            


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (type != null || code != null)
            {
                return BadRequest("این عنوان وجود دارد");
            }


            await _baseTyperepository.ws_CreateBaseType(tblCommonBaseType);

            return Ok(tblCommonBaseType);
        }



        //test



        // PUT api/<BaseTypeController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> ws_UpdateBaseType([FromRoute] int id, [FromBody] TblCommonBaseType tblCommonBaseType)
        {
            var title = _baseTyperepository.IsExistscode(tblCommonBaseType.BaseTypeTitle);
            var code = _baseTyperepository.IsExistscode(tblCommonBaseType.BaseTypeCode);



            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblCommonBaseType.CommonBaseTypeId)
            {
                return BadRequest();
            }
            if (title != null)
            {
                return BadRequest("این عنوان وجود دارد");
            }
            if (code != null)
            {
                return BadRequest("این کد وجود دارد");
            }


            await _baseTyperepository.ws_UpdateBaseType(tblCommonBaseType);



            return NoContent();
        }




        // DELETE api/<BaseTypeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> ws_DeleteBaseType([FromRoute] int id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var baseType = await _baseTyperepository.ws_loadBaseTypeById(id);
            if (baseType == null)
            {
                return NotFound();
            }

            if (baseType != null)
            {

            }

            await _baseTyperepository.ws_DeleteBaseType(id);

            return Ok(baseType);
        }
    }




}
