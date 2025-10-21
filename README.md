# 🧩 CRUD de usuarios

Um projeto desenvolvido em **.NET 8** com **Entity Framework Core** e **PostgreSQL**, que implementa um sistema completo de **CRUD de usuários** (criação, leitura, atualização e deleção), com **validação**, **tratamento de erros** e **padrão de camadas limpo** (Domain, Application, Infrastructure, API).

---

## 🚀 Tecnologias Utilizadas

- **.NET 8 / ASP.NET Core Web API**
- **Entity Framework Core**
- **FluentValidation**
- **PostgreSQL (via Supabase)**
- **BCrypt.Net-Next** (hash de senha)
- **Arquitetura em camadas (DDD simplificado)**

---

## 🏗️ Estrutura do Projeto

```
CRUDUsuarios/
├── CRUDUsuarios.API/               # Camada de apresentação (controllers e endpoints)
│   ├── Controllers/
│   │   └── UserController.cs
│
├── CRUDUsuarios.Aplication/        # Casos de uso e validações
│   ├── usecases/
│   │   └── User/
│   │       ├── Register/
│   │       ├── GetAll/
│   │       ├── Update/
│   │       └── Delete/
│   └── Validators/
│
├── CRUDUsuarios.Domain/            # Entidades e exceções de domínio
│   ├── Entities/
│   │   └── UserDto.cs
│   └── Exceptions/
│
├── CRUDUsuarios.Infrastructure/    # Acesso a dados e configuração do banco
│   ├── DataAccess/
│   │   └── CRUDUsuariosDBContext.cs
│   └── Migrations/
│
└── README.md
```

---

## ⚙️ Configuração do Banco de Dados

O projeto utiliza **PostgreSQL** hospedado no **Supabase**.  
Para configurar a conexão, edite o arquivo:

**`CRUDUsuarios.Infrastructure/DataAccess/CRUDUsuariosDBContext.cs`**

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.UseNpgsql("Host=SEU_HOST;Port=5432;Database=postgres;Username=SEU_USER;Password=SUA_SENHA;Ssl Mode=Require;Trust Server Certificate=true");
}
```


## 🔐 Segurança

As senhas dos usuários são armazenadas de forma **segura com hash** utilizando a biblioteca `BCrypt.Net-Next`.

```csharp
var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
var isValid = BCrypt.Net.BCrypt.Verify(inputPassword, hashedPassword);
```

---

## 🧠 Funcionalidades Principais

| Funcionalidade             | Descrição                                             |
| -------------------------- | ----------------------------------------------------- |
| ➕ **Registrar Usuário**    | Cria um novo usuário com validação e hash de senha    |
| 📋 **Listar Usuários**     | Retorna todos os usuários cadastrados                 |
| ✏️ **Atualizar Usuário**   | Atualiza informações de um usuário pelo ID            |
| ❌ **Excluir Usuário**      | Remove um usuário existente                           |
| ⚠️ **Tratamento de Erros** | Exceções personalizadas e respostas HTTP padronizadas |

---

## 🔍 Endpoints da API

| Método   | Rota             | Descrição                   |
| -------- | ---------------- | --------------------------- |
| `POST`   | `/api/user`      | Cria um novo usuário        |
| `GET`    | `/api/user`      | Lista todos os usuários     |
| `PUT`    | `/api/user/{id}` | Atualiza um usuário pelo ID |
| `DELETE` | `/api/user/{id}` | Remove um usuário pelo ID   |

---

## 🧰 Exemplos de Requisição

### Criar Usuário

```json
POST /api/user
{
  "name": "Lucas Gomes",
  "email": "lucas@email.com",
  "password": "123456"
}
```

### Resposta

```json
{
  "id": "b3f2c5f0-8c1e-4a91-9123-bb2f2a91a3ef",
  "name": "Lucas Gomes",
  "email": "lucas@email.com"
}
```

---



## 🧱 Padrão de Commits

Este projeto segue a convenção **Conventional Commits**, por exemplo:

```
feat(user): adicionar hash de senha no processo de registro
fix(user): corrigir erro ao validar email duplicado
refactor(db): atualizar contexto para incluir novos campos
```


## 👨‍💻 Autor

**Lucas Gomes**  
Desenvolvedor .NET & React  
📧 [seuemail@email.com](mailto:llucas.gomes.dev@gmail.com)  
🌐 [linkedin.com/in/seu-perfil]([https://linkedin.com/in/seu-perfil](https://www.linkedin.com/in/llucasgomess))
```

---

Quer que eu adicione ao README uma **seção de instruções de deploy** (ex: no Render, Railway ou Supabase com .NET)? Isso deixaria o projeto ainda mais completo para portfólio.
