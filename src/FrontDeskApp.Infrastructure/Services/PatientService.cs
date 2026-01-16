using FrontDeskApp.Application.Common;
using FrontDeskApp.Application.DTOs;
using FrontDeskApp.Application.RepositoryInterfaces;
using FrontDeskApp.Application.Services;
using FrontDeskApp.Domain.Entities;
using FrontDeskApp.Domain.Enums;

namespace FrontDeskApp.Infrastructure.Services
{
    public class PatientService : IPatientService
    {
        private readonly IGenericRepository<Patient> _patientsRepository;
        private readonly IGenericRepository<Wallet> _walletsRepository;

        public PatientService(
            IGenericRepository<Patient> patientsRepository,
            IGenericRepository<Wallet> walletsRepository)
        {
            _patientsRepository = patientsRepository;
            _walletsRepository = walletsRepository;
        }

        public async Task<ResponseInfo<Patient>> CreatePatientAsync(CreatePatientDto dto)
        {
            ResponseInfo<Patient> responseInfo = new();
            
            var existingPatient = await _patientsRepository.GetSingleAsync(p => p.Email == dto.Email);
            if (existingPatient != null) return responseInfo.MarkFail("Email is already registered.");

            var wallet = new Wallet
            {
                Balance = 0,
                Currency = dto.Currency
            };
            await _walletsRepository.AddAsync(wallet);

            // 3️⃣ Hash password
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            // 4️⃣ Create Patient
            var patient = new Patient
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                PasswordHash = passwordHash,
                Code = dto.Code,
                Status = PatientStatus.REGISTERED,
                Wallet = wallet
            };

            await _patientsRepository.AddAsync(patient);

            return responseInfo.MarkSuccess(patient);
        }

    }
}