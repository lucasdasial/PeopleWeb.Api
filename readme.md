### PeopleWeb.Api

- Projeto backend .NET Csharp (C#) e Sqlite para alimentar [dashboard](https://github.com/lucasdasial/PeopleWeb.App) de cadastro de pessoas.

**WIP - (Working in progress)**

- [x] cadastro de uma pessoa
- [x] atualização
- [x] deleção
- [x] listagem de todos as pessoas
- [x] busca por id da pessoa
- [x] implementação da V2 com dados de endereço adicionais
- [x] documentação dos endpoints com swagger
- [ ] configurar versionamento no swagger
- [ ] implementar testes unitarios e integração
- [ ] implementar sistema de autorização e autenicação

### Setup - Instruções para rodar localmente

0. Projeto foi escrito em [.NET 8](https://dotnet.microsoft.com/pt-br/download/dotnet/8.0), é nescessário ter instalado.
1. Clone repositorio com `git`
2. Instale as dependencias do projeto com `dotnet restore`
3. Rode a aplicação atraveis de uma IDE ou CLI com `dotnet run`
4. Após a inicialização bem sucessdida será gerado um arquivo `sqlite` na raiz do projeto.
5. Consuma os enpoints atraveis de um cliente Http, Swagger, ou se preferir utilize a interface dashboard disponível nesse [repositório](https://github.com/lucasdasial/PeopleWeb.App).
6. Caso esteja rodando a interface dashboard em conjuto, certifique-se que a porta seja a mesma configurada no CORS no arquivo `Program.cs`.


### Preview
<img width="1422" height="725" alt="image" src="https://github.com/user-attachments/assets/f5284035-ae54-440f-9216-c47e0e746a82" />
