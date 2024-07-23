![logoElite](https://github.com/user-attachments/assets/e7df54dc-4ced-4486-a615-f9c84293e552)
# Teste
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
<p>1. Para clonar o repositório acesse https://github.com/j-azer/Teste-Elite.git</p>
<p>2. Para abrir o projeto no Visual Studio, após acessar, click em <b>Code</b> e escolha a opção de abrir com Visual Studio, conforme imagem ilustrativa abaixo.</p>

![abrirProjeto](https://github.com/user-attachments/assets/93c5f7be-15c1-4e60-8088-4157f74ea87b)

<p>3. Configure a string de conexão no arquivo <b>appsettings.json</b> para conectar com seu banco de dados.</p>

![appsettings](https://github.com/user-attachments/assets/99cecd8b-c301-4ec8-a372-71b36bfed77c)

<p>4. No <b>wwwroot</b>, crie a pasta <b>Thumbnails</b> e a pasta <b>Uploads</b>.</p>

![wwwroot](https://github.com/user-attachments/assets/45535a36-353c-4f65-bdfb-4baa28652fe4)

<p>5. Execute o comando <b>Update-Database</b>.</p>

![update_database](https://github.com/user-attachments/assets/2973cc67-2366-40ab-a14c-93ebe44c4971)

<p>6. Execute o comando <b>dotnet run</b> ou <b>Crtl+F5</b> ou click no play do seu projeto. Abaixo imagem ilustrativa.</p>

![Start_projeto](https://github.com/user-attachments/assets/f2845bc3-1149-4566-95ac-cd3ca8bacac6)



<h3>Estrutura do Projeto</h3>
<p><b>Controllers:</b> Contém os controladores da aplicação.</p>
<p><b>Models:</b> Contém as classes de modelo.</p>
<p><b>Views:</b> Contém as views da aplicação.</p>

<h3>Tecnologias Utilizadas</h3>
<p>- ASP.NET Core MVC</p>
<p>- Entity Framework Core</p>
<p>- SQL Server</p>

<h3>Estrutura de Dados</h3>

![Diagrama_Elite](https://github.com/user-attachments/assets/31fa6f8b-d091-40c1-b4f6-3c7d9440cb2e)


