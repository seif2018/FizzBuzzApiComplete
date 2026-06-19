# FizzBuzz API - Test technique

Projet complet : Backend C#/.NET 8, Frontend Angular, tests, Docker, logging, configuration, Swagger et health check.

## Endpoint

```http
GET /api/fizzbuzz?int1=3&int2=5&limit=15&str1=Fizz&str2=Buzz
```

Réponse attendue :

```json
["1","2","Fizz","4","Buzz","Fizz","7","8","Fizz","Buzz","11","Fizz","13","14","FizzBuzz"]
```

## Lancer avec Docker

```bash
docker compose up --build
```

- Frontend : http://localhost:8080
- Swagger API : http://localhost:5000/swagger
- Health check : http://localhost:5000/health

## Backend local

```bash
cd backend/FizzBuzz.Api
dotnet restore
dotnet run
```

## Tests backend

```bash
cd backend
dotnet test
```

## Frontend local

```bash
cd frontend/fizzbuzz-ui
npm install
npm start
```

Puis ouvrir : http://localhost:4200

## Bonnes pratiques

- Controller REST séparé de la logique métier
- Service injectable via interface
- Validations des paramètres
- Middleware global de gestion d'erreurs
- Logging via ILogger
- Swagger/OpenAPI
- Health check `/health`
- Configuration CORS via `appsettings.json`
- Tests unitaires xUnit
- Tests d'intégration `WebApplicationFactory`
- Dockerfile backend, Dockerfile frontend et docker-compose
