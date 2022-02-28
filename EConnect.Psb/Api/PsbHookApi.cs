﻿using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using EConnect.Psb.Client;
using EConnect.Psb.Models;

namespace EConnect.Psb.Api;

public class PsbHookApi : IPsbHookApi
{
    private readonly PsbClient _psbClient;

    public PsbHookApi(PsbClient psbClient)
    {
        _psbClient = psbClient;
    }

    public async Task<Hook[]> GetEnviromentHooks(CancellationToken cancellation)
    {
        var targetUrl = $"/api/v1/hook";

        var hooks = await _psbClient.Get<Hook[]>(targetUrl, cancellation);
        return hooks;
    }

    public async Task<Hook> SetEnviromentHook(
        Hook hook,
        CancellationToken cancellation)
    {
        var targetUrl = $"/api/v1/hook";
        
        var createdHook = await _psbClient.Put<Hook>(
            requestUri: targetUrl,
            body: hook,
            cancellation: cancellation
        );

        return createdHook;
    }

    public async Task DeleteDefaultHook(
        string hookId,
        CancellationToken cancellation)
    {
        var encodedHookid = HttpUtility.UrlEncode(hookId);
        var targetUrl = $"/api/v1/hook/{encodedHookid}";

        await _psbClient.Delete<HttpResponseMessage>(
            requestUri: targetUrl,
            cancellation: cancellation
        );
    }


    #region partyHooks

    public async Task<Hook[]> GetPartyHooks(
        string partyId,
        CancellationToken cancellation = default)
    {
        var encodedPartyid = HttpUtility.UrlEncode(partyId);
        var targetUrl = $"/api/v1/{encodedPartyid}/hook";

        var hooks = await _psbClient.Get<Hook[]>(
            requestUri: targetUrl,
            cancellation: cancellation
        );

        return hooks;
    }

    public async Task<Hook> SetPartyHooks(
        string partyId,
        Hook hook,
        CancellationToken cancellation)
    {
        var encodedPartyid = HttpUtility.UrlEncode(partyId);
        var targetUrl = $"/api/v1/{encodedPartyid}/hook";

        var createdHook = await _psbClient.Put<Hook>(
            requestUri: targetUrl,
            body: hook,
            cancellation: cancellation
        );

        return createdHook;
    }

    public async Task<string> PingPartyHooks(
        string partyId,
        CancellationToken cancellation)
    {
        var encodedPartyid = HttpUtility.UrlEncode(partyId);
        var targetUrl = $"/api/v1/{encodedPartyid}/hook/ping";

        var party = await _psbClient.Get<Party>(
            requestUri: targetUrl,
            cancellation: cancellation
        );

        return party.Id;
    }

    public async Task DeletePartyHook(
        string hookId,
        string partyId,
        CancellationToken cancellation)
    {
        var encodedHookid = HttpUtility.UrlEncode(hookId);
        var encodedPartyid = HttpUtility.UrlEncode(partyId);
        var targetUrl = $"/api/v1/{encodedPartyid}/hook/{encodedHookid}";

        await _psbClient.Delete<HttpResponseMessage>(
            requestUri: targetUrl,
            cancellation: cancellation
        );
    }

    #endregion

}