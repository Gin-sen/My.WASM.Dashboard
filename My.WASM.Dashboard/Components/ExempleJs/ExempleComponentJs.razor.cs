using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;
using System.Text.Json.Serialization.Metadata;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace My.WASM.Dashboard.Components.ExempleJs
{
  public partial class ExempleComponentJs
  {
    protected override async Task OnInitializedAsync()
    {
      if (OperatingSystem.IsBrowser())
      {
        await JSHost.ImportAsync("My.WASM.Dashboard.Components.ExempleJs/ExempleComponentJs",
          "../Components/ExempleJs/ExempleComponentJs.razor.js");
        message = await Interop.GetMessage(this);
      }
    }

    [SupportedOSPlatform("browser")]
    public partial class Interop
    {
      [DynamicDependency(DynamicallyAccessedMemberTypes.PublicMethods, typeof(JsonTypeInfo))]
      [DynamicDependency(DynamicallyAccessedMemberTypes.PublicMethods, typeof(JsonSerializerContext))]
      static Interop()
      {
      }

      [JSImport("getMessage", "My.WASM.Dashboard.Components.ExempleJs/ExempleComponentJs")]
      internal static partial Task<string> GetMessage([JSMarshalAs<JSType.Any>] object component);
    }
  }
}
