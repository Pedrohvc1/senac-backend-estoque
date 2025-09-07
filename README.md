# 📦 Sistema de Gerenciamento de Estoque - Senac

Este projeto é uma **API REST desenvolvida em .NET 9** para gerenciamento de estoque, seguindo os princípios de **Clean Architecture** e **CQRS** com separação clara de responsabilidades entre as camadas.

## 🔖 Estrutura do Projeto

```plaintext
Senac.StockManagement.sln
├── Senac.StockManagement.API/                     # 🌐 Camada de Apresentação
│   ├── Controllers/V1/                            # Controllers versionados
│   ├── SwaggerConfig/                              # Configurações do Swagger
│   ├── Program.cs                                  # Ponto de entrada da aplicação
│   └── appsettings.json                           # Configurações da aplicação
│
├── Senac.StockManagement.Application/             # 🎯 Camada de Aplicação
│   ├── Commands/                                   # Commands (CQRS)
│   │   ├── CreateProduct/                         # Comando para criar produto
│   │   └── UpdateProduct/                         # Comando para atualizar produto
│   ├── Queries/                                    # Queries (CQRS)
│   │   ├── GetAllProducts/                        # Query para listar produtos
│   │   └── GetProductById/                        # Query para buscar produto por ID
│   └── Mapper/                                     # Configurações do AutoMapper
│
├── Senac.StockManagement.Domain/                  # 🏛️ Camada de Domínio
│   ├── Entities/                                   # Entidades do domínio
│   └── Interfaces/Repositories/                   # Contratos dos repositórios
│
└── Senac.StockManagement.Infrastructure.Data/     # 🔧 Camada de Infraestrutura
    ├── Context/                                    # Contexto do Entity Framework
    ├── Mappings/                                   # Mapeamentos do banco de dados
    └── Repositories/                              # Implementações dos repositórios
```

## ✅ Descrição dos Componentes

| Camada | Responsabilidade | Principais Arquivos |
|--------|------------------|-------------------|
| **API** | Interface de apresentação, endpoints REST | `ProductController.cs`, `Program.cs` |
| **Application** | Lógica de aplicação, handlers CQRS | Commands, Queries, Validators |
| **Domain** | Regras de negócio, entidades do domínio | `Product.cs`, Interfaces |
| **Infrastructure** | Acesso a dados, serviços externos | Repositórios, DbContext, Mappings |

## 🚀 Funcionalidades Implementadas

### 📋 Gestão de Produtos
- ✅ **Criar Produto** - `POST /api/v1/Product`
- ✅ **Atualizar Produto** - `PUT /api/v1/Product/{id}`
- ✅ **Listar Todos os Produtos** - `GET /api/v1/Product`
- ✅ **Buscar Produto por ID** - `GET /api/v1/Product/{id}`

### 🏗️ Arquitetura e Padrões
- ✅ **Clean Architecture** com separação de camadas
- ✅ **CQRS (Command Query Responsibility Segregation)**
- ✅ **MediatR** para mediação entre camadas
- ✅ **AutoMapper** para mapeamento de objetos
- ✅ **Repository Pattern** para acesso a dados
- ✅ **Versionamento de API** (v1)

### 🔧 Infraestrutura
- ✅ **Entity Framework Core** com PostgreSQL
- ✅ **Swagger/OpenAPI** com documentação automática
- ✅ **Dependency Injection** nativo do .NET
- ✅ **Logging** estruturado
- ✅ **Configuração por ambiente** (Development/Production)

## 📌 Tecnologias Utilizadas

| Tecnologia | Versão | Finalidade |
|------------|--------|------------|
| **.NET** | 9.0 | Framework principal |
| **ASP.NET Core** | 9.0 | Framework web |
| **Entity Framework Core** | 9.0 | ORM para acesso a dados |
| **PostgreSQL** | 15+ | Banco de dados relacional |
| **MediatR** | 11.1 | Padrão Mediator |
| **AutoMapper** | 13.0 | Mapeamento de objetos |
| **Swagger** | 9.0 | Documentação da API |
| **Npgsql** | 9.0 | Driver PostgreSQL para .NET |

## ⚙️ Configuração e Execução

### 📋 Pré-requisitos
- .NET 9 SDK
- PostgreSQL 15+
- IDE (Visual Studio, Rider, ou VS Code)

### 🗃️ Configuração do Banco de Dados

1. **Instalar PostgreSQL** e criar um banco de dados:
```sql
CREATE DATABASE StockManagementDb;
```

2. **Configurar a connection string** no `appsettings.Development.json`:
```json
{
  "ConnectionStrings": {
    "PostgreSQL_Estudos_Local": "Host=localhost;Database=StockManagementDb;Username=postgres;Password=sua_senha;Port=5432"
  }
}
```

### 🚀 Como Executar

1. **Clonar o repositório**:
```bash
git clone <url-do-repositorio>
cd senac-backend-estoque
```

2. **Restaurar pacotes**:
```bash
dotnet restore
```

3. **Executar as migrações** (quando disponíveis):
```bash
dotnet ef database update --project Senac.StockManagement.Infrastructure.Data --startup-project Senac.StockManagement.API
```

4. **Executar a aplicação**:
```bash
dotnet run --project Senac.StockManagement.API
```

5. **Acessar a API**:
   - **Swagger UI**: `https://localhost:5001/swagger`
   - **API Base**: `https://localhost:5001/api/v1`

## 📚 Exemplos de Uso

### Criar um Produto
```http
POST /api/v1/Product
Content-Type: application/json

{
  "name": "Mouse Logitech MX Master 3",
  "description": "Mouse sem fio com alta precisão",
  "price": 299.99,
  "stockQuantity": 50
}
```

### Listar Todos os Produtos
```http
GET /api/v1/Product
```

### Buscar Produto por ID
```http
GET /api/v1/Product/1
```

### Atualizar um Produto
```http
PUT /api/v1/Product/1
Content-Type: application/json

{
  "name": "Mouse Logitech MX Master 3S",
  "description": "Mouse sem fio com alta precisão - versão atualizada",
  "price": 349.99,
  "stockQuantity": 30
}
```

## 🔮 Próximos Passos

- [ ] Implementar autenticação JWT
- [ ] Adicionar validações com FluentValidation
- [ ] Criar testes unitários e de integração
- [ ] Implementar paginação nas listagens
- [ ] Adicionar filtros e ordenação
- [ ] Dockerizar a aplicação
- [ ] Implementar logs estruturados
- [ ] Adicionar monitoramento e health checks

## 👥 Contribuição

Este projeto faz parte do curso do **Senac** e está sendo desenvolvido com fins educacionais, aplicando as melhores práticas de desenvolvimento de software e arquitetura limpa.

---

**Desenvolvido com ❤️ usando .NET 9 e Clean Architecture**

