# AnalyticsDemo API

A analytics microservice built with .NET 8, designed to process and serve campaign and advertisement performance metrics.

## Architecture Overview

The system follows a event-driven architecture with the following components:

### Data Pipeline
- **ECS .net API**: Ingests user interaction events after tenant resolving and authrizing request.
- **Amazon SQS**: It is a backup buffer for events, if downstream services are unavailable
- **AWS Lambda**: Polls message queue and processes failed events and can be used fo retrying failed events
- **Amazon Kinesis Data Streams**: Handles high-throughput data streaming
- **PostgreSQL**: Stores aggregated metrics with read replicas for scaling
- **Dynamo DB**: Stores raw events
- **Redis**: Provides caching layer for frequently accessed data

### Microservice Architecture
- **Domain-Driven Design (DDD)**: Separation between Domain, Application, and Infrastructure layers. It can be extened for aggregates and bounded contexts.
- **CQRS Pattern**: Using MediatR for command/query separation
- **Multi-tenancy**: Built-in support for tenant isolation
- **Repository Pattern**: Abstracted data access with caching.

## Features

- **Real-time Analytics**: Track clicks, impressions, and conversions
- **Campaign Performance**: Aggregate metrics across multiple ads
- **Multi-tenant Support**: Isolated data per tenant with separate connection strings
- **Caching**: Redis integration for improved performance
- **Security**: JWT authentication with role-based authorization
- **Health Checks**: Monitor database and cache connectivity
- **API Documentation**: Swagger/OpenAPI integration

## Prerequisites

- .NET 8.0 SDK
- PostgreSQL 14+
- Redis 6+
- Docker 

## 🛠️ Installation

1. **Clone the repository**
```bash
git clone https://github.com/nvn012/analytics-demo/AnalyticsDemo.git
cd AnalyticsDemo
```

2. **Install dependencies**
```bash
dotnet restore
```

3. **Configure settings**

Update `appsettings.json` with your connection strings:

```json
{
  "Tenants": [
    {
      "TenantId": "Tenant1",
      "TenantName": "Tenant1",
      "ReadConnectionString": "Server=localhost;Port=5432;Database=analytics;User Id=app;Password=;",
      "WriteConnectionString": "Server=localhost;Port=5432;Database=analytics;User Id=app;Password=;"
    }
  ],
  "Redis": {
    "Configuration": "localhost:6379,password=yourpassword,ssl=false,abortConnect=false"
  }
}
```

4. **Run the application**
```bash
dotnet run --project AnalyticsDemo.Api
```

## API Endpoints

### Ad Metrics

#### Get Ad Clicks
```http
GET /ad/{adId}/campaign/{campaignId}/clicks?startDate={date}&endDate={date}
```

#### Get Ad Impressions
```http
GET /ad/{adId}/campaign/{campaignId}/impressions?startDate={date}&endDate={date}
```

#### Get Click-to-Basket Conversions
```http
GET /ad/{adId}/campaign/{campaignId}/clickToBasket?startDate={date}&endDate={date}
```

#### Get Complete Ad Performance
```http
GET /ad/{adId}/campaign/{campaignId}/adPerformance?startDate={date}&endDate={date}
```

### Campaign Metrics

#### Get Campaign Performance
```http
POST /campaign/{campaignId}/performance?startDate={date}&endDate={date}
Content-Type: application/json

[
  {
    "campaignId": "guid",
    "adId": "guid",
    "startDate": "2024-01-01",
    "endDate": "2024-01-31",
    "adType": "Banner",
    "adStatus": "Active"
  }
]
```

##  Testing

### Run all tests
```bash
dotnet test
```

### Test categories
```bash
# Unit tests only
dotnet test --filter "FullyQualifiedName~Controllers"

# Integration tests
dotnet test --filter "FullyQualifiedName~IntegrationTests"

```

## 🏛️ Project Structure

```
AnalyticsDemo/
├── AnalyticsDemo.Api/           # API Controllers and middleware
│   ├── Controllers/
│   ├── Middleware/
│   └── Program.cs
├── AnalyticsDemo.Application/   # Business logic and CQRS handlers
│   ├── AdMetrics/
│   │   └── Queries/
│   ├── Claims/
│   └── Services/
├── AnalyticsDemo.Domain/        # Domain entities and DTOs
│   ├── DTO/
│   ├── Request/
│   └── Tenant/
├── AnalyticsDemo.Infra/         # Data access and external services
│   ├── Persistence/
│   │   └── Repository/
│   ├── Services/
│   └── TenantRepo/
└── AnalyticsDemo.Api.Tests/     # Comprehensive test suite
    ├── Controllers/
```

##  Configuration

### Environment Variables
```bash
# Database
POSTGRES_HOST=localhost
POSTGRES_PORT=5432
POSTGRES_DB=analytics
POSTGRES_USER=app
POSTGRES_PASSWORD=

# Redis
REDIS_CONNECTION=localhost:6379,password=

# JWT
JWT_KEY=secretKey

# Logging
ASPNETCORE_ENVIRONMENT=Production
```

### Performance Tuning

1. **Database Connection Pooling**
```json
"ConnectionString": "...;Pooling=true;Minimum Pool Size=10;Maximum Pool Size=100;"
```

2. **Redis Cache Settings**
```json
"CacheSettings": {
  "DefaultExpirationMinutes": 5
}
```

##  Docker Support

### Build the image
```bash
docker build -t analyticsdemo:latest .
```

### Run with Docker Compose
```bash
docker-compose up -d
```

### Docker Compose includes:
- API service
- Redis
- Health check

##  Monitoring

### Health Checks
- Database connectivity
- Redis availability

### Logging
- Structured logging with Serilog
- Elasticsearch integration


##  Security

- JWT Bearer authentication
- CORS configuration
- HTTPS enforcement

## Roadmap

- [ ] GraphQL API support
- [ ] Real-time WebSocket updates
- [ ] Advanced analytics dashboard
- [ ] Machine learning predictions

---