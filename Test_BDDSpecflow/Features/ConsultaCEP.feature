#language: pt-BR

Funcionalidade: ConsultaCEP
	Consultar CEP

@UrlCEP
Cenario: Consultar por CEP 
	Dado que estou na pagina para consultar CEP
	Quando insiro um CEP válido
	Então valido os dados do CEP

Cenario: Consultar por CEP inválido
	Dado que estou na pagina para consultar CEP
	Quando insiro um CEP inválido
	Então valido a mensagem de retorno