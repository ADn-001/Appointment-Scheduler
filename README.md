# Project Development Report
**Project Title:** Appointment Scheduler Minimal Web API  

## Team Members
- **Adnan**: Project planning, DevOps, debugging, troubleshooting, and implementation of `Program.cs`, `AppointmentScheduler.Core`, and `AppointmentScheduler.Web`.  
- **Alex**: Implementation of `AppointmentScheduler.Application`.  
- **Vlad**: Implementation of `AppointmentScheduler.Infrastructure`.  

## Project Overview
The Appointment Scheduler is a Minimal Web API built with ASP.NET Core, following Clean Architecture principles. It provides endpoints to schedule, list, and cancel appointments. The project is organized into four layers—Core, Application, Infrastructure, and Web—to ensure separation of concerns and maintainability.

## Contributions
- **Adnan**:  
  - Led project planning and setup, creating the solution and projects in Visual Studio.  
  - Handled DevOps tasks, including environment configuration and build consistency.  
  - Implemented the core domain model (`Appointment.cs`) and repository interface (`IAppointmentRepository.cs`) in `AppointmentScheduler.Core`.  
  - Developed the Minimal API endpoints and dependency injection in `Program.cs` within `AppointmentScheduler.Web`.  
  - Performed debugging and troubleshooting to ensure functionality.  

- **Alex**:  
  - Implemented the application layer, specifically `AppointmentService.cs` in `AppointmentScheduler.Application`.  
  - Developed business logic for scheduling, listing, and canceling appointments, including conflict checking.  

- **Vlad**:  
  - Implemented the infrastructure layer, specifically `InMemoryAppointmentRepository.cs` in `AppointmentScheduler.Infrastructure`.  
  - Managed in-memory data storage for appointments, ensuring runtime persistence.  

## Conclusion
The team delivered a functional Appointment Scheduler API that meets the project’s core requirements. Each member contributed to their assigned areas, resulting in a well-structured application adhering to Clean Architecture principles.
