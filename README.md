# 🚀 **LearnExpress API**

Este repositório contém uma API desenvolvida para gerenciar uma **plataforma de cursos online**, construída com **.NET Core** e integrando diversos conceitos fundamentais de boas práticas em desenvolvimento de software.

---

## 🛠️ **Tecnologias e Princípios Aplicados**

- 🧑‍💻 **.NET Core** e **C#**: Desenvolvimento de APIs RESTful.
- 🗂️ **PostgreSQL**: Banco de dados relacional para persistência de dados.
- 🔄 **Entity Framework Core**: Mapeamento objeto-relacional (ORM).
- 🧩 **Injeção de Dependência (Dependency Injection)**: Simplifica o gerenciamento de dependências.
- 📂 **Padrão Repository**: Abstração de acesso a dados para maior desacoplamento.
- 📦 **DTO (Data Transfer Object)**: Transferência eficiente e segura de dados.
- 🔍 **Filtragem e Paginação**: Para otimizar requisições de grandes volumes de dados.
- 📖 **Swagger/OpenAPI**: Documentação interativa para explorar os endpoints.
- 🏛️ **Clean Architecture**: Código organizado para maior manutenibilidade e testabilidade.

---

## ✨ **Funcionalidades Principais**

1. **👤 Gestão de Usuários**  
   - ✅ Criação, leitura, atualização e exclusão.  
   - 📑 Paginação aplicada.  

2. **📚 Gestão de Cursos**  
   - ✅ Criação, leitura, atualização e exclusão.  
   - 📑 Paginação aplicada.  

3. **🎓 Gestão de Aulas**  
   - ✅ Criação, leitura, atualização e exclusão.  
   - 📑 Paginação aplicada.  

4. **📊 Progresso do Curso**  
   - ✅ Atualização e leitura.  
   - 🔍 Filtragem aplicada.  

5. **🛒 Pedidos**  
   - ✅ Criação, leitura, atualização e exclusão.  
   - 📑 Paginação e 🔍 filtragem aplicadas.  

6. **🏷️ Categorias**  
   - ✅ Criação, leitura, atualização e exclusão.  

---

## 📂 **Estrutura do Projeto**

```plaintext
LearnExpressSolution/
├── 📂 LearnExpress.Application/   # Camada de aplicação (DTOs, validações, etc.).
├── 📂 LearnExpress.Domain/        # Entidades e regras de negócio.
├── 📂 LearnExpress.Infrastructure/
│   ├── 📂 Data/                   # Configuração do banco de dados e Repository.
│   └── 📂 Ioc/                    # Configuração de injeção de dependência.
├── 📂 LearnExpress.WebAPI/        # Endpoints da API e Swagger.
└── 📄 LearnExpress.sln            # Arquivo de solução do projeto.
```
## 🚀 **Como Rodar o Projeto Localmente**

1. Clone o repositório:

```bash
git clone https://github.com/Wexxxley/2.LearnExpress-API.git
```
2. Navegue até a pasta do projeto:
```bash
cd LearnExpressSolution
```
3. Configure a string de conexão do PostgreSQL no arquivo appsettings.json.

4. Restaure os pacotes NuGet:
```bash
dotnet restore
```

5. Execute o projeto:

```bash
dotnet run --project LearnExpress.WebAPI
```
