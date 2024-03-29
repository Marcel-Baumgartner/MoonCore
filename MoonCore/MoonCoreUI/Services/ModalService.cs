﻿using Microsoft.JSInterop;

namespace MoonCoreUI.Services;

public class ModalService
{
    public static string Prefix { get; set; } = "mooncore";
    
    private readonly IJSRuntime JsRuntime;

    public ModalService(IJSRuntime jsRuntime)
    {
        JsRuntime = jsRuntime;
    }

    public async Task Show(string id, bool focus = true) // Focus can be specified to fix issues with other components
    {
        try
        {
            await JsRuntime.InvokeVoidAsync($"{Prefix}.show", id, focus);
        }
        catch (Exception)
        {
            // ignored
        }
    }
    
    public async Task Hide(string id)
    {
        try
        {
            await JsRuntime.InvokeVoidAsync($"{Prefix}.hide", id);
        }
        catch (Exception)
        {
            // Ignored
        }
    }
}