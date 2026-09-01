# Copilot Instructions

## Diretrizes de projeto
- Para entendimento rapido da arquitetura, dos fluxos e das rotas de busca, consultar primeiro `README.md`, na secao `Navegacao rapida do repositorio`, antes de espalhar leituras pelo repo.
- O usuário prefere estrutura de código menos dispersa: interfaces agrupadas, classes maiores em arquivos separados, com foco em consistência de nomenclatura e redução de condicionais soltas (clean code).
- O usuário prefere fortemente código com baixa carga cognitiva: menos condicionais soltas, padrão Command com dicionários de ações, métodos pequenos/autodescritivos e legibilidade máxima em C# por não dominar a linguagem (familiariadade python/typescipt).
- Quando pedir refatoração, priorizar padrão Command (dicionários de ações) para remover if/else/switch longos e decompor em métodos pequenos/autodescritivos em todos os arquivos (C#), mantendo alta legibilidade.
- Ampliar a instrumentação de falhas com `AdaptadorExcecoesArquivo` em mais etapas do fluxo narrativo para diagnóstico robusto no TS3.
- O usuário prefere que o servidor narrativo rode fora do projeto TS3, usando arquivo de pedidos dedicado (não estados), com purga de pedidos no servidor, modelo Ollama DeepSeek e script/bat para execução automatizada sem configuração manual recorrente.
- O usuário prefere que funções de sanitização, tratamento e IO de texto fiquem em arquivos próprios para reduzir poluição nos arquivos principais e manter código limpo.
- O usuário prefere evitar hardcoded e deseja documentação em estilo macro (XML doc) nas classes/métodos importantes, sem comentários inline, semelhante à experiência de JSDoc/TypeScript.
- **Não substituir o adaptador S3SE por System.IO; o projeto deve continuar usando S3SE/BatteryUtils para IO de arquivos no mod TS3, mantendo compatibilidade com .NET Framework 2.0.**
- **Snapshots periódicos devem atualizar apenas cabeçalhos/estado para contexto de LLM e não gerar eventos 'snapshot_periodico' no histórico, para evitar poluição dos estados.**
- O usuário deseja limites explícitos no contexto para múltiplos domínios (idade, necessidades, humor, carreira, habilidades, classe econômica). Para dar ao LLM contexto das opções disponíveis.
- Para consultas críticas do contexto no TS3 (necessidades/carreira), o usuário prefere acesso direto à API pública do jogo quando disponível e minimizar o uso de reflexão quando os dados já têm acesso direto conhecido.
- O usuário não quer manter suporte legado; quando possível, remover fallback legado em vez de preservá-lo (ex.: 'cabecalho' legado no servidor).
- **Evitar duplicações de regra e manter fonte única de verdade nos repositórios de consulta (ex.: situação financeira/carreira), para não existir duas fontes para o mesmo dado.**
- Quando a lógica for específica de um único repositório/consulta, o usuário prefere manter as tratativas no próprio arquivo em vez de criar um adaptador dedicado; usar adaptadores apenas para tratamento utilitário transversal (ex.: texto, caminhos).
- Quando o usuário pede renomeação de arquivo, ele espera que o nome físico do arquivo seja alterado e todos os usos/importações/referências no projeto sejam atualizados no mesmo ajuste.

- O usuário prefere configurações compartilhadas entre mod principal e servidor, evitando valores hard-coded e mantendo personalização de teor narrativo via arquivo de configuração.
- O usuário quer respostas conclusivas e execução completa no pedido atual, sem adiar com frases como 'se quiser na próxima'.

## Registro de Eventos
- No `RepositorioEventosTheSims3`, o usuário quer registro de eventos baseado apenas em tipos concretos que herdam de `EventoTheSims3`, sem inferências por `EventId`.

## Estrutura de Diretórios
- No diretório `RepositorioConsulta`, devem permanecer apenas arquivos `RepoConsulta.cs` e `Consulta*.cs`; serviços de sistema devem ser movidos para outra pasta.
- Preferir nomenclatura de consultas como `ConsultaClasseEconomica` para consistência.

## Servidor Narrativo
- Pedidos e respostas devem ser gravados no diretório Mods (não em Mods/Packages), e o contexto enviado ao LLM deve evitar logs de exceção/ruído para manter consistência com o estado do jogo.