using Data_Layer.Enums;
using Data_Layer.Interfaces;
using Data_Layer.Repositories;
using Entity_Layer.Entities;
using Logic_Layer.Interfaces;
using Olimpiadas.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_Layer.SportComplexLogics
{
    public class SportComplexLogic : ISportComplexLogic
    {
        public readonly ISportComplexRepository _sportComplexRepository;

        public SportComplexLogic(ISportComplexRepository sportComplexRepository)
        {
            _sportComplexRepository = sportComplexRepository;
        }

        public async Task CreateSportcomplex(SportComplexViewModel sportComplex)
        {
            await _sportComplexRepository.CreateSportComplex(ConvertSportComplexViewModelToSportComplex(sportComplex));
        }



        public async Task UnsuscribeSportComplex(int idSportComplex)
        {
            await _sportComplexRepository.UnsuscribeSportComplex(idSportComplex);
        }
        public async Task EditSportComplex(SportComplexViewModel sportcomplex)
        {
            await _sportComplexRepository.EditSportComplex(ConvertCampusViewModelToCampus(sportcomplex));
        }


        public SportComplex ConvertCampusViewModelToCampus(SportComplexViewModel sportcomplex)
        {
            SportComplex sportComplexBd = new SportComplex();
            sportComplexBd.Id = sportcomplex.Id;
            sportComplexBd.Type = sportcomplex.Type;
            sportComplexBd.Localization = sportcomplex.Localization;
            sportComplexBd.OrganizationManager = sportcomplex.OrganizationManager;
            sportComplexBd.TotalOccupiedArea = sportcomplex.TotalOccupiedArea;
            return sportComplexBd;
        }
        public SportComplex ConvertSportComplexViewModelToSportComplex(SportComplexViewModel sportComplexViewModel)
        {
            SportComplex sportComplex = new SportComplex();
            sportComplex.Localization = sportComplexViewModel.Localization;
            sportComplex.OrganizationManager = sportComplexViewModel.OrganizationManager;
            sportComplex.Type = sportComplexViewModel.Type;
            sportComplex.CampusId = sportComplexViewModel.CampusId;
            sportComplex.State = Convert.ToInt32(StateRegistration.Active);
            return sportComplex;
        }
    }
}
