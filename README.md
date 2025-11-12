# 🎬 GitHub Copilot Workshop - Movie Database Application

Welcome to the **GitHub Copilot Workshop**! This is a hands-on project that demonstrates how to build a full-stack application using GitHub Copilot, featuring a modern tech stack with .NET backend and Vue.js frontend.

## 📋 Project Overview

This repository contains a complete movie database application that serves as a learning platform for GitHub Copilot. The project includes:

- **Backend**: ASP.NET Core Web API (NET 9.0) with Entity Framework Core
- **Frontend**: Vue 3 + Vite with modern UI components
- **MCP Server**: Model Context Protocol server for advanced Copilot features
- **Testing**: Comprehensive backend tests using xUnit
- **Workshop Materials**: Step-by-step instructions and guides

## 🚀 Features

- Movie catalog management with categories
- In-memory database for quick prototyping
- RESTful API endpoints for movies and categories
- Modern, responsive Vue 3 frontend
- Movie seeding functionality
- CORS-enabled API for frontend-backend communication
- MCP server for enhanced GitHub Copilot capabilities

## 🏗️ Project Structure

```
.
├── backend/                 # ASP.NET Core Web API
│   ├── Models/             # Data models (Movie, Category, etc.)
│   ├── Data/               # Database context
│   ├── Properties/         # Launch settings
│   └── Program.cs          # Main application entry point
├── backend.Tests/          # Unit and integration tests
├── frontend/               # Vue 3 application
│   ├── src/               # Vue components and logic
│   │   ├── App.vue        # Main app component
│   │   ├── MovieList.vue  # Movie listing component
│   │   └── SeedMovies.vue # Movie seeding component
│   └── public/            # Static assets
├── instructions/           # Workshop step-by-step guides
├── starters/              # Starter files and templates
│   └── mcp/              # MCP server implementation
└── README.md             # This file
```

## 🛠️ Tech Stack

### Backend
- **Framework**: ASP.NET Core 9.0
- **Database**: Entity Framework Core with In-Memory provider
- **API**: RESTful Web API with OpenAPI/Swagger
- **Testing**: xUnit, Moq, WebApplicationFactory

### Frontend
- **Framework**: Vue 3.5+ with Composition API
- **Build Tool**: Vite 7.x
- **Development**: Hot Module Replacement (HMR)
- **Styling**: Modern CSS with scoped styles

### Additional Tools
- **MCP Server**: Model Context Protocol for GitHub Copilot
- **Node.js**: v20.19.0 or >=22.12.0
- **.NET SDK**: 9.0

## 📚 Prerequisites

Before starting, ensure you have the following installed:

- **GitHub Account**: With access to GitHub Copilot
- **Development Tools**:
  - [.NET SDK 9.0 or later](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
  - [Node.js and npm](https://nodejs.org/) (v20.19.0+ or v22.12.0+)
  - [Git](https://git-scm.com/downloads)
  - [Visual Studio Code](https://code.visualstudio.com/)
- **VS Code Extensions**:
  - [GitHub Copilot](https://marketplace.visualstudio.com/items?itemName=GitHub.copilot)
  - [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) (recommended)
  - [Vue Language Features (Volar)](https://marketplace.visualstudio.com/items?itemName=Vue.volar) (recommended)

## 🚀 Getting Started

### 1. Clone the Repository

```bash
git clone <repository-url>
cd copilot-hackathon
```

### 2. Backend Setup

```bash
# Navigate to backend directory
cd backend

# Restore dependencies
dotnet restore

# Run the backend
dotnet run
```

The backend API will be available at:
- HTTP: `http://localhost:5000`
- HTTPS: `https://localhost:5001`

### 3. Frontend Setup

```bash
# Navigate to frontend directory
cd frontend

# Install dependencies
npm install

# Start development server
npm run dev
```

The frontend will be available at `http://localhost:5173`

### 4. Running Tests

```bash
# Navigate to test project
cd backend.Tests

# Run all tests
dotnet test

# Run with detailed output
dotnet test --verbosity normal
```

## 🎯 API Endpoints

### Movies

- **GET** `/movies` - Get all movies with their categories
- **POST** `/seed` - Seed the database with sample movies

### Example API Usage

```bash
# Get all movies
curl http://localhost:5000/movies

# Seed database
curl -X POST http://localhost:5000/seed
```

## 📖 Workshop Instructions

This repository includes comprehensive workshop materials. Follow these instructions in order:

1. [Project Explanation](instructions/0-project-explanation.md) - Start here!
2. [Clean Boilerplate](instructions/1-clean-boilerplate.md)
3. [Add Backend Code](instructions/2-add-code-for-backend.md)
4. [Database Context](instructions/3-add-db-context.md)
5. [Backend Tests](instructions/4-backend-tests.md)
6. [Frontend Development](instructions/5-frontend.md)
7. [Connect Frontend-Backend](instructions/6-connecting-frontend-backend.md)
8. [MCP Server](instructions/7-mcp-server.md)
9. [Customizations](instructions/8-customizations.md)
10. [Debug Copilot](instructions/9-debug-copilot.md)
11. [Additional Workshops](instructions/10-additional-workshops.md)
12. [Custom Agent](instructions/11-custom-agent.md)
13. [Review Agent](instructions/12-review-agent.md)
14. [Spaces](instructions/13-spaces.md)

## 🧪 Testing

The project includes comprehensive unit and integration tests:

- **MoviesEndpointLogicTests.cs** - Tests for movies endpoint logic
- **SeedEndpointTests.cs** - Tests for seed functionality
- **UnitTest1.cs** - Additional unit tests

Run tests with:
```bash
cd backend.Tests
dotnet test
```

## 🤖 MCP Server

The Model Context Protocol (MCP) server enhances GitHub Copilot's capabilities for this project. Find the MCP implementation in:

```
starters/mcp/MoviesMCP/
```

The MCP server provides custom tools and context for working with movie data within GitHub Copilot.

## 🎨 Frontend Development

The Vue 3 frontend provides a modern interface for:
- Viewing the movie list
- Seeding the database with sample data
- Displaying movies with their categories

Key components:
- `App.vue` - Main application layout
- `MovieList.vue` - Displays all movies
- `SeedMovies.vue` - Provides database seeding functionality

## 🔧 Configuration

### Backend Configuration

Edit `backend/appsettings.json` or `backend/appsettings.Development.json` for backend configuration.

### Frontend Configuration

The frontend uses Vite for build configuration. See `frontend/vite.config.js` for build settings.

## 🤝 Contributing

This is a workshop project. Feel free to:
- Experiment with the code
- Add new features
- Improve existing functionality
- Create additional workshop materials

## 📝 License

This project is provided as-is for educational purposes as part of the GitHub Copilot workshop.

## 🆘 Troubleshooting

### Backend Issues

- **Port already in use**: Change the port in `backend/Properties/launchSettings.json`
- **Database issues**: The app uses in-memory database, restart the app to reset

### Frontend Issues

- **npm install fails**: Ensure you have Node.js v20.19.0+ or v22.12.0+
- **Port 5173 in use**: The Vite dev server will automatically use the next available port

### CORS Issues

If you encounter CORS errors:
1. Ensure the backend is running
2. Check the CORS policy in `backend/Program.cs`
3. Verify the frontend is making requests to the correct backend URL

## 📬 Support

For questions or issues:
1. Check the [workshop instructions](instructions/0-project-explanation.md)
2. Review the [troubleshooting section](#-troubleshooting)
3. Consult GitHub Copilot for code assistance

---

**Ready to get started?** Head over to the [workshop instructions](instructions/0-project-explanation.md) and begin your GitHub Copilot journey! 🚀
