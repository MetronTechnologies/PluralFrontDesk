the project is structured this way
    every one in the system is a user stored in the user entity
    a patient can be onboarded into the system and will automatically get a wallet
    an appointment can be created for a patient, and a clinic is assigned to the individual


the following are the entities in the project
    User entity
    Appointment entity
    Audit Trails
    Clinics
    Wallet entity
    Patient entity


the status of a patient can be either 
        REGISTERED,
        CHECKED_IN,
        UNDER_TREATMENT,
        ON_HOLD,
        DISCHARGED,
        TRANSFERRED,
        INACTIVE, or
        DECEASED


the status of an appointment can be either SCHEDULED,
        COMPLETED,
        CANCELLED, or
        NOSHOW

the is a migration ready-made in the project
endpoints are secured using jwt bearer token except the auth controller for login and user creation

        
