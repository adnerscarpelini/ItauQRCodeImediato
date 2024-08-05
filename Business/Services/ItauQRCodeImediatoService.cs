﻿using Business.Interfaces;
using Model.Entities;
using RestSharp;
using System.Text.Json;

namespace Business.Services
{
    public class ItauQRCodeImediatoService : IItauQRCodeImediato
    {

        public async Task<OAuth2> Authenticate(string ambiente, string clientId, string clientSecret)
        {
            try
            {
                string url = string.Empty;

                if (ambiente.Equals("sandbox"))
                    url = "https://sandbox.devportal.itau.com.br/api/oauth/jwt";
                else
                    throw new Exception("O Tipo de Ambiente informado não está disponível para utilização");


                var client = new RestClient();
                var request = new RestRequest(url, Method.Post);

                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                request.AddParameter("client_id", clientId);
                request.AddParameter("client_secret", clientSecret);
                request.AddParameter("grant_type", "client_credentials");
                RestResponse response = await client.ExecuteAsync(request);

                OAuth2? oAuth2 = null;
                if (response.IsSuccessStatusCode)
                {
                    if (!string.IsNullOrEmpty(response?.Content))
                        oAuth2 = JsonSerializer.Deserialize<OAuth2>(response.Content.ToString());
                }
                else
                {
                    string? errorMessage = MapErrorMessage(response.Content?.ToString());
                    if (!string.IsNullOrEmpty(errorMessage))
                        throw new Exception(errorMessage);
                    else
                        throw new Exception("Código do Erro: " + response.StatusCode.ToString() + " - " + response.StatusDescription);
                }

                if (oAuth2 == null)
                    throw new Exception("Não foi possível mapear o retorno da API. Verifique se houve modificação no layout do Banco.");

                return oAuth2;

            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao Autenticar. " + ex.Message);
            }

        }

        public async Task<QRCodeImediato> PostQRCodeImediato(string ambiente, string clientId, OAuth2 oAuth2, string chave, string valor)
        {
            try
            {
                string url = string.Empty;

                if (ambiente.Equals("sandbox"))
                    url = "https://sandbox.devportal.itau.com.br/itau-ep9-gtw-pix-recebimentos-ext-v2/v2/cob";
                else
                    throw new Exception("O Tipo de Ambiente informado não está disponível para utilização");


                var client = new RestClient();
                var request = new RestRequest(url, Method.Post);

                request.AddHeader("x-itau-apikey", clientId);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Authorization", oAuth2.token_type + " " + oAuth2.access_token);

                // Criar o Json da Request com interpolação dos parametros recebidos pela tela
                string jsonBody = $@"
                {{
                    ""valor"": {{
                        ""original"": ""{valor}""
                    }},
                    ""chave"": ""{chave}""
                }}";

                request.AddBody(jsonBody);
                RestResponse response = await client.ExecuteAsync(request);


                QRCodeImediato? qrCodeImediatoResponse = null;
                if (response.IsSuccessStatusCode)
                {
                    if (!string.IsNullOrEmpty(response?.Content))
                        qrCodeImediatoResponse = JsonSerializer.Deserialize<QRCodeImediato>(response.Content.ToString());
                }
                else
                {
                    string? errorMessage = MapErrorMessage(response.Content?.ToString());
                    if (!string.IsNullOrEmpty(errorMessage))
                        throw new Exception(errorMessage);
                    else
                        throw new Exception("Código do Erro: " + response.StatusCode.ToString() + " - " + response.StatusDescription);
                }

                if (qrCodeImediatoResponse == null)
                    throw new Exception("Não foi possível mapear o retorno da API. Verifique se houve modificação no layout do Banco.");

                return qrCodeImediatoResponse;

            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao Criar a Cobrança Imediata com Pix. " + ex.Message);
            }
        }

        private string? MapErrorMessage(string? errorMessage)
        {
            if (!string.IsNullOrEmpty(errorMessage))
            {
                ErroApi? erroApi = JsonSerializer.Deserialize<ErroApi>(errorMessage);

                if (erroApi != null)
                {
                    if (erroApi.error != null)
                        return "Código do Erro: " + erroApi.error.status + " - Mensagem: " + erroApi.error.message;
                    else
                        return erroApi.message;
                }
                else
                    return null;
            }
            else
                return null;
        }
    }
}
