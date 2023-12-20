using Data_Layer.Enums;
using Data_Layer.Interfaces;
using Entity_Layer.Entities;
using Logic_Layer.Interfaces;
using Olimpiadas.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_Layer.CampusLogic
{
    public class CampusLogic:ICampusLogic
    {
       public readonly ICampusRepository _campusRepository;

        public CampusLogic(ICampusRepository camusRepository) {
            _campusRepository = camusRepository;
        }

        public async Task<List<CampusViewModel>> GetAllCampuses()
        {
            return ConverCampusesToViewModels(await _campusRepository.GetAllCampuses());
        }

        public async Task UnsuscribeCampus(int idCampus)
        {
            await _campusRepository.UnsuscribeCampus(idCampus);
        }

        public async Task<CampusViewModel> GetCampusById(int idCampus)
        {
            return ConverCampusToViewModel(await _campusRepository.GetCampusById(idCampus));
        }
        public async Task CreateCampus(CampusViewModel campus)
        {
            var campusViewModel = ConvertCampusViewModelToCampus(campus);
            campusViewModel.State =  Convert.ToInt32(StateRegistration.Active);
            await _campusRepository.CreateCampus(campusViewModel);
        }
        /// <summary>Convierto mi modelo de vista a modelo de entidad ya que se actualizara en la capa de repositorio siguendo el principio de responsabilidad unica 
        /// </summary>
        public async Task EditCampus(CampusViewModel campus)
        {
            await _campusRepository.EditCampus(ConvertCampusViewModelToCampus(campus));   
        }
        /// <summary>
        /// Esta Seccion es de mappeos por practicidad esta manual, pero siempre trabajo con automapper, evitamos tener codigo duplicado
        /// </summary>
        public Campus ConvertCampusViewModelToCampus(CampusViewModel campus)
        {
            Campus campusBd= new Campus();
            campusBd.ApproximateEstimation = campus.ApproximateEstimation;
            campusBd.Name= campus.Name;
            campusBd.Id= campus.Id;
            return campusBd;
        }

        public CampusViewModel ConverCampusToViewModel(Campus campus)
        {
            CampusViewModel campusViewModel = new CampusViewModel();
            campusViewModel.SportComplexViewModels = new List<SportComplexViewModel>();
            campusViewModel.Name = campus.Name;
            campusViewModel.Id = campus.Id;
            campusViewModel.ApproximateEstimation = campus.ApproximateEstimation;

            if (campus.SportComplexes!=null)
            {
                foreach (var sportComplexes in campus.SportComplexes)
                {
                    campusViewModel.SportComplexViewModels.Add(new SportComplexViewModel
                    {
                        Localization = sportComplexes.Localization,
                        CampusId = sportComplexes.CampusId,
                        Id = sportComplexes.Id,
                        OrganizationManager = sportComplexes.OrganizationManager,
                        TotalOccupiedArea = sportComplexes.TotalOccupiedArea,
                        State = sportComplexes.State,
                        Type = sportComplexes.Type,
                        TypeString = ((TypeSportComplexEnum)sportComplexes.Type).ToString()
                    });
                }
            }
            return campusViewModel;
        }
        public List<CampusViewModel> ConverCampusesToViewModels(List<Campus> campuses)
        {
            List<CampusViewModel> campusViewModels = new List<CampusViewModel>();
            foreach (var campus in campuses)
            {
                var campusViewModel = new CampusViewModel { Id = campus.Id, Name = campus.Name, ApproximateEstimation = campus.ApproximateEstimation, State = campus.State };
                campusViewModels.Add(campusViewModel);

            }
            return campusViewModels;
        }
    } 
}
