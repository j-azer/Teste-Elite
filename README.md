# Teste Elite - RN
<h3>Descrição Geral</h3>
Desenvolver uma aplicação web que autentique usuários (professores), permita o upload de arquivos Excel contendo notas de alunos, salve os dados no MSSQL Server e gerencie esses arquivos. A aplicação deve fornecer funcionalidades de visualização, incluindo cálculos de médias e estatísticas, além de funcionalidades adicionais para avaliação.

<h3>Requisitos da Aplicação</h3>
  
<h5>1. Autenticação de Usuários</h5>
Descrição: Implementar um sistema de autenticação onde os usuários podem se registrar e fazer login.
Tecnologias: ASP.NET Core Identity
  
<h5>2. Upload de Arquivos Excel</h5>
Descrição: Permitir que usuários façam upload de arquivos Excel. Os dados devem ser armazenados no MSSQL Server.
Tecnologias: ASP.NET Core MVC, Entity Framework Core, ClosedXML ou similar (para leitura de arquivos Excel)

<h5>3. Gerenciamento de Arquivos</h5>
Descrição: Implementar funcionalidades para gerenciar arquivos carregados, incluindo adicionar thumbnails e descrições.
Tecnologias: ASP.NET Core MVC, Entity Framework Core

<h5>4. Rastreio de Uploads e Downloads</h5>
Descrição: O sistema deve rastrear quando um arquivo foi carregado e quantas vezes foi baixado.
Tecnologias: Entity Framework Core

<h5>5. Visualização de Dados</h5>
Descrição: Ao clicar para visualizar o conteúdo do arquivo, o sistema deve ler os dados do arquivo Excel, calcular a média das notas dos alunos e demonstrar a média geral da sala.
Tecnologias: ASP.NET Core MVC, ClosedXML ou similar

<h5>6. Design e Documentação</h5>
Descrição: Apresentar o diagrama do banco de dados, diagrama de fluxo de dados e documentação detalhada.
Tecnologias: Ferramentas de modelagem de dados (e.g., ERD tools), Microsoft Word/Markdown

<h3>Como Executar</h3>
1. Clone o repositório.
2. Abra o projeto no Visual Studio.
3. Configure a string de conexão no arquivo `appsettings.json`.
4. Execute o comando `dotnet run`.

<h3>Estrutura do Projeto</h3>
- **Controllers**: Contém os controladores da aplicação.
- **Models**: Contém as classes de modelo.
- **Views**: Contém as views da aplicação.

<h3>Tecnologias Utilizadas,/h3>
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server

<h3>Estrutura de Dados</h3>

![Diagrama_Elite](https://github.com/user-attachments/assets/31fa6f8b-d091-40c1-b4f6-3c7d9440cb2e)


