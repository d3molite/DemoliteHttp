﻿using Demolite.Http.Interfaces;

namespace Demolite.Http.Builder;

/// <summary>
///     Abstract version of the UrlBuilder
/// </summary>
/// <typeparam name="TB">Builder Type.</typeparam>
/// <typeparam name="TPb">Parameter Builder Type.</typeparam>
public abstract class AbstractUrlBuilder<TB, TPb> : IUrlBuilder<TPb>
	where TB : IUrlBuilder<TPb>, new()
	where TPb : class, IParameterBuilder<TPb>
{
	public static TB Endpoints => new();

	public TPb Parameters { get; init; } = null!;

	public IList<string> PathSegments { get; set; } = [];

	public abstract string BaseUrl { get; }

	public virtual string LastPathSegment => "/";

	protected IUrlBuilder<TPb> AddSegment(string segment)
	{
		PathSegments.Add(segment);
		return this;
	}
}