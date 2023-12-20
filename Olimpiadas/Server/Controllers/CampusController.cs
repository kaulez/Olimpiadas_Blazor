using Logic_Layer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Olimpiadas.Shared;
using Olimpiadas.Shared.ViewModels;

namespace Olimpiadas.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CampusController : ControllerBase
    {
        public readonly ICampusLogic _campusLogic;
        public CampusController(ICampusLogic campusLogic) {
            _campusLogic = campusLogic;
        }
        [HttpGet]
        public async Task<List<CampusViewModel>> Get()
        {
            return await _campusLogic.GetAllCampuses();   
        }
        [HttpDelete("{id?}")]
        public async Task Unsuscribe(int id)
        {
            await _campusLogic.UnsuscribeCampus(id);
        }
        [HttpPost("CreateCampus")]
        public async Task CreateCampus(CampusViewModel campus)
        {
            await _campusLogic.CreateCampus(campus);
        }
        [HttpPost("EditCampus")]
        public async Task EditCampus(CampusViewModel campus)
        {
            await _campusLogic.EditCampus(campus);
        }
        [HttpGet("GetById/{id?}")]

        public async Task<CampusViewModel> GetCampusById(int id)
        {
            return  await _campusLogic.GetCampusById(id);
        }
    }
}
