using FrontDeskApp.Application.Common;
using FrontDeskApp.Application.Common.Pagination;
using FrontDeskApp.Application.DTOs;
using FrontDeskApp.Application.RepositoryInterfaces;
using FrontDeskApp.Application.Services;
using FrontDeskApp.Domain.Entities;

namespace FrontDeskApp.Infrastructure.Services
{
    public class AppointmentService : IAppointmentService
    {

        private readonly IGenericRepository<Appointment> _appointmentsRepository;
        private readonly IGenericRepository<Patient> _patientsRepository;
        private readonly IGenericRepository<Clinic> _clinicsRepository;
        private readonly IAppointmentRepository _iAR;

        public AppointmentService(
            IGenericRepository<Appointment> appointmentsRepository,
            IGenericRepository<Patient> patientsRepository,
            IGenericRepository<Clinic> clinicsRepository,
            IAppointmentRepository iar)
        {
            _appointmentsRepository = appointmentsRepository;
            _patientsRepository = patientsRepository;
            _clinicsRepository = clinicsRepository;
            _iAR = iar;
        }


        public async Task<ResponseInfo<Appointment>> CreateAppointmentAsync(AppointmentDto appointmentDto)
        {
            ResponseInfo<Appointment> responseInfo = new();

            var patient = await _patientsRepository.GetByIdAsync(appointmentDto.PatientId);
            if (patient == null) return responseInfo.MarkFail("Patient not found");

            var clinic = await _clinicsRepository.GetByIdAsync(appointmentDto.ClinicId);
            if (clinic == null) return responseInfo.MarkFail("Clinic not found");

            Appointment appointment = new Appointment
            {
                PatientId = patient.Id,
                ClinicId = clinic.Id,
                AppointmentTime = appointmentDto.AppointmentTime,
                AppointmentStatus = appointmentDto.AppointmentStatus,
                AmountPaid = appointmentDto.AmountPaid,
                DiscountAllowed = appointmentDto.DiscountAllowed
            };

            await _appointmentsRepository.AddAsync(appointment);
            return responseInfo.MarkSuccess(appointment);
        }



        public async Task<ResponseInfo<PagedResult<Appointment>>> GetAppointmentsPagedAsync(
    int pageNumber,
    int pageSize,
    string? sortBy = null,
    bool sortDescending = false,
    string? searchParam = null)
        {

            ResponseInfo<PagedResult<Appointment>> responseInfo = new();

            PagedResult<Appointment> paged = await _iAR.GetPagedAppointmentsAsync(
                pageNumber,
                pageSize,
                sortBy,
                sortDescending,
                searchParam
            );

            return responseInfo.MarkSuccess(paged);

        }



    }
}