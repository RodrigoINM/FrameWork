#language:pt
#Author: Rodrigo Magno

Funcionalidade: Consulta Google

@chrome
Cenário: Pesquisar por SpecFlow no Google
	Dado que estou na pagina do Google
	Quando realizo uma pesquisa por SpecFlow
	Então visualizo o site do SpecFlow no resultado da busca

@chrome
Esquema do Cenário: Varias pesquisar no Google
	Dado que estou na pagina do Google
	Quando realizo uma pesquisa por SpecFlow <Busca>
	Então visualizo o site do SpecFlow no resultado da busca <TextoDoLinkDoResultado>
	  
  Exemplos: 
      | Busca      | TextoDoLinkDoResultado                                  |
      | "SpecFlow" | "SpecFlow - Binding Business Requirements to .NET Code" |
      | "Github"   | "GitHub"                                                |
  