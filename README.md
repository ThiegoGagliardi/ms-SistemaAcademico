# 🎓 Sistema Acadêmico - Arquitetura de Microsserviços

> Projeto de TCC MBA - Migração de um monolito para arquitetura de microsserviços

## 📋 Visão Geral

Este projeto implementa um **Sistema Acadêmico** baseado em **arquitetura de microsserviços**, utilizando **ASP.NET Core** e **SQL Server**. O sistema foi migrado de um monolito para uma arquitetura distribuída com serviços independentes, cada um responsável por um domínio específico.

### Arquitetura

```
┌─────────────────────────────────────────────────────────────────────┐
│                      API Gateway (Ocelot)                           │
│                      Porta: 8080 (padrão)                           │
└────────────────────┬──────────┬──────────┬─────────────────────────┘
                     │          │          │
          ┌──────────▼─┐  ┌─────▼────┐  ┌─▼──────────────┐
          │  MS Aluno  │  │ MS Curso │  │ MS Professor   │
          │  Porta 8050│  │ Porta... │  │ Porta 8070     │
          └──────────┬─┘  └─────┬────┘  └─┬──────────────┘
                     │          │        │
          ┌──────────▼─┐  ┌─────▼────┐  ┌─▼──────────────┐
          │   SQL Aluno│  │SQL Curso │  │ SQL Professor  │
          │   Porta1432│  │Porta...  │  │ Porta 1436     │
          └────────────┘  └──────────┘  └────────────────┘
```

## 📁 Estrutura do Projeto

```
ms-SistemaAcademico/
├── SistemaAcademicoAlunoMS/          # Microsserviço de Alunos
├── SistemaAcademicoCursoMS/          # Microsserviço de Cursos
├── SistemaAcademicoProfessorMS/      # Microsserviço de Professores
├── SistemaAcademicoApiGateway/       # API Gateway (Ocelot)
├── docker-compose.yaml               # Orquestração de containers
└── README.md                          # Documentação
```

## 🔧 Microsserviços

### 1. **MS Aluno** (SistemaAcademicoAlunoMS)

Gerencia dados e operações relacionadas a alunos.

- **Porta**: `8050` (Debug) / `5050`
- **Database**: `AlunoMsDB` - SQL Server
- **Controllers**:
  - `AlunoController` - Operações CRUD de alunos
  - `NotasAlunosController` - Gerenciamento de notas

**Repositories**:
- `AlunoRepository`
- `NotasAlunoRepository`

**Services**:
- `AlunoService`

---

### 2. **MS Curso** (SistemaAcademicoCursoMS)

Gerencia informações sobre cursos, disciplinas e grades horárias.

- **Porta**: `8060` (Debug) / `5060`
- **Database**: `CursoMsDb` - SQL Server
- **Controllers**:
  - `CursoController` - Operações CRUD de cursos
  - `DisciplinaController` - Gerenciamento de disciplinas
  - `FormacaoController` - Gerenciamento de formações

**Repositories**:
- `CursoRepository`
- `DisciplinaRepository`
- `FormacaoRepository`

**Services**:
- `CursoService`
- `DisciplinaService`
- `FormacaoService`

---

### 3. **MS Professor** (SistemaAcademicoProfessorMS)

Gerencia dados de professores, títulos e atribuição de aulas.

- **Porta**: `8070` (Debug) / `5070`
- **Database**: `ProfessorMsDb` - SQL Server
- **Controllers**:
  - `ProfessorController` - Operações CRUD de professores
  - `TituloController` - Gerenciamento de títulos/qualificações
  - `AtribuicaoAulaController` - Atribuição de aulas aos professores

**Repositories**:
- `ProfessorRepository`
- `TitulosRepository`
- `AtribuicaoAulaRepository`

**Services**:
- `ProfessorService`
- `TitulosService`
- `AtribuicaoAulaService`

---

### 4. **API Gateway** (SistemaAcademicoApiGateway)

Gateway de API centralizado usando **Ocelot** para rotear requisições aos microsserviços.

- **Porta**: Configurável em `ocelot.json`
- **Função**: Roteamento, agregação e controle de acesso

**Rotas Disponíveis**:
- `/api/aluno` → MS Aluno (8050)
- `/api/professores` → MS Professor (8070)

---

## 🗄️ Banco de Dados

Cada microsserviço possui seu próprio **banco de dados independente**, seguindo o padrão de dados descentralizados.

| Serviço | Database | Porta | User | Senha |
|---------|----------|-------|------|-------|
| Aluno | AlunoMsDB | 1432 | sa | S3nhA4luno.0 |
| Professor | ProfessorMsDb | 1436 | sa | S3nh@Profess0.r |
| Curso | CursoMsDb | - | sa | S3nh@Curs.04 |

**⚠️ Aviso**: As senhas estão hardcoded para ambiente de desenvolvimento. Use variáveis de ambiente em produção!

---

## 🚀 Como Iniciar

### Pré-requisitos

- **Docker** e **Docker Compose** instalados
- **.NET SDK 6.0+** (para desenvolvimento local)
- **SQL Server** (via Docker)

### 1. Usando Docker Compose

```bash
# Na raiz do projeto
docker-compose up -d

# Verificar status dos containers
docker ps

# Ver logs de um serviço específico
docker-compose logs aluno-app
docker-compose logs professor-app
```

**O que será iniciado**:
- ✅ SQL Server para Aluno (porta 1432)
- ✅ SQL Server para Professor (porta 1436)
- ✅ Migrations de banco de dados
- ✅ MS Aluno (porta 8050)
- ✅ MS Professor (porta 8070)
- ✅ API Gateway

### 2. Desenvolvimento Local

```bash
# Restaurar dependências
dotnet restore

# Para cada microsserviço:
cd SistemaAcademicoAlunoMS
dotnet ef database update
dotnet run

# Em outro terminal
cd SistemaAcademicoProfessorMS
dotnet ef database update
dotnet run

# Em outro terminal
cd SistemaAcademicoCursoMS
dotnet ef database update
dotnet run

# Em outro terminal
cd SistemaAcademicoApiGateway
dotnet run
```

---

## 📡 Endpoints da API

### Via Gateway (`/api`)

```
GET    /api/aluno           - Listar alunos
POST   /api/aluno           - Criar aluno
GET    /api/aluno/{id}      - Obter aluno por ID
PUT    /api/aluno/{id}      - Atualizar aluno
DELETE /api/aluno/{id}      - Deletar aluno

GET    /api/professores     - Listar professores
POST   /api/professores     - Criar professor
GET    /api/professores/{id} - Obter professor por ID
PUT    /api/professores/{id} - Atualizar professor
DELETE /api/professores/{id} - Deletar professor
```

### Via Microsserviços Diretos

**MS Aluno** (http://localhost:8050):
- `/api/aluno/*`
- `/api/notas-alunos/*`
- `/swagger` - Swagger UI

**MS Professor** (http://localhost:8070):
- `/api/professores/*`
- `/api/titulos/*`
- `/api/atribuicao-aula/*`
- `/swagger` - Swagger UI

**MS Curso** (http://localhost:8060):
- `/api/cursos/*`
- `/api/disciplinas/*`
- `/api/formacoes/*`
- `/swagger` - Swagger UI

---

## 🏗️ Arquitetura Interna de cada Microsserviço

Cada microsserviço segue o padrão camadas:

```
Controllers/           # Endpoints da API REST
├── AlunoController
├── ProfessorController
└── ...

Services/             # Lógica de negócio
├── AlunoService
├── ProfessorService
└── ...

Domain/
├── Repositories/     # Abstração de acesso a dados
├── Entities/         # Modelos de domínio
└── ...

Data/                 # Entity Framework
├── DbContext
└── ...

Factories/            # Criação de objetos
├── AlunoFactory
└── ...

DTOs/                 # Data Transfer Objects
├── AlunoDTO
└── ...
```

---

## 🔄 Fluxo de Requisição

```
Client Request
    ↓
[API Gateway - Ocelot]
    ↓
Routes request to appropriate microservice
    ↓
[Microservice Controller]
    ↓
[Service Layer - Business Logic]
    ↓
[Repository Layer]
    ↓
[Database]
```

---

## 📦 Tecnologias Utilizadas

| Tecnologia | Versão | Uso |
|------------|--------|-----|
| ASP.NET Core | 6.0+ | Framework web |
| Entity Framework Core | - | ORM e Migrations |
| SQL Server | 2022 | Banco de dados |
| Ocelot | - | API Gateway |
| Docker | Latest | Containerização |
| Swagger | - | Documentação de API |

---

## 🔐 Configuração de Ambiente

### appsettings.json
Cada microsserviço possui arquivo `appsettings.json` com configurações padrão.

### Variáveis de Ambiente (Docker)
```
DB_CONNECTION_STRING=Server=<host>,<port>;Database=<db>;User Id=sa;Password=<pwd>;TrustServerCertificate=True
ASPNETCORE_ENVIRONMENT=Development
```

### Migrations
Executadas automaticamente via Docker antes do serviço iniciar:
```bash
# Manual
dotnet ef database update

# Criar nova migration
dotnet ef migrations add <MigrationName>
```

---

## 🧪 Testes

Para testar os endpoints:

### Usando cURL
```bash
# Obter alunos
curl -X GET http://localhost:8050/api/aluno

# Criar novo aluno
curl -X POST http://localhost:8050/api/aluno \
  -H "Content-Type: application/json" \
  -d '{"nome":"João Silva","email":"joao@example.com"}'
```

### Usando Swagger UI
- MS Aluno: http://localhost:8050/swagger
- MS Professor: http://localhost:8070/swagger
- MS Curso: http://localhost:8060/swagger

---

## 📊 Diagrama de Entidades

### MS Aluno
- **Aluno**: id, nome, matricula, email, etc.
- **NotasAluno**: aluno_id, disciplina_id, nota, periodo

### MS Professor
- **Professor**: id, nome, email, departamento
- **Titulos**: professor_id, titulo, data_obtencao
- **AtribuicaoAula**: professor_id, disciplina_id, horario

### MS Curso
- **Curso**: id, nome, duracao, descricao
- **Disciplina**: id, nome, carga_horaria, curso_id
- **Formacao**: id, nome, curso_id
- **GradeHoraria**: id, formacao_id
- **Horario**: id, grade_id, disciplina_id, dia_semana, horario

---

## 🐛 Troubleshooting

### Problema: Database connection fails

**Solução**:
```bash
# Verificar se SQL Server está rodando
docker ps

# Reiniciar containers
docker-compose down
docker-compose up -d

# Verificar logs
docker-compose logs sqlserver-aluno-db
```

### Problema: Port already in use

**Solução**:
```bash
# Liberar porta
lsof -i :8050  # ou netstat -ano | findstr :8050
kill -9 <PID>  # Windows: taskkill /PID <PID> /F

# Ou mudar porta em docker-compose.yaml
```

### Problema: Migration falha

**Solução**:
```bash
# Limpar e recriar
docker-compose down -v
docker-compose up -d

# Ou manualmente
dotnet ef database drop
dotnet ef database update
```

---

## 📚 Documentação Adicional

- **Padrões de Design**: Repository Pattern, Factory Pattern, Service Layer
- **Princípios SOLID**: Aplicados em toda a arquitetura
- **Clean Architecture**: Separação clara de responsabilidades
- **API REST**: Convenções RESTful nos endpoints

---

## 👥 Contribuidores

- Seu Nome - TCC MBA

---

## 📝 Licença

Este projeto é para fins educacionais (TCC MBA).

---

## 🔗 Links Úteis

- [ASP.NET Core Docs](https://docs.microsoft.com/dotnet/core/)
- [Entity Framework Core](https://docs.microsoft.com/ef/core/)
- [Ocelot Gateway](https://ocelot.readthedocs.io/)
- [Docker Documentation](https://docs.docker.com/)

---

**Última atualização**: Janeiro 2026

