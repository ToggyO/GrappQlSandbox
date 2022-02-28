using System.Net;
using System.Net.Mime;
using System.Security.Claims;
using System.Text.Json;

using Business.Contracts;
using Business.Enums;

using Common.Constants.Errors;
using Common.Models.Response;

using GraphQL;

using Microsoft.AspNetCore.Mvc;

namespace Api.Middleware;

public class GraphQLAuthenticationMiddleware
{
	/// <summary>
	/// Bearer authentication scheme identifier.
	/// </summary>
	private const string Bearer = "Bearer ";


	private readonly RequestDelegate _next;

	public GraphQLAuthenticationMiddleware(RequestDelegate next)
	{
		_next = next;
	}

	public async Task InvokeAsync(HttpContext context, ITokensFactory tokensFactory)
	{
		Console.WriteLine("GraphQLAuthenticationMiddleware");

		var tokenStatus = TokenStatus.Invalid;
		string authHeader = context.Request.Headers["Authorization"];

		if (!string.IsNullOrEmpty(authHeader))
		{
			var token = GetCleanToken(authHeader);
			tokenStatus = tokensFactory.ValidateToken(token, out ClaimsPrincipal principal);

			if (tokenStatus == TokenStatus.Valid)
			{
				context.User = principal;
				await _next.Invoke(context);
				return;
			}
		}



		// TODO: check error response
		//var error = GetErrorByTokenStatus(tokenStatus);
		//var response = JsonSerializer.Serialize(error, new JsonSerializerOptions
		//{
		//	PropertyNamingPolicy = JsonNamingPolicy.CamelCase
		//});

		var result = new ExecutionResult
		{
			Errors = new ExecutionErrors
			{
				new ExecutionError("OOOps!")
			}
		};
		var response = JsonSerializer.Serialize(result, new JsonSerializerOptions
		{
			PropertyNamingPolicy = JsonNamingPolicy.CamelCase
		});

		context.Response.ContentType = MediaTypeNames.Application.Json;
		//context.Response.StatusCode = (int) error.HttpStatusCode;
		context.Response.StatusCode = (int) HttpStatusCode.Unauthorized;

		await context.Response.WriteAsync(response);
	}

	/// <summary>
	/// Creates error response from token validation status.
	/// </summary>
	/// <param name="tokenStatus">Token validation status.</param>
	/// <returns></returns>
	private ErrorResponse GetErrorByTokenStatus(TokenStatus tokenStatus)
		=> tokenStatus switch
		{
			TokenStatus.Expired => new ErrorResponse
			{
				HttpStatusCode = HttpStatusCode.Unauthorized,
				Message = ErrorMessages.Security.AccessTokenExpired,
				Code = ErrorCodes.Security.AccessTokenExpired
			},
			TokenStatus.Invalid => new ErrorResponse
			{
				HttpStatusCode = HttpStatusCode.Unauthorized,
				Message = ErrorMessages.Security.AccessTokenInvalid,
				Code = ErrorCodes.Security.AccessTokenInvalid
			},
			_ => new SecurityErrorResponse(),
		};

	/// <summary>
	/// Retrieves token from auth header.
	/// </summary>
	/// <param name="authHeader">Auth header value.</param>
	/// <returns></returns>
	private string GetCleanToken(string authHeader)
	{
		var index = authHeader.IndexOf(Bearer, StringComparison.CurrentCultureIgnoreCase);
		return index < 0 ? authHeader : authHeader.Remove(index, Bearer.Length);
	}
}
