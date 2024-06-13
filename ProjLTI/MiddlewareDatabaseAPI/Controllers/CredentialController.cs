﻿using System;
using System.Data.SqlClient;
using System.Security.AccessControl;
using MiddlewareDatabaseAPI.Models;
using System.Data;
using System.Web.Http;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace MiddlewareDatabaseAPI.Controllers
{
    [RoutePrefix("api/credentials")]
    public class CredentialController : ApiController
    {
        private string connStr = Properties.Settings.Default.ConnStr;
        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAllCredentials ()
        {
            List<Credential> credentials = new List<Credential>();
            string queryString = "SELECT TOP 10 * FROM Credentials ORDER BY Id DESC";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    SqlCommand command = new SqlCommand(queryString, conn);
                    command.Connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Credential c = new Credential
                            {
                                Id = (int)reader["Id"],
                                Ip = (string)reader["Ip"],
                                Porto_ssh = (string)reader["Porto_ssh"],
                                Porto_api = (string)reader["Porto_api"],
                                Username = (string)reader["Username"],
                                Password = reader["Password"] == DBNull.Value ? "" : (string)reader["Password"],
                            };
                            credentials.Add(c);
                        }
                    }
                }
                return Ok(credentials);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult StoreCredentials ([FromBody] Credential value)
        {

            Credential credential = new Credential
            {
                Ip = value.Ip,
                Porto_ssh = value.Porto_ssh,
                Porto_api = value.Porto_api,
                Username = value.Username,
                Password = value.Password,
            };

            List<Credential> credentials = getAllCredentials(); ;

            if (credentials.Contains(credential))
            {
                return Ok("Credenciais já guardadas. Login automático.");
            }

            string queryString = credential.Password != null ?
                "INSERT INTO Credentials (ip, username, porto_ssh, porto_api, password) VALUES (@ip, @username, @porto_ssh, @porto_api, @password)" :
                "INSERT INTO Credentials (ip, username, porto_ssh, porto_api) VALUES (@ip, @username, @porto_ssh, @porto_api)";

            try
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@ip", value.Ip);
                    command.Parameters.AddWithValue("@username", value.Username);
                    command.Parameters.AddWithValue("@porto_ssh", value.Porto_ssh);
                    command.Parameters.AddWithValue("@porto_api", value.Porto_api);
                    if (credential.Password != null)
                    {
                        command.Parameters.AddWithValue("@password", value.Password);
                    }
                    

                    try
                    {
                        command.Connection.Open();
                        if (command.ExecuteNonQuery() == 0)
                        {
                            return NotFound();
                        }
                        else
                        {
                            return Ok();
                        }
                    }
                    catch (Exception ex)
                    {
                        return InternalServerError(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        private List<Credential> getAllCredentials ()
        {
            var credentials = new List<Credential> ();

            string queryString = "SELECT * FROM Credentials";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    SqlCommand command = new SqlCommand(queryString, conn);
                    command.Connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Credential c = new Credential
                            {
                                Ip = (string)reader["Ip"],
                                Porto_ssh = (string)reader["Porto_ssh"],
                                Porto_api = (string)reader["Porto_api"],
                                Username = (string)reader["Username"],
                                Password = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String((string)reader["Password"])),
                            };
                            credentials.Add(c);
                        }
                    }
                }
                return credentials;
            }
            catch (Exception)
            {
                return credentials;
            }
        }
    }
}