# Teste-Elite

<h2>Descrição Geral</h2>

Desenvolver uma aplicação web que autentique usuários (professores), permita o upload de arquivos Excel contendo notas de alunos, salve os dados no MSSQL Server e gerencie esses arquivos. A aplicação deve fornecer funcionalidades de visualização, incluindo cálculos de médias e estatísticas, além de funcionalidades adicionais para avaliação.

<h2>Requisitos da Aplicação</h2>
  
<h3>1. Autenticação de Usuários</h3>

Descrição: Implementar um sistema de autenticação onde os usuários podem se registrar e fazer login.
Tecnologias: ASP.NET Core Identity
Pontuação: 15 pontos
O que estamos testando: Capacidade de implementar e configurar um sistema de autenticação, incluindo registro e login, que é uma funcionalidade essencial em quase todas as aplicações web.
  
<h3>2. Upload de Arquivos Excel</h3>

Descrição: Permitir que usuários façam upload de arquivos Excel. Os dados devem ser armazenados no MSSQL Server.
Tecnologias: ASP.NET Core MVC, Entity Framework Core, ClosedXML ou similar (para leitura de arquivos Excel)
Pontuação: 20 pontos
O que estamos testando: Habilidade em lidar com uploads de arquivos, processamento de dados de Excel e integração com banco de dados.

<h3>3. Gerenciamento de Arquivos</h3>
Descrição: Implementar funcionalidades para gerenciar arquivos carregados, incluindo adicionar thumbnails e descrições.
Tecnologias: ASP.NET Core MVC, Entity Framework Core
Pontuação: 15 pontos
O que estamos testando: Competência em criar funcionalidades CRUD (Create, Read, Update, Delete) e manipulação de dados no banco.

<h3>4. Rastreio de Uploads e Downloads</h3>
Descrição: O sistema deve rastrear quando um arquivo foi carregado e quantas vezes foi baixado.
Tecnologias: Entity Framework Core
Pontuação: 10 pontos
O que estamos testando: Capacidade de implementar funcionalidades de auditoria e rastreamento, importante para monitoramento e análise de uso.

<h3>5. Visualização de Dados</h3>
Descrição: Ao clicar para visualizar o conteúdo do arquivo, o sistema deve ler os dados do arquivo Excel, calcular a média das notas dos alunos e demonstrar a média geral da sala.
Tecnologias: ASP.NET Core MVC, ClosedXML ou similar
Pontuação: 20 pontos
O que estamos testando: Habilidade em processamento de dados e apresentação de resultados de maneira compreensível e útil.

<h3>6. Design e Documentação</h3>
Descrição: Apresentar o diagrama do banco de dados, diagrama de fluxo de dados e documentação detalhada.
Tecnologias: Ferramentas de modelagem de dados (e.g., ERD tools), Microsoft Word/Markdown
Pontuação: 20 pontos
O que estamos testando: Competência em planejar, documentar e comunicar o design do sistema, essencial para a manutenção e escalabilidade.

<h2>Pontos de Bônus</h2>

1. Impressão para PDF
Descrição: Implementar a funcionalidade para imprimir a lista de arquivos com thumbnails e descrições em PDF.
Tecnologias: PDF Printing
Pontuação: 10 pontos
O que estamos testando: Capacidade de gerar documentos PDF a partir de dados da aplicação, útil para relatórios e compartilhamento de informações.

2. Paginação da Lista de Arquivos
Descrição: Implementar paginação da lista de arquivos carregados (5, 10, 25, 50 arquivos por página).
Tecnologias: ASP.NET Core MVC
Pontuação: 5 pontos
O que estamos testando: Habilidade em melhorar a usabilidade da interface com paginação de dados.

3. Destaque do Aluno com Maior Nota
Descrição: Implementar um destaque em cor diferente para o aluno com a maior nota ao visualizar o conteúdo do arquivo.
Tecnologias: ASP.NET Core MVC, CSS
Pontuação: 5 pontos
O que estamos testando: Capacidade de melhorar a visualização de dados com destaques visuais.

4. Uso de Design Patterns
Descrição: Demonstrar o uso de design patterns (e.g., Repository Pattern, Unit of Work, etc.) na aplicação.
Tecnologias: ASP.NET Core, C#
Pontuação: 10 pontos
O que estamos testando: Conhecimento e aplicação de padrões de design para melhorar a estrutura e manutenibilidade do código.

5. Microserviços
Descrição: Separar a funcionalidade de upload e processamento de arquivos em um microserviços.
Tecnologias: ASP.NET Core, Docker
Pontuação: 15 pontos
O que estamos testando: Capacidade de dividir uma aplicação em microserviços, melhorando a escalabilidade e manutenção.

6. Testes Unitários
Descrição: Criar testes unitários para as principais funcionalidades da aplicação.
Tecnologias: xUnit, Moq
Pontuação: 15 pontos
O que estamos testando: Habilidade em escrever testes unitários para garantir a qualidade e funcionalidade do código.

Estrutura do Banco de Dados (Exemplo)
Tabelas:
- Users: Id, Username, PasswordHash, Email, etc.
- Files: Id, UserId, FileName, Thumbnail, Description, UploadDate, DownloadCount
- Students: Id, FileId, StudentName, Grade1, Grade2, Grade3, Grade4

Pontuação Total
Funcionalidades Requeridas: 100 pontos
Pontos de Bônus: 50 pontos adicionais

Critérios de Avaliação
Funcionalidade: A aplicação atende aos requisitos funcionais descritos.
Qualidade do Código: Organização, clareza e boas práticas de codificação.
Documentação: Completude e clareza da documentação fornecida.
Design: Uso apropriado de design patterns e arquitetura sempre que possível.
Extra: Implementação de funcionalidades bônus.

Entregáveis
Código-fonte completo da aplicação.
Scripts para criar e popular o banco de dados.
Documentação (diagramas de banco de dados, diagrama de fluxo de dados, instruções de configuração e uso).

Observações Finais
O candidato deverá preparar um relatório detalhado, explicando as escolhas técnicas feitas, desafios enfrentados e como eles foram superados. Este relatório será parte essencial da avaliação.
