# Libertea Contact Book

A full-stack contact book application built with .NET and Blazor, featuring a RESTful backend API and a responsive frontend interface for managing customer contacts and orders.

## 🔗 Repository
This project is available at [github.com/luisrosaleshub/libertea-contactbook](https://github.com/luisrosaleshub/libertea-contactbook.git)

## 🛠️ Prerequisites

- .NET SDK 8.0 (Backend)
- .NET SDK 6.0 (Frontend)
- SQLite (included in the project)
- Visual Studio 2022 or VS Code with C# extensions

## 🚀 Getting Started

1. Clone the repository:
   ```bash
   git clone https://github.com/luisrosaleshub/libertea-contactbook.git
   cd libertea-contactbook
   ```

2. Run the Backend:
   ```bash
   cd backend
   dotnet restore
   dotnet run
   ```
   The backend API will be available at `https://localhost:7042`

3. Run the Frontend:
   ```bash
   cd frontend
   dotnet restore
   dotnet run
   ```
   The frontend application will be available at `https://localhost:7041`

## 🏗️ Project Structure

- `backend/`: .NET 8.0 Web API project
  - `Data/`: Contains DbContext and database configurations
  - `Models/`: Data models for Customers and Orders
  - `Controllers/`: API endpoints (to be implemented)
  - `Services/`: Business logic layer (to be implemented)

- `frontend/`: Blazor Server project
  - `Pages/`: Blazor pages and components
  - `Models/`: Data models
  - `Services/`: (To be implemented) Service layer for API communication
  - `Shared/`: Shared components and layouts

## 🔄 Future Improvements and Best Practices

### Backend Enhancements
1. **Service Layer Implementation**
   - Add a dedicated services layer for business logic
   - Implement the repository pattern
   - Add dependency injection for better testability

2. **Logging**
   - Implement structured logging using Serilog
   - Add request/response logging middleware
   - Configure different log levels for development/production

3. **Unit Testing**
   - Add xUnit test project
   - Implement unit tests for services and controllers
   - Add integration tests for API endpoints
   - Use Moq for mocking dependencies

4. **API Documentation**
   - Enhance Swagger documentation
   - Add XML comments for API endpoints
   - Include request/response examples

### Frontend Enhancements
1. **Service Layer**
   - Implement HTTP service classes
   - Add proper error handling and loading states
   - Cache service responses where appropriate

2. **Component Architecture**
   - Break down large components into smaller, reusable ones
   - Implement proper state management
   - Add component unit tests

3. **UI/UX Improvements**
   - Add loading indicators
   - Implement proper error handling UI
   - Add form validation feedback
   - Improve responsive design

4. **Testing**
   - Add bUnit for Blazor component testing
   - Implement integration tests
   - Add UI automation tests

### General Improvements
1. **Security**
   - Implement authentication and authorization
   - Add API key management
   - Implement HTTPS enforcement
   - Add CORS policies

2. **Performance**
   - Implement caching strategies
   - Add database indexing
   - Optimize API responses
   - Implement lazy loading where appropriate

3. **Monitoring**
   - Add health checks
   - Implement application metrics
   - Add performance monitoring
   - Set up error tracking


## 👤 Author

[Luis Rosales](https://github.com/luisrosaleshub)