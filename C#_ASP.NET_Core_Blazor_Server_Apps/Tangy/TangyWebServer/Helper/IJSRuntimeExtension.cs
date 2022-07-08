/*
 * This app is built based on Udemy's Blazor Learning course, part of the self-study.
 *      It allows a full range of CRUD operations with a SQL Server DB and demonstrates Javascript integrations
 *      into the Blazor Server projects.
 * Author: Marat Nikitin.
 * When: July 2022.
 * This file contains two methods helping with displaying and hiding JS toastrs.
 */

using Microsoft.JSInterop;

namespace TangyWebServer.Helper
{
    public static class IJSRuntimeExtension
    {
        public static async ValueTask ToastrSuccess(this IJSRuntime jsRuntime, string message)
        {
            await jsRuntime.InvokeVoidAsync("ShowToastr", "success", message);
        }

        public static async ValueTask ToastrError(this IJSRuntime jsRuntime, string message)
        {
            await jsRuntime.InvokeVoidAsync("ShowToastr", "error", message);
        }
    }
}
