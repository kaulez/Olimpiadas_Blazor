using Logic_Layer.CampusLogic;
using Logic_Layer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Olimpiadas.Shared.ViewModels;

namespace Olimpiadas.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class SportComplexController :  ControllerBase
    {
        public readonly ISportComplexLogic _sportComplexLogic;
        public SportComplexController(ISportComplexLogic sportComplexLogic)
        {
            _sportComplexLogic = sportComplexLogic;
        }

        [HttpPost("CreateSportComplex")]
        public async Task CreateSportComplex(SportComplexViewModel sportComplexViewModel)
        {
            await _sportComplexLogic.CreateSportcomplex(sportComplexViewModel);
        }

        [HttpDelete("{id?}")]
        public async Task Unsuscribe(int id)
        {
            await _sportComplexLogic.UnsuscribeSportComplex(id);
        }
        [HttpPost("EditSportComplex")]
        public async Task EditSportComplex(SportComplexViewModel sportComplexViewModel)
        {
            await _sportComplexLogic.EditSportComplex(sportComplexViewModel);
        }
    }
}
