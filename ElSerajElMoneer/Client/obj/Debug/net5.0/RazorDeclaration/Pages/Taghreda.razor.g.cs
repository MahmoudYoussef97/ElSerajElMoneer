// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace ElSerajElMoneer.Client.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "/Users/mahyoussef/projects/ElSerajElMoneer/ElSerajElMoneer/Client/_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/mahyoussef/projects/ElSerajElMoneer/ElSerajElMoneer/Client/_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/mahyoussef/projects/ElSerajElMoneer/ElSerajElMoneer/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/mahyoussef/projects/ElSerajElMoneer/ElSerajElMoneer/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/mahyoussef/projects/ElSerajElMoneer/ElSerajElMoneer/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/Users/mahyoussef/projects/ElSerajElMoneer/ElSerajElMoneer/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/Users/mahyoussef/projects/ElSerajElMoneer/ElSerajElMoneer/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/Users/mahyoussef/projects/ElSerajElMoneer/ElSerajElMoneer/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "/Users/mahyoussef/projects/ElSerajElMoneer/ElSerajElMoneer/Client/_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "/Users/mahyoussef/projects/ElSerajElMoneer/ElSerajElMoneer/Client/_Imports.razor"
using ElSerajElMoneer.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "/Users/mahyoussef/projects/ElSerajElMoneer/ElSerajElMoneer/Client/_Imports.razor"
using ElSerajElMoneer.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/mahyoussef/projects/ElSerajElMoneer/ElSerajElMoneer/Client/Pages/Taghreda.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/mahyoussef/projects/ElSerajElMoneer/ElSerajElMoneer/Client/Pages/Taghreda.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/mahyoussef/projects/ElSerajElMoneer/ElSerajElMoneer/Client/Pages/Taghreda.razor"
using ElSerajElMoneer.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/mahyoussef/projects/ElSerajElMoneer/ElSerajElMoneer/Client/Pages/Taghreda.razor"
           [Authorize]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/taghredat/{id}")]
    public partial class Taghreda : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 471 "/Users/mahyoussef/projects/ElSerajElMoneer/ElSerajElMoneer/Client/Pages/Taghreda.razor"
       
    [Parameter]
    public string Id { get; set; }
    private TaghredatElSera taghreda = new TaghredatElSera();
    private string watchUrl;
    protected override async Task OnInitializedAsync()
    {
        try
        {
            taghreda = await Http.GetFromJsonAsync<TaghredatElSera>($"TaghredatElSera/{Id}");
        }
        catch(AccessTokenNotAvailableException exception)
        {
            exception.Redirect();
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
    }
}
#pragma warning restore 1591
