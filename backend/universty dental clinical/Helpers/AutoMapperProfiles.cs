using AutoMapper;
using universty_dental_clinical.DTO.Admin;
using universty_dental_clinical.DTO.Doctor;
using universty_dental_clinical.DTO.User;
using universty_dental_clinical.DTO.Treatment;
using universty_dental_clinical.Models;
using universty_dental_clinical.Models.UniversityDentalClinic.Models;
using universty_dental_clinical.DTO.Booking;
using universty_dental_clinical.DTO.Student;

namespace universty_dental_clinical.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {

            #region admin dto
            CreateMap<CreateAdmin, Admin>();

            CreateMap<Admin,GetAdmin>();

            CreateMap<UpdatedAdmin,Admin>();
            #endregion

            #region Doctor dto

            CreateMap<CreatDoctor, Doctor>();

            CreateMap<Doctor, GetDoctor>();

            CreateMap<UpdatedDoctor, Doctor>();
            #endregion
            #region UserDto

            CreateMap<CreateUser, User>();

            CreateMap<User, GetUser>();

            CreateMap<UpdateUser, User>();
            #endregion
            #region Treatment Dto

            CreateMap<CreateTreatment, Treatment>();

            CreateMap<Treatment, GetTreatment>();

            CreateMap<UpdatedTreatment, Treatment>();
            #endregion
            #region

            CreateMap<CreateBooking, Booking>();

            CreateMap<Booking, GetBooking>();

            CreateMap<UpdatedBooking, Booking>();

            #endregion

            CreateMap<CreateStudent, Student>().ReverseMap();


        }
    }
}
